CR_PreventDeleteCollapsedCode
=============================

This CodeRush plugin was created in response to a customer request.

Collapsed code is easily missed in the Editor.
This plugin is designed to prevent the accidental deletion of collapsed code.

This plugin eats (throws away) the keys that would otherwise cause code deletion (Del or Ctrl+X), but only if the editor has focus and the selection contains collapsed code.

This is a proof of concept and is not expected to prevent other means of code removal such as file deletion.






