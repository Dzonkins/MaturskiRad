﻿#pragma checksum "..\..\..\..\Views\Nabavke.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F430508CA246B8B4CF072F8E877FD288F53A2DE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProgramZaRacunovodstvo.ViewModels;
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
    /// Nabavke
    /// </summary>
    public partial class Nabavke : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 96 "..\..\..\..\Views\Nabavke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DatumTextbox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Views\Nabavke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.CalendarDatePicker DatumPocetni;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\Nabavke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DatumTextbox2;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\Views\Nabavke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.CalendarDatePicker DatumKrajnji;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\Views\Nabavke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid NabavkeDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/ProgramZaRacunovodstvo;component/views/nabavke.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Nabavke.xaml"
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
            
            #line 40 "..\..\..\..\Views\Nabavke.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DatumTextbox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DatumPocetni = ((Wpf.Ui.Controls.CalendarDatePicker)(target));
            return;
            case 4:
            this.DatumTextbox2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DatumKrajnji = ((Wpf.Ui.Controls.CalendarDatePicker)(target));
            return;
            case 6:
            this.NabavkeDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 183 "..\..\..\..\Views\Nabavke.xaml"
            this.NabavkeDataGrid.Loaded += new System.Windows.RoutedEventHandler(this.DataGrid_Ucitano);
            
            #line default
            #line hidden
            
            #line 184 "..\..\..\..\Views\Nabavke.xaml"
            this.NabavkeDataGrid.SizeChanged += new System.Windows.SizeChangedEventHandler(this.DataGrid_promenjeneDimenzije);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

