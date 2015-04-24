using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

[assembly: AssemblyTitle("Alsolos.Commons.Wpf")]
[assembly: AssemblyProduct("Alsolos Commons WPF")]
[assembly: AssemblyDescription("Common types for WPF / MVVM applications.")]
[assembly: AssemblyCopyright("Copyright © Heiner Suter 2015")]
[assembly: AssemblyVersion("1.1.*")]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguageAttribute("en")]
[assembly: ComVisible(false)]

[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Behaviors.MultiselectBehavior")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.Enabled")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.FindInSelector")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.NoAutoSize")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.Progress")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Controls.SimpleStretchPanel")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Mvvm.Converters")]
[assembly: XmlnsDefinition("http://alsolos.ch/Commons/Wpf", "Alsolos.Commons.Wpf.Resources")]

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
