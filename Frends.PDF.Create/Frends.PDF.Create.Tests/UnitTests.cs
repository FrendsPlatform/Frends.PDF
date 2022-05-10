﻿using Frends.PDF.Create.Definitions;
using NUnit.Framework;
using System;
using System.IO;

namespace Frends.PDF.Create.Tests;

[TestFixture]
public class UnitTests
{
    private static readonly string _fileName = "test_output.pdf";
    private static readonly string _folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../TestOutput");
    private static readonly string _destinationFullPath = Path.Combine(_folder, _fileName);
    private static readonly FileProperties _fileProperties = new() { Directory = _folder, FileName = _fileName, FileExistsAction = FileExistsActionEnum.Error, Unicode = true };
    private static readonly DocumentSettings _docSettings = new() { MarginBottomInCm = 2, MarginLeftInCm = 2.5, MarginRightInCm = 2.5, MarginTopInCm = 5, Orientation = PageOrientationEnum.Portrait, Size = PageSizeEnum.A4 };

    private PageContentElement _header;
    private PageContentElement _footer;
    private PageContentElement _title;
    private PageContentElement _paragraphContent;
    private PageContentElement _tableContent;

    private Options _options;

    [SetUp]
    public void TestSetup()
    {

        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }
        var logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Files/logo.png");
        _header = new PageContentElement { ContentType = ElementType.Header, FontFamily = "Times New Roman", FontSize = 8, FontStyle = FontStyleEnum.Regular, LineSpacingInPt = 11, ParagraphAlignment = ParagraphAlignmentEnum.Right, SpacingAfterInPt = 0, SpacingBeforeInPt = 8, ImagePath = logoPath, HeaderFooterStyle = HeaderFooterStyleEnum.LogoText, BorderWidthInPt = 0.5, ImageHeightInCm = 0.5 };
        _footer = new PageContentElement { ContentType = ElementType.Footer, FontFamily = "Times New Roman", FontSize = 8, FontStyle = FontStyleEnum.Regular, LineSpacingInPt = 11, ParagraphAlignment = ParagraphAlignmentEnum.Center, SpacingAfterInPt = 0, SpacingBeforeInPt = 8, HeaderFooterStyle = HeaderFooterStyleEnum.TextPagenum, BorderWidthInPt = 0.0 };
        _title = new PageContentElement { ContentType = ElementType.Paragraph, FontFamily = "Times New Roman", FontSize = 16, FontStyle = FontStyleEnum.Bold, LineSpacingInPt = 11, ParagraphAlignment = ParagraphAlignmentEnum.Left, SpacingAfterInPt = 0, SpacingBeforeInPt = 8 };
        _paragraphContent = new PageContentElement { ContentType = ElementType.Paragraph, FontFamily = "Times New Roman", FontSize = 11, FontStyle = FontStyleEnum.Regular, LineSpacingInPt = 11, ParagraphAlignment = ParagraphAlignmentEnum.Left, SpacingAfterInPt = 0, SpacingBeforeInPt = 8 };

        var tablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Files/ContentDefinition.json");
        var tableDefinition = File.ReadAllText(tablePath);
        _tableContent = new PageContentElement { ContentType = ElementType.Table, Table = tableDefinition };

