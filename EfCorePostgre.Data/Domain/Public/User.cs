namespace EfCorePostgre.Data.Domain.Public
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using EfCorePostgre.Data.Entity;

    /// <summary>The system user.</summary>
    [Serializable]
    [DataContract]
    [Table("user", Schema = "public")]
    public class User : BaseEntity
    {
        /// <summary>Gets or sets the first name.</summary>
        [DataMember]
        [Column("first_name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        [DataMember]
        [Column("last_name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        [DataMember]
        [Column("email")]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        [DataMember]
        [Column("password")]
        [MaxLength(255)]
        [Required]
        public string Password { get; set; }

        /// <summary>Gets or sets the password salt.</summary>
        [DataMember]
        [Column("password_salt")]
        [MaxLength(255)]
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>Gets or sets the ıs password change first login.</summary>
        [DataMember]
        [Column("is_passwordChangeFirstLogin")]
        public bool? IsPasswordChangeFirstLogin { get; set; } = true;
    }
}