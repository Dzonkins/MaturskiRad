﻿#pragma checksum "..\..\..\..\Views\Prijava.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CEE566A3907EF4EDF557FD243E6432CF1C5B3FA"
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
using System.Windows.Controls.Ribbon;
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
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace ProgramZaRacunovodstvo {
    
    
    /// <summary>
    /// Prijava
    /// </summary>
    public partial class Prijava : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\..\Views\Prijava.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPasswordPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\Prijava.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\Views\Prijava.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPasswordVisible;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\Views\Prijava.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProgramZaRacunovodstvo;component/views/prijava.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Prijava.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 31 "..\..\..\..\Views\Prijava.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 63 "..\..\..\..\Views\Prijava.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPasswordPlaceholder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 102 "..\..\..\..\Views\Prijava.xaml"
            this.txtPassword.GotFocus += new System.Windows.RoutedEventHandler(this.txtPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 103 "..\..\..\..\Views\Prijava.xaml"
            this.txtPassword.LostFocus += new System.Windows.RoutedEventHandler(this.txtPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPasswordVisible = ((System.Windows.Controls.TextBox)(target));
            
            #line 145 "..\..\..\..\Views\Prijava.xaml"
            this.txtPasswordVisible.GotFocus += new System.Windows.RoutedEventHandler(this.txtPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 146 "..\..\..\..\Views\Prijava.xaml"
            this.txtPasswordVisible.LostFocus += new System.Windows.RoutedEventHandler(this.txtPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtEmail = ((Wpf.Ui.Controls.TextBox)(target));
            
            #line 186 "..\..\..\..\Views\Prijava.xaml"
            this.txtEmail.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 187 "..\..\..\..\Views\Prijava.xaml"
            this.txtEmail.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 233 "..\..\..\..\Views\Prijava.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

