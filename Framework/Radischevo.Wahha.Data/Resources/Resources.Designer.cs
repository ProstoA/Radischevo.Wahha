﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Radischevo.Wahha.Data.Resources {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Radischevo.Wahha.Data.Resources.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Ambiguous column name &apos;{0}&apos; found in the data record..
        /// </summary>
        internal static string Error_AmbiguousColumnName {
            get {
                return ResourceManager.GetString("Error_AmbiguousColumnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The currently configured cache provider &apos;{0}&apos; does not support item tagging..
        /// </summary>
        internal static string Error_CacheProviderDoesNotSupportTags {
            get {
                return ResourceManager.GetString("Error_CacheProviderDoesNotSupportTags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DbDataProvider collection cannot have more than one default provider. The DbDataProvider &apos;{0}&apos; was already marked as a default..
        /// </summary>
        internal static string Error_CannotAddMoreThanOneDefaultProvider {
            get {
                return ResourceManager.GetString("Error_CannotAddMoreThanOneDefaultProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot enumerate the result set more than once..
        /// </summary>
        internal static string Error_CannotEnumerateMoreThanOnce {
            get {
                return ResourceManager.GetString("Error_CannotEnumerateMoreThanOnce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Case statement should contain at least one When statement..
        /// </summary>
        internal static string Error_CaseShouldContainWhenStatements {
            get {
                return ResourceManager.GetString("Error_CaseShouldContainWhenStatements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a field with the specified name &apos;{0}&apos; in the result set..
        /// </summary>
        internal static string Error_ColumnNameDoesNotExistInResultSet {
            get {
                return ResourceManager.GetString("Error_ColumnNameDoesNotExistInResultSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a field with the specified ordinal &apos;{0}&apos; in the result set..
        /// </summary>
        internal static string Error_ColumnOrdinalDoesNotExistInResultSet {
            get {
                return ResourceManager.GetString("Error_ColumnOrdinalDoesNotExistInResultSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; property should be initialized with the System.Data.IDbCommand instance..
        /// </summary>
        internal static string Error_CommandIsNotInitialized {
            get {
                return ResourceManager.GetString("Error_CommandIsNotInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command text cannot be null or an empty string..
        /// </summary>
        internal static string Error_CommandTextIsNull {
            get {
                return ResourceManager.GetString("Error_CommandTextIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Couldn&apos;t find any connection strings in the configuration file..
        /// </summary>
        internal static string Error_ConnectionStringNotConfigured {
            get {
                return ResourceManager.GetString("Error_ConnectionStringNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connection string cannot be null or an empty string..
        /// </summary>
        internal static string Error_ConnectionStringNotInitialized {
            get {
                return ResourceManager.GetString("Error_ConnectionStringNotInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided link can not be materialized since it can not be explicitly converted to the &apos;Link&lt;TAssociation&gt;&apos; type..
        /// </summary>
        internal static string Error_CouldNotMaterializeCollectionLink {
            get {
                return ResourceManager.GetString("Error_CouldNotMaterializeCollectionLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Index (zero based) must be greater than or equal to zero and less than the size of the argument list..
        /// </summary>
        internal static string Error_FormatParameterMismatch {
            get {
                return ResourceManager.GetString("Error_FormatParameterMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; must implement the ICacheProvider or ITaggedCacheProvider interface and have a public parameterless constructor..
        /// </summary>
        internal static string Error_IncompatibleCacheProviderType {
            get {
                return ResourceManager.GetString("Error_IncompatibleCacheProviderType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; must implement the IDbMaterializer interface..
        /// </summary>
        internal static string Error_IncompatibleMaterializerType {
            get {
                return ResourceManager.GetString("Error_IncompatibleMaterializerType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; must implement the IDbDataProviderFactory interface and have a public parameterless constructor..
        /// </summary>
        internal static string Error_IncompatibleProviderFactoryType {
            get {
                return ResourceManager.GetString("Error_IncompatibleProviderFactoryType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; must implement the IDbDataProvider interface and have a public parameterless constructor..
        /// </summary>
        internal static string Error_IncompatibleProviderType {
            get {
                return ResourceManager.GetString("Error_IncompatibleProviderType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expression parameter &apos;{0}&apos; must target the lambda argument..
        /// </summary>
        internal static string Error_MethodCallMustTargetLambdaArgument {
            get {
                return ResourceManager.GetString("Error_MethodCallMustTargetLambdaArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot access the &apos;{0}&apos;. The object is disposed..
        /// </summary>
        internal static string Error_ObjectDisposed {
            get {
                return ResourceManager.GetString("Error_ObjectDisposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of the &apos;{0}&apos; parameter should be greater than {1}..
        /// </summary>
        internal static string Error_ParameterMustBeGreaterThan {
            get {
                return ResourceManager.GetString("Error_ParameterMustBeGreaterThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of the &apos;{0}&apos; parameter should be greater than or equal to {1}..
        /// </summary>
        internal static string Error_ParameterMustBeGreaterThanOrEqual {
            get {
                return ResourceManager.GetString("Error_ParameterMustBeGreaterThanOrEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The default data provider is not set. Please check the configuration file..
        /// </summary>
        internal static string Error_ProviderNotConfigured {
            get {
                return ResourceManager.GetString("Error_ProviderNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a DbDataProvider type mapped to specified name &apos;{0}&apos;..
        /// </summary>
        internal static string Error_ProviderTypeMappingNotConfigured {
            get {
                return ResourceManager.GetString("Error_ProviderTypeMappingNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot read the result set from the closed data reader..
        /// </summary>
        internal static string Error_ReaderIsEmpty {
            get {
                return ResourceManager.GetString("Error_ReaderIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Selector expression &apos;{0}&apos; must be a method call..
        /// </summary>
        internal static string Error_SelectorMustBeAMethodCall {
            get {
                return ResourceManager.GetString("Error_SelectorMustBeAMethodCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data provider could not connect to the specified data source..
        /// </summary>
        internal static string Error_UnableToConnect {
            get {
                return ResourceManager.GetString("Error_UnableToConnect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not parse the configuration file. See the inner exception for details..
        /// </summary>
        internal static string Error_UnableToLoadConfiguration {
            get {
                return ResourceManager.GetString("Error_UnableToLoadConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The database command type &apos;{0}&apos; is not supported by the provider..
        /// </summary>
        internal static string Error_UnsupportedCommandType {
            get {
                return ResourceManager.GetString("Error_UnsupportedCommandType", resourceCulture);
            }
        }
    }
}
