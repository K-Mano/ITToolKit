<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.WizardControl1 = New AeroWizard.WizardControl()
        Me.MainPage = New AeroWizard.WizardPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CommandLink2 = New System.Windows.Forms.CommandLink()
        Me.CommandLink1 = New System.Windows.Forms.CommandLink()
        Me.InfoPage = New AeroWizard.WizardPage()
        Me.CommandLink8 = New System.Windows.Forms.CommandLink()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataPage = New AeroWizard.WizardPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DataName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Data = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CommandLink3 = New System.Windows.Forms.CommandLink()
        Me.ProxyPage = New AeroWizard.WizardPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.actie = New System.Windows.Forms.RadioButton()
        Me.noneie = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.actsys = New System.Windows.Forms.RadioButton()
        Me.nonesys = New System.Windows.Forms.RadioButton()
        Me.CommandLink6 = New System.Windows.Forms.CommandLink()
        Me.FinishPage = New AeroWizard.WizardPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CommandLink7 = New System.Windows.Forms.CommandLink()
        Me.CommandLink5 = New System.Windows.Forms.CommandLink()
        Me.CommandLink4 = New System.Windows.Forms.CommandLink()
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPage.SuspendLayout()
        Me.InfoPage.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.DataPage.SuspendLayout()
        Me.ProxyPage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FinishPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer)))
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "CSVファイル (*.csv)|*.csv|テキストファイル (*.txt)|*.txt|すべてのファイル(*.*)|*.*"
        Me.SaveFileDialog1.Title = "名前を付けてデータリストを保存"
        '
        'WizardControl1
        '
        Me.WizardControl1.BackColor = System.Drawing.Color.White
        Me.WizardControl1.CancelButtonText = "キャンセル(&C)"
        Me.WizardControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WizardControl1.FinishButtonText = "完了(&F)"
        Me.WizardControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WizardControl1.Location = New System.Drawing.Point(0, 0)
        Me.WizardControl1.Name = "WizardControl1"
        Me.WizardControl1.NextButtonText = "次へ(&N)"
        Me.WizardControl1.Pages.Add(Me.MainPage)
        Me.WizardControl1.Pages.Add(Me.InfoPage)
        Me.WizardControl1.Pages.Add(Me.DataPage)
        Me.WizardControl1.Pages.Add(Me.ProxyPage)
        Me.WizardControl1.Pages.Add(Me.FinishPage)
        Me.WizardControl1.Size = New System.Drawing.Size(631, 450)
        Me.WizardControl1.TabIndex = 0
        Me.WizardControl1.Text = "IT管理委員ToolKit"
        Me.WizardControl1.Title = "IT管理委員ToolKit (PreRelease v1.2b4)"
        Me.WizardControl1.TitleIcon = CType(resources.GetObject("WizardControl1.TitleIcon"), System.Drawing.Icon)
        '
        'MainPage
        '
        Me.MainPage.AllowNext = False
        Me.MainPage.Controls.Add(Me.LinkLabel1)
        Me.MainPage.Controls.Add(Me.CommandLink2)
        Me.MainPage.Controls.Add(Me.CommandLink1)
        Me.MainPage.Name = "MainPage"
        Me.MainPage.NextPage = Me.InfoPage
        Me.MainPage.Size = New System.Drawing.Size(584, 296)
        Me.MainPage.TabIndex = 0
        Me.MainPage.Text = "IT管理委員ToolKitへようこそ"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 281)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(75, 15)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "バージョン情報"
        '
        'CommandLink2
        '
        Me.CommandLink2.Enabled = False
        Me.CommandLink2.Location = New System.Drawing.Point(3, 84)
        Me.CommandLink2.Name = "CommandLink2"
        Me.CommandLink2.Note = "ツール マネージャを起動します。"
        Me.CommandLink2.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink2.TabIndex = 11
        Me.CommandLink2.Text = "その他のツール(&T)(削除検討中)"
        Me.CommandLink2.UseVisualStyleBackColor = True
        '
        'CommandLink1
        '
        Me.CommandLink1.Location = New System.Drawing.Point(3, 3)
        Me.CommandLink1.Name = "CommandLink1"
        Me.CommandLink1.Note = "PC許可願に必要な固有データの確認やプロキシの設定を行います。"
        Me.CommandLink1.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink1.TabIndex = 10
        Me.CommandLink1.Text = "新しいPCのセットアップ(&S)"
        Me.CommandLink1.UseVisualStyleBackColor = True
        '
        'InfoPage
        '
        Me.InfoPage.AllowNext = False
        Me.InfoPage.Controls.Add(Me.CommandLink8)
        Me.InfoPage.Controls.Add(Me.GroupBox5)
        Me.InfoPage.Controls.Add(Me.GroupBox4)
        Me.InfoPage.Controls.Add(Me.GroupBox3)
        Me.InfoPage.Name = "InfoPage"
        Me.InfoPage.NextPage = Me.DataPage
        Me.InfoPage.ShowNext = False
        Me.InfoPage.Size = New System.Drawing.Size(584, 296)
        Me.InfoPage.TabIndex = 4
        Me.InfoPage.Text = "レポートに必要な情報を入力"
        '
        'CommandLink8
        '
        Me.CommandLink8.Location = New System.Drawing.Point(3, 218)
        Me.CommandLink8.Name = "CommandLink8"
        Me.CommandLink8.Note = "入力された情報をレポートに記録して続けます。"
        Me.CommandLink8.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink8.TabIndex = 1
        Me.CommandLink8.Text = "確定して次のステップへ進む"
        Me.CommandLink8.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ComboBox2)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox5.Location = New System.Drawing.Point(3, 166)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(550, 48)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "記入者情報(IT管理委員)"
        '
        'ComboBox2
        '
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"(*未実装)", "真野 京介, 2I", "高橋 直樹, 2I", "宮本 圭一郎, 2I"})
        Me.ComboBox2.Location = New System.Drawing.Point(252, 16)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(222, 23)
        Me.ComboBox2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Location = New System.Drawing.Point(18, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "記入者の名前 :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TextBox2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Location = New System.Drawing.Point(3, 83)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(550, 77)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "使用者情報"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(252, 45)
        Me.TextBox4.MaxLength = 7
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(222, 23)
        Me.TextBox4.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Location = New System.Drawing.Point(18, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 15)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "学籍番号 :"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(252, 16)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(222, 23)
        Me.TextBox2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Location = New System.Drawing.Point(18, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "名前 :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(550, 77)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "セキュリティ"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(252, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(222, 23)
        Me.TextBox1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(18, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ライセンスキー :"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"ESET", "ウイルスバスタークラウド", "カスペルスキーセキュリティ", "ノートンセキュリティ", "Avast AntiVirus", "AVG AntiVirus", "Avira AntiVirus", "(その他)"})
        Me.ComboBox1.Location = New System.Drawing.Point(252, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 23)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ウイルス対策ソフトウェア :"
        '
        'DataPage
        '
        Me.DataPage.Controls.Add(Me.Button1)
        Me.DataPage.Controls.Add(Me.ListView1)
        Me.DataPage.Controls.Add(Me.CommandLink3)
        Me.DataPage.Name = "DataPage"
        Me.DataPage.Size = New System.Drawing.Size(584, 296)
        Me.DataPage.TabIndex = 1
        Me.DataPage.Text = "固有データの確認"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(490, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "更新(&R)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DataName, Me.Data})
        Me.ListView1.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(550, 179)
        Me.ListView1.TabIndex = 8
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DataName
        '
        Me.DataName.Text = "名称"
        Me.DataName.Width = 160
        '
        'Data
        '
        Me.Data.Text = "固有データ"
        Me.Data.Width = 200
        '
        'CommandLink3
        '
        Me.CommandLink3.Location = New System.Drawing.Point(3, 218)
        Me.CommandLink3.Name = "CommandLink3"
        Me.CommandLink3.Note = "固有データのリストを指定された形式で出力します。"
        Me.CommandLink3.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink3.TabIndex = 9
        Me.CommandLink3.Text = "名前を付けてデータを保存(&A)..."
        Me.CommandLink3.UseVisualStyleBackColor = True
        '
        'ProxyPage
        '
        Me.ProxyPage.Controls.Add(Me.GroupBox1)
        Me.ProxyPage.Controls.Add(Me.GroupBox2)
        Me.ProxyPage.Controls.Add(Me.CommandLink6)
        Me.ProxyPage.Name = "ProxyPage"
        Me.ProxyPage.Size = New System.Drawing.Size(584, 296)
        Me.ProxyPage.TabIndex = 2
        Me.ProxyPage.Text = "プロキシの設定"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.actie)
        Me.GroupBox1.Controls.Add(Me.noneie)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(550, 100)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "通常プロキシ"
        '
        'actie
        '
        Me.actie.AutoSize = True
        Me.actie.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.actie.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actie.Location = New System.Drawing.Point(13, 47)
        Me.actie.Margin = New System.Windows.Forms.Padding(2)
        Me.actie.Name = "actie"
        Me.actie.Size = New System.Drawing.Size(213, 20)
        Me.actie.TabIndex = 1
        Me.actie.Text = "高専内 (proxy.anan-nct.ac.jp:8080)"
        Me.actie.UseVisualStyleBackColor = True
        '
        'noneie
        '
        Me.noneie.AutoSize = True
        Me.noneie.Checked = True
        Me.noneie.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.noneie.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noneie.Location = New System.Drawing.Point(13, 20)
        Me.noneie.Margin = New System.Windows.Forms.Padding(2)
        Me.noneie.Name = "noneie"
        Me.noneie.Size = New System.Drawing.Size(86, 20)
        Me.noneie.TabIndex = 0
        Me.noneie.TabStop = True
        Me.noneie.Text = "プロキシなし"
        Me.noneie.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.actsys)
        Me.GroupBox2.Controls.Add(Me.nonesys)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(2, 106)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(550, 100)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "WinHTTPプロキシ"
        '
        'actsys
        '
        Me.actsys.AutoSize = True
        Me.actsys.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.actsys.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actsys.Location = New System.Drawing.Point(13, 50)
        Me.actsys.Margin = New System.Windows.Forms.Padding(2)
        Me.actsys.Name = "actsys"
        Me.actsys.Size = New System.Drawing.Size(213, 20)
        Me.actsys.TabIndex = 8
        Me.actsys.Text = "高専内 (proxy.anan-nct.ac.jp:8080)"
        Me.actsys.UseVisualStyleBackColor = True
        '
        'nonesys
        '
        Me.nonesys.AutoSize = True
        Me.nonesys.Checked = True
        Me.nonesys.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.nonesys.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nonesys.Location = New System.Drawing.Point(13, 23)
        Me.nonesys.Margin = New System.Windows.Forms.Padding(2)
        Me.nonesys.Name = "nonesys"
        Me.nonesys.Size = New System.Drawing.Size(86, 20)
        Me.nonesys.TabIndex = 1
        Me.nonesys.TabStop = True
        Me.nonesys.Text = "プロキシなし"
        Me.nonesys.UseVisualStyleBackColor = True
        '
        'CommandLink6
        '
        Me.CommandLink6.Location = New System.Drawing.Point(2, 218)
        Me.CommandLink6.Name = "CommandLink6"
        Me.CommandLink6.Note = "すべての設定を反映します。"
        Me.CommandLink6.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink6.TabIndex = 14
        Me.CommandLink6.Text = "すべてに適用"
        Me.CommandLink6.UseVisualStyleBackColor = True
        '
        'FinishPage
        '
        Me.FinishPage.AllowNext = False
        Me.FinishPage.Controls.Add(Me.Label4)
        Me.FinishPage.Controls.Add(Me.CommandLink7)
        Me.FinishPage.Controls.Add(Me.CommandLink5)
        Me.FinishPage.Controls.Add(Me.CommandLink4)
        Me.FinishPage.IsFinishPage = True
        Me.FinishPage.Name = "FinishPage"
        Me.FinishPage.Size = New System.Drawing.Size(584, 296)
        Me.FinishPage.TabIndex = 3
        Me.FinishPage.Text = "セットアップが完了しました"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(437, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "重要:使用者は必ずその他問題がないか確認してから申請書を提出するようにしてください。"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CommandLink7
        '
        Me.CommandLink7.Location = New System.Drawing.Point(3, 183)
        Me.CommandLink7.Name = "CommandLink7"
        Me.CommandLink7.Note = "IT管理委員ToolKitを終了します。"
        Me.CommandLink7.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink7.TabIndex = 18
        Me.CommandLink7.Text = "終了"
        Me.CommandLink7.UseVisualStyleBackColor = True
        '
        'CommandLink5
        '
        Me.CommandLink5.Enabled = False
        Me.CommandLink5.Location = New System.Drawing.Point(3, 102)
        Me.CommandLink5.Name = "CommandLink5"
        Me.CommandLink5.Note = "許可願に直接データを印刷できる文書ファイルを出力します。"
        Me.CommandLink5.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink5.TabIndex = 17
        Me.CommandLink5.Text = "PC持ち込み許可願に印刷(未実装,検討中)"
        Me.CommandLink5.UseVisualStyleBackColor = True
        '
        'CommandLink4
        '
        Me.CommandLink4.Location = New System.Drawing.Point(3, 21)
        Me.CommandLink4.Name = "CommandLink4"
        Me.CommandLink4.Note = "セットアップ レポートをpdf形式(*.pdf)で出力します。"
        Me.CommandLink4.Size = New System.Drawing.Size(550, 75)
        Me.CommandLink4.TabIndex = 16
        Me.CommandLink4.Text = "セットアップ レポートの出力(未実装)"
        Me.CommandLink4.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(631, 450)
        Me.Controls.Add(Me.WizardControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IT管理委員ToolKit"
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPage.ResumeLayout(False)
        Me.MainPage.PerformLayout()
        Me.InfoPage.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.DataPage.ResumeLayout(False)
        Me.ProxyPage.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.FinishPage.ResumeLayout(False)
        Me.FinishPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents WizardControl1 As AeroWizard.WizardControl
    Friend WithEvents MainPage As AeroWizard.WizardPage
    Friend WithEvents DataPage As AeroWizard.WizardPage
    Friend WithEvents ProxyPage As AeroWizard.WizardPage
    Friend WithEvents FinishPage As AeroWizard.WizardPage
    Friend WithEvents CommandLink2 As CommandLink
    Friend WithEvents CommandLink1 As CommandLink
    Friend WithEvents Button1 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents DataName As ColumnHeader
    Friend WithEvents Data As ColumnHeader
    Friend WithEvents CommandLink3 As CommandLink
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents actie As RadioButton
    Friend WithEvents noneie As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents actsys As RadioButton
    Friend WithEvents nonesys As RadioButton
    Friend WithEvents CommandLink6 As CommandLink
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents CommandLink7 As CommandLink
    Friend WithEvents CommandLink5 As CommandLink
    Friend WithEvents CommandLink4 As CommandLink
    Friend WithEvents InfoPage As AeroWizard.WizardPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CommandLink8 As CommandLink
End Class
