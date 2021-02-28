
## Run the Console
Run the console application
```
dotnet run --project QikConsole/QikConsole.csproj
```
Run the tests
```
dotnet test ./qiktests/qiktests.csproj
```
Adding `InternalsVisibleTo` for tests.
```
<InternalsVisibleTo Include="CustomTest1" /> <!-- [assembly: InternalsVisibleTo("CustomTest1")] -->
```

## Creation
Project was created using these commands

```
dotnet new sln -n Qik
dotnet new classlib -o Qik
dotnet sln add Qik/Qik.csproj
dotnet build
dotnet new console QikConsole
dotnet new console -o QikConsole
dotnet sln add QikConsole/QikConsole.csproj
dotnet add QikConsole/QikConsole.csproj reference Qik/Qik.csproj
```
## Install NUnit Template and Create an NUnit Test Project
Install the template
```
dotnet new -i NUnit3.DotNetNew.Template
```
Create the unit tests
```
dotnet new nunit -n QikTests
dotnet add qiktests/qiktests.csproj reference Qik/Qik.csproj
```
Run the tests
```
dotnet test ./qiktests/qiktests.csproj
```

## ANTLR4 grammar syntax support VS Code Plugin

- [MarketPlace](https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4&ssr=false#qna)
- [Github](https://github.com/mike-lischke/vscode-antlr4)

### Usage

 Item | Value |
| --- | :--- |
| mode | external  |
| language | CSharp  |
| listeners | true  |
| visitors | true  |
| outputDir | _antlr  |
| package | CygSoft.Qik.LanguageEngine.Antlr  |


### Possible Test Explorers/Runners

- https://marketplace.visualstudio.com/items?itemName=hbenl.vscode-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=wghats.vscode-nxunit-test-adapter&ssr=false#overview

### Console Command Line

- [System.CommandLine (Nuget)](https://www.nuget.org/packages/System.CommandLine)
- [System.CommandLine (Github)](https://github.com/dotnet/command-line-api/blob/master/docs/Your-first-app-with-System-CommandLine.md)
- [Dependency Injection and Settings](https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/)
