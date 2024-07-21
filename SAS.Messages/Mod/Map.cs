using System.Collections.Concurrent;

namespace SAS.Messages.Mod
{
    public class Map
    {
        public string Name { get; set; }
        public object? Data { get; private set; }
        public ConcurrentDictionary<string, Map>? Locations { get; set; }

        public Map(string name)
        {
            Name = name;
        }

        public void Add(string name, object? obj = null)
        {
            if (Locations == null)
                Locations = new ConcurrentDictionary<string, Map>();

            Locations.TryAdd(name, new Map(name) { Data = obj });
        }

        public bool Has(string name)
        {
            if (Locations == null) return false;
            return Locations.ContainsKey(name);
        }

        public bool Find(params string[] names)
        {
            if (Goto(names) != null) return true;
            return false;
        }

        public Map? Goto(params string[] names)
        {
            var location = this;
            for (int i = 0; i < names.Length; i++)
            {
                if (location!.Has(names[i]))
                {
                    location = location![names[i]];
                }
                else
                {
                    return null;
                }
            }
            return location;
        }

        public Map? this[string name]
        {
            get {
                if (Has(name)) return Locations![name];
                return null;
            }
        }
    }
}
