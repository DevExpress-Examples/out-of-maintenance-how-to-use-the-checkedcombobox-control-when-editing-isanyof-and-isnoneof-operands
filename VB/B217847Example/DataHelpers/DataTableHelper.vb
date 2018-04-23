Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data

Namespace B217847Example
	Public Class DataTableHelper
		Public Shared Sub GetDataTable(ByVal table As DataTable)
			Dim Row1 As DataRow = table.NewRow()
			Row1("Number") = 23
			Row1("Name") = "Mike"
			Row1("Date") = New DateTime(2012, 9, 18)
			table.Rows.Add(Row1)

			Dim Row2 As DataRow = table.NewRow()
			Row2("Number") = 12
			Row2("Name") = "Jon"
			Row2("Date") = New DateTime(2012, 9, 19)
			table.Rows.Add(Row2)

			Dim Row3 As DataRow = table.NewRow()
			Row3("Number") = 1
			Row3("Name") = "Bill"
			Row3("Date") = New DateTime(2012, 9, 20)
			table.Rows.Add(Row3)

			Dim Row4 As DataRow = table.NewRow()
			Row4("Number") = 121
			Row4("Name") = "Bruce"
			Row4("Date") = New DateTime(2012, 9, 21)
			table.Rows.Add(Row4)

			Dim Row5 As DataRow = table.NewRow()
			Row5("Number") = 132
			Row5("Name") = "Lex"
			Row5("Date") = New DateTime(2012, 9, 22)
			table.Rows.Add(Row5)
		End Sub
	End Class
End Namespace
