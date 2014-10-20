MoonsharpExtensions
===================

This repository is to contain C# extensions and helpers for use with Xanathar's moonsharp (Moon#) assembly. For links to Xanathar's project, please see the the bottom of this document.

This is a work in progress


### Architecture
There will be two projects / assemblies. These will be:
* Dibware.MoonsharpExtensions
* Dibware.MoonsharpExtensions.Shared
* Dibware.MoonsharpExtensionTests

### Extensions
* DynValueExtensions


###Dibware.MoonsharpExtensions.InterpreterExtensions
#### DynValueExtensions
##### Public Members

    /// <summary>
    /// Gets the property defined by the specified key.
    /// </summary>
    /// <typeparam name="T">Defines thr expected return type.</typeparam>
    /// <param name="instance">The instance.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static T GetProperty<T>(this DynValue instance, String key)
    {
    ...
    }


### MoonSharp Project

#### Project Page
http://www.moonsharp.org/

#### Git Hib repository
https://github.com/xanathar/moonsharp

