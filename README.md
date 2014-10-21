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

###### GetMember
    /// <summary>
    /// Gets the member specified by key.
    /// </summary>
    /// <param name="instance">The instance to get member from.</param>
    /// <param name="key">The key of the member to get.</param>
    /// <returns>
    /// Returns the value of the member, or null if the member does not exist.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown if the key is null or empty
    /// </exception>
    public static DynValue GetMember(this DynValue instance, String key)
    {
    ...
    }

###### GetProperty
    /// <summary>
    /// Gets the value of the property defined by the specified key.
    /// </summary>
    /// <typeparam name="T">Defines thr expected return type.</typeparam>
    /// <param name="instance">The instance to get property from.</param>
    /// <param name="key">The key of the property to get.</param>
    /// <returns>
    /// Returns the value of the property, or the default value for the 
    /// target type if the property does not exist.
    /// </returns>
    /// <exception cref="TypeParameterException">
    /// Thrown if the target type is not in the acceptable list of CLR types
    /// </exception>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// Thrown if the key is null or empty
    /// </exception>
    /// <exception cref="System.InvalidCastException">
    /// Thrown if the source (property value) and target types do not match
    /// </exception>
    public static T GetProperty<T>(this DynValue instance, String key)
    {
    ...
    }


### MoonSharp Project
Please see links below for Xanathar's Moonsharp (Moon#) assembly

#### Project Page
http://www.moonsharp.org/

#### Git Hib repository
https://github.com/xanathar/moonsharp

