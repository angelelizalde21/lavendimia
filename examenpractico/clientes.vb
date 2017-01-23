Imports System.Data.SqlClient

Public Class clientes
    Dim ep As New propiedades
    Dim func As New Funciones
    Dim act_clnt As New actualizar_cliente
    Dim clave As Integer
    Dim con As New SqlConnection(My.Settings.coneccion)

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        lbl_clave.Hide()
        btn_cancelar.Hide()
        btn_guardar.Hide()
        Button2.Hide()
        TextBox1.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        fecha.Text = DateTime.Now().ToShortDateString()
        Dim sql As String = "SELECT * FROM clientes"
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "clientes")
            Me.DataGridView1.DataSource = ds.Tables("clientes")
            Me.DataGridView1.BorderStyle = BorderStyle.Fixed3D


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Show()
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()
        lbl_clave.Show()
        Dim comando As SqlCommand = New SqlCommand
        comando.CommandText = "SELECT TOP 1 clave_cliente FROM clientes ORDER BY clave_cliente DESC"
        comando.Connection = con
        con.Open()
        Dim i As Integer
        i = comando.ExecuteScalar()
        con.Close()
        lbl_clave.Text = i + 1
        btn_cancelar.Show()
        btn_guardar.Show()
        TextBox1.Show()
        TextBox2.Show()
        TextBox3.Show()
        TextBox4.Show()
        DataGridView1.Hide()
        GroupBox4.Hide()
        Button1.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        lbl_clave.Hide()
        btn_cancelar.Hide()
        btn_guardar.Hide()
        TextBox1.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        DataGridView1.Show()
        GroupBox4.Show()
        Button1.Show()
        Button2.Hide()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If TextBox1.Text = "" Then

            MessageBox.Show("No es posible continuar, debe ingresar NOMBRE es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar APELLIDO PATERNO es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar APELLIDO MATERNO es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar RFC es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Try
                ep.cod_prod = lbl_clave.Text
                ep.nombre = TextBox1.Text & " " & TextBox2.Text & " " & TextBox3.Text
                ep.rfcclient = TextBox4.Text

                If func.agregar_cliente(ep) Then
                    MessageBox.Show("Bien Hecho. El cliente ha sido registrado correctamente", "agregando cliente")
                    Label1.Hide()
                    Label2.Hide()
                    Label3.Hide()
                    Label4.Hide()
                    Label5.Hide()
                    lbl_clave.Hide()
                    btn_cancelar.Hide()
                    btn_guardar.Hide()
                    TextBox1.Hide()
                    TextBox2.Hide()
                    TextBox3.Hide()
                    TextBox4.Hide()
                    DataGridView1.Show()
                    GroupBox4.Show()
                    Button1.Show()
                    Dim sql As String = "SELECT * FROM clientes"
                    Dim cmd As New SqlCommand(sql, con)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        da.Fill(ds, "clientes")
                        Me.DataGridView1.DataSource = ds.Tables("clientes")

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                Else
                    MessageBox.Show("Cliente no agregado", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        clave = Me.DataGridView1.CurrentRow.Cells.Item("clave_cliente").Value
                editar()

    End Sub
    Sub editar()

        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        Dim con As New SqlConnection(My.Settings.coneccion)
        cmd.Connection = con
        cmd.CommandText =
    “SELECT nom_cliente FROM clientes WHERE clave_cliente = @clave”

        Dim param As System.Data.SqlClient.SqlParameter
        param = New System.Data.SqlClient.SqlParameter()
        param.ParameterName = "@clave"
        param.SqlDbType = SqlDbType.VarChar
        param.Size = 50
        param.Value = clave
        cmd.Parameters.Add(param)
        con.Open()
        Dim a As String
        a = cmd.ExecuteScalar()
        con.Close()

        cmd.CommandText =
“SELECT rfc_cliente FROM clientes WHERE clave_cliente = @clave2”

        Dim param2 As System.Data.SqlClient.SqlParameter
        param2 = New System.Data.SqlClient.SqlParameter()
        param2.ParameterName = "@clave2"
        param2.SqlDbType = SqlDbType.VarChar
        param2.Size = 50
        param2.Value = clave
        cmd.Parameters.Add(param2)
        con.Open()
        Dim b As String
        b = cmd.ExecuteScalar()
        con.Close()
        Label1.Show()
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()
        Button2.Show()
        lbl_clave.Show()
        lbl_clave.Text = clave
        btn_cancelar.Show()
        btn_guardar.Hide()
        TextBox1.Show()
        TextBox2.Show()
        TextBox3.Show()
        TextBox4.Show()
        DataGridView1.Hide()
        GroupBox4.Hide()
        Button1.Hide()
        TextBox4.Text = b
        Dim ArrCadena As String() = a.Split(" ")
        TextBox1.Text = ArrCadena(0)
        TextBox2.Text = ArrCadena(1)
        TextBox3.Text = ArrCadena(2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then

            MessageBox.Show("No es posible continuar, debe ingresar NOMBRE es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar APELLIDO PATERNO es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar APELLIDO MATERNO es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar RFC es obligatorio", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Try
                act_clnt.clave = lbl_clave.Text
                act_clnt.nombre = TextBox1.Text & " " & TextBox2.Text & " " & TextBox3.Text
                act_clnt.rfc = TextBox4.Text

                If func.actualizar_cliente(act_clnt) Then
                    MessageBox.Show("Bien Hecho. El cliente ha sido Actualizado correctamente", "Actualizando cliente")
                    Label1.Hide()
                    Label2.Hide()
                    Label3.Hide()
                    Label4.Hide()
                    Label5.Hide()
                    lbl_clave.Hide()
                    btn_cancelar.Hide()
                    btn_guardar.Hide()
                    TextBox1.Hide()
                    TextBox2.Hide()
                    TextBox3.Hide()
                    TextBox4.Hide()
                    DataGridView1.Show()
                    GroupBox4.Show()
                    Button1.Show()
                    Button2.Hide()

                    Dim sql As String = "SELECT * FROM clientes"
                    Dim cmd As New SqlCommand(sql, con)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        da.Fill(ds, "clientes")

                        Me.DataGridView1.DataSource = ds.Tables("clientes")


                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                Else
                    MessageBox.Show("Cliente no Actualizado", "Actualizando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Class