namespace WorkRegistrarAPI.Models
{
    /// <summary>
    ///  Olyan modell mely arra szolgál hogy tárolja a lapozáshoz szükséges adatokat.
    /// </summary>
    public class DataLoaderOptions
    {

        /// <summary>
        /// Gets or sets PageSize.
        /// <para>Initial value: <code>int.MaxVlaue</code></para>
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets PageNumber.
        /// <para>Initial value: <code>1</code></para>
        /// </summary>
        public int PageNumber { get; set; } = 1;

        public string? Orderfield { get; set; }

        public bool OrderDescand { get; set; } = false;

    }
}
