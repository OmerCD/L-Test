﻿#pragma checksum "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0BEF88D7E24C0E10BF5CC451B64A9FA346BFC4E7"
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
using ltest.UserControllers.UcTestler;


namespace ltest.UserControllers.UcTestler {
    
    
    /// <summary>
    /// UcDuzenle
    /// </summary>
    public partial class UcDuzenle : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// Olustur Name Field
        /// </summary>
        
        #line 16 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DockPanel Olustur;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TestCombobox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SureTextbox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SoruTextbox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CevapTextbox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SoruStack;
        
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
            System.Uri resourceLocater = new System.Uri("/L-Test;component/usercontrollers/uctestler/ucduzenle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
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
            
            #line 8 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
            ((ltest.UserControllers.UcTestler.UcDuzenle)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Duzelt_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Olustur = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.TestCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
            this.TestCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TestCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SureTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
            this.SureTextbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SayiKontrol);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SoruTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
            this.SoruTextbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SayiKontrol);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CevapTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\..\UserControllers\UcTestler\UcDuzenle.xaml"
            this.CevapTextbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SayiKontrol);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SoruStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
