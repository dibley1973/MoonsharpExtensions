﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dibware.MoonsharpExtensions.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMesssages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMesssages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dibware.MoonsharpExtensions.Resources.ExceptionMesssages", typeof(ExceptionMesssages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} is not supported.
        /// </summary>
        internal static string DataTypeNotSupported {
            get {
                return ResourceManager.GetString("DataTypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An invalid Type pararameter was encountered.
        /// </summary>
        internal static string InvalidTypeParameterEncountered {
            get {
                return ResourceManager.GetString("InvalidTypeParameterEncountered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The key must not be null.
        /// </summary>
        internal static string KeyNotNull {
            get {
                return ResourceManager.GetString("KeyNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No value was found for the supplied key.
        /// </summary>
        internal static string NoValueWasFoundForTheSuppliedKey {
            get {
                return ResourceManager.GetString("NoValueWasFoundForTheSuppliedKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Type parameter supplied does not match the type of the table value for the supplied key.
        /// </summary>
        internal static string TypeParameterSuppliedMatchError {
            get {
                return ResourceManager.GetString("TypeParameterSuppliedMatchError", resourceCulture);
            }
        }
    }
}