﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.1432.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Backups {
    
    private BackupsDatabases[] databasesField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Databases")]
    public BackupsDatabases[] Databases {
        get {
            return this.databasesField;
        }
        set {
            this.databasesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class BackupsDatabases {
    
    private byte idField;
    
    private string dBNameField;
    
    private string serverNameField;
    
    private string backupLocationField;
    
    /// <remarks/>
    public byte ID {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    public string DBName {
        get {
            return this.dBNameField;
        }
        set {
            this.dBNameField = value;
        }
    }
    
    /// <remarks/>
    public string ServerName {
        get {
            return this.serverNameField;
        }
        set {
            this.serverNameField = value;
        }
    }
    
    /// <remarks/>
    public string BackupLocation {
        get {
            return this.backupLocationField;
        }
        set {
            this.backupLocationField = value;
        }
    }
}
