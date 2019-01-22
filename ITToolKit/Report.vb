Imports System.ComponentModel

Public Class Report
    Private Sub セットアップに戻るEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セットアップに戻るEToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub バージョン情報VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles バージョン情報VToolStripMenuItem.Click
        InfomationForm.Show()
    End Sub

    Private Sub 名前を付けて保存AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 名前を付けて保存AToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub 更新RToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新RToolStripMenuItem.Click
        AxAcroPDF1.Refresh()
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim path As String = IO.Path.GetFullPath(SaveFileDialog1.FileName)
        MainForm.CreatePdf(path)
    End Sub
End Class