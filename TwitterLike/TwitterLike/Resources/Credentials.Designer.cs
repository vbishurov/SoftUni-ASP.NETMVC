﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterLike.Resources {
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
    internal class Credentials {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Credentials() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TwitterLike.Resources.Credentials", typeof(Credentials).Assembly);
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
        ///   Looks up a localized string similar to vbishurov@gmail.com.
        /// </summary>
        internal static string DefaultSenderEmailAddress {
            get {
                return ResourceManager.GetString("DefaultSenderEmailAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 1503226939996093.
        /// </summary>
        internal static string FacebookAppId {
            get {
                return ResourceManager.GetString("FacebookAppId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 120fa824a709b28349f3782276510cfd.
        /// </summary>
        internal static string FacebookAppSecret {
            get {
                return ResourceManager.GetString("FacebookAppSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to rzrwzregiypnrpnq.
        /// </summary>
        internal static string GmailServicePassword {
            get {
                return ResourceManager.GetString("GmailServicePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to vbishurov@gmail.com.
        /// </summary>
        internal static string GmailServiceUsername {
            get {
                return ResourceManager.GetString("GmailServiceUsername", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 284586852962-gt5kkj69dnuemql1d0k7sfqnb69qpcm6.apps.googleusercontent.com.
        /// </summary>
        internal static string GoogleClientId {
            get {
                return ResourceManager.GetString("GoogleClientId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to wzRp9cN56_Fk3rt2URiuFBIZ.
        /// </summary>
        internal static string GoogleClientSecret {
            get {
                return ResourceManager.GetString("GoogleClientSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to smtp.gmail.com.
        /// </summary>
        internal static string SmtpHost {
            get {
                return ResourceManager.GetString("SmtpHost", resourceCulture);
            }
        }
    }
}