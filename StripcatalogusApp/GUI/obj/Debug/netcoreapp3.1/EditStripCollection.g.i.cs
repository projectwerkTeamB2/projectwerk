// Updated by XamlIntelliSenseFileGenerator 12/06/20 12:24:01
#pragma checksum "..\..\..\EditStripCollection.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9C39CA13F54CD1AD1226008611DF74D558EE261F"
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


namespace GUI
{


    /// <summary>
    /// EditStripCollection
    /// </summary>
    public partial class EditStripCollection : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    {


#line 22 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ExtraInfo_TextBox;

#line default
#line hidden


#line 40 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_update;

#line default
#line hidden


#line 41 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_update_confirmed;

#line default
#line hidden


#line 43 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_titel;

#line default
#line hidden


#line 47 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_nr;

#line default
#line hidden


#line 59 "..\..\..\EditStripCollection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TextBox_uitgeverij;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;V1.0.0.0;component/editstripcollection.xaml", System.UriKind.Relative);

#line 1 "..\..\..\EditStripCollection.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 8 "..\..\..\EditStripCollection.xaml"
                    ((GUI.EditStripCollection)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.ExtraInfo_TextBox = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.cancel_update = ((System.Windows.Controls.Button)(target));

#line 40 "..\..\..\EditStripCollection.xaml"
                    this.cancel_update.Click += new System.Windows.RoutedEventHandler(this.cancel_update_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.Button_update_confirmed = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\..\EditStripCollection.xaml"
                    this.Button_update_confirmed.Click += new System.Windows.RoutedEventHandler(this.Button_update_confirmed_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.TextBox_titel = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.TextBox_nr = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.TextBox_reeks = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 8:
                    this.TextBox_uitgeverij = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 9:
                    this.TextBox_auteurs = ((System.Windows.Controls.ListBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 10:

#line 73 "..\..\..\EditStripCollection.xaml"
                    ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.OnChecked);

#line default
#line hidden

#line 73 "..\..\..\EditStripCollection.xaml"
                    ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.OnChecked);

#line default
#line hidden
                    break;
            }
        }

        internal System.Windows.Controls.ListBox TextBox_Strips;
    }
}

