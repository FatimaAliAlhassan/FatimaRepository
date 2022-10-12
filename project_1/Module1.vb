Imports System.Data.OleDb
Module Module1
    Public connn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project\telephone1.accdb")
    Public usersdt As New DataTable
    Public usersda As New OleDbDataAdapter
    Public Sub users_Load()
        usersda = New OleDbDataAdapter("Select * from telephone_num  ", connn)
        usersda.Fill(usersdt)
        connn.Close()

    End Sub
  
End Module
