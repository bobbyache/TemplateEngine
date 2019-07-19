using System.Reflection;

[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("CygSoft")]
[assembly: AssemblyProduct("Qik")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("5.0.0.0")]

/*
 * https://developercommunity.visualstudio.com/content/problem/311322/the-specified-version-string-contains-wildcards-so.html
 * 
 Thank you for your feedback! We have determined that this issue is not a bug. 
 The "determinism" flag is set by default in .NET Core projects. Determinism means 
 that identical inputs will produce bit-for-bit identical outputs, to allow for 
 reproducible builds. The '*' syntax provides variable input, so it is incompatible 
 with determinism. You can either remove '*' from your version string, or disable 
 determinism in your project file by setting the MSBuild property 
    `<Deterministic>false</Deterministic>`.
 * */
