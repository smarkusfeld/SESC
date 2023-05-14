using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Mapper
{
    
    
    public abstract class Enumeration : IComparable
    {
        private readonly int _id;
        private readonly string _name;
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }

        protected Enumeration(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();
        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }
        private static T Parse<T, TIntOrString>(TIntOrString nameOrId,string description, Func<T, bool> predicate) where T : Enumeration
        {
            var match = GetAll<T>().FirstOrDefault(predicate);

            return match ?? throw new InvalidOperationException(
                    $"'{nameOrId}' is not a valid {description} in {typeof(T)}");
        }
        public static T FromValue<T>(int id) where T : Enumeration
        {
            var match = Parse<T, int>(id, "ID", x => x.Id == id);
            return match;
        }
        public static T FromName<T>(string name) where T : Enumeration
        {
            var match = Parse<T, string>(name, "name", item => item.Name == name);
            return match;
        }
        public int CompareTo(object? other)
        {
            if (other is not Enumeration e)
            {
                throw new ArgumentException("obj is not the same type as this instance");
            }
            return Id.CompareTo(e.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }

    public class InvoiceType
    : Enumeration
    {
        public static InvoiceType Tutition = new(1, nameof(Tutition));
        public static InvoiceType Libaray = new(2, nameof(Libaray));

        public InvoiceType(int id, string name)
            : base(id, name)
        {
        }
    }

    public class InvoiceStatus
    : Enumeration
    {
        public static InvoiceStatus Outstanding = new(1, nameof(Outstanding));
        public static InvoiceStatus Paid = new(2, nameof(Paid));
        public static InvoiceStatus Cancelled = new(3, nameof(Cancelled));

        public InvoiceStatus(int id, string name)
            : base(id, name)
        {
        }
    }
    public class PaymentStatus
   : Enumeration
    {
        public static PaymentStatus Recieved = new(1, nameof(Recieved));
        public static PaymentStatus Processed = new(2, nameof(Processed));
        public static PaymentStatus Cancelled = new(3, nameof(Cancelled));
        public static PaymentStatus Declined = new(4, nameof(Declined));

        public PaymentStatus(int id, string name)
            : base(id, name)
        {
        }
    }

    public class PaymentMethod
  : Enumeration
    {
        public static PaymentMethod CashCheck = new(1, nameof(CashCheck));
        public static PaymentMethod BACS = new(2, nameof(BACS));
        public static PaymentMethod DebitCredit = new(3, nameof(DebitCredit));
        public static PaymentMethod Other = new(4, nameof(Other));

        public PaymentMethod(int id, string name)
            : base(id, name)
        {
        }
    }
    
    

}
