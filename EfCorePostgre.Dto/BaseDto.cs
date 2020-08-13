namespace EfCorePostgre.Dto
{
    /// <summary>The base dto.</summary>
    public class BaseDto
    {
        /// <summary>Gets or sets the ıd.</summary>
        public long Id { get; set; }

        /// <summary>Gets or sets a value indicating whether ıs active.</summary>
        public bool IsActive { get; set; } = true;

        /// <summary>Gets or sets a value indicating whether ıs deleted.</summary>
        public bool IsDeleted { get; set; } = false;
    }
}