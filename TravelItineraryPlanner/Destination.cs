using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace TravelItineraryPlanner
{
    public sealed class Destination
    {
        public string Name { get; }
        public string Country { get; }
        public string Description { get; }

        public Destination(string name, string country, string description)
        {
            Name = name?.Trim() ?? string.Empty;
            Country = country?.Trim() ?? string.Empty;
            Description = description?.Trim() ?? string.Empty;
        }

        public override string ToString()
            => $"{Name} ({Country}) — {Description}";

        // Optional: equality by Name+Country (case-insensitive)
        public static IEqualityComparer<Destination> NameCountryComparer { get; } =
            new NameCountryEq();

        private sealed class NameCountryEq : IEqualityComparer<Destination>
        {
            public bool Equals(Destination? x, Destination? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null || y is null) return false;
                return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(x.Country, y.Country, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Destination obj)
            {
                return HashCode.Combine(
                    obj.Name?.ToLowerInvariant(),
                    obj.Country?.ToLowerInvariant()
                );
            }
        }
    }
}
