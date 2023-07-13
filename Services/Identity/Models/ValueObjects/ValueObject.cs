using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Models.Common
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }
        /// <summary>
        /// Overload == operator
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }
        /// <summary>
        /// overload !=
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}