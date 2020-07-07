using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("EDSDKLib")]
[assembly: AssemblyDescription("Canon SDK wrapper library")]
[assembly: AssemblyProduct("EDSDKLib")]
[assembly: AssemblyCopyright("Copyright © Johannes Bildstein 2016")]

[assembly: ComVisible(false)]
[assembly: Guid("15e99248-6161-46a4-9183-609ca62406a6")]

// [assembly: AssemblyVersion("1.1.1.0")]
// [assembly: AssemblyFileVersion("1.1.1.0")]
[assembly: AssemblyVersion(ThisAssembly.Git.SemVer.Major + "." + ThisAssembly.Git.SemVer.Minor + "." + ThisAssembly.Git.SemVer.Patch)]
[assembly: AssemblyFileVersion(ThisAssembly.Git.SemVer.Major + "." + ThisAssembly.Git.SemVer.Minor + "." + ThisAssembly.Git.SemVer.Patch)]
[assembly: AssemblyInformationalVersion(
    ThisAssembly.Git.SemVer.Major + "." +
    ThisAssembly.Git.SemVer.Minor + "." +
    ThisAssembly.Git.SemVer.Patch + "-" +
    ThisAssembly.Git.Branch + "+" +
    ThisAssembly.Git.Commit)]
