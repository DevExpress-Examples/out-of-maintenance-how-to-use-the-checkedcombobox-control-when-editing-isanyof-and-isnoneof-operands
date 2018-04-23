Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors
Namespace B217847Example
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
			Me.dataSet1 = New System.Data.DataSet()
			Me.dtTest = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			Me.dataColumn3 = New System.Data.DataColumn()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colNumber = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.filterAdapter1 = New B217847Example.FilterAdapter()
			Me.filterControl1 = New DevExpress.XtraEditors.FilterControl()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dtTest, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.filterAdapter1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.bindingSource1
			Me.gridControl1.Location = New System.Drawing.Point(27, 13)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(400, 220)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' bindingSource1
			' 
			Me.bindingSource1.DataMember = "Test"
			Me.bindingSource1.DataSource = Me.dataSet1
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dtTest})
			' 
			' dtTest
			' 
			Me.dtTest.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2, Me.dataColumn3})
			Me.dtTest.TableName = "Test"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "Number"
			Me.dataColumn1.DataType = GetType(Integer)
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "Name"
			' 
			' dataColumn3
			' 
			Me.dataColumn3.ColumnName = "Date"
			Me.dataColumn3.DataType = GetType(System.DateTime)
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colNumber, Me.colName, Me.colDate})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' colNumber
			' 
			Me.colNumber.FieldName = "Number"
			Me.colNumber.Name = "colNumber"
			Me.colNumber.Visible = True
			Me.colNumber.VisibleIndex = 0
			' 
			' colName
			' 
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 1
			' 
			' colDate
			' 
			Me.colDate.FieldName = "Date"
			Me.colDate.Name = "colDate"
			Me.colDate.Visible = True
			Me.colDate.VisibleIndex = 2
			' 
			' filterAdapter1
			' 
			Me.filterAdapter1.DataSource = Me.bindingSource1
'			Me.filterAdapter1.RowFilterChanged += New System.EventHandler(Me.OnFilterAdapterRowFilterChanged);
			' 
			' filterControl1
			' 
			Me.filterControl1.Cursor = System.Windows.Forms.Cursors.Arrow
			Me.filterControl1.Location = New System.Drawing.Point(27, 239)
			Me.filterControl1.MaxOperandsCount = 2
			Me.filterControl1.Name = "filterControl1"
			Me.filterControl1.Size = New System.Drawing.Size(400, 168)
			Me.filterControl1.SourceControl = Me.filterAdapter1
			Me.filterControl1.TabIndex = 1
			Me.filterControl1.Text = "filterControl1"
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(352, 413)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton1.TabIndex = 2
			Me.simpleButton1.Text = "&Apply Filter"
'			Me.simpleButton1.Click += New System.EventHandler(Me.OnApplyFilterButtonClick);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(460, 447)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.filterControl1)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dtTest, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.filterAdapter1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private WithEvents filterAdapter1 As FilterAdapter
		Private dataSet1 As System.Data.DataSet
		Private dtTest As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private dataColumn2 As System.Data.DataColumn
		Private dataColumn3 As System.Data.DataColumn
		Private bindingSource1 As System.Windows.Forms.BindingSource
		Private filterControl1 As FilterControl
		Private colNumber As DevExpress.XtraGrid.Columns.GridColumn
		Private colName As DevExpress.XtraGrid.Columns.GridColumn
		Private colDate As DevExpress.XtraGrid.Columns.GridColumn
		Private WithEvents simpleButton1 As SimpleButton
	End Class
End Namespace

