﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doopec {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Doopec : global::System.Configuration.ApplicationSettingsBase {
        
        private static Doopec defaultInstance = ((Doopec)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Doopec())));
        
        public static Doopec Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Doopec.Rtps.SharedMem.FakeEngine, Doopec")]
        public string RTPSEngineType {
            get {
                return ((string)(this["RTPSEngineType"]));
            }
            set {
                this["RTPSEngineType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mem://sharedmemory")]
        public string ListenerUris {
            get {
                return ((string)(this["ListenerUris"]));
            }
            set {
                this["ListenerUris"] = value;
            }
        }
    }
}
