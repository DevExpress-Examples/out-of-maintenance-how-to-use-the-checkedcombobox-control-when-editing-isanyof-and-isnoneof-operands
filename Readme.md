<!-- default file list -->
*Files to look at*:

* [CustomFilterColumn.cs](./CS/B217847Example/Custom/CustomFilterColumn.cs) (VB: [CustomFilterColumn.vb](./VB/B217847Example/Custom/CustomFilterColumn.vb))
* [FilterAdapter.cs](./CS/B217847Example/Custom/FilterAdapter.cs) (VB: [FilterAdapter.vb](./VB/B217847Example/Custom/FilterAdapter.vb))
* [DataTableHelper.cs](./CS/B217847Example/DataHelpers/DataTableHelper.cs) (VB: [DataTableHelper.vb](./VB/B217847Example/DataHelpers/DataTableHelper.vb))
* [Form1.cs](./CS/B217847Example/Form1.cs) (VB: [Form1.vb](./VB/B217847Example/Form1.vb))
* [Program.cs](./CS/B217847Example/Program.cs) (VB: [Program.vb](./VB/B217847Example/Program.vb))
<!-- default file list end -->
# How to use the CheckedComboBox control when editing IsAnyOf and IsNoneOf operands


<p>In FilterControl, there are two operand presentation modes when editing the "Is Any Of" and "Is None Of" group operands: simple and advanced. The simple mode is enabled when the number of atomic operands in a group operand is equal to or less than FilterControl.MaxOperandCount. Otherwise the advanced mode is activated, where:</p><p>- in display mode, a group operand's text presentation is trimmed. </p><p>- in edit mode, the group operand's values are edited with the help of the CheckedComboBoxEdit control. </p><br />
<p>The advanced operand presentation mode is supported when the FilterControl is bound to the XtraGrid. Otherwise, this feature is not supported.</p><br />
<p>This example shows how to overcome this limitation by creating a custom SourceControl component and an UnbounFilterColumn descendant.</p><p>In the descendant class two members are overridden:</p><p>- The AllowItemCollectionEditor property determines whether or not the feature is allowed for certain columns.</p><p>- The CreateItemCollectionEditor method creates a CheckedComboBoxEdit control.</p>

<br/>


