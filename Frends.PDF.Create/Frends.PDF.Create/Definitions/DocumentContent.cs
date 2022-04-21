using System.ComponentModel;

namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Class for wrapping page contents together.
    /// </summary>
    public class DocumentContent
    {
        /// <summary>
        /// Document content
        /// </summary>
        [DisplayName("Document Content")]
        public PageContentElement[] Contents { get; set; }
    }
}
