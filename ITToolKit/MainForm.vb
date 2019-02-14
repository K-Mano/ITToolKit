Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Management
Imports iTextSharp.text.pdf
Imports iText = iTextSharp.text
Imports ClosedXML.Excel
Imports System.Net

'*****************************************************************************************************
'
'   ITToolKit(TM) MainForm
'
'   Main of this Program
'
'   Copyright (c) 2018-2019 ACT Information Dev.org All Rights Reserved.
'   Licensed under the MIT License.
'
'*****************************************************************************************************

Public Class MainForm
    '関数の宣言----------------------------------
    Public Extentions As String
    Public CurrentLanguage As String
    Dim LanguageAuthor As String
    Dim newbuild As String = ".\NewestBuild.md"
    Dim nowbuild As String = ".\CurrentBuild.md"
    Dim downloadClient As WebClient = Nothing
    Dim phythicsnumber As String
    Dim dtNow As Date = Date.Now
    Dim antivirus As String
    Dim username As String
    Dim itname As String
    Dim license As String
    Dim number As String
    Dim filename As String
    Dim items(,) As String = {
        {"メーカー", ""},
        {"機種", ""},
        {"シリアルナンバー", ""},
        {"OSバージョン", ""},
        {"MACアドレス", ""},
        {"シリアルナンバーの有無", ""}
    }
    '--------------------------------------------
    Private Sub Maker()
        '*****************************************************************************************************
        '
        '   Description:メーカー情報の取得
        '
        '*****************************************************************************************************
        Dim scope As ManagementScope = New ManagementScope("root\cimv2")
        scope.Connect()
        Dim q As ObjectQuery = New ObjectQuery("select Manufacturer,Model from Win32_ComputerSystem")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, q)
        Dim collection As ManagementObjectCollection = searcher.[Get]()

        For Each o As ManagementObject In collection
            items(0, 1) = Convert.ToString(o.GetPropertyValue("Manufacturer"))
        Next
    End Sub
    Private Sub Hardware()
        '*****************************************************************************************************
        '
        '   Description:ハードウェア情報の取得
        '
        '*****************************************************************************************************

        Dim scope As ManagementScope = New ManagementScope("root\cimv2")
        scope.Connect()
        Dim q As ObjectQuery = New ObjectQuery("select Manufacturer,Model from Win32_ComputerSystem")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, q)
        Dim collection As ManagementObjectCollection = searcher.[Get]()

        For Each o As ManagementObject In collection
            items(1, 1) = Convert.ToString(o.GetPropertyValue("Model"))
        Next
    End Sub
    Private Sub SerialNumber()
        '*****************************************************************************************************
        '
        '   Description:シリアルナンバー/プロダクトIDの取得
        '
        '*****************************************************************************************************

        Dim scope As ManagementScope = New ManagementScope("root\cimv2")
        scope.Connect()
        Dim q As ObjectQuery = New ObjectQuery("select SerialNumber from Win32_BIOS")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, q)
        Dim collection As ManagementObjectCollection = searcher.[Get]()

        For Each o As ManagementObject In collection
            Dim serial As String = Convert.ToString(o.GetPropertyValue("SerialNumber"))

            If serial.Contains("Not Applicable") Then
                Dim mc As ManagementClass = New ManagementClass("Win32_OperatingSystem")
                Dim moc As ManagementObjectCollection = mc.GetInstances()

                For Each mo As ManagementObject In moc
                    items(2, 1) = Convert.ToString(mo("SerialNumber"))
                Next
                items(5, 1) = "False"
            Else
                items(2, 1) = serial
                items(5, 1) = "True"
            End If
        Next
    End Sub
    Private Sub OSVersion()
        '*****************************************************************************************************
        '
        '   Description:OSバージョンの取得
        '
        '*****************************************************************************************************

        items(3, 1) = My.Computer.Info.OSFullName
    End Sub
    Public Sub MACAddress()
        '*****************************************************************************************************
        '
        '   Description:Wi-Fiボードの物理アドレスの取得
        '
        '*****************************************************************************************************

        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For Each adapter As NetworkInterface In adapters
            If adapter.Name.Contains("Wi-Fi") Then
                Dim ip_prop As IPInterfaceProperties = adapter.GetIPProperties()
                ' MACアドレスの取得
                Dim phy As PhysicalAddress = adapter.GetPhysicalAddress()
                phythicsnumber = phy.ToString
                Dim phymodified As String = phy.ToString()
                phymodified = phymodified.Insert(2, ":")
                phymodified = phymodified.Insert(5, ":")
                phymodified = phymodified.Insert(8, ":")
                phymodified = phymodified.Insert(11, ":")
                phymodified = phymodified.Insert(14, ":")
                items(4, 1) = phymodified
            End If
        Next

    End Sub
    Public Sub CommandLink1_Click(sender As Object, e As EventArgs) Handles CommandLink1.Click
        '*****************************************************************************************************
        '
        '   Description:メインページ-情報入力ページに移動
        '
        '*****************************************************************************************************

        MainPage.NextPage = InfoPage
        WizardControl1.NextPage()

    End Sub

    Private Sub CommandLink3_Click(sender As Object, e As EventArgs) Handles CommandLink3.Click
        '*****************************************************************************************************
        '
        '   Description:リスト化したデータを名前を付けて保存
        '
        '*****************************************************************************************************

        SaveFileDialog1.ShowDialog()

    End Sub

    Private Sub CommandLink5_Click(sender As Object, e As EventArgs) Handles CommandLink5.Click
        '*****************************************************************************************************
        '
        '   Description:データベースへ送信(*未実装)
        '
        '*****************************************************************************************************

        DataBase.Show()

    End Sub
    Private Sub SaveDataListForText()
        '*****************************************************************************************************
        '
        '   Description:(*.txt)で保存
        '
        '*****************************************************************************************************

        Dim itemx As ListViewItem = New ListViewItem()
        Try
            Dim path As String = IO.Path.GetFullPath(SaveFileDialog1.FileName)
            Dim sjisEnc As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim writer As StreamWriter = New StreamWriter(path, True, sjisEnc)
            For I As Integer = 0 To 5
                writer.WriteLine(items(I, 0) & ":" & items(I, 1))
            Next
            writer.Close()
        Catch ex As Exception
            MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SaveDataListForCSV()
        '*****************************************************************************************************
        '
        '   Description:(*.csv)で保存
        '
        '*****************************************************************************************************

        phythicsnumber = phythicsnumber.Insert(2, ",")
        phythicsnumber = phythicsnumber.Insert(5, ",")
        phythicsnumber = phythicsnumber.Insert(8, ",")
        phythicsnumber = phythicsnumber.Insert(11, ",")
        phythicsnumber = phythicsnumber.Insert(14, ",")
        Dim itemx As ListViewItem = New ListViewItem()
        Try
            Dim path As String = IO.Path.GetFullPath(SaveFileDialog1.FileName)
            Dim sjisEnc As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim writer As StreamWriter = New StreamWriter(path, True, sjisEnc)
            For I As Integer = 0 To 3
                writer.WriteLine(items(I, 0) & ":," & items(I, 1))
            Next
            writer.WriteLine(items(4, 0) & ":," & phythicsnumber)
            writer.WriteLine(items(5, 0) & ":," & items(5, 1))
            writer.Close()
        Catch ex As Exception
            MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveDataListForXLSX()
        '*****************************************************************************************************
        '
        '   Description:(*.xlsx)で保存
        '
        '*****************************************************************************************************

        Try
            phythicsnumber = phythicsnumber.Insert(2, ",")
            phythicsnumber = phythicsnumber.Insert(5, ",")
            phythicsnumber = phythicsnumber.Insert(8, ",")
            phythicsnumber = phythicsnumber.Insert(11, ",")
            phythicsnumber = phythicsnumber.Insert(14, ",")
            Dim delim As Char = ","
            Dim destArr As String() = Split(phythicsnumber, delim, -1)
            Dim path As String = IO.Path.GetFullPath(SaveFileDialog1.FileName)
            Dim objWBook As New XLWorkbook
            Dim objSheet As IXLWorksheet = objWBook.Worksheets.Add("Sheet1")
            '------------------------.xlsxブックの内容--------------------------
            objSheet.Range("B1:G1").Merge()
            objSheet.Range("B2:G2").Merge()
            objSheet.Range("B3:G3").Merge()
            objSheet.Range("B4:G4").Merge()
            objSheet.Range("B6:G6").Merge()
            objSheet.Range("A1").Value = items(0, 0)
            objSheet.Range("A2").Value = items(1, 0)
            objSheet.Range("A3").Value = items(2, 0)
            objSheet.Range("A4").Value = items(3, 0)
            objSheet.Range("A5").Value = items(4, 0)
            objSheet.Range("A6").Value = items(5, 0)
            objSheet.Range("B1").Value = items(0, 1)
            objSheet.Range("B2").Value = items(1, 1)
            objSheet.Range("B3").Value = items(2, 1)
            objSheet.Range("B4").Value = items(3, 1)
            objSheet.Range("B5").Value = destArr(0)
            objSheet.Range("B6").Value = items(5, 1)
            objSheet.Range("C5").Value = destArr(1)
            objSheet.Range("D5").Value = destArr(2)
            objSheet.Range("E5").Value = destArr(3)
            objSheet.Range("F5").Value = destArr(4)
            objSheet.Range("G5").Value = destArr(5)
            objWBook.SaveAs(path)
        Catch ex As Exception
            MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk
        '*****************************************************************************************************
        '
        '   Description:保存作業
        '
        '*****************************************************************************************************

        If Path.GetExtension(SaveFileDialog1.FileName).Contains("csv") Then
            SaveDataListForCSV()
        ElseIf Path.GetExtension(SaveFileDialog1.FileName).Contains("txt") Then
            SaveDataListForText()
        ElseIf Path.GetExtension(SaveFileDialog1.FileName).Contains("xlsx") Then
            SaveDataListForXLSX()
        End If

    End Sub

    Sub RunCMD(strcmd As String)
        '*****************************************************************************************************
        '
        '   Description:バックグラウンド-コマンドを実行
        '
        '*****************************************************************************************************

        Try
            Dim proc As New Process()
            proc.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec")
            proc.StartInfo.CreateNoWindow = True
                proc.StartInfo.Arguments = "/c " & strcmd
                proc.Start()
            proc.WaitForExit()
            proc.Close()
        Catch ex As Exception
            MessageBox.Show("プロキシの設定に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub CommandLink6_Click(sender As Object, e As EventArgs) Handles CommandLink6.Click
        '*****************************************************************************************************
        '
        '   Description:プロキシ設定を適用
        '
        '*****************************************************************************************************

        Dim ShellObj
        ShellObj = CreateObject("WScript.Shell")
        If noneie.Checked Then
            RunCMD("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 0")
        ElseIf actie.Checked Then
            RunCMD("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 1")
            RunCMD("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyServer /t reg_sz /d proxy.anan-nct.ac.jp:8080")
            RunCMD("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyOverride /t reg_sz /d ""192.168.0.50;<local>""")
        End If
        If nonesys.Checked Then
            RunCMD("netsh winhttp reset proxy")
        ElseIf actsys.Checked Then
            RunCMD("netsh winhttp set proxy proxy-server=""proxy.anan-nct.ac.jp:8080"" bypass-list=""192.168.0.50""")
        End If
    End Sub
    Public Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '*****************************************************************************************************
        '
        '   Description:MainForm(起動時)
        '
        '*****************************************************************************************************
        Try
            Dim fs As String() = Directory.GetFiles(".\languages", "*.lng")
            Dim f As String
            For Each f In fs
                Settings.ComboBox1.Items.Add(Path.GetFileNameWithoutExtension(f))
            Next
        Catch ex As Exception

        End Try
        LoadSettings()
        Initialization()
        LoadLanguages(CurrentLanguage)
        Try
            Settings.ComboBox1.SelectedItem = CurrentLanguage.Replace(".lng", String.Empty)
        Catch ex As Exception

        End Try
        Maker()
        Hardware()
        OSVersion()
        SerialNumber()
        MACAddress()
        For I As Integer = 0 To (items.Length \ items.Rank) - 1
            Dim itemx As New ListViewItem With {.Text = items(I, 0)}
            itemx.SubItems.Add(items(I, 1))
            ListView1.Items.Add(itemx)
        Next
        For L As Integer = 0 To 5
            ListView1.Items(L).SubItems(0).Font = New Font("Consolas", 9)
        Next
        ComboBox1.SelectedItem = "ESET"
        Try
            If File.Exists(nowbuild) Then

            Else
                Dim vw As New StreamWriter(nowbuild, False, Encoding.GetEncoding("shift_jis"))
                vw.Write(My.Application.Info.Version)
                vw.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("バージョン情報の格納に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '*****************************************************************************************************
        '
        '   Description:リストのリセット
        '
        '*****************************************************************************************************

        ListView1.Items.Clear()
        Maker()
        Hardware()
        OSVersion()
        SerialNumber()
        MACAddress()
        For I As Integer = 0 To (items.Length \ items.Rank) - 1
            Dim itemx As New ListViewItem With {.Text = items(I, 0)}
            itemx.SubItems.Add(items(I, 1))
            ListView1.Items.Add(itemx)
        Next
        For L As Integer = 0 To 5
            ListView1.Items(L).SubItems(0).Font = New Font("Consolas", 9)
        Next

    End Sub

    Private Sub CommandLink7_Click(sender As Object, e As EventArgs) Handles CommandLink7.Click
        filename = "\Reports\report_" & number & ".pdf"
        Dim filepath As String = My.Application.Info.DirectoryPath & filename
        If license.Length = 0 Then
            license = "無し"
        End If
        If File.Exists(filepath) Then
            File.Delete(filepath)
        End If
        CreatePdf(filepath)
        End
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "ESET" Then
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
        End If
    End Sub

    Private Sub CommandLink4_Click(sender As Object, e As EventArgs) Handles CommandLink4.Click
        '*****************************************************************************************************
        '
        '   Description:PC持込願の表示
        '
        '*****************************************************************************************************
    End Sub

    Private Sub CommandLink8_Click(sender As Object, e As EventArgs) Handles CommandLink8.Click
        If ComboBox2.Text <> "(選択してください)" Then
            If CheckBox1.Checked Then
                If ComboBox1.Text.Length > 0 Then
                    If TextBox2.TextLength > 0 Then
                        If TextBox4.TextLength = 9 Then
                            If ComboBox1.SelectedItem = "ESET" Then
                                antivirus = ComboBox1.SelectedItem
                                license = TextBox1.Text
                                username = TextBox2.Text
                                number = TextBox4.Text
                                itname = ComboBox2.SelectedItem
                                WizardControl1.NextPage()
                            Else
                                If TextBox1.TextLength > 0 Then
                                    antivirus = ComboBox1.SelectedItem
                                    license = TextBox1.Text
                                    username = TextBox2.Text
                                    number = TextBox4.Text
                                    itname = ComboBox2.SelectedItem
                                    WizardControl1.NextPage()
                                Else
                                    MessageBox.Show("ライセンスキーを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("学籍番号を正しく入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("申請者の名前を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("ウイルス対策ソフトウェアを選択または入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If ComboBox1.Text.Length > 0 Then
                    If TextBox2.TextLength > 0 Then
                        If TextBox4.TextLength = 7 Then
                            If ComboBox1.SelectedItem = "ESET" Then
                                antivirus = ComboBox1.SelectedItem
                                license = TextBox1.Text
                                username = TextBox2.Text
                                number = TextBox4.Text
                                itname = ComboBox2.SelectedItem
                                WizardControl1.NextPage()
                            Else
                                If TextBox1.TextLength > 0 Then
                                    antivirus = ComboBox1.SelectedItem
                                    license = TextBox1.Text
                                    username = TextBox2.Text
                                    number = TextBox4.Text
                                    itname = ComboBox2.SelectedItem
                                    WizardControl1.NextPage()
                                Else
                                    MessageBox.Show("ライセンスキーを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("学籍番号を正しく入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("申請者の名前を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("ウイルス対策ソフトウェアを選択または入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("IT管理委員の名前を選択または入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub CreatePdf(savepath As String)
        Try
            Dim savefolder As String = "\Reports"
            Dim savedirectory As String = My.Application.Info.DirectoryPath & savefolder
            Directory.CreateDirectory(savedirectory)
            Dim doc = New iText.Document()
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(savepath, FileMode.Create))
            doc.Open()
            Dim cb As PdfContentByte = writer.DirectContent
            Dim basefont As BaseFont = BaseFont.CreateFont("C:\Windows\Fonts\meiryo.ttc,0", BaseFont.IDENTITY_H, True)
            cb.BeginText()
            cb.SetFontAndSize(basefont, 14)
            'レポートの内容
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITToolKit Setup Report (" & Date.Today & ")", 150, 800, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "――――――――――――――――――――――――――――――――――――――――", 20, 785, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "*管理情報", 20, 765, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "申請を受け付けたIT管理委員:", 20, 745, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, itname, 300, 745, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PC所有者:", 20, 725, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, username, 300, 725, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "学籍番号:", 20, 705, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, number, 300, 705, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "使用しているウイルス対策ソフト:", 20, 685, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, antivirus, 300, 685, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ライセンスキー: ", 20, 665, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, license, 300, 665, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "――――――――――――――――――――――――――――――――――――――――", 20, 645, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "*システム情報", 20, 625, 0)
            Dim y As Integer = 605
            For I As Integer = 0 To 5
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(I, 0) & ":", 20, y, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(I, 1), 300, y, 0)
                y = y - 20
            Next
            cb.EndText()
            doc.Close()
        Catch ex As Exception
            MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LoadSettings()
        Try
            If File.Exists(".\Settings.dat") Then
                Dim cReader As New StreamReader(".\Settings.dat", Encoding.Default)
                Dim l As Integer = 0
                While cReader.Peek() >= 0
                    Dim stBuffer As String = cReader.ReadLine()
                    ComboBox2.Items.Add(stBuffer)
                    l = l + 1
                End While
                cReader.Close()
                ComboBox2.SelectedItem = "(選択してください)"
            Else
                Dim sw As New StreamWriter(".\Settings.dat", False, Encoding.GetEncoding("shift_jis"))
                sw.WriteLine("(選択してください)")
                sw.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("設定ファイルのロードに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Initialization()
        If Directory.Exists(".\languages") Then
        Else
            Directory.CreateDirectory(".\languages")
        End If
        If File.Exists(".\languages\Preference.ini") Then
            Dim cReader As New StreamReader(".\languages\Preference.ini", Encoding.Default)
            CurrentLanguage = cReader.ReadLine
            Extentions = cReader.ReadLine
            cReader.Close()
            If Extentions = "Extentions=true" Then
                Button3.Enabled = True
            Else
                Button3.Enabled = False
            End If
        Else
            Dim pf As New StreamWriter(".\languages\Preference.ini", True, Encoding.GetEncoding("shift_jis"))
            pf.WriteLine("Japanese.lng")
            pf.WriteLine("Extentions=false")
            pf.Close()
            Dim sw As New StreamWriter(".\languages\Japanese.lng", True, Encoding.GetEncoding("shift_jis"))
            '言語パックタイトル
            sw.WriteLine("Japanese(日本語) by K-Mano@nsip.org")
            'MainPage
            sw.WriteLine(Text)
            sw.WriteLine(WizardControl1.Title)
            sw.WriteLine(MainPage.Text)
            sw.WriteLine(CommandLink1.Text)
            sw.WriteLine(CommandLink1.Note)
            sw.WriteLine(CommandLink9.Text)
            sw.WriteLine(CommandLink9.Note)
            sw.WriteLine(CommandLink10.Text)
            sw.WriteLine(CommandLink10.Note)
            sw.WriteLine(Button4.Text)
            sw.WriteLine(WizardControl1.BackButtonToolTipText)
            sw.WriteLine(WizardControl1.CancelButtonText)
            sw.WriteLine(WizardControl1.NextButtonText)
            'InfoPage
            sw.WriteLine(InfoPage.Text)
            sw.WriteLine(GroupBox3.Text)
            sw.WriteLine(Label1.Text)
            sw.WriteLine(Label2.Text)
            sw.WriteLine(GroupBox4.Text)
            sw.WriteLine(Label3.Text)
            sw.WriteLine(Label7.Text)
            sw.WriteLine(CheckBox1.Text)
            sw.WriteLine(GroupBox5.Text)
            sw.WriteLine(Label5.Text)
            sw.WriteLine(Button2.Text)
            sw.WriteLine(CommandLink8.Text)
            sw.WriteLine(CommandLink8.Note)
            'DataPage
            sw.WriteLine(DataPage.Text)
            sw.WriteLine(Button1.Text)
            sw.WriteLine(CommandLink3.Text)
            sw.WriteLine(CommandLink3.Note)
            'ProxyPage
            sw.WriteLine(ProxyPage.Text)
            sw.WriteLine(GroupBox1.Text)
            sw.WriteLine(noneie.Text)
            sw.WriteLine(actie.Text)
            sw.WriteLine(GroupBox2.Text)
            sw.WriteLine(nonesys.Text)
            sw.WriteLine(actsys.Text)
            sw.WriteLine(CommandLink6.Text)
            sw.WriteLine(CommandLink6.Note)
            'FinishPage
            sw.WriteLine(FinishPage.Text)
            sw.WriteLine(Label4.Text)
            sw.WriteLine(CommandLink4.Text)
            sw.WriteLine(CommandLink4.Note)
            sw.WriteLine(CommandLink5.Text)
            sw.WriteLine(CommandLink5.Note)
            sw.WriteLine(CommandLink7.Text)
            sw.WriteLine(CommandLink7.Note)
            'PDFのプレビューウィンドウ
            sw.WriteLine(Report.Text)
            sw.WriteLine(Report.ファイルFToolStripMenuItem.Text)
            sw.WriteLine(Report.表示VToolStripMenuItem.Text)
            sw.WriteLine(Report.更新RToolStripMenuItem.Text)
            sw.WriteLine(Report.操作AToolStripMenuItem.Text)
            sw.WriteLine(Report.名前を付けて保存AToolStripMenuItem.Text)
            sw.WriteLine(Report.ヘルプHToolStripMenuItem.Text)
            sw.WriteLine(Report.バージョン情報VToolStripMenuItem.Text)
            sw.WriteLine(Report.セットアップに戻るEToolStripMenuItem.Text)
            '設定ウィンドウ
            sw.WriteLine(Settings.Text)
            sw.WriteLine(Settings.GroupBox1.Text)
            sw.WriteLine(Settings.Label1.Text)
            sw.WriteLine(Settings.Button1.Text)
            sw.WriteLine(Settings.Button2.Text)
            sw.WriteLine(Settings.Label2.Text)
            sw.WriteLine(Settings.GroupBox2.Text)
            sw.WriteLine(Settings.ListView2.Columns(0).Text)
            sw.WriteLine(Settings.ListView2.Items(0).Text)
            sw.WriteLine(Settings.ListView2.Items(1).Text)
            '拡張機能ウィンドウ
            sw.WriteLine(ExtentionsList.Text)
            sw.WriteLine(ExtentionsList.CommandLink1.Text)
            sw.WriteLine(ExtentionsList.CommandLink1.Note)
            sw.WriteLine(ExtentionsList.Label1.Text)
            sw.WriteLine(ExtentionsList.Label2.Text)
            sw.WriteLine(ExtentionsList.Label3.Text)
            sw.WriteLine(ExtentionsList.Label4.Text)
            sw.WriteLine(ExtentionsList.ListView1.Columns(0).Text)
            sw.WriteLine(ExtentionsList.ListView1.Columns(1).Text)

            sw.Close()
        End If
    End Sub
    Sub LoadLanguages(language As String)
        Try
            Dim cReader As New StreamReader(".\languages\" & language, Encoding.Default)
            Dim l As Integer = 0
            Dim langBuffer(100) As String
            While cReader.Peek() >= 0
                langBuffer(l) = cReader.ReadLine()
                l = l + 1
            End While
            cReader.Close()
            Settings.Label3.Text = langBuffer(0)
            Text = langBuffer(1)
            WizardControl1.Title = langBuffer(2)
            CommandLink1.Text = langBuffer(4)
            CommandLink1.Note = langBuffer(5)
            CommandLink9.Text = langBuffer(6)
            CommandLink9.Note = langBuffer(7)
            CommandLink10.Text = langBuffer(8)
            CommandLink10.Note = langBuffer(9)
            Button4.Text = langBuffer(10)
            WizardControl1.BackButtonToolTipText = langBuffer(11)
            WizardControl1.CancelButtonText = langBuffer(12)
            WizardControl1.NextButtonText = langBuffer(13)
            'InfoPage
            InfoPage.Text = langBuffer(14)
            GroupBox3.Text = langBuffer(15)
            Label1.Text = langBuffer(16)
            Label2.Text = langBuffer(17)
            GroupBox4.Text = langBuffer(18)
            Label3.Text = langBuffer(19)
            Label7.Text = langBuffer(20)
            CheckBox1.Text = langBuffer(21)
            GroupBox5.Text = langBuffer(22)
            Label5.Text = langBuffer(23)
            Button2.Text = langBuffer(24)
            CommandLink8.Text = langBuffer(25)
            CommandLink8.Note = langBuffer(26)
            'DataPage
            DataPage.Text = langBuffer(27)
            Button1.Text = langBuffer(28)
            CommandLink3.Text = langBuffer(29)
            CommandLink3.Note = langBuffer(30)
            'ProxyPage
            ProxyPage.Text = langBuffer(31)
            GroupBox1.Text = langBuffer(32)
            noneie.Text = langBuffer(33)
            actie.Text = langBuffer(34)
            GroupBox2.Text = langBuffer(35)
            nonesys.Text = langBuffer(36)
            actsys.Text = langBuffer(37)
            CommandLink6.Text = langBuffer(38)
            CommandLink6.Note = langBuffer(39)
            'FinishPage
            FinishPage.Text = langBuffer(40)
            Label4.Text = langBuffer(41)
            CommandLink4.Text = langBuffer(42)
            CommandLink4.Note = langBuffer(43)
            CommandLink5.Text = langBuffer(44)
            CommandLink5.Note = langBuffer(45)
            CommandLink7.Text = langBuffer(46)
            CommandLink7.Note = langBuffer(47)
            'PDFのプレビューウィンドウ
            Report.Text = langBuffer(48)
            Report.ファイルFToolStripMenuItem.Text = langBuffer(49)
            Report.表示VToolStripMenuItem.Text = langBuffer(50)
            Report.更新RToolStripMenuItem.Text = langBuffer(51)
            Report.操作AToolStripMenuItem.Text = langBuffer(52)
            Report.名前を付けて保存AToolStripMenuItem.Text = langBuffer(53)
            Report.ヘルプHToolStripMenuItem.Text = langBuffer(54)
            Report.バージョン情報VToolStripMenuItem.Text = langBuffer(55)
            Report.セットアップに戻るEToolStripMenuItem.Text = langBuffer(56)
            '設定ウィンドウ
            Settings.Text = langBuffer(57)
            Settings.GroupBox1.Text = langBuffer(58)
            Settings.Label1.Text = langBuffer(59)
            Settings.Button1.Text = langBuffer(60)
            Settings.Button2.Text = langBuffer(61)
            Settings.Label2.Text = langBuffer(62)
            Settings.GroupBox2.Text = langBuffer(63)
            Settings.ListView2.Columns(0).Text = langBuffer(64)
            Settings.ListView2.Items(0).Text = langBuffer(65)
            Settings.ListView2.Items(1).Text = langBuffer(66)
            '拡張機能ウィンドウ
            ExtentionsList.Text = langBuffer(67)
            ExtentionsList.CommandLink1.Text = langBuffer(68)
            ExtentionsList.CommandLink1.Note = langBuffer(69)
            ExtentionsList.Label1.Text = langBuffer(70)
            ExtentionsList.Label2.Text = langBuffer(71)
            ExtentionsList.Label3.Text = langBuffer(72)
            ExtentionsList.Label4.Text = langBuffer(73)
            ExtentionsList.ListView1.Columns(0).Text = langBuffer(74)
            ExtentionsList.ListView1.Columns(1).Text = langBuffer(75)
            MainPage.Text = langBuffer(3)
        Catch ex As Exception
            MessageBox.Show("言語ファイルのロードに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CommandLink9_Click(sender As Object, e As EventArgs) Handles CommandLink9.Click
        Settings.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox2.Items.Clear()
        LoadSettings()
    End Sub

    Private Sub CommandLink10_Click(sender As Object, e As EventArgs) Handles CommandLink10.Click
        Dim nu As New Uri("https://github.com/K-Mano/ITToolKit/releases/download/VT/NewestBuild.md")
        Try
            If downloadClient Is Nothing Then
                downloadClient = New WebClient()
                AddHandler downloadClient.DownloadFileCompleted,
                   AddressOf DownloadClient_DownloadFileCompleted
            End If
            downloadClient.DownloadFileAsync(nu, newbuild)
        Catch ex As Exception
            MessageBox.Show("アップデート情報の取得に失敗しました。" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DownloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        Try
            Dim nb As New StreamReader(newbuild, Encoding.GetEncoding("Shift_JIS"))
            Dim cb As New StreamReader(nowbuild, Encoding.GetEncoding("Shift_JIS"))
            Dim newestVersion As String = nb.ReadToEnd()
            nb.Close()
            Dim currentVersion As String = cb.ReadToEnd()
            cb.Close()
            If currentVersion = newestVersion Then
                MessageBox.Show("最新バージョンを使用中です。(" + currentVersion + ")", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim updateAns As DialogResult = MessageBox.Show("最新バージョンがあります。アップデートしますか？", "情報", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If updateAns = DialogResult.Yes Then
                    Process.Start(".\Updater.exe")
                    End
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("アップデート情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox4.MaxLength = 9
            TextBox4.Text = "foreign"
        Else
            TextBox4.MaxLength = 7
            TextBox4.Text = ""
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ExtentionsList.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '*****************************************************************************************************
        '
        '   Description:バージョン情報の表示
        '
        '*****************************************************************************************************

        InfomationForm.Show()
    End Sub
End Class
