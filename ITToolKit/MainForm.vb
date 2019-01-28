Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Management
Imports iTextSharp.text.pdf
Imports iText = iTextSharp.text
Imports ClosedXML.Excel
Public Class MainForm
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
    Private Sub Maker()
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
        items(3, 1) = My.Computer.Info.OSFullName
    End Sub
    Public Sub MACAddress()
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
        MainPage.NextPage = InfoPage
        WizardControl1.NextPage()
    End Sub

    Private Sub CommandLink3_Click(sender As Object, e As EventArgs) Handles CommandLink3.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub CommandLink5_Click(sender As Object, e As EventArgs) Handles CommandLink5.Click
        MainPage.NextPage = MainPage
        WizardControl1.NextPage()
    End Sub
    Private Sub SaveDataListForText()
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
            '----------------------.xlsxブックの内容--------------------------
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
        If Path.GetExtension(SaveFileDialog1.FileName).Contains("csv") Then
            SaveDataListForCSV()
        ElseIf Path.GetExtension(SaveFileDialog1.FileName).Contains("txt") Then
            SaveDataListForText()
        ElseIf Path.GetExtension(SaveFileDialog1.FileName).Contains("xlsx") Then
            SaveDataListForXLSX()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        InfomationForm.Show()
    End Sub

    Private Sub CommandLink6_Click(sender As Object, e As EventArgs) Handles CommandLink6.Click
        Try
            Dim ShellObj
            ShellObj = CreateObject("WScript.Shell")
            If noneie.Checked Then
                Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 0")
            ElseIf actie.Checked Then
                Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 1")
                Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyServer /t reg_sz /d proxy.anan-nct.ac.jp:8080")
                Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyOverride /t reg_sz /d ""192.168.0.50;<local>""")
            End If
            If nonesys.Checked Then
                Call ShellObj.Run("netsh winhttp reset proxy")
            ElseIf actsys.Checked Then
                Call ShellObj.Run("netsh winhttp set proxy proxy-server=""proxy.anan-nct.ac.jp:8080"" bypass-list=""192.168.0.50""")
            End If
        Catch ex As Exception
            MessageBox.Show("プロキシの設定に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        filename = "\Reports\report_" & number & ".pdf"
        Dim filepath As String = My.Application.Info.DirectoryPath & filename
        If license.Length = 0 Then
            license = "無し"
        End If
        If itname = "(選択してください)" Then
            itname = "[使用者不明]"
        End If
        CreatePdf(filepath)
        Try
            Report.AxAcroPDF1.LoadFile(filepath)
            Report.Show()
        Catch ex As Exception
            MessageBox.Show("Adobe Acrobatがインストールされていないため、レポートを表示できませんでした。(レポートは自動で保存されています。)", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CommandLink8_Click(sender As Object, e As EventArgs) Handles CommandLink8.Click
        If TextBox2.TextLength > 0 And TextBox4.TextLength = 7 Then
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
                    MessageBox.Show("必要事項を正しく入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("必要事項を正しく入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub CommandLink9_Click(sender As Object, e As EventArgs) Handles CommandLink9.Click
        Dim p As Process = Process.Start(".\Settings.dat")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox2.Items.Clear()
        LoadSettings()
    End Sub

    Private Sub CommandLink10_Click(sender As Object, e As EventArgs) Handles CommandLink10.Click
        Try
            Dim updater As Process = Process.Start(".\Updater.exe")
        Catch ex As Exception
            MessageBox.Show("アップデータの起動に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
