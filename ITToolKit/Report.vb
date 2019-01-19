Public Class Report
    Private Sub DataGridView1_MouseEnter(sender As Object, e As EventArgs) Handles DataGridView1.MouseEnter
        StatusBar1.Text = "収集したデータのリストです"
    End Sub
    Private Sub RichTextBox1_MouseEnter(sender As Object, e As EventArgs) Handles RichTextBox1.MouseEnter
        StatusBar1.Text = "出力されたレポートのプレビューです"
    End Sub
    Private Sub StatusBar1_MouseEnter(sender As Object, e As EventArgs) Handles StatusBar1.MouseEnter
        StatusBar1.Text = "Ready"
    End Sub

    Private Sub MenuStrip1_MouseEnter(sender As Object, e As EventArgs) Handles MenuStrip1.MouseEnter
        StatusBar1.Text = "Ready"
    End Sub

    Private Sub セットアップに戻るEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セットアップに戻るEToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub 名前を付けて保存AToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
End Class