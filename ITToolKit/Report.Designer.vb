﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Report
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.名前を付けて保存AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.セットアップに戻るEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.操作AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.表示VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.プレビュー用表示PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存用表示SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ヘルプHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.バージョン情報VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.操作AToolStripMenuItem, Me.表示VToolStripMenuItem, Me.ヘルプHToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(778, 26)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルFToolStripMenuItem
        '
        Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.名前を付けて保存AToolStripMenuItem, Me.セットアップに戻るEToolStripMenuItem})
        Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
        Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(85, 22)
        Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
        '
        '名前を付けて保存AToolStripMenuItem
        '
        Me.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem"
        Me.名前を付けて保存AToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(&A)..."
        '
        'セットアップに戻るEToolStripMenuItem
        '
        Me.セットアップに戻るEToolStripMenuItem.Name = "セットアップに戻るEToolStripMenuItem"
        Me.セットアップに戻るEToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.セットアップに戻るEToolStripMenuItem.Text = "セットアップに戻る(&E)"
        '
        '操作AToolStripMenuItem
        '
        Me.操作AToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.更新RToolStripMenuItem})
        Me.操作AToolStripMenuItem.Name = "操作AToolStripMenuItem"
        Me.操作AToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.操作AToolStripMenuItem.Text = "操作(&A)"
        '
        '更新RToolStripMenuItem
        '
        Me.更新RToolStripMenuItem.Name = "更新RToolStripMenuItem"
        Me.更新RToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.更新RToolStripMenuItem.Text = "更新(&R)"
        '
        '表示VToolStripMenuItem
        '
        Me.表示VToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.プレビュー用表示PToolStripMenuItem, Me.保存用表示SToolStripMenuItem})
        Me.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem"
        Me.表示VToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.表示VToolStripMenuItem.Text = "表示(&V)"
        '
        'プレビュー用表示PToolStripMenuItem
        '
        Me.プレビュー用表示PToolStripMenuItem.Name = "プレビュー用表示PToolStripMenuItem"
        Me.プレビュー用表示PToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.プレビュー用表示PToolStripMenuItem.Text = "プレビュー用表示(&P)"
        '
        '保存用表示SToolStripMenuItem
        '
        Me.保存用表示SToolStripMenuItem.Name = "保存用表示SToolStripMenuItem"
        Me.保存用表示SToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.保存用表示SToolStripMenuItem.Text = "保存用表示(&S)"
        '
        'ヘルプHToolStripMenuItem
        '
        Me.ヘルプHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.バージョン情報VToolStripMenuItem})
        Me.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem"
        Me.ヘルプHToolStripMenuItem.Size = New System.Drawing.Size(75, 22)
        Me.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)"
        '
        'バージョン情報VToolStripMenuItem
        '
        Me.バージョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem"
        Me.バージョン情報VToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.バージョン情報VToolStripMenuItem.Text = "バージョン情報(&V)"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 561)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(778, 27)
        Me.StatusBar1.TabIndex = 3
        Me.StatusBar1.Text = "Ready"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 535)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "パソコン持込許可願"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "pdfファイル (*.pdf)|*.pdf|すべてのファイル(*.*)|*.*"
        '
        'Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 588)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Report"
        Me.Text = "セットアップ レポートのプレビュー"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents セットアップに戻るEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents 操作AToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 表示VToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ヘルプHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents 名前を付けて保存AToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 更新RToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents プレビュー用表示PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存用表示SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents バージョン情報VToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
