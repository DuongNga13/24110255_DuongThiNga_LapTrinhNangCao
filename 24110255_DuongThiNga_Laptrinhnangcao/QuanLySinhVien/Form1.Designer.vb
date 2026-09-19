<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tinh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.A = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Buttoncong = New System.Windows.Forms.Button()
        Me.Buttonnhan = New System.Windows.Forms.Button()
        Me.Buttontru = New System.Windows.Forms.Button()
        Me.Buttonchia = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'A
        '
        Me.A.AutoSize = True
        Me.A.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!)
        Me.A.Location = New System.Drawing.Point(81, 43)
        Me.A.Name = "A"
        Me.A.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.A.Size = New System.Drawing.Size(90, 44)
        Me.A.TabIndex = 0
        Me.A.Text = "số a"
        Me.A.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!)
        Me.Label1.Location = New System.Drawing.Point(81, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(90, 44)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "số b"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!)
        Me.Label2.Location = New System.Drawing.Point(81, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(149, 44)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Kết quả"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Buttoncong
        '
        Me.Buttoncong.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Buttoncong.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Buttoncong.Location = New System.Drawing.Point(999, 125)
        Me.Buttoncong.Name = "Buttoncong"
        Me.Buttoncong.Size = New System.Drawing.Size(98, 65)
        Me.Buttoncong.TabIndex = 6
        Me.Buttoncong.Text = "Cộng"
        Me.Buttoncong.UseVisualStyleBackColor = False
        '
        'Buttonnhan
        '
        Me.Buttonnhan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Buttonnhan.Location = New System.Drawing.Point(867, 217)
        Me.Buttonnhan.Name = "Buttonnhan"
        Me.Buttonnhan.Size = New System.Drawing.Size(98, 61)
        Me.Buttonnhan.TabIndex = 7
        Me.Buttonnhan.Text = "Nhân"
        Me.Buttonnhan.UseVisualStyleBackColor = True
        '
        'Buttontru
        '
        Me.Buttontru.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Buttontru.Location = New System.Drawing.Point(867, 124)
        Me.Buttontru.Name = "Buttontru"
        Me.Buttontru.Size = New System.Drawing.Size(98, 65)
        Me.Buttontru.TabIndex = 8
        Me.Buttontru.Text = "Trừ"
        Me.Buttontru.UseVisualStyleBackColor = True
        '
        'Buttonchia
        '
        Me.Buttonchia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Buttonchia.Location = New System.Drawing.Point(999, 217)
        Me.Buttonchia.Name = "Buttonchia"
        Me.Buttonchia.Size = New System.Drawing.Size(98, 65)
        Me.Buttonchia.TabIndex = 9
        Me.Buttonchia.Text = "Chia"
        Me.Buttonchia.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(260, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(384, 26)
        Me.TextBox1.TabIndex = 10
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(260, 163)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(384, 26)
        Me.TextBox2.TabIndex = 11
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(260, 277)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(384, 26)
        Me.TextBox3.TabIndex = 12
        '
        'tinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1375, 853)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Buttonchia)
        Me.Controls.Add(Me.Buttontru)
        Me.Controls.Add(Me.Buttonnhan)
        Me.Controls.Add(Me.Buttoncong)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.A)
        Me.Name = "tinh"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents A As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Buttoncong As Button
    Friend WithEvents Buttonnhan As Button
    Friend WithEvents Buttontru As Button
    Friend WithEvents Buttonchia As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
End Class
