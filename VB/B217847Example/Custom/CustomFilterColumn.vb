Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Filtering
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Data.Filtering.Helpers

Namespace B217847Example
	Friend Class CustomFilterColumn
		Inherits UnboundFilterColumn
		Public Sub New(ByVal columnCaption As String, ByVal fieldName As String, ByVal columnType As Type, ByVal columnEdit As RepositoryItem, ByVal clauseClass As FilterColumnClauseClass, ByVal owner As FilterAdapter)
			MyBase.New(columnCaption, fieldName, columnType, columnEdit, clauseClass)
			Me.Owner = owner
		End Sub

		Protected ReadOnly Owner As FilterAdapter

		Private ReadOnly Property DataSource() As Object
			Get
				Return Owner.DataSource
			End Get
		End Property

		Private Sub GetAllUniqueValues(ByVal List As IList, ByVal op As List(Of Object))
			For Each Lob As Object In List
				For Each pd As PropertyDescriptor In Owner.GetProperties()
					If pd.Name = FieldName Then
						op.Add(pd.GetValue(Lob))
					End If

				Next pd

			Next Lob
		End Sub
		Public Overrides Function CreateItemCollectionEditor() As RepositoryItem
			Dim re As New FilterRepositoryItemCheckedComboBoxEdit()

			If DataSource Is Nothing Then
				Return re
			End If

			Dim List As IList

			If TypeOf DataSource Is IList Then
				List = TryCast(DataSource, IList)
			Else
				Dim Ilist As IListSource = TryCast(DataSource, IListSource)
				List = Ilist.GetList()
			End If

			Dim op As New List(Of Object)()
			GetAllUniqueValues(List, op)

			For Each Value As Object In op
				If Value.ToString() <> "" AndAlso re.Items(Value) Is Nothing Then
					re.Items.Add(Value, Value.ToString())
				End If
			Next Value

			Return re
		End Function


		Public Overrides ReadOnly Property AllowItemCollectionEditor() As Boolean
			Get
				Return True
			End Get
		End Property

	End Class
End Namespace

