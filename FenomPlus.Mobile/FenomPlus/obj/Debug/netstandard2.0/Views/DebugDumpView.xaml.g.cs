//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("FenomPlus.Views.DebugDumpView.xaml", "Views/DebugDumpView.xaml", typeof(global::FenomPlus.Views.DebugDumpView))]

namespace FenomPlus.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\DebugDumpView.xaml")]
    public partial class DebugDumpView : global::FenomPlus.Views.BaseContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.XForms.ComboBox.SfComboBox MessageId;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.XForms.ComboBox.SfComboBox SubId;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox Var;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ListView DebugListView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(DebugDumpView));
            MessageId = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.XForms.ComboBox.SfComboBox>(this, "MessageId");
            SubId = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.XForms.ComboBox.SfComboBox>(this, "SubId");
            Var = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox>(this, "Var");
            DebugListView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ListView>(this, "DebugListView");
        }
    }
}