/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IHeartFiction.Domain.SeedWork
{
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        ///     Unique Identifier of the Enumneration Store
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Name should be similiar to the static name of
        ///     the Enumeration.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Inheritance use only.
        /// </summary>
        protected Enumeration() { }

        /// <summary>
        ///     Creates a new enumerator with the specific ID, and the specific name,
        ///     Do not use internal Enumeration type for complex data-stored enumerations.
        ///     https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
        /// </summary>
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }
        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => Id.GetHashCode();
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => Name;

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        /// <summary>
        ///     Returns a list of all the enumerations that exist for this type.
        /// </summary>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }
    }
}
