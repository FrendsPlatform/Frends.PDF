namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Class for table styles.
    /// </summary>
    public class TableStyle
    {
        /// <summary>
        /// Font family.
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Font size in points.
        /// </summary>
        public double FontSizeInPt { get; set; }

        /// <summary>
        /// Font style.
        /// </summary>
        public FontStyleEnum FontStyle { get; set; }

        /// <summary>
        /// Spacing between words in points.
        /// </summary>
        public double LineSpacingInPt { get; set; }

        /// <summary>
        /// Spacing before line in points.
        /// </summary>
        public double SpacingBeforeInPt { get; set; }

        /// <summary>
        /// Spacing after line in points.
        /// </summary>
        public double SpacingAfterInPt { get; set; }

        /// <summary>
        /// Border width in points.
        /// </summary>
        public double BorderWidthInPt { get; set; }

        /// <summary>
        /// Style of borders.
        /// </summary>
        public TableBorderStyle BorderStyle { get; set; }
    }
}
