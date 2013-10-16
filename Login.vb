Public Class Login
    'setter variablen utenfor knappen, så ikke verdien nullstilles ved hvert klikk
    Dim teller As Integer

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        'her kan passordet være alt mulig rart, så det blir ikke utført sjekk om det er numerisk
        'tall osv. enkel if test som tillater brukeren å gå videre
        'teller 3 ganger, dersom feil passord er oppgitt mer enn 3 ganger, avsluttes programmet



        If txtPassord.Text = "filip" Then
            Regneoppgave.Show()
            Me.Hide()
        Else
            ErrorProvider1.SetError(txtPassord, "Feil passord!")
            teller += 1
        End If

        If teller >= 3 Then
            End
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassord.Select() 'Setter tekstboksen i fokus
    End Sub
End Class
