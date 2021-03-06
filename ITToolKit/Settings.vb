﻿Imports System.IO
Imports System.Text

'*****************************************************************************************************
'
'   ITToolKit(TM) Settings
'
'   Settings
'
'   Copyright (c) 2018-2019 ACT Information Dev.org All Rights Reserved.
'   Licensed under the MIT License.
'
'*****************************************************************************************************

Public Class Settings
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.LoadLanguages(ComboBox1.SelectedItem + ".lng")
        If File.Exists(".\languages\Preference.ini") Then
            File.Delete(".\languages\Preference.ini")
        End If
        Dim pf As New StreamWriter(".\languages\Preference.ini", True, Encoding.GetEncoding("shift_jis"))
        pf.WriteLine(ComboBox1.SelectedItem + ".lng")
        If ListView2.Items(0).Checked Then
            MainForm.Button3.Enabled = True
            pf.WriteLine("Extentions=true")
        Else
            MainForm.Button3.Enabled = False
            pf.WriteLine("Extentions=false")
        End If
        pf.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.Extentions = "Extentions=true" Then
            ListView2.Items(0).Checked = True
        Else
            ListView2.Items(0).Checked = False
        End If
    End Sub

    Public Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim location As String = ".\languages\" + ComboBox1.SelectedItem + ".lng"
        Dim ls As New StreamReader(location, Encoding.Default)
        Label3.Text = ls.ReadLine()
    End Sub
End Class