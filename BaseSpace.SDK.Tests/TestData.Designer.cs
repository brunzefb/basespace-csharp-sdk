﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Illumina.BaseSpace.SDK.Tests {
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
    internal class TestData {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Illumina.BaseSpace.SDK.Tests.TestData", typeof(TestData).Assembly);
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
        ///   Looks up a localized string similar to {
        ///    &quot;Rel&quot;: &quot;UsedBy&quot;,
        ///    &quot;Type&quot;: &quot;AppResult&quot;,
        ///    &quot;Href&quot;: &quot;v1pre3/appresults/291294&quot;,
        ///    &quot;HrefContent&quot;: &quot;v1pre3/appresults/291294&quot;,
        ///    &quot;Content&quot;: {
        ///        &quot;Id&quot;: &quot;291294&quot;,
        ///        &quot;Href&quot;: &quot;v1pre3/appresults/291294&quot;,
        ///        &quot;UserOwnedBy&quot;: {
        ///            &quot;Id&quot;: &quot;1001&quot;,
        ///            &quot;Href&quot;: &quot;v1pre3/users/1001&quot;,
        ///            &quot;Id&quot;: &quot;Illumina Inc&quot;
        ///        },
        ///        &quot;Id&quot;: &quot;BWA GATK - HiSeq 2500 NA12878 demo 2x150&quot;,
        ///        &quot;Status&quot;: &quot;Complete&quot;,
        ///        &quot;StatusSummary&quot;: &quot;&quot;,
        ///        &quot;DateCreate [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AppResultReference {
            get {
                return ResourceManager.GetString("AppResultReference", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to {
        ///                &quot;Rel&quot;: &quot;Using&quot;,
        ///                &quot;Type&quot;: &quot;Sample&quot;,
        ///                &quot;Href&quot;: &quot;v1pre3/samples/262264&quot;,
        ///                &quot;HrefContent&quot;: &quot;v1pre3/samples/262264&quot;,
        ///                &quot;Content&quot;: {
        ///                    &quot;Id&quot;: &quot;262264&quot;,
        ///                    &quot;Href&quot;: &quot;v1pre3/samples/262264&quot;,
        ///                    &quot;UserOwnedBy&quot;: {
        ///                        &quot;Id&quot;: &quot;1001&quot;,
        ///                        &quot;Href&quot;: &quot;v1pre3/users/1001&quot;,
        ///                        &quot;Id&quot;: &quot;Illumina Inc&quot;
        ///                    },
        ///           [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SampleReference {
            get {
                return ResourceManager.GetString("SampleReference", resourceCulture);
            }
        }
    }
}
