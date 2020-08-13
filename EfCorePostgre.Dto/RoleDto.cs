namespace EfCorePostgre.Dto
{
    /// <summary>The role dto.</summary>
    public class RoleDto : AuditDto
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }
    }
}