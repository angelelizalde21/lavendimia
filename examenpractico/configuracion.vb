Imports System.Data.SqlClient

Public Class configuracion
    Dim cg As New configuracion_general
    Dim func As New Funciones
    Dim con As New SqlConnection(My.Settings.coneccion)

    Private Sub configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim comando As SqlCommand = New SqlCommand
        comando.CommandText = "SELECT tasa FROM configuracion "
        comando.Connection = con
        con.Open()
        Dim i As Double
        i = comando.ExecuteScalar()
        con.Close()
        TextBox1.Text = i
        Dim comando2 As SqlCommand = New SqlCommand
        comando2.CommandText = "SELECT enganche FROM configuracion "
        comando2.Connection = con
        con.Open()
        Dim x As Double
        x = comando2.ExecuteScalar()
        con.Close()
        TextBox2.Text = x
        Dim comando3 As SqlCommand = New SqlCommand
        comando3.CommandText = "SELECT plazo FROM configuracion "
        comando3.Connection = con
        con.Open()
        Dim z As Integer
        z = comando3.ExecuteScalar()
        con.Close()
        TextBox3.Text = z

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("Rellene todos los campos", "Actualizar Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                cg.tasa = TextBox1.Text
                cg.enganche = TextBox2.Text
                cg.plazo = TextBox3.Text
                If func.configuracion_general(cg) Then
                    MessageBox.Show("Bien Hecho. La configuración ha sido registrada", "Actualizar Configuracion")
                    Me.Close()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class