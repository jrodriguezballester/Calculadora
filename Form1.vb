Public Class Form1

    Private operacion As String
    Private primerOperando As Double
    Private segundoOperando As Double
    Private pendienteOperacion As Boolean
    Private resultado As String
    Private pulsado As Boolean
    Private porcentaje As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Concatenar()
        Display.Text &= "1"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Concatenar()
        Display.Text &= "2"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Concatenar()
        Display.Text &= "3"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Concatenar()
        Display.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Concatenar()
        Display.Text &= "5"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Concatenar()
        Display.Text &= "6"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Concatenar()
        Display.Text &= "7"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Concatenar()
        Display.Text &= "8"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Concatenar()
        Display.Text &= "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Concatenar()
        Display.Text &= "0"
    End Sub

    Private Sub Button_Punto_Click(sender As Object, e As EventArgs) Handles Punto.Click
        Concatenar()
        If Display.Text = "" Then
            Display.Text &= "0."
        End If
        If Not Display.Text.Contains(".") Then
            Display.Text &= "."
        End If
    End Sub


    Private Sub Concatenar()
        ' casos posibles
        'inicio (marca 0)
        If Display.Text = "0" Then
            Display.Text = ""
        End If

        'Despues de texto
        If Display.Text = "Error Division por 0" Then
            Display.Text = ""
        End If
        'Despues de pulsar operador, igual,.... ==> pulsado=true
        If pulsado Then
            Display.Text = ""
            pulsado = False
        End If

    End Sub

    Private Sub Button_C_Click(sender As Object, e As EventArgs) Handles Button_C.Click
        Display.Text = "0"
    End Sub


    Private Sub GuardarOperacion(operador As String)
        If pendienteOperacion Then
            CalcularOperacion()
        End If
        operacion = operador
        Try
            primerOperando = Display.Text
        Catch
            Display.Text = 0
            primerOperando = Display.Text
        End Try
        'Display.Text = ""
        pendienteOperacion = True
    End Sub

    Private Sub CalcularOperacion()
        'Calcula la operacion  
        If porcentaje Then
            segundoOperando = primerOperando * Display.Text / 100
        Else
            segundoOperando = Display.Text
        End If

        Select Case operacion
            Case "+"
                resultado = primerOperando + segundoOperando
            Case "-"
                resultado = primerOperando - segundoOperando
            Case "*"
                resultado = primerOperando * segundoOperando
            Case "/"
                If segundoOperando = 0 Then
                    resultado = "Error Division por 0"
                Else
                    resultado = primerOperando / segundoOperando
                End If
            Case Else
                resultado = segundoOperando
        End Select
        Display.Text = resultado
        ' y ademas
        primerOperando = Nothing
        segundoOperando = Nothing
        pendienteOperacion = False
        porcentaje = False

    End Sub

    Private Sub ButtonIgual_Click(sender As Object, e As EventArgs) Handles ButtonIgual.Click
        pulsado = True
        CalcularOperacion()

    End Sub

    Private Sub ButtonResta_Click(sender As Object, e As EventArgs) Handles ButtonResta.Click
        Dim operador = "-"
        pulsado = True
        GuardarOperacion(operador)
    End Sub

    Private Sub ButtonMultiplicacion_Click(sender As Object, e As EventArgs) Handles ButtonMultiplicacion.Click
        Dim operador = "*"
        pulsado = True
        GuardarOperacion(operador)
    End Sub

    Private Sub ButtonDivision_Click(sender As Object, e As EventArgs) Handles ButtonDivision.Click
        Dim operador = "/"
        pulsado = True
        GuardarOperacion(operador)
    End Sub

    Private Sub ButtonSumar_Click(sender As Object, e As EventArgs) Handles ButtonSumar.Click
        Dim operador = "+"
        pulsado = True
        GuardarOperacion(operador)
    End Sub

    Private Sub ButtonMasMenos_Click(sender As Object, e As EventArgs) Handles ButtonMasMenos.Click
        Display.Text = -Display.Text
    End Sub

    Private Sub Button_CE_Click(sender As Object, e As EventArgs) Handles Button_CE.Click
        If Display.Text.Length > 0 Then
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1)
        End If
    End Sub

    Private Sub ButtonInversa_Click(sender As Object, e As EventArgs) Handles ButtonInversa.Click
        Display.Text = 1 / Display.Text
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim culture As New System.Globalization.CultureInfo("es-ES")
        culture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = culture
    End Sub

    Private Sub ButtonPorcentaje_Click(sender As Object, e As EventArgs) Handles ButtonPorcentaje.Click
        ' pendiente operacion debe ser true
        If pendienteOperacion Then
            porcentaje = True
            CalcularOperacion()
        End If


    End Sub
End Class
