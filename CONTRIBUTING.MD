# Introduction

Thank you for considering being part of Txt2StaticHtml. All contributions, no matter how small or large are welcome. This document provides the guidelines for the contribution process.
___

## Project Setup

- Make sure to have .Net SDK installed and added to the Path in evnrionment variables.
- Clone the repository.
- Navigate to the local project directory by using the command prompt.
- Navigate to the Text2StaticHtml directory where the source code is.
- Build the application by using the command:
```
dotnet build
```
- Change directory to where the executable file was created: `bin/debug/net6.0 (Your .Net version might be different)`
- Run the application using the command:
```
Text2StaticHtml
```
___

## Code Formatter Setup

This project uses dotnet-format as a code formatter.
- Please refer to the dotnet-format [README.MD](https://github.com/dotnet/format/blob/main/README.md) for installation process.
- To run the formatter on the project after installation change directory to the project's location and run the command ```dotnet-format```.
- For additional command options please refer to the dotnet-format [README.MD](https://github.com/dotnet/format/blob/main/README.md).
___

## Linter Setup

This porject uses Roslynator analyzers as linter.
- Please refer to the Roslynator [README.MD](https://github.com/dotnet/roslynator/blob/main/README.md) for isntallation process.
- To install the Roslynator command line tool run: ```dotnet tool install -g roslynator.dotnet.cli```.
- To add Roslynator analyzers run: ```dotnet add package Roslynator.Analyzers --version 4.6.1```.
- Use the default .editorconfig file for analyzers. To configure analyzers edit the .editorconfig file. Click [here](https://josefpihrt.github.io/docs/.roslynator/configuration/) for the details.
- To run the Roslynator from the command line run: ```roslynator analyze``` from the project directory.
- Use Rosylnator extension available for Visual Studio Code and Visual Studio.
___

## Testing

This project uses NUnit as a testing framework.
- After creating new functionalities or making changes, please write test functions to check they function probably.
- For Visual Studio, Create and add a new test class to the project and run the tests through the test explorer.
- For Visual Studio Code, make sure you have [C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started) installed. Then, like Visual Studio create and add a new test class to the project and run the tests,
___

## Making Changes

1. Make your changes based on the requirements provided for the issue you will be working on.
2. Ensure your code follows the project's coding and documentation standards. Run the formatter and linter to make sure the code is formatted correctly.
3. If applicaple, write tests that check your code.
4. Update the README.md file if a new feature was created, to reflect what it does.
4. Commit your changes: `git commit -m "Brief description of the changes"`
___

## Submit a Pull Request

1. Push your changes to your forked repository on Github: `git push origin your-issue-branch-name`
2. Go to the [Txt2StaticHtml](https://github.com/Amir-Helali/Txt2StaticHtml) repository on Github.
3. Under Pull Requests click "New Pull Request" and choose your branch.
4. Provide a brief description about your changes.
5. Wait for a project maintainer or a community member to review your Pull Request.
___

## Feedback & Merging

If some feedback is provided after your pull request was reviewed, please update your work to reflect the changes provided in the feedback. Afterwards, once your Pull Request is approved it will be merged into the main repository.
___

## Bug Reports

In case of finding a bug, please create an issue under the repository's [issues](https://github.com/Amir-Helali/Txt2StaticHtml/issues) section. Please, provide as much detail as possible to help us understand and reproduce the problem. Additionally, feel free to recommend a fix for the bug you have encountered.
___

## Notes

For larger changes that have a significant impact on the code base, it's always good practice to discuss your plans as an issue first.