﻿#pragma checksum "..\..\DataForMeasurementWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "911526AFAC5FA319E86675AE76B59DCC0F7A9670DB7F10ADDADB9EDF07205444"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gravity;
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


namespace Gravity {
    
    
    /// <summary>
    /// DataForMeasurementWindow
    /// </summary>
    public partial class DataForMeasurementWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _strOperatorName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _strProductName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _productMassNominal;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _productXNominal;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _productYNominal;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DataForMeasurementWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _productZNominal;
        
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
            System.Uri resourceLocater = new System.Uri("/Gravity;component/dataformeasurementwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DataForMeasurementWindow.xaml"
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
            this._strOperatorName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this._strProductName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this._productMassNominal = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\DataForMeasurementWindow.xaml"
            this._productMassNominal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this._productXNominal = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\DataForMeasurementWindow.xaml"
            this._productXNominal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this._productYNominal = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\DataForMeasurementWindow.xaml"
            this._productYNominal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this._productZNominal = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\DataForMeasurementWindow.xaml"
            this._productZNominal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 32 "..\..\DataForMeasurementWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClose);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 33 "..\..\DataForMeasurementWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnOK);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

