Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class ventas
    Public conexiones As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Public adaptador As SqlDataAdapter
    Dim glb_existencia As String
    Dim entro, entro2 As Integer
    Dim m, b, tasa, plazo, precio_contado As Double
    Dim precio_final As Integer
    Dim busco As Integer
    Private Sub ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VendimiaDataSet.clientes' table. You can move, or remove it, as needed.
        Me.ClientesTableAdapter.Fill(Me.VendimiaDataSet.clientes)
        grp_ventas.Show()
        TextBox1.Hide()
        TextBox2.Hide()
        btn_agar.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        lbl_folio.Hide()
        GroupBox3.Hide()
        Button2.Hide()
        Button2.Enabled = False
        Button1.Hide()
        TextBox3.Hide()
        Label5.Hide()
        GroupBox1.Hide()
        GroupBox2.Hide()
        nueva_venta.Show()
        grd_ventas.Show()
        GroupBox4.Show()
        entro2 = 0
        busco = 0
        fecha.Text = DateTime.Now().ToShortDateString()
        grp_ventas.Text = "Ventas Activas"
        Dim con As New SqlConnection(My.Settings.coneccion)
        Dim sql As String = "SELECT * FROM ventas"
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "ventas")
            Me.grd_ventas.DataSource = ds.Tables("ventas")
            Me.grd_ventas.BorderStyle = BorderStyle.Fixed3D

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub nueva_venta_Click_1(sender As Object, e As EventArgs) Handles nueva_venta.Click
        TextBox3.Enabled = True
        TextBox1.Show()
        TextBox2.Show()
        btn_agar.Show()
        Label2.Show()
        Label3.Show()
        Label4.Show()
        lbl_folio.Show()
        lbl_rfc.Show()
        Button1.Show()
        Button2.Show()
        Button2.Text = "Siguente"
        nueva_venta.Hide()
        grd_ventas.Hide()
        GroupBox4.Hide()
        grp_ventas.Text = "Registro de Ventas"
        autoCompletarTexbox(TextBox1)
        autoCompletarTexbox2(TextBox2)
        Dim comando As SqlCommand = New SqlCommand
        Dim con As New SqlConnection(My.Settings.coneccion)
        comando.CommandText = "SELECT TOP 1 folio_venta FROM ventas ORDER BY folio_venta  DESC"
        comando.Connection = con
        con.Open()
        Dim i As Integer
        i = comando.ExecuteScalar()
        con.Close()
        lbl_folio.Text = i + 1
    End Sub

    'Llena un texbox con opciones de autocompletar'
    Sub autoCompletarTexbox(ByVal campoTexto As TextBox)
        conexiones = New SqlConnection(My.Settings.coneccion)
        conexiones.Open()

        Try
            enunciado = New SqlCommand("select nom_cliente from clientes", conexiones)
            respuesta = enunciado.ExecuteReader()
            While respuesta.Read
                campoTexto.AutoCompleteCustomSource.Add(respuesta.Item("nom_cliente"))
            End While
            respuesta.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub autoCompletarTexbox2(ByVal campoTexto As TextBox)
        Try
            conexiones = New SqlConnection(My.Settings.coneccion)
            conexiones.Open()
        Catch ex As Exception
            conexiones.Close() 'Cierra la conexion'
        End Try
        Try
            enunciado = New SqlCommand("select desc_articulo from articulos", conexiones)
            respuesta = enunciado.ExecuteReader()
            While respuesta.Read
                campoTexto.AutoCompleteCustomSource.Add(respuesta.Item("desc_articulo"))
            End While
            respuesta.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub grp_ventas_Enter(sender As Object, e As EventArgs) Handles grp_ventas.Enter

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        Dim con As New SqlConnection(My.Settings.coneccion)
        cmd.Connection = con
        cmd.CommandText =
    “SELECT rfc_cliente FROM clientes WHERE nom_cliente = @Nombre”

        Dim param As System.Data.SqlClient.SqlParameter
        param = New System.Data.SqlClient.SqlParameter()
        param.ParameterName = "@Nombre"
        param.SqlDbType = SqlDbType.VarChar
        param.Size = 50
        param.Value = TextBox1.Text
        cmd.Parameters.Add(param)
        con.Open()
        Dim z As String
        z = cmd.ExecuteScalar()
        con.Close()
        lbl_rfc.Text = "RFC:  " + z

    End Sub

    Private Sub btn_agar_Click(sender As Object, e As EventArgs) Handles btn_agar.Click
        If glb_existencia <= 0 Then
            MessageBox.Show("El artículo seleccionado no cuenta con existencia, favor de verifica", "Sin Existencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            btn_agar.Enabled = False
            GroupBox1.Show()
            GroupBox2.Show()
            Button2.Enabled = True
            TextBox3.Text = 1
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            Dim con As New SqlConnection(My.Settings.coneccion)
            cmd.Connection = con
            TextBox3.Show()
            Label5.Show()
            cmd.CommandText =
        “SELECT precio FROM articulos WHERE desc_articulo =  @desc_articulo2”

            Dim param2 As System.Data.SqlClient.SqlParameter
            param2 = New System.Data.SqlClient.SqlParameter()
            param2.ParameterName = "@desc_articulo2"
            param2.SqlDbType = SqlDbType.VarChar
            param2.Size = 100
            param2.Value = TextBox2.Text
            cmd.Parameters.Add(param2)
            con.Open()
            Dim z As String
            z = cmd.ExecuteScalar()
            con.Close()
            cmd.CommandText =
        “SELECT modelo FROM articulos WHERE desc_articulo =  @desc_articulo3”
            Dim param3 As System.Data.SqlClient.SqlParameter
            param3 = New System.Data.SqlClient.SqlParameter()
            param3.ParameterName = "@desc_articulo3"
            param3.SqlDbType = SqlDbType.VarChar
            param3.Size = 100
            param3.Value = TextBox2.Text
            cmd.Parameters.Add(param3)
            con.Open()
            Dim model As String
            model = cmd.ExecuteScalar()
            con.Close()
            Label11.Text = model
            Label10.Text = TextBox2.Text
            cmd.CommandText =
        “SELECT tasa FROM configuracion”
            con.Open()
            tasa = cmd.ExecuteScalar()
            con.Close()

            cmd.CommandText =
        “SELECT plazo FROM configuracion”
            con.Open()
            plazo = cmd.ExecuteScalar()
            con.Close()

            Dim r, t, y As Double
            r = tasa * plazo
            y = r / 100
            t = y + 1
            precio_final = z * t
            Label12.Text = precio_final
            Label13.Text = precio_final

            cmd.CommandText =
                    “SELECT enganche FROM configuracion”
            con.Open()
            Dim eng As Double
            eng = cmd.ExecuteScalar()
            con.Close()
            Dim enganche As Double
            m = eng / 100
            enganche = m * Label13.Text
            lbl_enganche.Text = enganche
            Dim bono As Double
            b = tasa * plazo / 100
            bono = enganche * b
            lbl_bono.Text = bono

            Dim total As Double
            total = Label13.Text - enganche - bono
            lbl_total.Text = total
        End If
    End Sub
    Sub regresar()
        grp_ventas.Show()
        TextBox1.Hide()
        TextBox2.Hide()
        btn_agar.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        lbl_folio.Hide()
        Button1.Hide()
        Button2.Hide()
        Button2.Enabled = False
        GroupBox3.Hide()
        TextBox3.Hide()
        Label5.Hide()
        GroupBox1.Hide()
        GroupBox2.Hide()
        nueva_venta.Show()
        grd_ventas.Show()
        GroupBox4.Show()
        entro2 = 0
        busco = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        lbl_rfc.Text = ""
        btn_agar.Enabled = True
        grp_ventas.Text = "Ventas Activas"
        Dim con As New SqlConnection(My.Settings.coneccion)
        Dim sql As String = "SELECT * FROM ventas"
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "ventas")
            Me.grd_ventas.DataSource = ds.Tables("ventas")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        regresar()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        GroupBox1.Hide()
        GroupBox2.Hide()
        GroupBox3.Hide()
        entro2 = 0
        busco = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        lbl_rfc.Text = ""
        btn_agar.Enabled = True

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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Then
            TextBox3.Text = 0
        End If
        If TextBox3.Text < 10 Then
            Dim anclar As String
            anclar = 0 & TextBox3.Text
            TextBox3.Text = anclar
        End If
        If TextBox3.Text > glb_existencia Then
            MessageBox.Show("Articulos en existencia insuficientes", "Registrando Venta")

        Else
            If lbl_total.Text <= 0 Or TextBox3.Text <= 0 Or TextBox1.Text = "" Then
                MessageBox.Show("Los datos ingresados no son correctos, favor de verificar", "Registrando Venta")
            Else
                GroupBox3.Show()
                'precio contado
                Dim precio As Double
                precio = 1 + (tasa * plazo) / 100
                precio_contado = lbl_total.Text / precio
                'total a pagar
                Dim total_pagar3 As Double
                total_pagar3 = precio_contado * (1 + (tasa * 3) / 100)
                total3.Text = total_pagar3

                Dim total_pagar6 As Double
                total_pagar6 = precio_contado * (1 + (tasa * 6) / 100)
                total6.Text = total_pagar6

                Dim total_pagar9 As Double
                total_pagar9 = precio_contado * (1 + (tasa * 9) / 100)
                total9.Text = total_pagar9

                Dim total_pagar12 As Double
                total_pagar12 = precio_contado * (1 + (tasa * 12) / 100)
                total12.Text = total_pagar12
                'abonos por plazo
                Dim imp_abono3 As Double
                imp_abono3 = total3.Text / 3
                abono3.Text = imp_abono3

                Dim imp_abono6 As Double
                imp_abono6 = total6.Text / 6
                abono6.Text = imp_abono6

                Dim imp_abono9 As Double
                imp_abono9 = total9.Text / 9
                abono9.Text = imp_abono9

                Dim imp_abono12 As Double
                imp_abono12 = total12.Text / 12
                abono12.Text = imp_abono12

                'importe de ahorro
                Dim imp_ahorro3 As Double
                imp_ahorro3 = lbl_total.Text - total3.Text
                ahorro3.Text = imp_ahorro3

                Dim imp_ahorro6 As Double
                imp_ahorro6 = lbl_total.Text - total6.Text
                ahorro6.Text = imp_ahorro6

                Dim imp_ahorro9 As Double
                imp_ahorro9 = lbl_total.Text - total9.Text
                ahorro9.Text = imp_ahorro9

                Dim imp_ahorro12 As Double
                imp_ahorro12 = lbl_total.Text - total12.Text
                ahorro12.Text = imp_ahorro12
                If Button2.Text = "Guardar" Then
                    If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And RadioButton4.Checked = False Then
                        MessageBox.Show("Debe seleccionar un plazo para realizar el pago de su compra", "Registrando Venta")
                    Else
                        Dim cmd As System.Data.SqlClient.SqlCommand
                        cmd = New System.Data.SqlClient.SqlCommand()
                        Dim con As New SqlConnection(My.Settings.coneccion)
                        cmd.Connection = con
                        cmd.CommandText =
                        “SELECT clave_cliente FROM clientes WHERE nom_cliente =  @nombre”

                        Dim param2 As System.Data.SqlClient.SqlParameter
                        param2 = New System.Data.SqlClient.SqlParameter()
                        param2.ParameterName = "@nombre"
                        param2.SqlDbType = SqlDbType.VarChar
                        param2.Size = 50
                        param2.Value = TextBox1.Text
                        cmd.Parameters.Add(param2)
                        con.Open()
                        Dim z As String
                        z = cmd.ExecuteScalar()
                        con.Close()

                        If z = "" Then
                            MessageBox.Show("Usuario no encontrado", "Registrando Venta")
                        Else
                            Dim cg As New registrar_venta
                            Dim func As New Funciones
                            If RadioButton1.Checked = True Then
                                Try
                                    cg.folio = lbl_folio.Text
                                    cg.clave = z
                                    cg.nombre = TextBox1.Text
                                    cg.total = total3.Text
                                    cg.fecha = fecha.Text
                                    cg.plazo = 3
                                    If func.registrar_venta(cg) Then
                                        MessageBox.Show("Bien Hecho, Tu venta ha sido registrada correctamente", "Venta Registranda")
                                        actualizar_existencia()
                                        regresar()
                                    End If

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try


                            ElseIf RadioButton2.Checked = True Then
                                Try
                                    cg.folio = lbl_folio.Text
                                    cg.clave = z
                                    cg.nombre = TextBox1.Text
                                    cg.total = total6.Text
                                    cg.fecha = fecha.Text
                                    cg.plazo = 6
                                    If func.registrar_venta(cg) Then
                                        MessageBox.Show("Bien Hecho, Tu venta ha sido registrada correctamente", "Venta Registranda")
                                        actualizar_existencia()
                                        regresar()

                                    End If

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                            ElseIf RadioButton3.Checked = True Then
                                Try
                                    cg.folio = lbl_folio.Text
                                    cg.clave = z
                                    cg.nombre = TextBox1.Text
                                    cg.total = total9.Text
                                    cg.fecha = fecha.Text
                                    cg.plazo = 9
                                    If func.registrar_venta(cg) Then
                                        MessageBox.Show("Bien Hecho, Tu venta ha sido registrada correctamente", "Venta Registranda")
                                        actualizar_existencia()
                                        regresar()

                                    End If

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                            ElseIf RadioButton4.Checked = True Then
                                Try
                                    cg.folio = lbl_folio.Text
                                    cg.clave = z
                                    cg.nombre = TextBox1.Text
                                    cg.total = total12.Text
                                    cg.fecha = fecha.Text
                                    cg.plazo = 12
                                    If func.registrar_venta(cg) Then
                                        MessageBox.Show("Bien Hecho, Tu venta ha sido registrada correctamente", "Venta Registranda")
                                        actualizar_existencia()
                                        regresar()
                                    End If

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                            End If

                        End If


                    End If

                End If
                TextBox3.Enabled = False
                Button2.Text = "Guardar"

            End If
        End If


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        Dim con As New SqlConnection(My.Settings.coneccion)
        cmd.Connection = con
        cmd.CommandText =
    “SELECT existencia FROM articulos WHERE desc_articulo =  @desc_articulo”

        Dim param As System.Data.SqlClient.SqlParameter
        param = New System.Data.SqlClient.SqlParameter()
        param.ParameterName = "@desc_articulo"
        param.SqlDbType = SqlDbType.VarChar
        param.Size = 100
        param.Value = TextBox2.Text
        cmd.Parameters.Add(param)
        con.Open()
        glb_existencia = cmd.ExecuteScalar()
        con.Close()
        If TextBox2.Text = "" Then
            btn_agar.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If entro = 1 Then

            Dim res As Integer
            Dim multi As Integer
            If TextBox3.Text <> "" Then
                multi = TextBox3.Text
                res = precio_final * multi
                Label13.Text = res
                lbl_enganche.Text = m * Label13.Text
                lbl_bono.Text = b * lbl_enganche.Text
                lbl_total.Text = Label13.Text - lbl_enganche.Text - lbl_bono.Text
            End If
        End If

        entro = 1
    End Sub
    Sub actualizar_existencia()
        Dim func As New Funciones
        Dim aex As New actualizar_existencia
        Try
            aex.cantidad = TextBox3.Text
            aex.articulo = TextBox2.Text
            If func.actualizar_existencia(aex) Then
                Button1.Hide()

            Else
                MessageBox.Show("ERROR", "agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class