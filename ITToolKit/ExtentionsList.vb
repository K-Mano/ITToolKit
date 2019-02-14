Imports System.IO
Imports System.Reflection

'*****************************************************************************************************
'
'   ITToolKit(TM) ExtentionsList
'
'   Provides extensions for ITToolKit.
'
'   Copyright (c) 2018-2019 ACT Information Dev.org All Rights Reserved.
'   Licensed under the MIT License.
'
'*****************************************************************************************************

Public Class ExtentionsList
    Dim classname As String
    Dim instance_base As Object
    Private Sub ExtentionsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExtentions()
    End Sub
    Private Sub LoadExtentions()
        Try
            If Directory.Exists(".\extentions") Then
                Dim asm() As Assembly = Nothing
                Dim fs As String() = Directory.GetFiles(".\extentions", "*.dll")
                Dim f As String
                Dim l As Integer = 0
                For Each f In fs
                    Dim itemx As New ListViewItem With {.Text = Path.GetFileName(f)}
                    itemx.SubItems.Add(Path.GetFullPath(f))
                    ListView1.Items.Add(itemx)
                Next
            Else
                Directory.CreateDirectory(".\extentions")
            End If
        Catch ex As Exception
            MessageBox.Show("拡張機能の情報の取得に失敗しました。(" & ex.Message & ")", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 Then
            CommandLink1.Enabled = False
            Label5.Text = ""
            Label6.Text = ""
            Label7.Text = ""
            Label8.Text = ""
        Else
            CommandLink1.Enabled = True
            Try
                Dim itemx As ListViewItem = ListView1.SelectedItems(0)
                Dim asm As Assembly = Assembly.LoadFrom(".\extentions\" & itemx.Text)
                Dim classname As String = itemx.Text.Replace(".dll", String.Empty)
                instance_base = Activator.CreateInstance(asm.GetType(classname & "." & classname))
                Label5.Text = instance_base.ext_name
                Label6.Text = instance_base.ext_auth
                Label7.Text = instance_base.ext_desc
                Label8.Text = "Installed"
            Catch ex As Exception
                MessageBox.Show("拡張機能の情報の取得に失敗しました。(" & ex.Message & ")", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Label5.Text = "None"
                Label6.Text = "None"
                Label7.Text = "None"
                Label8.Text = "Can't Load"
            End Try
        End If
    End Sub

    Private Sub CommandLink1_Click(sender As Object, e As EventArgs) Handles CommandLink1.Click
        Try
            Dim itemx As ListViewItem = ListView1.SelectedItems(0)
            Dim asm As Assembly = Assembly.LoadFrom(".\extentions\" & itemx.Text)
            Dim instance As Object = Activator.CreateInstance(asm.GetType(itemx.Text.Replace(".dll", String.Empty) & ".MainForm"))
            Dim extform As Form = CType(instance, Form)
            If instance_base.ext_auth <> "K-Mano@ACT-Information-Development.org" Then
                Dim ans As DialogResult = MessageBox.Show("重要:これはサードパーティ製の拡張機能です。このプログラムの拡張機能では管理者権限でコードを実行することができるため、危険である可能性があります。起動しますか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If ans = DialogResult.OK Then
                    extform.Show()
                ElseIf ans = DialogResult.Cancel Then
                    Close()
                End If
            ElseIf instance_base.ext_auth = "K-Mano@ACT-Information-Development.org" Then
                extform.Show()
            End If

        Catch ex As Exception
            MessageBox.Show("拡張機能のロードに失敗しました。(" & ex.Message & ")", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 更新RToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ListView1.Items.Clear()
        LoadExtentions()
    End Sub

    Private Sub 終了XToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub バージョン情報ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        InfomationForm.Show()
    End Sub
End Class