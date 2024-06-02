# Test Solution
Test project targeting popular test framework including NUnit, XUnit and MSTest. Test design covers Unit Test in TDD & Integration test in BDD style.

## Software required
.NET is free, open-source, cross platform software development framework created by Microsoft. It provides a framework for building and running applications on different operating system including Windows, Linux and Mac. 

Required:
* IDE (Visual Studio 2022/Visual Studio Code)
* [.NET SDK](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)
* Visual Studio 2022 (Specflow/Reqnroll, SonarLint)

Optional Package:
* [Allure](#allure) (for local report generation)
* [Specflow + LivingDoc](#specflow--livingdoc) (Dotnet tool for documentation using `TestExecution.json`)

## Test Execution
Any preferred CLI (Shell/Bash/Command Prompt/Powershell) can be used to execute test.

To build all project in `bdd-test-soln-cs.sln`
```ps
dotnet restore
dotnet build -c Release --no-restore
```
**Note**: Add `--no-build` & `--no-restore` flag in `dotnet test` script to skip above stage.

### Console App
Project: **Console.Calculator.Nunit.UnitTests** (NUnit)
```sh
dotnet test --results-directory Console.Calculator.Nunit.UnitTests/TestResults --logger "console;verbosity=detailed" Console.Calculator.Nunit.UnitTests
```

### Windows App

Project: **Windows.Native.MSTest.Specflow.Tests** (Specflow BDD using MSTest)
```sh
dotnet test --results-directory Windows.Native.MSTest.Specflow.Tests/TestResults --logger "console;verbosity=detailed" Windows.Native.MSTest.Specflow.Tests
```
Reference: https://docs.specflow.org/projects/specflow/en/latest/Execution/Executing-Specific-Scenarios.html

## Test Report
Execution report for test project will be available under corresponding `<testProjectDirectory>/TestResults` directory.

### Allure
Allure command-line tool require Java 8 or above. https://allurereport.org/docs/install/

```
allure generate Console.Calculator.Nunit.UnitTests/bin/Release/net8.0/allure-results -o Console.Calculator.Nunit.UnitTests/TestResults/allure-report
allure open Console.Calculator.Nunit.UnitTests/TestResults/allure-report
```
Reference: https://allurereport.org/docs/nunit/

### Pickles
It enables team to share features locked up in code with stakeholders and starting living documentation for reference. Various format supported include HTML(Static & Dynamic), Excel, Word, JSON & Cucumber JSON. Pre-built runners are available here: https://github.com/picklesdoc/pickles/releases

**Note**: Not maintained for 2+ years, are looking for new maintainers https://github.com/picklesdoc/pickles. 
```cli
<!-- Require .NET 6 -->
dotnet tool install --global Pickles.CommandLine --version 4.0.3
```
```cli
pickles --feature-directory=Web.App.xUnit.Gherkin.Tests/Features/ --output-directory=Web.App.xUnit.Gherkin.Tests/TestResults/documentation -Language en --link-results-file=Web.App.xUnit.Gherkin.Tests/TestResults/TestResult.xml
```
Format selection: http://docs.picklesdoc.com/en/latest/ArgumentsDocumentationFormat/

### Specflow + LivingDoc
It is a set of tools that allows you to share and collaborate on Gherkin Feature Files with stakeholders who may not be familiar with developer tools.

```ps
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```
```ps
cd Windows.Native.MSTest.Specflow.Tests/bin/Release/net8.0
livingdoc test-assembly Windows.Native.MSTest.Specflow.Tests.dll -t TestExecution.json --output ../../../TestResults --title "Specflow BDD Test"
```
Reference: 
* https://docs.specflow.org/projects/specflow-livingdoc/en/latest/
* https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Using-the-command-line-tool.html
