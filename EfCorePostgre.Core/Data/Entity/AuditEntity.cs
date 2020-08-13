namespace EfCorePostgre.Core.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>The audit entity.</summary>
    [Serializable]
    public abstract class AuditEntity : BaseEntity
    {
        /// <summary>Gets or sets the created user ıd.</summary>
        [Column("created_userId")]
        public long CreatedUserId { get; set; }

        /// <summary>Gets or sets the created date time.</summary>
        [Column("created_dateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        /// <summary>Gets or sets the updated user ıd.</summary>
        [Column("updated_userId")]
        public long? UpdatedUserId { get; set; }

        /// <summary>Gets or sets the updated date time.</summary>
        [Column("updated_dateTime")]
        public DateTime? UpdatedDateTime { get; set; }
    }
}