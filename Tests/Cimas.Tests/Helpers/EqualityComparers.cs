using Cimas.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimas.Tests.Helpers
{
    internal class CompanyEqualityComparer : IEqualityComparer<Company>
    {
        public bool Equals([AllowNull] Company x, [AllowNull] Company y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id &&
                x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Company obj)
        {
            return obj.GetHashCode();
        }
    }
}
