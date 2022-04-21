namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Definition-class for table columns.
    /// </summary>
    public class TableColumnDefinition
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Column width in centimeters.
        /// </summary>
        public double WidthInCm { get; set; }

        /// <summary>
        /// Column height in centimeters.
        /// </summary>
        public double HeightInCm { get; set; }

        /// <summary>
        /// Type of column.
        /// </summary>
        public TableColumnType Type { get; set; }
    }
}
