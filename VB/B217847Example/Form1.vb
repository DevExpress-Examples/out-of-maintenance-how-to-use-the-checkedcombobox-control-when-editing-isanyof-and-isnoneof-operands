Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows.Forms
Imports System.Collections.Generic

Namespace B217847Example
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			DataTableHelper.GetDataTable(dtTest)
		End Sub

		Private Sub OnFilterAdapterRowFilterChanged(ByVal sender As Object, ByVal e As EventArgs) Handles filterAdapter1.RowFilterChanged
			gridView1.ActiveFilterCriteria = filterAdapter1.RowCriteria
		End Sub

		Private Sub OnApplyFilterButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			filterControl1.ApplyFilter()
		End Sub
	End Class
End Namespace
