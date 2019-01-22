Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Management
Imports iTextSharp.text.pdf
Imports iText = iTextSharp.text
Imports ClosedXML.Excel

Public Class MainForm
    Dim items(,) As String = {
        {"メーカー", ""},
        {"機種", ""},
        {"シリアルナンバー", ""},
        {"OSバージョン", ""},
        {"MACアドレス", ""},
        {"シリアルナンバーの有無", ""}}
    Dim phythicsnumber As String
    Dim dtNow As Date = Date.Now
    Dim antivirus As String
    Dim username As String
    Dim itname As String
    Dim license As String
    Dim number As String
    Dim filename As String
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
            writer.WriteLine(items(0, 0) & ":" & items(0, 1))
            writer.WriteLine(items(1, 0) & ":" & items(1, 1))
            writer.WriteLine(items(2, 0) & ":" & items(2, 1))
            writer.WriteLine(items(3, 0) & ":" & items(3, 1))
            writer.WriteLine(items(4, 0) & ":" & items(4, 1))
            writer.WriteLine(items(5, 0) & ":" & items(5, 1))
            writer.Close()
        Catch ex As Exception
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
            writer.WriteLine(items(0, 0) & ":," & items(0, 1))
            writer.WriteLine(items(1, 0) & ":," & items(1, 1))
            writer.WriteLine(items(2, 0) & ":," & items(2, 1))
            writer.WriteLine(items(3, 0) & ":," & items(3, 1))
            writer.WriteLine(items(4, 0) & ":," & phythicsnumber)
            writer.WriteLine(items(5, 0) & ":," & items(5, 1))
            writer.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SaveDataListForXLSX()

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk
        If Path.GetExtension(SaveFileDialog1.FileName).Contains("csv") Then
            SaveDataListForCSV()
        ElseIf Path.GetExtension(SaveFileDialog1.FileName).Contains("txt") Then
            SaveDataListForText()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        InfomationForm.Show()
    End Sub

    Private Sub CommandLink6_Click(sender As Object, e As EventArgs) Handles CommandLink6.Click
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
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
        Maker()
        Hardware()
        OSVersion()
        SerialNumber()
        MACAddress()
        For I As Integer = 0 To (items.Length \ items.Rank) - 1
            Dim itemx As New ListViewItem
            itemx.Text = items(I, 0)
            itemx.SubItems.Add(items(I, 1))
            ListView1.Items.Add(itemx)
        Next
        ListView1.Items(0).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(1).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(2).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(3).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(4).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(5).SubItems(0).Font = New Font("Consolas", 9)
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
            Dim itemx As New ListViewItem
            itemx.Text = items(I, 0)
            itemx.SubItems.Add(items(I, 1))
            ListView1.Items.Add(itemx)
        Next
        ListView1.Items(0).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(1).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(2).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(3).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(4).SubItems(0).Font = New Font("Consolas", 9)
        ListView1.Items(5).SubItems(0).Font = New Font("Consolas", 9)
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
        CreatePdf(filepath)
        Report.AxAcroPDF1.LoadFile(filepath)
        Report.Show()
    End Sub

    Private Sub CommandLink8_Click(sender As Object, e As EventArgs) Handles CommandLink8.Click
        antivirus = ComboBox1.SelectedItem
        license = TextBox1.Text
        username = TextBox2.Text
        number = TextBox4.Text
        itname = ComboBox2.SelectedItem
        WizardControl1.NextPage()
    End Sub
    Public Sub CreatePdf(savepath As String)
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
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "------------------------------------------------------------------------------------------", 20, 785, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "*管理情報", 20, 765, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "申請を受け付けたIT管理委員:     " & itname, 20, 745, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PC所有者:                       " & username, 20, 725, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "学籍番号:                       " & number, 20, 705, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "使用しているウイルス対策ソフト: " & antivirus, 20, 685, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ライセンスキー:                 " & license, 20, 665, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "------------------------------------------------------------------------------------------", 20, 645, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "*システム情報", 20, 625, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(0, 0) & ":                       " & items(0, 1), 20, 605, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(1, 0) & ":                             " & items(1, 1), 20, 585, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(2, 0) & ":           " & items(2, 1), 20, 565, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(3, 0) & ":                " & items(3, 1), 20, 545, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(4, 0) & ":                " & items(4, 1), 20, 525, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, items(5, 0) & ":  " & items(5, 1), 20, 505, 0)
        cb.EndText()
        doc.Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim result As DialogResult = MessageBox.Show("これは開発者向けのデバッグ用モードです。続けますか?", "警告:これは開発者向け機能です", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If result = DialogResult.OK Then
            DebugControl.Show()
        ElseIf result = DialogResult.Cancel Then
            Close()
        End If
    End Sub
    Sub LoadSettings()
        If File.Exists(".\Settings.dat") Then
            Dim cReader As New StreamReader(".\Settings.dat", Encoding.Default)

            ' 読み込んだ結果をすべて格納するための変数を宣言する
            Dim l As Integer = 0
            ' 読み込みできる文字がなくなるまで繰り返す
            While cReader.Peek() >= 0
                ' ファイルを 1 行ずつ読み込む
                Dim stBuffer As String = cReader.ReadLine()
                ComboBox2.Items.Add(stBuffer)
                l = l + 1
            End While
            cReader.Close()
            ComboBox2.SelectedItem = "(選択してください)"
        Else
            'Dim fs As FileStream = File.Create(".\Settings.dat")
            Dim sw As New StreamWriter(".\Settings.dat", False, Encoding.GetEncoding("shift_jis"))
            sw.WriteLine("(選択してください)")
            sw.Close()
        End If
    End Sub
End Class
