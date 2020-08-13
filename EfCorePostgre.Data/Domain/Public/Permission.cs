namespace EfCorePostgre.Data.Domain.Public
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using EfCorePostgre.Core.Data.Entity;

    /// <summary>The permission.</summary>
    [Serializable]
    [DataContract]
    [Table("permission", Schema = "public")]
    public class Permission : AuditEntity
    {
        /// <summary>Gets or sets the permission type ıd.</summary>
        [DataMember]
        [Column("permission_typeId")]
        public int PermissionTypeId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [DataMember]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        [DataMember]
        [Column("description")]
        public string Description { get; set; }
    }
}