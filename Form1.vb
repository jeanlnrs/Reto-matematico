Public Class Form1
    Dim vTxt(7) As TextBox 'Dim = funcion para declarar variable
    Dim vTxtpos(4) As Button
    Dim Pos As Integer = 0
    Dim PosBo As Boolean = True
    Dim vTxt1(7) As TextBox
    Dim vBtn(8) As Button
    Dim vOpr(4) As String
    Dim Calcularm As New Calcular()
    Dim CalculoParcialm As New ResultadoParcial()
    Dim rnd As Random = New Random()
    Dim rnd1 As Random = New Random()
    Dim rnd2 As Random = New Random()
    Dim i As Integer
    Dim j As Integer
    Dim Segundos As Integer = 61

    'DECLARACIONES
    Public Sub New()
        InitializeComponent()
        vTxt = New TextBox() {TxtNum1, TxtNum2, TxtNum3, TxtNum4, TxtNum5, TxtNum6, TxtNum7}
        vTxt1 = New TextBox() {T1, T2, T3, T4, T5, T6, T7}
        vBtn = New Button() {BtnNum1, BtnNum2, BtnNum3, BtnNum4, BtnNum5, BtnNum6, BtnNum7, BtnNum8}
        vOpr = New String() {"+", "-", "*", "/"}
        TxtIndice.Text = (0)
    End Sub
    'TIMER
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Segundos = 0 Then
            Timer1.Enabled = False
            MsgBox("El Juego a Terminado", MsgBoxStyle.Exclamation)
            Me.Close()
        Else
            Segundos = Segundos - 1
            TimerTxt.Text = Segundos
        End If

        'Desacierto
        If (Val(vTxt(6).Text = "")) Then

        Else
            Timer1.Stop()
            If (TxtResultadoParcial.Text) <> (TxtResultado.Text) Then
                MsgBox("No acertastes, Intentalo nuevamente", MsgBoxStyle.Exclamation)
            End If
        End If
        'Acierto
        If (Val(vTxt(6).Text = "")) Then
        Else
            If (TxtResultadoParcial.Text) = (TxtResultado.Text) Then
                TxtAcierto.Text = Val(TxtAcierto.Text) + 1
                TimerTxt.Text = Val(TimerTxt.Text) + 40
                Segundos = TimerTxt.Text
                BtnNext.Enabled = True
                BtnLimpiar.Enabled = False
                BtnInicio.Enabled = False
                BtnAns.Enabled = False
                BtnLimpiarUno.Enabled = False
                Timer1.Stop()
                MsgBox("Ha obtenido " & TxtAcierto.Text + " Acierto(s)")
                For i = 0 To 3
                    vBtn(i).Enabled = False
                Next
                PanelBlock.Enabled = False
                TimerTxt.Text = Segundos
            End If
        End If

        If (Val(TimerTxt.Text) = "10") Then
            BtnInicio.Enabled = False
            TextdTimer.ForeColor = Color.Red
            BtnAns.BackColor = Color.Blue
            BtnAns.ForeColor = Color.White
        End If

        If TextdTimer.Text = "Tiempo Restante:" Then
            TextdTimer.Text = ""
        Else
            TextdTimer.Text = "Tiempo Restante:"
        End If
    End Sub
    'BOTONES DE ACCION
    Private Sub BtnInicio_Click(sender As Object, e As EventArgs) Handles BtnInicio.Click  '<-Metodo del btn inicio
        TxtIndice.Text = (0)
        Timer1.Start()
        TimerTxt.Visible = True
        TextdTimer.Visible = True
        BtnInicio.Enabled = False
        BtnAns.Enabled = True
        BtnInicio.BackColor = Color.Blue

        For i = 0 To 3
            vBtn(i).Enabled = True
            PanelBlock.Enabled = False
        Next

        vBtn(4).Text = vOpr(0)
        vBtn(5).Text = vOpr(1)
        vBtn(6).Text = vOpr(2)
        vBtn(7).Text = vOpr(3)

        vTxt1(1).Text = vOpr(rnd2.Next(0, 4))
        vTxt1(3).Text = vOpr(rnd2.Next(0, 4))
        vTxt1(5).Text = vOpr(rnd2.Next(0, 4))

        RndBtn()
        AsignValVtxt1()
        CalcValVtxt1()
    End Sub
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        TxtIndice.Text = (0)
        Pos = 0
        BtnNext.Enabled = False
        BtnAns.Enabled = True
        Timer1.Start()
        RndBtn()
        For i = 0 To 3
            vBtn(i).Enabled = True
        Next
        OcultarvTxt1()
        TxtClear()
        AsignValVtxt1()
        CalcValVtxt1()
    End Sub
    Private Sub BtnLimpiarUno_Click(sender As Object, e As EventArgs) Handles BtnLimpiarUno.Click
        Timer1.Start()
        vTxt(TxtIndice.Text - 1).Text = ""
        vBtn(TxtIndice.Text - 1).Tag = 0
        TxtIndice.Text = TxtIndice.Text - 1

        If (TxtIndice.Text = 0) Then
            MsgBox("No puede borrar mas")
            BtnLimpiarUno.Enabled = False
        End If

        If (PosBo) Then
            PosBo = False
            PanelBlock.Enabled = True
        Else
            vTxtpos(Pos - 1).Enabled = True
            Pos -= 1
            PosBo = True
            PanelBlock.Enabled = False
        End If

    End Sub
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Pos = 0
        TxtIndice.Text = (0)
        Timer1.Start()
        TxtClear()

        For i = 0 To 3
            vBtn(i).Tag = "0" 'Habilitar NUM
        Next

        For i = 0 To 3
            vBtn(i).Enabled = True
            PanelBlock.Enabled = False
        Next

        OcultarvTxt1()

    End Sub
    Private Sub BtnAns_Click(sender As Object, e As EventArgs) Handles BtnAns.Click
        Timer1.Stop()
        BtnAns.Enabled = False
        BtnNext.Enabled = True

        For i = 0 To 3
            vBtn(i).Enabled = False 'Habilitar NUM

        Next

        For i = 0 To 6
            If vTxt1(i).Visible = False Then
                For j = 0 To 6
                    vTxt1(j).Visible = True
                Next
            End If
        Next
        MsgBox("Seleccione boton Siguiente")
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
    'Sub rutinas
    Private Sub OcultarvTxt1()
        For i = 0 To 6
            If vTxt1(i).Visible = True Then
                For j = 0 To 6
                    vTxt1(j).Visible = False
                Next
            End If
        Next
    End Sub
    Private Sub Llenar(ByVal n As Integer)
        If (vTxt(6).Text = "") Then
            vTxt(TxtIndice.Text).Text = vBtn(n).Text
            TxtIndice.Text = TxtIndice.Text + 1
            vBtn(n).Tag = "1" 'Habilitar NUM
            BtnLimpiar.Enabled = True
            BtnLimpiarUno.Enabled = True
            DesNum() 'habilitar operadores 
            'Timer1.Start()
        Else
            MessageBox.Show("Esta Lleno")
            For i = 0 To 6
                PanelBlock.Enabled = False
            Next
        End If
    End Sub
    Private Sub DesNum()
        For i = 0 To 3 ' deshabilita numeros 
            vBtn(i).Enabled = False
            PanelBlock.Enabled = True
        Next
    End Sub
    Private Sub HabNum(ByVal n As Integer) 'Habilitar NUM
        For i = 0 To 3
            If vBtn(i).Tag = 0 Then
                vBtn(i).Enabled = True
                PanelBlock.Enabled = False
            End If
        Next
    End Sub
    Private Sub ResultadoParcial()
        TxtResultadoParcial.Text = CalculoParcialm.CalculoParcial(Val(vTxt(0).Text), (vTxt(1).Text), Val(vTxt(2).Text), (vTxt(3).Text), Val(vTxt(4).Text), (vTxt(5).Text), Val(vTxt(6).Text))
    End Sub
    Private Sub AsignValVtxt1()
        vTxt1(0).Text = vBtn(0).Text
        vTxt1(1).Text = vOpr(rnd2.Next(0, 4))
        vTxt1(2).Text = vBtn(1).Text
        vTxt1(3).Text = vOpr(rnd2.Next(0, 4))
        vTxt1(4).Text = vBtn(2).Text
        vTxt1(5).Text = vOpr(rnd2.Next(0, 4))
        vTxt1(6).Text = vBtn(3).Text
    End Sub
    Private Sub CalcValVtxt1()
        TxtResultado.Text = Calcularm.CalculoDeVectors(Val(vTxt1(0).Text), (vTxt1(1).Text), Val(vTxt1(2).Text))
        TxtResultado.Text = Calcularm.CalculoDeVectors(Val(TxtResultado.Text), (vTxt1(3).Text), Val(vTxt1(4).Text))
        TxtResultado.Text = Calcularm.CalculoDeVectors(Val(TxtResultado.Text), (vTxt1(5).Text), Val(vTxt1(6).Text))
    End Sub
    Private Sub RndBtn()
        For i = 0 To 3
            vBtn(i).Text = rnd.Next(1, 20)
            vBtn(i).Tag = "0" 'Habilitar NUM
        Next
    End Sub
    Private Sub TxtClear()
        For i = 0 To 6
            vTxt(i).Clear()
            TxtResultadoParcial.Text = ""
        Next
    End Sub
    'BOTONES NUMEROS Y OPERADORES
    Private Sub BtnNum1_Click(sender As Object, e As EventArgs) Handles BtnNum1.Click
        Llenar(0)
        ResultadoParcial()
        vTxtpos(Pos) = BtnNum1
        Pos += 1
        PosBo = False
    End Sub
    Private Sub BtnNum2_Click(sender As Object, e As EventArgs) Handles BtnNum2.Click
        Llenar(1)
        ResultadoParcial()
        vTxtpos(Pos) = BtnNum2
        Pos += 1
        PosBo = False
    End Sub
    Private Sub BtnNum3_Click(sender As Object, e As EventArgs) Handles BtnNum3.Click
        Llenar(2)
        ResultadoParcial()
        vTxtpos(Pos) = BtnNum3
        Pos += 1
        PosBo = False
    End Sub
    Private Sub BtnNum4_Click(sender As Object, e As EventArgs) Handles BtnNum4.Click
        Llenar(3)
        ResultadoParcial()
        vTxtpos(Pos) = BtnNum4
        Pos += 1
        PosBo = False
    End Sub
    Private Sub BtnNum5_Click(sender As Object, e As EventArgs) Handles BtnNum5.Click
        Llenar(4)
        HabNum(0) 'Habilitar NUM
        PosBo = True
    End Sub
    Private Sub BtnNum6_Click(sender As Object, e As EventArgs) Handles BtnNum6.Click
        Llenar(5)
        HabNum(1) 'Habilitar NUM
        PosBo = True
    End Sub
    Private Sub BtnNum7_Click(sender As Object, e As EventArgs) Handles BtnNum7.Click
        Llenar(6)
        HabNum(2) 'Habilitar NUM
        PosBo = True
    End Sub
    Private Sub BtnNum8_Click(sender As Object, e As EventArgs) Handles BtnNum8.Click
        Llenar(7)
        HabNum(3) 'Habilitar NUM
        PosBo = True
    End Sub

    Private Sub TextdTimer_Click(sender As Object, e As EventArgs) Handles TextdTimer.Click

    End Sub
End Class
