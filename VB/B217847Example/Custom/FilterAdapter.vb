Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Filtering
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers

Namespace B217847Example
	<ToolboxItem(True)> _
	Public Class FilterAdapter
		Inherits Component
		Implements IFilteredComponent, ISupportInitialize
		<AttributeProvider(GetType(IListSource))> _
		Public Property DataSource() As Object
			Get
				Return fDataSource
			End Get
			Set(ByVal value As Object)
				Dim oldBindingList As IBindingList = TryCast(fDataSource, IBindingList)
				If oldBindingList IsNot Nothing Then
					RemoveHandler oldBindingList.ListChanged, AddressOf OnListChanged
				End If
				fDataSource = value
				Dim newBindingList As IBindingList = TryCast(fDataSource, IBindingList)
				If newBindingList IsNot Nothing Then
					AddHandler newBindingList.ListChanged, AddressOf OnListChanged
				End If
			End Set
		End Property

		Private fRowCriteria As CriteriaOperator
		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Overridable Property RowCriteria() As CriteriaOperator
			Get
				Return fRowCriteria
			End Get
			Set(ByVal value As CriteriaOperator)
				If ReferenceEquals(fRowCriteria, value) Then
					Return
				End If
				fRowCriteria = value
				RaiseRowFilterChanged()
			End Set
		End Property

		Private fDataSource As Object
		Private Shared DefaultEditor As New RepositoryItemTextEdit()
		Private Shared DefaultDateEditor As New RepositoryItemDateEdit()

		Protected Overridable Function GetFilterColumns() As FilterColumnCollection
			Dim PDC As PropertyDescriptorCollection = GetProperties()
			Dim td As List(Of PropertyDescriptor) = FilterPropertyDescriptionCollection(PDC)
			Return GetFilterColumnsCollection(td)

		End Function

		Public Function GetProperties() As PropertyDescriptorCollection
			Dim list As IList = TryCast(DataSource, IList)
			If list Is Nothing Then
				If TypeOf DataSource Is IListSource Then
					list = (CType(DataSource, IListSource)).GetList()
				End If
			End If

			If list Is Nothing Then
				Return New PropertyDescriptorCollection(New PropertyDescriptor(){}, True)
			End If

			Dim typedList As ITypedList = TryCast(list, ITypedList)
			If typedList Is Nothing Then
				If list.Count > 0 Then
					Return TypeDescriptor.GetProperties(list(0))
				End If
			Else
				Return typedList.GetItemProperties(New PropertyDescriptor(){})
			End If
			Return New PropertyDescriptorCollection(New PropertyDescriptor(){}, True)
		End Function

		Private Shared Function FilterPropertyDescriptionCollection(ByVal PDC As PropertyDescriptorCollection) As List(Of PropertyDescriptor)
			Dim td As New List(Of PropertyDescriptor)()
			For Each pd As PropertyDescriptor In PDC
				Dim op As Object = pd.PropertyType
				If (Not pd.PropertyType.IsClass) OrElse (pd.PropertyType Is GetType(String)) Then
					td.Add(pd)
				End If

			Next pd
			Return td
		End Function

		Private Function GetFilterColumnsCollection(ByVal td As List(Of PropertyDescriptor)) As FilterColumnCollection
			Dim filterCollection As New FilterColumnCollection()
			For Each pd As PropertyDescriptor In td

				Dim UFC As New CustomFilterColumn(pd.DisplayName, pd.Name, pd.PropertyType, GetDefaultEditor(pd.PropertyType), GetClauseClass(pd.PropertyType), Me)
				filterCollection.Add(UFC)
			Next pd
			Return filterCollection
		End Function

		Private Shared Function GetClauseClass(ByVal type As Type) As FilterColumnClauseClass
			If type Is GetType(String) Then
				Return FilterColumnClauseClass.String
			End If
			If type Is GetType(DateTime) Then
				Return FilterColumnClauseClass.DateTime
			End If
			Return FilterColumnClauseClass.Generic
		End Function

		Private Shared Function GetDefaultEditor(ByVal type As Type) As RepositoryItem
			If type Is GetType(DateTime) Then
				Return DefaultDateEditor
			End If
			Return DefaultEditor
		End Function

		Private Sub OnListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
			If e.ListChangedType = ListChangedType.PropertyDescriptorAdded OrElse e.ListChangedType = ListChangedType.PropertyDescriptorDeleted OrElse e.ListChangedType = ListChangedType.PropertyDescriptorChanged Then
				RaisePropertiesChanged()
			End If
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				Dim oldBindingList As IBindingList = TryCast(fDataSource, IBindingList)
				If oldBindingList IsNot Nothing Then
					RemoveHandler oldBindingList.ListChanged, AddressOf OnListChanged
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Custom Event RowFilterChanged As EventHandler Implements IFilteredComponent.RowFilterChanged
			AddHandler(ByVal value As EventHandler)
				Events.AddHandler(fRowFilterChanged, value)
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				Events.RemoveHandler(fRowFilterChanged, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		#Region "IFilteredComponent"
		Private Function CreateFilterColumnCollection() As IBoundPropertyCollection Implements IFilteredComponent.CreateFilterColumnCollection
			If Initializing Then
				Return New FilterColumnCollection()
			End If
			Return GetFilterColumns()
		End Function

		Private Shared ReadOnly fPropertiesChanged As Object = New Object()
		Private Custom Event PropertiesChanged As EventHandler Implements IFilteredComponentBase.PropertiesChanged
			AddHandler(ByVal value As EventHandler)
				Events.AddHandler(fPropertiesChanged, value)
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				Events.RemoveHandler(fPropertiesChanged, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		Private Sub RaisePropertiesChanged()
			Dim handler As EventHandler = TryCast(Events(fPropertiesChanged), EventHandler)
			If handler IsNot Nothing Then
				handler(Me, EventArgs.Empty)
			End If
		End Sub

		Private Property IFilteredComponentBase_RowCriteria() As CriteriaOperator Implements IFilteredComponentBase.RowCriteria
			Get
				Return RowCriteria
			End Get
			Set(ByVal value As CriteriaOperator)
				RowCriteria = value
			End Set
		End Property

		Private Shared ReadOnly fRowFilterChanged As Object = New Object()
        Private Custom Event mRowFilterChanged As EventHandler
            AddHandler(ByVal value As EventHandler)
                AddHandler RowFilterChanged, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                RemoveHandler RowFilterChanged, value
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event

		Private Sub RaiseRowFilterChanged()
			Dim handler As EventHandler = TryCast(Events(fRowFilterChanged), EventHandler)
			If handler IsNot Nothing Then
				handler(Me, EventArgs.Empty)
			End If
		End Sub
		#End Region

		#Region "ISupportInitialize"
		Private Initializing As Boolean
		Private Sub BeginInit() Implements ISupportInitialize.BeginInit
			Initializing = True
		End Sub

		Private Sub EndInit() Implements ISupportInitialize.EndInit
			Initializing = False
			RaisePropertiesChanged()
		End Sub
		#End Region
	End Class
End Namespace
