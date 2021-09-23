Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblOldPassword.Click

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles lblUsername.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword1.TextChanged

    End Sub

    Private Sub BtnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        lblError.Visible = False
        lblSuccess.Visible = False
        lblPasswdError.Visible = False
        lblCatch.Visible = False
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
            lblPasswdError.Visible = True
            Exit Sub
        End If

        Using RootDSE As New DirectoryServices.DirectoryEntry("LDAP://RootDSE")
            Dim DomainDN As String = RootDSE.Properties("DefaultNamingContext").Value
            Dim parts = New System.DirectoryServices.DirectoryEntry("LDAP://CN=Partitions,CN=Configuration," & DomainDN)
            Dim NTBIOSName As String = Nothing
            For Each part In parts.Children
                If part.Properties("nCName")(0) = DomainDN Then
                    'MsgBox(part.Properties("nETBIOSName")(0))
                    NTBIOSName = part.Properties("nETBIOSName")(0)
                    MsgBox(NTBIOSName)
                    Exit For
                End If
            Next
            Dim oldpassword As String = txtOldPassword.Text
            Dim username As String = txtUsername.Text
            MsgBox(DomainDN)
            'Dim ADEntry As New System.DirectoryServices.DirectoryEntry("LDAP://" & DomainDN)
            'Dim ADSearch As New System.DirectoryServices.DirectorySearcher(ADEntry)
            'Dim ADSearchResult As System.DirectoryServices.SearchResult
            '
            'ADSearch.Filter = "(samAccountName=" & Security.Principal.WindowsIdentity.GetCurrent.Name.Split("\"c)(1) & ")"
            'ADSearch.SearchScope = SearchScope.Subtree

            'ADSearchResult = ADSearch.FindOne()
            MsgBox($"{NTBIOSName}\{username}", oldpassword)
            Dim ADEntry As New System.DirectoryServices.DirectoryEntry("LDAP://OU=Test," & DomainDN,
                                                                       NTBIOSName & "\" & username, oldpassword)

            Try
                MsgBox("Try!")
                Dim ADSearch As New System.DirectoryServices.DirectorySearcher(ADEntry) With {
                    .SearchScope = DirectoryServices.SearchScope.Subtree,
                    .Filter = "(SAMAccountName=" & username & ")"
                }
                Dim ADSearchResult As System.DirectoryServices.SearchResult
                Dim searchResult As DirectoryServices.SearchResult = ADSearch.FindOne()
                ADSearchResult = searchResult

                Dim check As String = CType(ADSearchResult.Properties("SAMAccountName")(0), String)
                If check = Nothing Then MsgBox("Check is nothing!")
                If check <> Nothing Then
                    MsgBox("Check is not nothing!")
                    If check = username Then
                        MsgBox("Check is username!" & check & username)
                        Dim newpassword1 As String = txtNewPassword1.Text
                        Dim newpassword2 As String = txtNewPassword2.Text
                        If newpassword1 = newpassword2 Then
                            MsgBox("Usernames match!" & oldpassword & newpassword1 & newpassword2)
                            ADEntry = ADSearchResult.GetDirectoryEntry()
                            ADEntry.Username = NTBIOSName & "\" & check
                            MsgBox(ADEntry.Username)
                            ADEntry.Password = oldpassword
                            ADEntry.AuthenticationType = DirectoryServices.AuthenticationTypes.Secure
                            ADEntry.Options.Referral = DirectoryServices.ReferralChasingOption.All
                            ADEntry.Invoke("ChangePassword", oldpassword, newpassword1)
                            ADEntry.CommitChanges()
                            lblSuccess.Visible = "Password Changed."
                        Else
                            lblPasswdError.Visible = True
                        End If
                    Else
                        lblError.Visible = True
                    End If
                Else
                    lblError.Visible = True
                End If

                'If Not IsNothing(ADSearchResult) Then
                'MsgBox("Hello!")
                'MsgBox(DomainDN)
                'MsgBox(username)
                'MsgBox(oldpassword)
                'MsgBox(newpassword1)

                'Dim myUser As System.DirectoryServices.DirectoryEntry = New System.DirectoryServices.DirectoryEntry()
                'myUser.Path = ADSearchResult.GetDirectoryEntry().Path
                'myUser.AuthenticationType = System.DirectoryServices.AuthenticationTypes.Secure
                'Dim ret As Object = myUser.Invoke("ChangePassword", oldpassword, newpassword1)
                'myUser.CommitChanges()
                'myUser.Close()

                'newpassword1 = True

                MsgBox("Password Changed.", MsgBoxStyle.Information, "Password Changed")

                Me.Close()
                'End If
                'End Using
            Catch ex As Exception
                MsgBox("Fails 3!")
                lblCatch.Text = "Error message: " + ex.InnerException.Message
                lblCatch.Visible = True
            End Try
        End Using
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtOldPassword.TextChanged

    End Sub

    Private Sub Label1_Click_2(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtNewPassword2.TextChanged

    End Sub
End Class
