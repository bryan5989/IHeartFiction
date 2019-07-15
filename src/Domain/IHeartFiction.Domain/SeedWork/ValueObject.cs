/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System.Collections.Generic;
using System.Linq;

namespace IHeartFiction.Domain.SeedWork
{
    /// <summary>
    ///     This abstract defines a new basic type called <see cref="ValueObject"/>, which
    ///     is much like the basic type of a structure. However, it is an object that does
    ///     not have an identity. ValueObjects are immutable, they don't change.
    ///     <example>
    ///         An address is unique, but usually belongs to a person.
    ///     </example>
    ///     https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        ///     Overrides the base object equals functionality to check
        ///     if the value object is equivalent on parameters that are
        ///     defined in the <see cref="GetAtomicValues"/> functions.
        /// </summary>
        /// <param name="obj">
        ///     The other valueobject we're comparing to.
        /// </param>
        /// <returns>
        ///     True if the ValueObjects are equal on all properties
        ///     defined in <see cref="GetAtomicValues"/>, false
        ///     otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
        /// <summary>
        ///     Shallow clone of the ValueObject.
        /// </summary>
        /// <returns>
        ///     Copies the object.
        /// </returns>
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }

        /// <summary>
        ///     Returns a list of properties that must be equivalent in order
        ///     for value objects to be equivalent.
        ///     <example>
        ///         12345 2nd Street must have the same house number, and
        ///         street address fields/properties to be equivalent to
        ///         any other address.
        ///     </example>
        /// </summary>
        /// <returns>
        ///     A enumerable of values that are needed to be check for
        ///     equality.
        /// </returns>
        protected abstract IEnumerable<object> GetAtomicValues();

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }
    }
}