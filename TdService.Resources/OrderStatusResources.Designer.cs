﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TdService.Resources {
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
    public class OrderStatusResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OrderStatusResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TdService.Resources.OrderStatusResources", typeof(OrderStatusResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disposed.
        /// </summary>
        public static string Disposed {
            get {
                return ResourceManager.GetString("Disposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New.
        /// </summary>
        public static string New {
            get {
                return ResourceManager.GetString("New", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Received.
        /// </summary>
        public static string Received {
            get {
                return ResourceManager.GetString("Received", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Returned.
        /// </summary>
        public static string Returned {
            get {
                return ResourceManager.GetString("Returned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Return Requested.
        /// </summary>
        public static string ReturnRequested {
            get {
                return ResourceManager.GetString("ReturnRequested", resourceCulture);
            }
        }
    }
}