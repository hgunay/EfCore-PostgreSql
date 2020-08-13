namespace EfCorePostgre.Data.Domain.Public
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using EfCorePostgre.Core.Data.Entity;

    /// <summary>The role.</summary>
    [Serializable]
    [DataContract]
    [Table("role", Schema = "public")]
    public class Role : AuditEntity
    {
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