namespace EfCorePostgre.Dto
{
    /// <summary>The permission dto.</summary>
    public class PermissionDto : AuditDto
    {
        /// <summary>Gets or sets the permission type ıd.</summary>
        public int PermissionTypeId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }
    }
}