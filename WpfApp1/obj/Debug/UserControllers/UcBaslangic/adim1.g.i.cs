﻿#pragma checksum "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4E104650BFF6A731F4DA3353A333AC89D058AD47"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using ltest.UserControllers.UcBaslangic;


namespace ltest.UserControllers.UcBaslangic {
    
    
    /// <summary>
    /// adim1
    /// </summary>
    public partial class adim1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OdaButon;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OdaButonLbl;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Kullanicilar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/L-Test;component/usercontrollers/ucbaslangic/adim1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.OdaButon = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
            this.OdaButon.Click += new System.Windows.RoutedEventHandler(this.OdayiOlustur);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OdaButonLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Kullanicilar = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\UserControllers\UcBaslangic\adim1.xaml"
            this.Kullanicilar.Click += new System.Windows.RoutedEventHandler(this.KullaniciGoster);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
