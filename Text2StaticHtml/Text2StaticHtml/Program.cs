using System.Reflection;
using System.Text.RegularExpressions;

namespace Text2StaticHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if the number of arguments are valid
            if(args.Length > 3)
            {
                Helper.DisplayArgumentsError();
                return;
            }
            else
            {
                // If 0 arguments show help menu
                if(args.Length == 0)
                {
                    Helper.DisplayHelp();
                    return;
                }
                if(args.Length == 1)
                {
                    // Show version and name if the argument is -v or --version
                    if (args[0] == "-v" || args[0] == "--version")
                    {
                        Helper.DisplayNameAndVersion();
                        return;
                    }
                    // Show help menu if the argument is -h or --help
                    else if(args[0] == "-h" || args[0] == "--help")
                    {
                        Helper.DisplayHelp();
                        return;
                    }
                    // If the argument provided is a file path do the conversion
                    else if (File.Exists(args[0]))
                    {
                        string path = args[0];
                        // Check if the file is a text file
                        if (Path.GetExtension(path) != ".txt" || Path.GetExtension(path) != ".md")
                        {
                            Helper.DisplayPathError();
                            return;
                        }
                        else
                        {
                            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                            Helper.OutputDirectoryHandler(outputDirectory);
                            Helper.FinalizeOutput(path, outputDirectory);
                            Console.WriteLine("You file was converted.");
                            return;
                        }
                    }
                    // If the argument provided is a directory do the conversion
                    else if (Directory.Exists(args[0]))
                    {
                        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                        string path = args[0];
                        // Only get text & md files in the directory
                        Regex reg = new Regex("^.*.(txt|md)");
                        List<string> files = Directory.GetFiles(path)
                            .Where(path => reg.IsMatch(path))
                            .ToList();

                        if (files.Count == 0)
                        {
                            Helper.DisplayPathError();
                            return;
                        }
                        else
                        {
                            Helper.OutputDirectoryHandler(outputDirectory);
                            foreach (string file in files)
                            {
                                Helper.FinalizeOutput(file, outputDirectory);
                            }
                            Console.WriteLine("Your files were converted");
                            return;
                        }
                    }
                    else
                    {
                        Helper.DisplayArgumentsError();
                        return;
                    }
                }
                if(args.Length == 3 || args.Length == 2)
                {
                    // Check for optional feature arguments like -o or --ouput or -s and --stylesheet
                    if (args[0] == "-o" || args[0] == "--output" || args[0] == "-s" || args[0] == "--stylesheet")
                    {
                        // If the first argument is -s or --stylesheet use the stylesheet url provided to apply to the html conversion
                        if ( args.Length == 3 && (args[0] == "-s" || args[0] == "--stylesheet") && (Directory.Exists(args[2]) || File.Exists(args[2])))
                        {
                            string styleSheet = args[1];
                            if (File.Exists(args[2]))
                            {
                                string path = args[2];
                                if (Path.GetExtension(path) != ".txt" || Path.GetExtension(path) != ".md")
                                {
                                    Helper.DisplayPathError();
                                    return;
                                }
                                else
                                {
                                    string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                                    Helper.OutputDirectoryHandler(outputDirectory);
                                    Helper.FinalizeOutput(path, outputDirectory, styleSheet);
                                    Console.WriteLine("You file was converted.");
                                    return;
                                }
                            }
                            else if (Directory.Exists(args[2]))
                            {
                                string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                                string path = args[2];
                                Regex reg = new Regex("^.*.(txt|md)");
                                List<string> files = Directory.GetFiles(path)
                                    .Where(path => reg.IsMatch(path))
                                    .ToList();
                                if (files.Count == 0)
                                {
                                    Helper.DisplayPathError();
                                    return;
                                }
                                else
                                {
                                    Helper.OutputDirectoryHandler(outputDirectory);
                                    foreach (string file in files)
                                    {
                                        Helper.FinalizeOutput(file, outputDirectory, styleSheet);
                                    }
                                    Console.WriteLine("Your files were converted");
                                    return;
                                }
                            }
                            else
                            {
                                Helper.DisplayPathError();
                                return;
                            }
                        }
                        // If the first argument is -o or --output use the provided output directory as the destination
                        else if ((args[0] == "-o" || args[0] == "--output") && (Directory.Exists(args[1]) || File.Exists(args[1])))
                        {
                            // If the output directory path is provided
                            if (args.Length == 3)
                            {
                                if (File.Exists(args[1]))
                                {
                                    string path = args[1];
                                    if (Path.GetExtension(path) != ".txt")
                                    {
                                        Helper.DisplayPathError();
                                        return;
                                    }
                                    else
                                    {
                                        string outputDirectory = args[2];
                                        // Check if the path provided for the destination directory is valid and the directory gets created
                                        try
                                        {
                                            Helper.OutputDirectoryHandler(outputDirectory);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                            Console.WriteLine("Please provide a correct path for the destination directory");
                                            return;
                                        }
                                        Helper.FinalizeOutput(path, outputDirectory);
                                        Console.WriteLine("You file was converted.");
                                        return;
                                    }
                                }
                                else if (Directory.Exists(args[1]))
                                {
                                    string outputDirectory = args[2];
                                    string path = args[1];
                                    Regex reg = new Regex("^.*.(txt|md)");
                                    List<string> files = Directory.GetFiles(path)
                                        .Where(path => reg.IsMatch(path))
                                        .ToList();
                                    if (files.Count == 0)
                                    {
                                        Helper.DisplayPathError();
                                        return;
                                    }
                                    else
                                    {
                                        // Check if the path provided for the destination directory is valid and the directory gets created
                                        try
                                        {
                                            Helper.OutputDirectoryHandler(outputDirectory);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                            Console.WriteLine("Please provide a correct path for the destination directory");
                                            return;
                                        }
                                        foreach (string file in files)
                                        {
                                            Helper.FinalizeOutput(file, outputDirectory);
                                        }
                                        Console.WriteLine("Your files were converted");
                                        return;
                                    }
                                }
                                else
                                {
                                    Helper.DisplayPathError();
                                    return;
                                }
                            }
                            else
                            {
                                if (File.Exists(args[1]))
                                {
                                    string path = args[1];
                                    if (Path.GetExtension(path) != ".txt" || Path.GetExtension(path) != ".md")
                                    {
                                        Helper.DisplayPathError();
                                        return;
                                    }
                                    else
                                    {
                                        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                                        Helper.OutputDirectoryHandler(outputDirectory);
                                        Helper.FinalizeOutput(path, outputDirectory);
                                        Console.WriteLine("You file was converted.");
                                        return;
                                    }
                                }
                                else if (Directory.Exists(args[1]))
                                {
                                    string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "til");
                                    string path = args[1];
                                    Regex reg = new Regex("^.*.(txt|md)");
                                    List<string> files = Directory.GetFiles(path)
                                        .Where(path => reg.IsMatch(path))
                                        .ToList();
                                    if (files.Count == 0)
                                    {
                                        Helper.DisplayPathError();
                                        return;
                                    }
                                    else
                                    {
                                        Helper.OutputDirectoryHandler(outputDirectory);
                                        foreach (string file in files)
                                        {
                                            Helper.FinalizeOutput(file, outputDirectory);
                                        }
                                        Console.WriteLine("Your files were converted");
                                        return;
                                    }
                                }
                                else
                                {
                                    Helper.DisplayPathError();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Helper.DisplayArgumentsError();
                            return;
                        }
                    }
                    else
                    {
                        Helper.DisplayArgumentsError();
                        return;              
                    }
                }
            }
        }
    }
}