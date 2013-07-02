using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_PreventDeleteCollapsedCode
{
    public partial class PlugIn1 : StandardPlugIn
    {
        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();

            EventNexus.KeyPressed += EventNexus_KeyPressed;
        }

        void EventNexus_KeyPressed(KeyPressedEventArgs ea)
        {
            // Exit if key is not Delete or Ctrl+X (Clipboard Cut).
            if (!ea.IsDelete 
                && !(ea.KeyCode == (int)Keys.X && ea.CtrlKeyDown)
                && !(ea.KeyCode == (int)Keys.Back))
                return;
            
            // Exit if we have no Active Document.
            TextDocument ActiveDoc = CodeRush.Documents.ActiveTextDocument;
            if (ActiveDoc == null)
                return;

            // Exit if Editor does not have focus.
            if (!CodeRush.Editor.HasFocus)
                return;

            // Exit if Selection does not contain collapsed code.
            if (!SelectionContainsCollapsedCode())
                return;

            // All criteria met. Eat Key.
            ea.EatKey();
        }
        private bool SelectionContainsCollapsedCode()
        {
            
            TextDocument ActiveDoc = CodeRush.Documents.ActiveTextDocument;
            SourceRange Selection;
            
            // Get Selection to Selection
            var Success = ActiveDoc.GetSelection(out Selection);
            
            // return false if no Selection.
            if (!Success)
                return false;
            
            // Get Enumerable of Collapsed Code in selection
            var collapsed = ActiveDoc.GetCollapsibleRegions(GetCollapsibleRegionFlags.IntersectsRange | GetCollapsibleRegionFlags.CollapsedRegionsOnly, Selection);
            
            // return true if count > 0 
            return collapsed.Any();

        }
        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            EventNexus.KeyPressed -= EventNexus_KeyPressed;
            base.FinalizePlugIn();
        }
        #endregion
    }
}