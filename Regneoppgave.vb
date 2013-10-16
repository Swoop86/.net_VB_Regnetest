Public Class Regneoppgave
    'Oppretter en ny variabel for random, samt initialiserer randomiseren
    Dim random As New Random

    'Oppretter variabel for antall rette
    Dim intRette As Integer

    'oppretter variabel for antall forsøk som brukeren har feilet på
    Dim intFors0kFeil As Integer

    'oppretter en variabel for antall forsøk brukt
    Dim intFors0k As Integer

    'oppretter variabel for telling av oppgavenummer
    Dim intOppgaveTeller As Integer

    'oppretter variabel for hvor mange ganger brukeren ønsker å løse oppgaver
    Dim strSvar As String
    Dim intAntall As Integer

    'oppretter tallene som det skal velges fra og velger tilfeldige tall, og setter verdi til variablene
    'random genereres som double, derfor konverteres den lenger ned
    Dim tall1 As Integer = random.Next(1, 10)
    Dim tall2 As Integer = random.Next(1, 10)


    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        strSvar = InputBox("Hvor mange oppgaver ønsker du å løse?") 'Spør bruker hvor mange oppgaver han vil ha

        cmdSvar.Visible = True ' Viser knappen og tekstboksen
        txtSvar.ReadOnly = False

        If Integer.TryParse(strSvar, 0) Then 'Sjekker om svaret er et tall
            intAntall = Convert.ToInt16(strSvar) 'Konverterer stringverdien til integer
        Else
            MsgBox("Du må oppgi et heltall!")
        End If


        'Setter startverdi på variablene, og nullstiller
        intOppgaveTeller = 1
        intFors0k = 1
        intFors0kFeil = 0

        'setter teksten til oppgavenr og hvilke tall som skal plusses
        lblOppgave.Text = "Oppgave nr: " & intOppgaveTeller & "  " & tall1 & " + " & tall2

        cmdStart.Visible = False ' Skjuler startknappen

    End Sub

    Private Sub cmdSvar_Click(sender As Object, e As EventArgs) Handles cmdSvar.Click


        If intFors0k < intAntall Then

            If Integer.TryParse(txtSvar.Text, 0) Then

                'Hvis det er et tall oppgitt, og verdien er riktig
                If Convert.ToInt16(txtSvar.Text) = tall1 + tall2 Then 'Konverterer fra double til integer
                    txtSvar.Text = "" 'Setter blank tekst og gjør klar til neste input
                    intRette += 1 'Legger til verdi
                    lblRette.Text = Convert.ToString(intRette)

                    txtSvar.Focus() 'Setter fokus til tekstboksen

                    intFors0k += 1 ' Legger til 1 i forsøk, så programmet avsluttes når brukeren har nådd sitt antall
                    intOppgaveTeller += 1 ' Legger til 1 i oppgavenummer

                    lblRette.Text = Convert.ToString(intRette)

                    tall1 = random.Next(1, 10) 'Genererer nye tall
                    tall2 = random.Next(1, 10)

                    lblOppgave.Text = "Oppgave nr: " & intOppgaveTeller & "  " & tall1 & " + " & tall2 ' Setter ny oppgavetekst
                ElseIf Not Convert.ToInt16(txtSvar.Text) = tall1 + tall2 Then
                    txtSvar.Text = ""
                    txtSvar.Focus()
                    intFors0k += 1
                    intFors0kFeil += 1
                    lblForsøk.Text = Convert.ToString(intFors0kFeil)
                    MsgBox("Beklager, du regnet feil!")
                End If

            Else
                MsgBox("Du må skrive et tall!")
            End If

        Else
            MsgBox("Du har brukt opp alle forsøkene dine")
            cmdStart.Visible = True ' Viser startknappen igjen
        End If




    End Sub

    Private Sub Regneoppgave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSvar.Visible = False ' Skjuler knappen, så brukeren ikke kan svare før han trykker på start
        txtSvar.ReadOnly = True 'Gjør tekstfeltet read-only så brukeren ikke kan skrive noe før han trykker start
    End Sub
End Class
