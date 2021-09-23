Public Class Form1
    Private Sub BtnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        'lblDomainName.Visible = False
        'lblNetBiosName.Visible = False
        'lblPasswdError.Visible = False
        'lblCatch.Visible = False
        'Dim defaultNamingContext As String

        If txtUsername.Text = "" Then
            MsgBox("Please Enter Username!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If txtOldPassword.Text = "" Then
            MsgBox("Please Enter Current / Old Password!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If txtNewPassword1.Text = "" Then
            MsgBox("Please Enter New Password!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If txtNewPassword2.Text = "" Then
            MsgBox("Please Confirm New Password!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        ElseIf txtNewPassword1.Text <> txtNewPassword2.Text Then
            MsgBox("Passwords must match, please try again.", MsgBoxStyle.Critical, "Error")
            'lblPasswdError.Visible = True
            Exit Sub
        End If

        Dim username As String = txtUsername.Text
        Dim oldpassword As String = txtOldPassword.Text
        Dim newpassword1 As String = txtNewPassword1.Text
        Dim newpassword2 As String = txtNewPassword2.Text
        Dim objNETBiosName As String = Nothing

        Using RootDSE As New DirectoryServices.DirectoryEntry("LDAP://RootDSE")
            Dim objDomainName As String = RootDSE.Properties("DefaultNamingContext").Value
            Dim parts = New DirectoryServices.DirectoryEntry("LDAP://CN=Partitions,CN=Configuration," & objDomainName)
            Dim objUserPath = New DirectoryServices.DirectoryEntry("LDAP://OU=UK-GLW-GLASGOW,OU=UK,OU=Employees," & objDomainName)
            MsgBox(objDomainName)

            For Each part In parts.Children
                If part.Properties("nCName")(0) = objDomainName Then
                    objNETBiosName = part.Properties("nETBIOSName")(0)
                    MsgBox(objNETBiosName)
                    Exit For
                End If
            Next

            Dim objUserSearch As New DirectoryServices.DirectorySearcher(objUserPath)
            objUserSearch.SearchScope = DirectoryServices.SearchScope.Subtree
            objUserSearch.Filter = "(SAMAccountName=" & username & ")"
            Dim objUserSearchResult As DirectoryServices.SearchResult = objUserSearch.FindOne()

            Dim objCheck As String = CType(objUserSearchResult.Properties("SAMAccountName")(0), String)
            If objCheck <> Nothing Then
                If objCheck = username Then 'MsgBox("Check equals username!")
                    objUserPath = objUserSearchResult.GetDirectoryEntry()
                    objUserPath.Username = objNETBiosName & "\" & objCheck
                    MsgBox(objUserPath.Username)
                    objUserPath.Password = oldpassword
                    objUserPath.AuthenticationType = DirectoryServices.AuthenticationTypes.Secure
                    objUserPath.Options.Referral = DirectoryServices.ReferralChasingOption.All
                    objUserPath.Invoke("ChangePassword", oldpassword, newpassword1)
                    objUserPath.CommitChanges()
                End If
            End If


        End Using




    End Sub
End Class
