Public Class Form1

    Private operacion As String
    Private primerOperando As Double
    Private segundoOperando As Double
    Private pendienteOperacion As Boolean
    Private resultado As String
    Private pulsado As Boolean
    Private porcentaje As Boolean


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

        If Display.Text = "Aun no se calcular ese factorial" Then
            Display.Text = ""
        End If
        'Despues de pulsar operador, igual,.... ==> pulsado=true
        If pulsado Then
            Display.Text = ""
            pulsado = False
        End If

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
            Case "x^y"
                resultado = Math.Pow(primerOperando, segundoOperando)
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


    Private Sub Calculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim culture As New System.Globalization.CultureInfo("es-ES")
        culture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = culture
        Size = New Size(395, 430)
        ButtonIgual.Size = New Size(346, 52)
        Button12.Hide()
        Button13.Hide()
    End Sub

    Private Sub ButtonPorcentaje_Click(sender As Object, e As EventArgs) Handles ButtonPorcentaje.Click
        ' pendiente operacion debe ser true
        If pendienteOperacion Then
            porcentaje = True
            CalcularOperacion()
        End If
    End Sub

    Private Sub Opcion_standard_click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        Size = New Size(395, 430)
        ButtonIgual.Size = New Size(346, 52)
        Display.Size = New Size(346, 30)
        Button12.Hide()
        Button13.Hide()
    End Sub

    Private Sub Opcion_cientifica_click(sender As Object, e As EventArgs) Handles CientificaToolStripMenuItem.Click
        Size = New Size(480, 430)
        ButtonIgual.Size = New Size(182, 52)
        Display.Size = New Size(425, 30)
        Button12.Show()
        Button13.Show()

    End Sub



    Private Sub Numeros_click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click
        Concatenar()
        Display.Text &= sender.Text
    End Sub


    Private Sub Operacion_dos_operandos_click(sender As Object, e As EventArgs) Handles ButtonX_ElevadoY.Click, ButtonSumar.Click, ButtonResta.Click, ButtonMultiplicacion.Click, ButtonDivision.Click
        Dim operador = sender.Text
        pulsado = True
        GuardarOperacion(operador)
    End Sub


    Private Sub Operacion_un_operando_click(sender As Object, e As EventArgs) Handles ButtonMasMenos.Click, ButtonInversa.Click, ButtonFactorial.Click, ButtonCubo.Click, ButtonCuadrado.Click, Button13.Click, Button12.Click, Button11.Click, Button_CE.Click, Button_C.Click, Button14.Click
        Dim x = Display.Text
        Dim numDouble As Double
        resultado = 0
        If Double.TryParse(Display.Text, numDouble) Then
            Select Case sender.text
                Case "sen"
                    resultado = Math.Sin(x)
                Case "cos"
                    resultado = Math.Cos(x)
                Case "tan"
                    resultado = Math.Tan(x)
                Case "±"
                    resultado = -x
                Case "x^2"
                    resultado = Math.Pow(x, 2)
                Case "x^3"
                    resultado = Math.Pow(x, 3)
                Case "n!"
                    Dim operando As Integer
                    If (Integer.TryParse(Display.Text, operando)) Then
                        operando = Display.Text
                        If operando >= 0 Then
                            resultado = 1
                            For index = 2 To operando
                                resultado = resultado * index
                            Next
                        Else
                            resultado = "Aun no se calcular ese factorial"
                        End If
                    Else
                        resultado = "Aun no se calcular ese factorial"
                    End If
                Case "1/x"
                    resultado = 1 / resultado
                Case "←"
                    If Display.Text.Length > 0 Then
                        resultado = Display.Text.Substring(0, Display.Text.Length - 1)
                    End If
                Case "CE"
                    resultado = 0
                Case "C"
                    resultado = 0
                    primerOperando = Nothing
                    segundoOperando = Nothing
                    pendienteOperacion = False
                    porcentaje = False
            End Select
            'Display.Text = resultado
        End If
        Display.Text = resultado
    End Sub
End Class
