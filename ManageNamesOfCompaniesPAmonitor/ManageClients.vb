Imports System.Text

Public Class ManageClients

    Dim madechanges As Boolean

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If madechanges = True Then
            If MessageBox.Show("Do you want to save your changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim sb As New System.Text.StringBuilder()
                For Each o As Object In ListBox1.Items
                    sb.AppendLine(o)
                Next
                Dim pathWithEnv = "%userprofile%\Desktop\Application for Daily check email\Application Files\Companies_from_PA_monitor.txt"
                Dim filePath = Environment.ExpandEnvironmentVariables(pathWithEnv)
                System.IO.File.WriteAllText(filePath, sb.ToString())
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.Up.Enabled = If(ListBox1.SelectedIndex > 0, True, False)
        Me.Down.Enabled = If(ListBox1.SelectedIndex < ListBox1.Items.Count - 1, True, False)
        If ListBox1.SelectedItem IsNot Nothing Then
            TextBox2.Text = ListBox1.SelectedItem.ToString()
        Else
            TextBox2.Text = ""
        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Delete.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem.ToString)
        madechanges = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim text As New StringBuilder
        text.Append(TextBox1.Text)
        ListBox1.Items.Add(text.ToString())
        madechanges = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pathWithEnv = "%userprofile%\Desktop\Application for Daily check email\Application Files\Companies_from_PA_monitor.txt"
        Dim filePath = Environment.ExpandEnvironmentVariables(pathWithEnv)
        Dim lines() As String = IO.File.ReadAllLines(filePath)
        ListBox1.Items.AddRange(lines)
        TextBox2.ReadOnly = True
        TextBox2.Enabled = False
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        Me.Delete.Enabled = Not String.IsNullOrWhiteSpace(Me.TextBox2.Text)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Me.Add.Enabled = Not String.IsNullOrWhiteSpace(Me.TextBox1.Text)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Up.Click
        madechanges = True
        Dim index = ListBox1.SelectedIndex
        Dim listBoxItemText = ListBox1.SelectedItem.ToString()
        ListBox1.Items.RemoveAt(index)
        ListBox1.Items.Insert(index - 1, listBoxItemText)
        ListBox1.SetSelected(index - 1, True)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Down.Click
        madechanges = True
        Dim index = ListBox1.SelectedIndex
        Dim listBoxItemText = ListBox1.SelectedItem.ToString()
        ListBox1.Items.RemoveAt(index)
        ListBox1.Items.Insert(index + 1, listBoxItemText)
        ListBox1.SetSelected(index + 1, True)

    End Sub
End Class
