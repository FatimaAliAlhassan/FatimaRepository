Imports System.Data.OleDb
Imports System.ComponentModel

Public Class users
    Dim connn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project\telephone1.accdb")

    Public Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "Search"

        End If
    End Sub

    Public Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "Search" Then
            TextBox1.Text = ""

        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'Telephone1DataSet.telephone_num' table. You can move, or remove it, as needed.
        'Me.Telephone_numTableAdapter.Fill(Me.Telephone1DataSet.telephone_num)

        users_Load()
        TextBox1.Text = "Search"
        'Round Corner
        'roundcorners(Me)
        ''Round Corner
        'roundcorners(Me)
        'roundbutton(btn_add))
        'roundbutton(btn_clear)
        'roundbutton(btn_del)
        'roundbutton(btn_allton(btn_ser)
        'Dim da As New OleDbDataAdapter("Select * from telephone_num  ", connn)
        'Dim dt As New DataTable
        'da.Fill(dt)
        'dt.Clear()
        'dgv1.DataSource = dt
        dgv1.DataSource = usersdt


        connn.Close()

        txt_name.Text = Nothing
        txt_num.Text = Nothing

    End Sub

    Private Sub filldgv()
        Dim da As New OleDbDataAdapter("Select tel_name,tel_num from telephone_num  ", connn)
        'where tel_name='" & txt_name.Text & "' & tel_num='" & txt_name.Text & "'", connn)
        '("Select namebox,numbox from usertel where namebox='" & txt_name.Text & "'", connn)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)

        dgv1.DataSource = dt
    End Sub
    'Public Sub roundcorners(obj As Form)
    '    obj.FormBorderStyle = FormBorderStyle.SizableToolWindow
    '    obj.BackColor = Color.SteelBlue
    '    Dim DGP As New Drawing2D.GraphicsPath
    '    DGP.StartFigure()
    '    'Top LEFT
    '    DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
    '    DGP.AddLine(40, 0, obj.Width - 40, 0)
    '    'DGP.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
    '    'DGP.AddLine(10, 0, obj.Width - 20, 0)

    '    'Top RIGHT
    '    DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
    '    DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)
    '    'DGP.AddArc(New Rectangle(obj.Width - 20, 0, 20, 20), -90, 90)
    '    'DGP.AddLine(obj.Width, 20, obj.Width, obj.Height - 10)
    '    'BUTTOM RIGHT
    '    DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
    '    DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
    '    'DGP.AddArc(New Rectangle(obj.Width - 30, obj.Height - 40, 40, 40), 0, 90)
    '    'DGP.AddLine(obj.Width - 10, obj.Width, 20, obj.Height)
    '    'BUTTOM LEFT
    '    DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
    '    'DGP.AddArc(New Rectangle(0, obj.Height - 20, 20, 20), 90, 90)
    '    DGP.CloseFigure()
    '    obj.Region = New Region(DGP)

    'End Sub


    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        connn.Open()
        Dim cmod As New OleDbCommand("Select tel_num from telephone_num where tel_num=" & txt_num.Text, connn)

        Dim dr As OleDbDataReader = cmod.ExecuteReader



        Dim cmd As New OleDbCommand("insert into telephone_num (tel_name,tel_num) values(@txt_name,@txt_num)", connn)
        cmd.Parameters.Add(New OleDbParameter("@tel_name", OleDbType.VarWChar)).Value = txt_name.Text
        cmd.Parameters.Add(New OleDbParameter("@tel_num", OleDbType.Integer)).Value = txt_num.Text
        If dr.Read() Then
            MsgBox("This Number Is Alrealy Exist")
        Else
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Added")
        End If
        filldgv()
        connn.Close()
        txt_name.Text = Nothing
        txt_num.Text = Nothing


        '    Dim res As Integer
        '    Dim sql As String
        '    'Dim sql1 As String
        '    Dim i As Integer = res
        '    sql = "SELECT * FROM telephone_num WHERE tel_num = '" & txt_num.Text & "'  IS NULL"
        '    Dim comm As New OleDbCommand(sql, connn)




        '    'If a > 0 Then
        '    '    res = comm.CommandText = "INSERT INTO telephone_num([tel_name], [tel_num]) VALUES ('" & txt_name.Text & "','" & txt_num.Text & "' )"
        '    '    res = comm.ExecuteNonQuery()
        '    '    MessageBox.Show("Successfully Added")

        '    'Else
        '    '    MessageBox.Show("Time Out Successfully Added.")

        '    'End If

        '    If i > 0 Then

        '        res = comm.ExecuteNonQuery
        '        MsgBox("New record has been inserted successfully!")
        '    Else
        '        MsgBox("No record has been inserted successfully!")
        '    End If


        '    users_Load()
        '    connn.Close()
        '    txt_name.Text = Nothing
        '    txt_num.Text = Nothing

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        'connn.Open()
        'usersda = New OleDbDataAdapter("select * from telephone_num where tel_name  like '%'", connn)
        'usersda.Fill(usersdt)
        'dgv1.DataSource = usersdt
        'Dim usersdt As New DataTable
        'usersdt.Clear()
        TextBox1.Text = "Search"
        usersda = New OleDbDataAdapter("Select * from telephone_num where tel_name like '%" & TextBox1.Text & "%' ", connn)
        usersda.Fill(usersdt)
        'connn.Close()


    End Sub

    Private Sub dgv1_SelectionChanged(sender As Object, e As EventArgs) Handles dgv1.SelectionChanged, dgv1.Sorted
        'Try
        '    Dim pos As Integer = BindingContext(usersdt).Position
        '    txt_num.Text = usersdt.Rows(pos).Item("txt_num")
        '    txt_name.Text = usersdt.Rows(pos).Item("txt_name")
        'Catch ex As Exception

        'End Try
        Try
            Dim Current_Row As Integer = dgv1.CurrentRow.Index
            txt_name.Text = dgv1(0, Current_Row).Value
            txt_num.Text = dgv1(1, Current_Row).Value
        Catch ex As Exception

            '    MsgBox(ex.Message)
        End Try

        'dgv1.Sort(dgv1.Columns(TelnumDataGridViewTextBoxColumn), ListSortDirection.Ascending)
        'dgv1.Sort(dgv1.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        'dgv1.Sort(dgv1.Columns(0), ListSortDirection.Ascending)
        'dgv1.Sort(dgv1.Columns(1), ListSortDirection.Ascending)
        'dgv1.Sort(dgv1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click

        Try
            If MessageBox.Show("Update", "Do You Want to Update this Record? ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim pos As Integer = BindingContext(usersdt).Position
                usersdt.Rows(pos).Item("tel_name") = txt_name.Text
                usersdt.Rows(pos).Item("tel_num") = txt_num.Text

                Dim save As New OleDbCommandBuilder(usersda)
                usersda.Update(usersdt)
                usersdt.AcceptChanges()
                MsgBox("Successfully Updated", MsgBoxStyle.Information)
            End If

            'users_Load()
        Catch ex As Exception
            filldgv()

        End Try
        connn.Close()
        txt_name.Text = Nothing
        txt_num.Text = Nothing

        'connn.Open()
        'Dim res As Integer
        'Dim sql As String
        'sql = "update telephone_num set tel_name='" & txt_name.Text & "',tel_num='" & txt_num.Text & "')"
        'Dim comm As New OleDbCommand(sql, connn)
        'res = comm.ExecuteNonQuery
        'MsgBox("??? ????? ????? ?????? ???")
        'connn.Close()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        connn.Open()
        'Dim res As Integer
        'Dim sql As String
        'sql = "delete from telephone_num where tel_name=" & txt_name.Text
        'Dim comm As New OleDbCommand(sql, connn)
        'res = comm.ExecuteNonQuery
        'MsgBox("??? ????? ??? ???", MsgBoxStyle.Information)
        'connn.Close()
        'Dim res As Integer
        'Dim sql As String
        If MessageBox.Show("Delete", "Do You Want to Delete this Record?  ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Dim res As Integer
            Dim sql As String

            sql = "Delete * from telephone_num where tel_num=" & txt_num.Text
            Dim comm As New OleDbCommand(sql, connn)
            res = comm.ExecuteNonQuery
            MsgBox("Successfully Deleted", MsgBoxStyle.Information)
            Dim save As New OleDbCommandBuilder(usersda)
            usersda.Update(usersdt)
            usersdt.AcceptChanges()
            filldgv()
            'users_Load()
        End If
        connn.Close()
        txt_name.Text = Nothing
        txt_num.Text = Nothing

        'users_Load()

        'txt_name.Text = Nothing
        'txt_num.Text = Nothing

        'connn.Close()

        'Sql = "Delete * from telephone_num where tel_name=" & txt_name.Text
        'Dim comm As New OleDbCommand(Sql, connn)
        'res = comm.ExecuteNonQuery
        'Dim cmd As New OleDbCommand("Delete * from telephone_num where tel_num=" & txt_num.Text, connn)
        'cmd.ExecuteNonQuery()
        'MsgBox("تمت التعديل بنجاح ")
        'Dim save As New OleDbCommandBuilder(usersda)
        'usersda.Update(usersdt)
        'usersdt.AcceptChanges()
        'End If
        'connn.Close()
        'txt_name.Text = Nothing
        'txt_num.Text = Nothing

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txt_num.Text = (txt_num.Text + "1")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txt_num.Text = (txt_num.Text + "2")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txt_num.Text = (txt_num.Text + "3")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txt_num.Text = (txt_num.Text + "4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txt_num.Text = (txt_num.Text + "5")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txt_num.Text = (txt_num.Text + "6")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        txt_num.Text = (txt_num.Text + "7")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        txt_num.Text = (txt_num.Text + "8")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        txt_num.Text = (txt_num.Text + "9")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        txt_num.Text = (txt_num.Text + "0")
    End Sub
   
End Class
