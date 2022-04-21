using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Class for adding settings for the PDF document.
    /// </summary>
    public class DocumentSettings
    {
        /// <summary>
        /// Optional PDF document title.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Title { get; set; }

        /// <summary>
        /// Optional PDF document Author.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Author { get; set; }

        /// <summary>
        /// Document page size.
        /// </summary>
        [DefaultValue(PageSizeEnum.A4)]
        public PageSizeEnum Size { get; set; }

        /// <summary>
        /// Page orientation.
        /// </summary>
        [DefaultValue(PageOrientationEnum.Portrait)]
        public PageOrientationEnum Orientation { get; set; }

        /// <summary>
        /// Page margin left in CM.
        /// </summary>
        [DefaultValue(2.5)]
        public double MarginLeftInCm { get; set; }

        /// <summary>
        /// Page margin top in CM.
        /// </summary>
        [DefaultValue(2)]
        public double MarginTopInCm { get; set; }

        /// <summary>
        /// Page margin right in CM.
        /// </summary>
        [DefaultValue(2.5)]
        public double MarginRightInCm { get; set; }

        /// <summary>
        /// Page margin bottom in CM.
        /// </summary>
        [DefaultValue(2)]
        public double MarginBottomInCm { get; set; }

    }
}
