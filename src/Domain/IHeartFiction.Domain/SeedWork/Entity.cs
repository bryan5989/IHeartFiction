/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using MediatR;
using System;
using System.Collections.Generic;

namespace IHeartFiction.Domain.SeedWork
{
    /// <summary>
    ///     Entities are objects that aren't identified by their attributes, but by
    ///     a thread of continuity and identity. If confused by this statement read
    ///     the following article before continuing.
    ///     https://lostechies.com/jimmybogard/2008/05/21/entities-value-objects-aggregates-and-roots/
    /// </summary>
    public abstract class Entity
    {
        private int? _requestedHashCode;

        /// <summary>
        ///     Identifies when the entity was created.
        /// </summary>
        public DateTime Created { get; } = DateTime.Now;

        /// <summary>
        ///     Unique identifier of the identity. May be overriden and hidden if
        ///     an entity decides to use a different base type, or a custom implementation
        ///     of id.
        /// </summary>
        public virtual int Id { get; set; }

        private List<INotification> _domainEvents;
        /// <summary>
        ///     Domain events are stored on the entity, in memory, until they can be
        ///     dispered throughout the domain. Domain events are "fact", and cannot
        ///     be changed. They can only be reversed by other domain events. Think
        ///     how services like "Git" work.
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        /// <summary>
        ///     Add a domain event to the internal collection of domain events.
        ///     Using lazy loading to initialize the domain events list.
        /// </summary>
        /// <param name="eventItem">
        ///     A specific domain event to add to the list of events.
        ///     The library "MediatR" is used to handler events, thus the
        ///     INotification contract.
        /// </param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        ///     Remove a domain event from the entity if the list exists
        /// </summary>
        /// <param name="eventItem">
        ///     Event to remove.
        /// </param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        ///     Resets the domain events of this entity to a clean list.
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        /// <summary>
        ///     If the entity doesn't have a defined Id, its transient.
        ///     Meaning that it is not stored in storage.
        /// </summary>
        /// <returns>
        ///     True if the entity is transient, false otherwise.
        /// </returns>
        public bool IsTransient()
        {
            return Id == default(int);
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id == this.Id;
        }
        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}