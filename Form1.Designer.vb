<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblOldPassword = New System.Windows.Forms.Label()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.txtNewPassword1 = New System.Windows.Forms.TextBox()
        Me.btnResetPassword = New System.Windows.Forms.Button()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewPassword2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblOldPassword
        '
        Me.lblOldPassword.AutoSize = True
        Me.lblOldPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOldPassword.Location = New System.Drawing.Point(68, 54)
        Me.lblOldPassword.Name = "lblOldPassword"
        Me.lblOldPassword.Size = New System.Drawing.Size(72, 13)
        Me.lblOldPassword.TabIndex = 7
        Me.lblOldPassword.Text = "Old Password"
        Me.lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNewPassword.Location = New System.Drawing.Point(62, 81)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(78, 13)
        Me.lblNewPassword.TabIndex = 8
        Me.lblNewPassword.Text = "New Password"
        Me.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(142, 50)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtOldPassword.TabIndex = 2
        Me.txtOldPassword.UseSystemPasswordChar = True
        '
        'txtNewPassword1
        '
        Me.txtNewPassword1.Location = New System.Drawing.Point(142, 77)
        Me.txtNewPassword1.Name = "txtNewPassword1"
        Me.txtNewPassword1.Size = New System.Drawing.Size(100, 20)
        Me.txtNewPassword1.TabIndex = 3
        Me.txtNewPassword1.UseSystemPasswordChar = True
        '
        'btnResetPassword
        '
        Me.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetPassword.Location = New System.Drawing.Point(142, 142)
        Me.btnResetPassword.Name = "btnResetPassword"
        Me.btnResetPassword.Size = New System.Drawing.Size(100, 23)
        Me.btnResetPassword.TabIndex = 5
        Me.btnResetPassword.Text = "Reset Password"
        Me.btnResetPassword.UseVisualStyleBackColor = True
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblUsername.Location = New System.Drawing.Point(85, 28)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 6
        Me.lblUsername.Text = "Username"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(142, 24)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Repeat New Password"
        '
        'txtNewPassword2
        '
        Me.txtNewPassword2.Location = New System.Drawing.Point(142, 104)
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.Size = New System.Drawing.Size(100, 20)
        Me.txtNewPassword2.TabIndex = 4
        Me.txtNewPassword2.UseSystemPasswordChar = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 173)
        Me.Controls.Add(Me.txtNewPassword2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.btnResetPassword)
        Me.Controls.Add(Me.txtNewPassword1)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.Controls.Add(Me.lblOldPassword)
        Me.Name = "Form1"
        Me.Text = "Password Reset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblOldPassword As Label
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtOldPassword As TextBox
    Friend WithEvents txtNewPassword1 As TextBox
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNewPassword2 As TextBox
End Class
