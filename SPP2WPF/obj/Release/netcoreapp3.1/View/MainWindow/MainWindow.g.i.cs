﻿#pragma checksum "..\..\..\..\..\View\MainWindow\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E3CE935B067B3A64A8F65B72B6F0A4913298255"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SPP2WPF.Converters;
using SPP2WPF.View.MainWindow;
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


namespace SPP2WPF.View.MainWindow {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SPP2WPF.View.MainWindow.MainWindow wind;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SPP2WPF;V1.0.0.0;component/view/mainwindow/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.wind = ((SPP2WPF.View.MainWindow.MainWindow)(target));
            return;
            case 2:
            
            #line 14 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Open);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Save);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_Save_CanExecute);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Rotate90);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 17 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_RotateR90);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 18 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Rotate180);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 19 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Contrast);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 20 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Lighten);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 21 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Saturate);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 22 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Resize);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 23 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Scale);
            
            #line default
            #line hidden
            return;
            case 12:
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 13:
            this.img = ((System.Windows.Controls.Image)(target));
            
            #line 48 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            this.img.MouseMove += new System.Windows.Input.MouseEventHandler(this.img_MouseMove);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            this.img.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.img_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\..\View\MainWindow\MainWindow.xaml"
            this.img.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.img_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
