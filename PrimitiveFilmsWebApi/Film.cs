namespace PrimitiveFilmsWebApi
{
    /// <summary>
    /// Provides properties for creating films.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Gets or sets the id <see cref="Film"/> as a <see cref="Guid"/> value.
        /// </summary>
        public string Id { get; set; } = "";
        /// <summary>
        /// Gets or sets the title <see cref="Film"/>. 
        /// </summary>
        public string Title { get; set; } = "";
        /// <summary>
        /// Gets or sets the genre <see cref="Film"/>.
        /// </summary>
        public string Genre { get; set; } = "";
        /// <summary>
        /// Gets or sets the descrption <see cref="Film"/>.
        /// </summary>
        public string Description { get; set; } = "";
    }
}
