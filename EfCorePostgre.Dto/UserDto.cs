namespace EfCorePostgre.Dto
{
    /// <summary>The user dto.</summary>
    public class UserDto : BaseDto
    {
        /// <summary>Gets or sets the first name.</summary>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        public string Password { get; set; }

        /// <summary>Gets or sets the password salt.</summary>
        public string PasswordSalt { get; set; }
        
        /// <summary>Gets or sets the ıs password change first login.</summary>
        public bool? IsPasswordChangeFirstLogin { get; set; }
    }
}