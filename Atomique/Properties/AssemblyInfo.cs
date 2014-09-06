using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Atomique")]
[assembly: AssemblyDescription("Sane atomic operations for .NET based on the C++11 memory model.")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Alex Rønne Petersen")]
[assembly: AssemblyProduct("Atomique")]
[assembly: AssemblyCopyright("Copyright © 2014")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
