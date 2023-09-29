﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text2StaticHtml
{
    public class Helper
    {
        // Shows the help Menu
        public static void DisplayHelp()
        {
            Console.WriteLine("---Guide---");
            Console.WriteLine("1. Text2StaticHtml <Path> => <Path> can be a path to .txt or .md file or a directory containing .txt or .md files.");
            Console.WriteLine("2. Text2StaticHtml -o <InputPath> <OutpuPath> => <InputPath> is the .txt or .md file directory and" +
                " <OutputPath> is the new output directory");
            Console.WriteLine("3. Text2StaticHtml --output <InputPath> <OutpuPath> => <InputPath> is the .txt or .md file directory " +
                "and <OutputPath> is the new output directory");
            Console.WriteLine("2. Text2StaticHtml -s <StylesheetUrl> <TextFilePath> => <StylesheetUrl> is the url to a custom CSS stylesheet " +
                "and <TextFilePath> is the path to the text file input");
            Console.WriteLine("2. Text2StaticHtml --stylesheet <StylesheetUrl> <TextFilePath> => <StylesheetUrl> is the url to a custom CSS stylesheet " +
                "and <TextFilePath> is the path to the text file or a directory of text files");
            Console.WriteLine("4. Text2StaticHtml -v or --version => Shows the name and the version of the app");
            Console.WriteLine("5. Text2StaticHtml -h or --help => Shows the Guide menu");
            Console.WriteLine("---Guide---");
        }
        // Shows the name and the version of the program
        public static void DisplayNameAndVersion()
        {
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Version: " + version);
        }
        // Shows an error if the arguments provided are incorrect
        public static void DisplayArgumentsError()
        {
            Console.WriteLine("Please provide a correct input. Run the program with -h or --help for help.");
        }
        // Shows an error if the path(s) provided as arguments are incorrect
        public static void DisplayPathError()
        {
            Console.WriteLine("Please provide a correct path to a .txt or .md file or a directory containing .txt or .md file(s). " +
                "Run the program with -h or --help for help.");
        }
        // Creates a new directory everytime based on the path provided
        public static void OutputDirectoryHandler (string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }
        // Converts the contents of a text file to html and returns the converted content as a string
        public static string TextToHtmlConverter (string fileName, string path, string stylesheetUrl)
        {
            string fileExt = Path.GetExtension(fileName);
            string content = File.ReadAllText(path);
            string[] paragraphs = content.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string html = "";
            bool md = false;
            html = $"<!doctype html>\n<html lang=\"en\">\n<head>\n\t<meta charset=\"utf-8\">\n\t<title>{fileName.Split(".")[0]}</title>" +
            $"\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
            $"\n\t<link rel=\"stylesheet\" href=\"{stylesheetUrl}\">\n</head>";
            if (fileExt == ".md")
            {
                Console.WriteLine("MD File");
                md = true;
                if(paragraphs[0].StartsWith("# ")) {
                    html += $"\n\t<h1>\n\t{paragraphs[0].Replace("#", "")}\n\t</h1>";
                }
            } else if (fileExt == ".txt") {
                Console.WriteLine("TXT File");
            }
            html += "\n<body>";
            foreach (string p in paragraphs)
            {
                string paragraph = p.Trim();
                if (md)
                {
                    Regex reg = new Regex("\\[([^]]*)\\]\\(([^\\s^\\)]*)[\\s\\)]");
                    if (p.StartsWith("##"))
                    {
                        html += $"\n\t<h2>\n\t{paragraph.Replace("##", "")}\n\t</h2>";
                    }
                    else if (reg.IsMatch(p))
                    {
                        Match m = reg.Match(p);
                        html += $"\n\t<a href={m.Groups[1]}>\n\t{m.Groups[2]}\n\t</a>";
                    }
                    else if ((p == "---") || (p == "***") || (p == "___"))
                    {
                        
                        html += $"\n\t<hr>\n\t";
                    }
                    else 
                    {
                        html += $"\n\t<p>\n\t{p}\n\t</p>";
                    }
                }
                else
                {
                    html += $"\n\t<p>\n\t{paragraph}\n\t</p>";
                }
            }
            html += "\n</body>\n</html>";
            
            return html;
        }
        // Creates the html file(s) and saves them to the approprite directory
        public static void FinalizeOutput(string path, string outPutDirectory, string stylesheetUrl = "")
        {
            string textFileName = Path.GetFileName(path);
            string htmlFileName = Path.GetFileNameWithoutExtension(path) + ".html";        
            string outputFilePath = Path.Combine(outPutDirectory, htmlFileName);
            string html = TextToHtmlConverter(textFileName, path, stylesheetUrl);
            File.WriteAllText(outputFilePath, html);
        }
    }
}
