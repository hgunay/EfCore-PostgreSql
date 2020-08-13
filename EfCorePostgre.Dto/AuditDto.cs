namespace EfCorePostgre.Dto
{
    using System;

    /// <summary>The audit dto.</summary>
    public class AuditDto : BaseDto
    {
        /// <summary>Gets or sets the created user ıd.</summary>
        public long CreatedUserId { get; set; }

        /// <summary>Gets or sets the created date time.</summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        /// <summary>Gets or sets the updated user ıd.</summary>
        public long? UpdatedUserId { get; set; }

        /// <summary>Gets or sets the updated date time.</summary>
        public DateTime? UpdatedDateTime { get; set; }
    }
}