
## Run the Console
Run the console application
```
dotnet run --project QikConsole/QikConsole.csproj
```
Run the tests
```
dotnet test ./qiktests/qiktests.csproj
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
```
Run the tests
```
dotnet test ./qiktests/qiktests.csproj
```