using Microsoft.Extensions.Hosting;
using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Scheduler.ServiceJobs
{
    internal class ScanLateIncome : IHostedService
    {
        private AppDatabase MDatabases { get; set; }
        public ScanLateIncome(AppDatabase MDatabases)
        {
            this.MDatabases = MDatabases;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var timeRepeat = 10;
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(timeRepeat));
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                var timenow = DateTime.Now;
                var top = timenow.Subtract(TimeSpan.FromMinutes(timeRepeat * 1.5));
                var floor = timenow.Subtract(TimeSpan.FromMinutes(timeRepeat * 3));

                var lateItems = await MDatabases.Status.FindAll(
                    record => !record.Completed && !record.Canceled &&
                    record.TimeUpdated >= floor && record.TimeUpdated <= top);

                foreach (var item in lateItems)
                {
                    var order = await MDatabases.Orders[item.Id];
                    var status = await MDatabases.Status[item.Id];
                    if (order != null && status != null)
                    {
                        order.Priority = order.Priority + 1;
                        status.ScanCount = status.ScanCount + 1;
                    }
                }

                MDatabases.SaveChanged();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
