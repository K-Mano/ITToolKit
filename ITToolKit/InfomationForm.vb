Public NotInheritable Class InfomationForm

    Private Sub InfomationForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Text = String.Format("{0} のバージョン情報", ApplicationTitle)
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = String.Format("バージョン PreRelease{0}b", My.Application.Info.Version.ToString)
        LabelCopyright.Text = My.Application.Info.Copyright
        LabelCompanyName.Text = My.Application.Info.CompanyName
        'TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKButton.Click
        Close()
    End Sub
End Class
