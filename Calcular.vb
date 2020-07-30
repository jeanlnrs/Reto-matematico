Public Class Calcular
    Dim Resultado As Integer
    Function CalculoDeVectors(a, b, c)
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
        Return Resultado
    End Function
End Class
