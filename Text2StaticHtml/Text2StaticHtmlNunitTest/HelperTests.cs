using Microsoft.VisualStudio.TestPlatform.TestHost;
using Text2StaticHtml;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Text2StaticHtmlNunitTest;

public class HelperTests
{
    private string TestDirectory = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\TestDirectory");
    private string OutputDirectory = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\TestOutputDirectory");
    private string TextFileTest = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\TestInputDirectory\\Example2.txt");
    private string MdFileTest = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\TestInputDirectory\\Example4.md");
    private string HtmlFileTest = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\TestInputDirectory\\InvalidExampleHtml.html");
    private string StyleSheet = "https://cdn.jsdelivr.net/npm/water.css@2/out/water.css";

    [SetUp]
    public void Setup()
    {
        Directory.CreateDirectory(TestDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(TestDirectory))
        {
            Directory.Delete(TestDirectory, true);
        }
    }

    [Test]
    public void Passing_Empty_Directory_Path()
    {
        try
        {
            Helper.OutputDirectoryHandler("");
            Assert.IsTrue(true);
        }
        catch
        {
            Assert.IsTrue(false);
        }
    }

    [Test]
    public void Passing_Existing_Directory_Path()
    {
        try
        {
            Helper.OutputDirectoryHandler(TestDirectory);
            Assert.IsTrue(true);
        }
        catch
        {
            Assert.IsTrue(false);
        }
    }

    [Test]
    public void DisplayHelp_NotThrowException()
    {
        Assert.DoesNotThrow(() => Helper.DisplayHelp());
    }

    [Test]
    public void DisplayNameAndVersion_NotThrowException()
    {
        Assert.DoesNotThrow(() => Helper.DisplayNameAndVersion());
    }

    [Test]
    public void DisplayArgumentsError_NotThrowException()
    {
        Assert.DoesNotThrow(() => Helper.DisplayArgumentsError());
    }

    [Test]
    public void DisplayPathError_NotThrowException()
    {
        Assert.DoesNotThrow(() => Helper.DisplayPathError());
    }

    [Test]
    public void OutputDirectoryHandler_CreateDirectory()
    {
        Helper.OutputDirectoryHandler(OutputDirectory);
        Assert.IsTrue(Directory.Exists(OutputDirectory));
    }

    [Test]
    public void FinalizeOutput_TextToHtmlFileExists()
    {
        Helper.FinalizeOutput(TextFileTest, OutputDirectory);
        string expectedConvertedHtmlFile = Path.Combine(OutputDirectory, "Example2.html");
        Assert.IsTrue(File.Exists(expectedConvertedHtmlFile));
    }

    [Test]
    public void FinalizeOutput_MdToHtmlFileExists()
    {
        Helper.FinalizeOutput(MdFileTest, OutputDirectory);
        string expectedConvertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        Assert.IsTrue(File.Exists(expectedConvertedHtmlFile));
    }

    [Test]
    public void FinalizeOutput_TextToHtmlFileContentHasParagraphTag()
    {
        Helper.FinalizeOutput(TextFileTest, OutputDirectory);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example2.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains("<p>"));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasStyleSheet()
    {
        Helper.FinalizeOutput(MdFileTest, OutputDirectory,StyleSheet);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains(StyleSheet));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasLanguage()
    {
        string language = "fr";
        Helper.FinalizeOutput(MdFileTest, OutputDirectory, StyleSheet, language);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains(language));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasHorizontalRule()
    {
        string language = "fr";
        Helper.FinalizeOutput(MdFileTest, OutputDirectory, StyleSheet, language);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains("<hr>"));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasH1()
    {
        string language = "fr";
        Helper.FinalizeOutput(MdFileTest, OutputDirectory, StyleSheet, language);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains("<h1>"));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasH2()
    {
        string language = "fr";
        Helper.FinalizeOutput(MdFileTest, OutputDirectory, StyleSheet, language);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains("<h2>"));
    }
    [Test]
    public void FinalizeOutput_MdToHtmlFileHasLink()
    {
        string language = "fr";
        Helper.FinalizeOutput(MdFileTest, OutputDirectory, StyleSheet, language);
        string convertedHtmlFile = Path.Combine(OutputDirectory, "Example4.html");
        string html = File.ReadAllText(convertedHtmlFile);
        Assert.IsTrue(html.Contains("</a>"));
    }
    [Test]
    public void FinalizeOutput_InvalidInputFile()
    {
        bool retVal = Helper.FinalizeOutput(HtmlFileTest, OutputDirectory);
        Assert.IsFalse(retVal);
    }
}