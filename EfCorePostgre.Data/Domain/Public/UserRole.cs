namespace EfCorePostgre.Data.Domain.Public
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using EfCorePostgre.Core.Data.Entity;

    /// <summary>The user role.</summary>
    [Serializable]
    [DataContract]
    [Table("user_role", Schema = "public")]
    public class UserRole : AuditEntity
    {
        /// <summary>Gets or sets the user ıd.</summary>
        [DataMember]
        [Column("user_id")]
        public long UserId { get; set; }

        /// <summary>Gets or sets the role ıd.</summary>
        [DataMember]
        [Column("role_id")]
        public long RoleId { get; set; }
    }
}