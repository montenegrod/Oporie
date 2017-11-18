using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Dominio.Core.Entidades
{
    /// <summary>
    /// Custom extensions methods for STE entities
    /// </summary>
    public static class ChangeTrackerExtensions
    {
        /// <summary>
        /// Start tracking in all entities associated with <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">Root entity</param>
        public static void StartTrackingAll(this IObjectWithChangeTracker entity)
        {
            using (ChangeTrackerIterator iterator = ChangeTrackerIterator.Create(entity))
                iterator.Execute(ste => ste.StartTracking());
        }

        /// <summary>
        /// Stop tracking in all entities associated with <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">Root entity</param>
        public static void StopTrackingAll(this IObjectWithChangeTracker entity)
        {
            using (ChangeTrackerIterator iterator = ChangeTrackerIterator.Create(entity))
                iterator.Execute(ste => ste.StopTracking());
        }

        /// <summary>
        /// Accept all changes in all entities associated with <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">Root entity</param>
        public static void AcceptAllChanges(this IObjectWithChangeTracker entity)
        {
            using (ChangeTrackerIterator iterator = ChangeTrackerIterator.Create(entity))
                iterator.Execute(ste => ste.AcceptChanges());
        }
    }

}
