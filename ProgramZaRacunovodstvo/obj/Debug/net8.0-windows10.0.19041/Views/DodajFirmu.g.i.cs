﻿#pragma checksum "..\..\..\..\Views\DodajFirmu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "035ABDB63F5DB539168FD55946EA5E128727880B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProgramZaRacunovodstvo.Views;
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


namespace ProgramZaRacunovodstvo.Views {
    
    
    /// <summary>
    /// DodajFirmu
    /// </summary>
    public partial class DodajFirmu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImeFirme;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMaticni;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPIB;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresa;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGrad;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojZiroRacuna;
        
        #line default
        #line hidden
        
        
        #line 272 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtZastupnik;
        
        #line default
        #line hidden
        
        
        #line 427 "..\..\..\..\Views\DodajFirmu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock greska;
        
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
            System.Uri resourceLocater = new System.Uri("/ProgramZaRacunovodstvo;V1.0.0.0;component/views/dodajfirmu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\DodajFirmu.xaml"
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
            this.txtImeFirme = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtImeFirme.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtImeFirme.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtMaticni = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtMaticni.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BrojCheck);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtMaticni.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 78 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtMaticni.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPIB = ((System.Windows.Controls.TextBox)(target));
            
            #line 119 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtPIB.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BrojCheck);
            
            #line default
            #line hidden
            
            #line 120 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtPIB.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 121 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtPIB.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtAdresa = ((System.Windows.Controls.TextBox)(target));
            
            #line 161 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtAdresa.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 162 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtAdresa.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtGrad = ((System.Windows.Controls.TextBox)(target));
            
            #line 202 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtGrad.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 203 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtGrad.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtBrojZiroRacuna = ((System.Windows.Controls.TextBox)(target));
            
            #line 243 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtBrojZiroRacuna.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 244 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtBrojZiroRacuna.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 245 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtBrojZiroRacuna.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BrojCheck);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtZastupnik = ((System.Windows.Controls.TextBox)(target));
            
            #line 285 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtZastupnik.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 286 "..\..\..\..\Views\DodajFirmu.xaml"
            this.txtZastupnik.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 322 "..\..\..\..\Views\DodajFirmu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Nazad);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 378 "..\..\..\..\Views\DodajFirmu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.dodajFirmu);
            
            #line default
            #line hidden
            return;
            case 10:
            this.greska = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

