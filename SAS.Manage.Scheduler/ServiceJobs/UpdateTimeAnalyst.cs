using Microsoft.Extensions.Hosting;
using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Scheduler.ServiceJobs
{
    internal class UpdateTimeAnalyst : IHostedService
    {
        private AppDatabase MDatabases { get; set; }
        public UpdateTimeAnalyst(AppDatabase MDatabases)
        {
            this.MDatabases = MDatabases;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                var completedOrder = await MDatabases.Status.FindAll(record => record.Completed);

                IEnumerable<(Guid TypeId, TimeSpan Duration)> data = MDatabases.ViewTypesTimeAnalysts.Take(20).Select(record =>
                (
                    record.TypeId,
                    record.TimeUpdated - record.TimeCreated
                ));

                IEnumerable<(Guid TypeId, int Count, double DurationAverage)> avg = data.GroupBy(
                    record => record.TypeId,
                    record => record.Duration,
                    (id, timespans) => (
                        id,
                        timespans.Count(),
                        timespans.Average(time => time.TotalMilliseconds)
                    ));

                foreach (var item in avg)
                {
                    var ordertype = await MDatabases.Ordertypes[item.TypeId];
                    if (ordertype != null)
                    {
                        var newAvg = (ordertype.SampleAvgTimeInMinisecond + item.DurationAverage) / 2;

                        ordertype.SampleTypecount = item.Count;
                        ordertype.SampleAvgTimeInMinisecond = Convert.ToInt32(Math.Floor(newAvg));
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
