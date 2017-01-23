Imports System.Data.SqlClient
Public Class Funciones
    Dim cn As New SqlConnection(My.Settings.coneccion)
    Dim cmd As New SqlCommand

    Public Function agregar_cliente(ByVal data As propiedades) As Boolean

        Try
            cn.Open()
            cmd = New SqlCommand("proc_agregaracliente", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@clavecleinte", data.cod_prod)
            cmd.Parameters.AddWithValue("@nomcliente", data.nombre)
            cmd.Parameters.AddWithValue("@rfccliente", data.rfcclient)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
    Public Function agregar_articulo(ByVal data As propiedades_articulos) As Boolean

        Try
            cn.Open()
            cmd = New SqlCommand("proc_agregararti", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@clavearticulo", data.cod_prod)
            cmd.Parameters.AddWithValue("@descarticulo", data.descripcion)
            cmd.Parameters.AddWithValue("@modeloarticulo", data.modelo)
            cmd.Parameters.AddWithValue("@precioarticulo", data.precio)
            cmd.Parameters.AddWithValue("@existenciaarticulo", data.existencia)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
    Public Function configuracion_general(ByVal data As configuracion_general) As Boolean
        Try
            cn.Open()
            cmd = New SqlCommand("proc_configuracion", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@tasa", data.tasa)
            cmd.Parameters.AddWithValue("@enganche", data.enganche)
            cmd.Parameters.AddWithValue("@plazo", data.plazo)

            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try
    End Function
    Public Function registrar_venta(ByVal data As registrar_venta) As Boolean

        Try
            Dim cn As New SqlConnection(My.Settings.coneccion)
            Dim cmd4 As New SqlCommand
            cn.Open()
            cmd4 = New SqlCommand("registro_venta", cn)
            cmd4.CommandType = CommandType.StoredProcedure

            cmd4.Parameters.AddWithValue("@folio", data.folio)
            cmd4.Parameters.AddWithValue("@clave", data.clave)
            cmd4.Parameters.AddWithValue("@nombre", data.nombre)
            cmd4.Parameters.AddWithValue("@total", data.total)
            cmd4.Parameters.AddWithValue("@fecha", data.fecha)
            cmd4.Parameters.AddWithValue("@plazo", data.plazo)

            If cmd4.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
    Public Function actualizar_existencia(ByVal data As actualizar_existencia) As Boolean

        Try
            Dim cn As New SqlConnection(My.Settings.coneccion)
            Dim cmd4 As New SqlCommand
            cn.Open()
            cmd4 = New SqlCommand("actualizar_existencia", cn)
            cmd4.CommandType = CommandType.StoredProcedure

            cmd4.Parameters.AddWithValue("@cantidad", data.cantidad)
            cmd4.Parameters.AddWithValue("@articulo", data.articulo)

            If cmd4.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
    Public Function actualizar_articulo(ByVal data As actualizar_articulo) As Boolean

        Try
            Dim cn As New SqlConnection(My.Settings.coneccion)
            Dim cmd4 As New SqlCommand
            cn.Open()
            cmd4 = New SqlCommand("actualizar_articulos", cn)
            cmd4.CommandType = CommandType.StoredProcedure

            cmd4.Parameters.AddWithValue("@clave", data.clave)
            cmd4.Parameters.AddWithValue("@articulo", data.articulo)
            cmd4.Parameters.AddWithValue("@modelo", data.modelo)
            cmd4.Parameters.AddWithValue("@precio", data.precio)
            cmd4.Parameters.AddWithValue("@existencia", data.existencia)

            If cmd4.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
    Public Function actualizar_cliente(ByVal data As actualizar_cliente) As Boolean

        Try
            Dim cn As New SqlConnection(My.Settings.coneccion)
            Dim cmd4 As New SqlCommand
            cn.Open()
            cmd4 = New SqlCommand("actualizar_cliente", cn)
            cmd4.CommandType = CommandType.StoredProcedure

            cmd4.Parameters.AddWithValue("@clave", data.clave)
            cmd4.Parameters.AddWithValue("@nombre", data.nombre)
            cmd4.Parameters.AddWithValue("@rfc", data.rfc)

            If cmd4.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
End Class
