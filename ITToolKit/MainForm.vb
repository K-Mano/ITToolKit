Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Management
Public Class MainForm
    Dim items(,) As String = {
        {"メーカー", "Data1"},
        {"機種", "Data2"},
        {"シリアルナンバー", "Data3"},
        {"OSバージョン", "Data4"},
        {"MACアドレス", "Data5"},
        {"シリアルナンバーの有無", "Data6"}}
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
                items(5, 1) = "なし"
            Else
                items(2, 1) = serial
                items(5, 1) = "あり"
            End If
        Next
    End Sub
    Private Sub OSVersion()
        items(3, 1) = My.Computer.Info.OSFullName
    End Sub
    Private Sub MACAddress()
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For Each adapter As NetworkInterface In adapters
            If adapter.Name.Contains("Wi-Fi") Then
                Dim ip_prop As IPInterfaceProperties = adapter.GetIPProperties()
                ' MACアドレスの取得
                Dim phy As PhysicalAddress = adapter.GetPhysicalAddress()
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
        Dim itemx As ListViewItem = New ListViewItem()
        Try
            Dim path As String = IO.Path.GetFullPath(SaveFileDialog1.FileName)
            Dim sjisEnc As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim writer As StreamWriter = New StreamWriter(path, True, sjisEnc)
            writer.WriteLine(items(0, 0) & "," & items(0, 1))
            writer.WriteLine(items(1, 0) & "," & items(1, 1))
            writer.WriteLine(items(2, 0) & "," & items(2, 1))
            writer.WriteLine(items(3, 0) & "," & items(3, 1))
            writer.WriteLine(items(4, 0) & "," & items(4, 1))
            writer.WriteLine(items(5, 0) & "," & items(5, 1))
            writer.Close()
        Catch ex As Exception
        End Try

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

    Private Sub CommandLink2_Click(sender As Object, e As EventArgs) Handles CommandLink2.Click
        ToolManager.Show()
    End Sub

    Private Sub CommandLink6_Click(sender As Object, e As EventArgs) Handles CommandLink6.Click
        Dim ShellObj
        ShellObj = CreateObject("WScript.Shell")
        If noneie.Checked Then
            Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 0")
        ElseIf actie.Checked Then
            Call ShellObj.Run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyEnable /t reg_dword /d 1")
            Call ShellObj.run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyServer /t reg_sz /d proxy.anan-nct.ac.jp:8080")
            Call ShellObj.run("reg add ""HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings"" /f /v ProxyOverride /t reg_sz /d ""192.168.0.50;<local>""")
        End If
        If nonesys.Checked Then
            Call ShellObj.Run("netsh winhttp reset proxy")
        ElseIf actsys.Checked Then
            Call ShellObj.Run("netsh winhttp set proxy proxy-server=""proxy.anan-nct.ac.jp:8080"" bypass-list=""192.168.0.50""")
        End If
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class
