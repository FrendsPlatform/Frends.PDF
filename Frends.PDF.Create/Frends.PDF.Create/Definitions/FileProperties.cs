using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Page size options.
    /// </summary>
    public class FileProperties
    {
        /// <summary>
        /// PDF document destination Directory
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"C:\Output")]
        public string Directory { get; set; }

        /// <summary>
        /// Filename for created PDF file
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("example_file.pdf")]
        public string FileName { get; set; }

        /// <summary>
        /// What to do if destination file already exists
        /// </summary>
        [DefaultValue(FileExistsActionEnum.Error)]
        public FileExistsActionEnum FileExistsAction { get; set; }

        /// <summary>
        /// Use Unicode text (true) or ANSI (false).
        /// </summary>
        [DefaultValue(true)]
        public bool Unicode { get; set; }
    }
}
