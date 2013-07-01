using System.ComponentModel.Composition;
using DevExpress.CodeRush.Common;

namespace CR_PreventDeleteCollapsedCode
{
    [Export(typeof(IVsixPluginExtension))]
    public class CR_PreventDeleteCollapsedCodeExtension : IVsixPluginExtension { }
}