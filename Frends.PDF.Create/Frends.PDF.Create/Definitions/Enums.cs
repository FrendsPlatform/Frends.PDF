﻿#pragma warning disable CS1591 // Some of the enums are self-explanatory.

namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Actions if the output document already exists.
    /// </summary>
    public enum FileExistsActionEnum
    {
        /// <summary>
        /// Throw error.
        /// </summary>
        Error,
        /// <summary>
        /// Overwrite the existing document.
        /// </summary>
        Overwrite,
        /// <summary>
        /// Rename the new document.
        /// </summary>
        Rename
    }

    /// <summary>
    /// Page size options.
    /// </summary>
    public enum PageSizeEnum
    {
        A0,
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
        B5,
        Ledger,
        Legal,
        Letter
    }

    /// <summary>
    /// Options for page orientation.
    /// </summary>
    public enum PageOrientationEnum
    {
        Portrait,
        Landscape
    }

    /// <summary>
    /// Élement which will be added to the document.
    /// </summary>
    public enum ElementType
    {
        Paragraph,
        Image,
        PageBreak,
        Header,
        Footer,
        Table
    }

    /// <summary>
    /// Alignment of paragraph.
    /// </summary>
    public enum ParagraphAlignmentEnum
    {
        Left,
        Center,
        Justify,
        Right
    }

    /// <summary>
    /// Alignment for image.
    /// </summary>
    public enum ImageAlignmentEnum
    {
        Left,
        Center,
        Right
    }

    /// <summary>
    /// Options for paragraph font.
    /// </summary>
    public enum FontStyleEnum
    {
        Regular,
        Bold,
        Italic,
        BoldItalic,
        Underline
    }

    /// <summary>
    /// Options for header/footer input.
    /// </summary>
    public enum HeaderFooterStyleEnum
    {
        /// <summary>
        /// Add only text.
        /// </summary>
        Text,
        /// <summary>
        /// Add text and page numbers.
        /// </summary>
        TextPagenum,
        /// <summary>
        /// Add text and image.
        /// </summary>
        LogoText,
        /// <summary>
        /// Add text, image and page numbers.
        /// </summary>
        LogoTextPagenum
    }

    /// <summary>
    /// Options for table type.
    /// </summary>
    public enum TableTypeEnum
    {
        /// <summary>
        /// Normal table in the document.
        /// </summary>
        Table,
        /// <summary>
        /// Add table to header.
        /// </summary>
        Header,
        /// <summary>
        /// Add table to footer.
        /// </summary>
        Footer
    }

    /// <summary>
    /// Type of data which will be added to the table columns.
    /// </summary>
    public enum TableColumnType
    {
        /// <summary>
        /// Text data.
        /// </summary>
        Text,
        /// <summary>
        /// Images.
        /// </summary>
        Image,
        /// <summary>
        /// Page numbers.
        /// </summary>
        PageNum
    }

    /// <summary>
    /// Table style selector for changing style to different borders.
    /// </summary>
    public enum TableBorderStyle
    {
        None,
        Top,
        Bottom,
        All
    }
}
