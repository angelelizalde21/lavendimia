Imports System.Data.SqlClient

Public Class articulos
    Dim con As New SqlConnection(My.Settings.coneccion)
    Dim pa As New propiedades_articulos
    Dim func As New Funciones
    Dim act_art As New actualizar_articulo
    Dim clave As String

    Private Sub articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        lbl_clave.Hide()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        TextBox1.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        fecha.Text = DateTime.Now().ToShortDateString()

        Dim sql As String = "SELECT clave_articulo,desc_articulo FROM articulos"
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "articulos")
            Me.DataGridView1.DataSource = ds.Tables("articulos")

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
        comando.CommandText = "SELECT TOP 1 clave_articulo FROM articulos ORDER BY clave_articulo DESC"
        comando.Connection = con
        con.Open()
        Dim i As Integer
        i = comando.ExecuteScalar()
        con.Close()
        lbl_clave.Text = i + 1
        Button2.Show()
        Button3.Show()
        TextBox1.Show()
        TextBox2.Show()
        TextBox3.Show()
        TextBox4.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DataGridView1.Hide()
        GroupBox4.Hide()
        Button1.Hide()
        GroupBox1.Text = "Registro de Articulos"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        lbl_clave.Hide()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        TextBox1.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        DataGridView1.Show()
        GroupBox4.Show()
        Button1.Show()
        GroupBox1.Text = "Articulos Registrados"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar DESCRIPCION es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar MODELO es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar PRECIO es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar EXISTENCIA es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else
            Try
                pa.cod_prod = lbl_clave.Text
                pa.descripcion = TextBox1.Text
                pa.modelo = TextBox2.Text
                pa.precio = TextBox3.Text
                pa.existencia = TextBox4.Text
                If func.agregar_articulo(pa) Then
                    MessageBox.Show("Bien Hecho. El Articulo ha sido registrado correctamente", "Agregando Articulo")
                    Label1.Hide()
                    Label2.Hide()
                    Label3.Hide()
                    Label4.Hide()
                    Label5.Hide()
                    lbl_clave.Hide()
                    Button2.Hide()
                    Button3.Hide()
                    TextBox1.Hide()
                    TextBox2.Hide()
                    TextBox3.Hide()
                    TextBox4.Hide()
                    DataGridView1.Show()
                    GroupBox4.Show()
                    Button1.Show()
                
                    Dim sql As String = "SELECT clave_articulo,desc_articulo FROM articulos"
                    Dim cmd As New SqlCommand(sql, con)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        da.Fill(ds, "articulos")
                        Me.DataGridView1.DataSource = ds.Tables("articulos")
                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                Else
                    MessageBox.Show("Articulo no agregado", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

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

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        clave = Me.DataGridView1.CurrentRow.Cells.Item("clave_articulo").Value
            Label7.Text = clave
        editar()
    End Sub
    Sub editar()
        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        Dim con As New SqlConnection(My.Settings.coneccion)
        cmd.Connection = con
        cmd.CommandText =
    “SELECT desc_articulo FROM articulos WHERE clave_articulo = @clave”

        Dim param As System.Data.SqlClient.SqlParameter
        param = New System.Data.SqlClient.SqlParameter()
        param.ParameterName = "@clave"
        param.SqlDbType = SqlDbType.VarChar
        param.Size = 50
        param.Value = clave
        cmd.Parameters.Add(param)
        con.Open()
        Dim z As String
        z = cmd.ExecuteScalar()
        con.Close()

        cmd.CommandText =
   “SELECT modelo FROM articulos WHERE clave_articulo = @clave2”

        Dim param2 As System.Data.SqlClient.SqlParameter
        param2 = New System.Data.SqlClient.SqlParameter()
        param2.ParameterName = "@clave2"
        param2.SqlDbType = SqlDbType.VarChar
        param2.Size = 50
        param2.Value = clave
        cmd.Parameters.Add(param2)
        con.Open()
        Dim p As String
        p = cmd.ExecuteScalar()
        con.Close()

        cmd.CommandText =
   “SELECT precio FROM articulos WHERE clave_articulo = @clave3”

        Dim param3 As System.Data.SqlClient.SqlParameter
        param3 = New System.Data.SqlClient.SqlParameter()
        param3.ParameterName = "@clave3"
        param3.SqlDbType = SqlDbType.VarChar
        param3.Size = 50
        param3.Value = clave
        cmd.Parameters.Add(param3)
        con.Open()
        Dim q As String
        q = cmd.ExecuteScalar()
        con.Close()

        cmd.CommandText =
   “SELECT existencia FROM articulos WHERE clave_articulo = @clave4”

        Dim param4 As System.Data.SqlClient.SqlParameter
        param4 = New System.Data.SqlClient.SqlParameter()
        param4.ParameterName = "@clave4"
        param4.SqlDbType = SqlDbType.VarChar
        param4.Size = 50
        param4.Value = clave
        cmd.Parameters.Add(param4)
        con.Open()
        Dim r As String
        r = cmd.ExecuteScalar()
        con.Close()
        Label1.Show()
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()
        lbl_clave.Show()
        lbl_clave.Text = Label7.Text
        Button2.Show()
        Button3.Hide()
        Button4.Show()
        TextBox1.Show()
        TextBox2.Show()
        TextBox3.Show()
        TextBox4.Show()
        DataGridView1.Hide()
        GroupBox4.Hide()
        Button1.Hide()
        GroupBox1.Text = "Registro de Articulos"
        TextBox1.Text = z
        TextBox2.Text = p
        TextBox3.Text = q
        TextBox4.Text = r

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar DESCRIPCION es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar MODELO es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar PRECIO es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("No es posible continuar, debe ingresar EXISTENCIA es obligatorio", "Agregando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else
            Try
                act_art.clave = lbl_clave.Text
                act_art.articulo = TextBox1.Text
                act_art.modelo = TextBox2.Text
                act_art.precio = TextBox3.Text
                act_art.existencia = TextBox4.Text
                If func.actualizar_articulo(act_art) Then
                    MessageBox.Show("Bien Hecho. El Articulo ha sido Actualizado correctamente", "Actualizando Articulo")
                    Label1.Hide()
                    Label2.Hide()
                    Label3.Hide()
                    Label4.Hide()
                    Label5.Hide()
                    lbl_clave.Hide()
                    Button2.Hide()
                    Button3.Hide()
                    TextBox1.Hide()
                    TextBox2.Hide()
                    TextBox3.Hide()
                    TextBox4.Hide()
                    DataGridView1.Show()
                    GroupBox4.Show()
                    Button1.Show()
                    Button4.Hide()

                    Dim sql As String = "SELECT clave_articulo,desc_articulo FROM articulos"
                    Dim cmd As New SqlCommand(sql, con)
                    Try
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        da.Fill(ds, "articulos")
                        Me.DataGridView1.DataSource = ds.Tables("articulos")
                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                Else
                    MessageBox.Show("Articulo no Actualizado", "Actualizando Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
End Class