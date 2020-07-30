Public Class ResultadoParcial
    Dim Resultado As Integer
    Function CalculoParcial(a, b, c, d, e, h, i)
        Resultado = a
        If b = "+" Then
            Resultado = a + c
        End If
        If b = "-" Then
            Resultado = a - c
        End If
        If b = "*" Then
            Resultado = a * c
        End If
        If b = "/" Then
            Resultado = a / c
        End If

        If d = "+" Then
            Resultado = Resultado + e
        End If
        If d = "-" Then
            Resultado = Resultado - e
        End If
        If d = "*" Then
            Resultado = Resultado * e
        End If
        If d = "/" Then
            Resultado = Resultado / e
        End If


        If h = "+" Then
            Resultado = Resultado + i
        End If
        If h = "-" Then
            Resultado = Resultado - i
        End If
        If h = "*" Then
            Resultado = Resultado * i
        End If
        If h = "/" Then
            Resultado = Resultado / i
        End If
        Return Resultado
    End Function
End Class