        _options = new Options { ThrowErrorOnFailure = true };
    }

    [TearDown]
    public void TestTearDown()
    {
        Directory.Delete(_folder, true);
    }

    private Result CallCreatePdf(PageContentElement[] contents)
    {
        return PDF.Create(_fileProperties, _docSettings, new DocumentContent { Contents = contents }, _options);
    }

    [Test]
    public void CreatePDFTest()
    {
        _fileProperties.FileExistsAction = FileExistsActionEnum.Overwrite;
        _paragraphContent.Text = @"Some text           for testing
with some tab
    one
        two
            three. Then end with scandic letter ö and russian word код.";

        var result = CallCreatePdf(new PageContentElement[] { _header, _footer, _title, _paragraphContent, new PageContentElement { ContentType = ElementType.PageBreak }, _tableContent });

        Assert.IsTrue(File.Exists(_destinationFullPath));
        Assert.IsTrue(result.Success);
    }

    [Test]
    public void Create_DoesNotFailIfContentIsEmptyTest()
    {
        _paragraphContent.Text = string.Empty;
        var result = CallCreatePdf(new PageContentElement[] { _paragraphContent });

        Assert.IsTrue(File.Exists(_destinationFullPath));
        Assert.IsTrue(result.Success);
    }

    [Test]
    public void Create_ThrowsExceptionIfFileExistsTest()
    {
        _options.ThrowErrorOnFailure = true;
        _fileProperties.FileExistsAction = FileExistsActionEnum.Error;
        var errorMessage = "Output file already exists: " + _destinationFullPath;

        // Run once so file exists.
        CallCreatePdf(new PageContentElement[] { _paragraphContent });

        var result = Assert.Throws<Exception>(() => CallCreatePdf(new PageContentElement[] { _paragraphContent }));
        Assert.AreEqual(errorMessage, result.Message);
    }

    [Test]
    public void Create_OverwriteFileIfItExistsTest()
    {
        _options.ThrowErrorOnFailure = true;
        _fileProperties.FileExistsAction = FileExistsActionEnum.Overwrite;

        // Run once so file exists.
        CallCreatePdf(new PageContentElement[] { _paragraphContent });
        Assert.IsTrue(File.Exists(_destinationFullPath));

        // Run second time to overwrite the previous file.
        CallCreatePdf(new PageContentElement[] { _paragraphContent });
        Assert.IsTrue(File.Exists(_destinationFullPath));
    }

    [Test]
    public void Create_RenamesFilesIfAlreadyExistsTest()
    {
        _fileProperties.FileExistsAction = FileExistsActionEnum.Rename;

        // Create 3 files.
        var result1 = CallCreatePdf(new PageContentElement[] { _paragraphContent });
        var result2 = CallCreatePdf(new PageContentElement[] { _paragraphContent });
        var result3 = CallCreatePdf(new PageContentElement[] { _paragraphContent });

        Assert.IsTrue(File.Exists(result1.FileName));
        Assert.AreEqual(_destinationFullPath, result1.FileName);
        Assert.IsTrue(File.Exists(result2.FileName));
        Assert.IsTrue(result2.FileName.Contains("_(1)"));
        Assert.IsTrue(File.Exists(result3.FileName));
        Assert.IsTrue(result3.FileName.Contains("_(2)"));
    }

    [Test]
    public void Create_LogoNotFoundTest()
    {
        _fileProperties.FileExistsAction = FileExistsActionEnum.Overwrite;

        var logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\no_such_logo.png");
        var header = new PageContentElement { ContentType = ElementType.Header, FontFamily = "Times New Roman", FontSize = 8, FontStyle = FontStyleEnum.Regular, LineSpacingInPt = 11, ParagraphAlignment = ParagraphAlignmentEnum.Right, SpacingAfterInPt = 0, SpacingBeforeInPt = 8, ImagePath = logoPath, HeaderFooterStyle = HeaderFooterStyleEnum.LogoText, BorderWidthInPt = 0.5, ImageHeightInCm = 0.5 };
        header.Text = @"This is a header";
        var errorMessage = "Path to header graphics was empty or the file does not exist: " + logoPath;

        var result = Assert.Throws<FileNotFoundException>(() => CallCreatePdf(new PageContentElement[] { header }));
        Assert.AreEqual(errorMessage, result.Message);
        Assert.IsFalse(File.Exists(_destinationFullPath));
    }

    [Test]
    public void Create_TableWidthTooLargeTest()
    {
        var tooWideTable = @"{ ""HasHeaderRow"": true, ""TableType"": ""Table"", ""Columns"": [ { ""Name"": ""Sarake 1"", ""WidthInCm"": 21, ""HeightInCm"": 0, ""Type"": ""Text"" } ], ""RowData"": [] }";
        var table1 = new PageContentElement { ContentType = ElementType.Table, Table = tooWideTable };
        var errorMessage = "Page allows table to be 16 cm wide. Provided table's width is larger than that";
        var result1 = Assert.Throws<Exception>(() => CallCreatePdf(new PageContentElement[] { table1 }));

        // Tables width is calculated during runtime, so exact check of the error message is not possible.
        Assert.IsTrue(result1.Message.Contains(errorMessage));
        Assert.IsFalse(File.Exists(_destinationFullPath));
    }
}
