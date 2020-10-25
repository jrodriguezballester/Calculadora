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

    ''' <summary>
    ''' Método para permitir concatenar texto (numeros) en el display
    ''' </summary>
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
        If Display.Text = "No se ese factorial" Then
            Display.Text = ""
        End If
        If Display.Text = "NaN" Then
            Display.Text = ""
        End If
        If Display.Text = "∞" Then
            Display.Text = ""
        End If
        ' posible codigo para controlar que sea cualquier texto, falta depurar no funciona correctamente
        'Try
        'Convert.ToDouble(Display.Text)
        'Catch Ex As Exception
        'Display.Text = ""
        ' End Try

        'Despues de pulsar operador, igual,.... ==> pulsado=true
        If pulsado Then
            Display.Text = ""
            pulsado = False
        End If

    End Sub
    ''' <summary>
    ''' Si ya habia una operacion pendiente la calcula.
    ''' Guarda el primer operador (numero) 
    ''' </summary>
    ''' <param name="operador"></param>
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
    ''' <summary>
    ''' Obtiene el segundo operador y realiza la operacion
    ''' </summary>
    Private Sub CalcularOperacion()
        'Calcula la operacion  
        If porcentaje Then
            segundoOperando = primerOperando * Display.Text / 100
            If operacion IsNot "+" And operacion IsNot "-" Then
                operacion = ""
            End If

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

    ''' <summary>
    ''' Inicio de la aplicacion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Calculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim culture As New System.Globalization.CultureInfo("es-ES")
        culture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = culture
        Size = New Size(330, 375)
        'ButtonIgual.Size = New Size(225, 52)
        Label2.Hide()
        Label1.Hide()
    End Sub

    Private Sub ButtonPorcentaje_Click(sender As Object, e As EventArgs) Handles ButtonPorcentaje.Click
        ' pendiente operacion debe ser true
        If pendienteOperacion Then
            porcentaje = True
            CalcularOperacion()
        Else
            Display.Text = "Vea Ayuda"
        End If
    End Sub

    Private Sub Opcion_standard_click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        Size = New Size(330, 375)
    End Sub

    Private Sub Opcion_cientifica_click(sender As Object, e As EventArgs) Handles CientificaToolStripMenuItem.Click
        Size = New Size(470, 375)
    End Sub
    ''' <summary>
    ''' Botones de los Numeros con el evento click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Numeros_click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click
        Concatenar()
        Display.Text &= sender.Text
    End Sub

    ''' <summary>
    ''' Metodo asignado a las operaciones que necesitan dos numeros como por ejemplo: a + b
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Operacion_dos_operandos_click(sender As Object, e As EventArgs) Handles ButtonX_ElevadoY.Click, ButtonSumar.Click, ButtonResta.Click, ButtonMultiplicacion.Click, ButtonDivision.Click
        Dim operador = sender.Text
        pulsado = True
        GuardarOperacion(operador)
    End Sub

    ''' <summary>
    ''' Método asignado a los botones que solo necesitan un numero (o el display) por ejemplo: seno de x ;
    ''' dan el resultado en pantalla sin necesidad de apretar otro boton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Operacion_un_operando_click(sender As Object, e As EventArgs) Handles ButtonMasMenos.Click, ButtonInversa.Click, ButtonFactorial.Click, ButtonCubo.Click, ButtonCuadrado.Click, Button13.Click, Button12.Click, Button11.Click, Button_CE.Click, Button_C.Click, Button14.Click, Button17.Click, Button16.Click, Button15.Click

        Dim numDouble As Double
        resultado = 0
        If Double.TryParse(Display.Text, numDouble) Then
            Dim x = Display.Text
            Dim Xrad = x * (Math.PI / 180) ' Pasar a radianes para calculo trigonometrico
            Select Case sender.text
                Case "sen"
                    resultado = Math.Sin(Xrad)
                Case "cos"
                    resultado = Math.Cos(Xrad)
                Case "tan"
                    resultado = Math.Tan(Xrad)
                Case "sen–¹"
                    resultado = Math.Asin(x) * 180 / Math.PI
                Case "cos–¹"
                    resultado = Math.Acos(x) * 180 / Math.PI
                Case "tan–¹"
                    resultado = Math.Atan(x) * 180 / Math.PI
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
                            resultado = "No se ese factorial"
                        End If
                    Else
                        resultado = "No se ese factorial"
                    End If
                Case "1/x"
                    If x = 0 Then
                        resultado = "Error Division por 0"
                    Else
                        resultado = 1 / x
                    End If

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

    Private Sub OperacionConToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionConToolStripMenuItem.Click
        Ayuda.Show()
    End Sub

    Private Sub maxcaracter(sender As Object, e As EventArgs) Handles Display.TextChanged
        If Display.TextLength > 17 Then
            Label1.Show()
            Label2.Show()
            Label1.Text = Display.TextLength - 17
        Else
            Label2.Hide()
            Label1.Hide()
        End If
    End Sub

    Private Sub PantallaLlenaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PantallaLlenaToolStripMenuItem.Click
        Ayuda2.LabelAyuda.Text = "Si el numero es mayor del display,se muestra una etiqueta:
* 10 elevado al numero de digitos ocultos"
        Ayuda2.Size = New Size(600, 200)
        Ayuda2.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Ayuda2.LabelAyuda.Text = "Calculadora version 5.0.0
Lenguaje: Visual Basic
Autor: Jose Rodriguez"
        Ayuda2.Size = New Size(300, 200)
        Ayuda2.ShowDialog()
    End Sub

    Private Sub ButtonVistaStandard_Click(sender As Object, e As EventArgs) Handles ButtonVistaStandard.Click
        Size = New Size(330, 375)
    End Sub


End Class
