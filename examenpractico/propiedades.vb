Public Class propiedades
    Private _clave As Integer
    Private _NOMBRE As String
    Private _rfccliente As String

    Public Property cod_prod As Integer
        Get
            Return _clave
        End Get
        Set(value As Integer)
            _clave = value
        End Set
    End Property
    Public Property nombre As String
        Get
            Return _NOMBRE
        End Get
        Set(value As String)
            _NOMBRE = value
        End Set
    End Property
    Public Property rfcclient As String
        Get
            Return _rfccliente

        End Get
        Set(value As String)
            _rfccliente = value
        End Set
    End Property
End Class
Public Class propiedades_articulos
    Private _clave As Integer
    Private _descripcion As String
    Private _modelo As String
    Private _precio As Double
    Private _existencia As Integer

    Public Property cod_prod As Integer
        Get
            Return _clave
        End Get
        Set(value As Integer)
            _clave = value
        End Set
    End Property
    Public Property descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property modelo As String
        Get
            Return _modelo

        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property
    Public Property precio As Double
        Get
            Return _precio
        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property
    Public Property existencia As Integer
        Get
            Return _existencia

        End Get
        Set(value As Integer)
            _existencia = value
        End Set
    End Property
End Class
Public Class configuracion_general
    Private _tasa As Double
    Private _enganche As Double
    Private _plazo As Integer
    Public Property tasa As Double
        Get
            Return _tasa

        End Get
        Set(value As Double)
            _tasa = value
        End Set
    End Property
    Public Property enganche As Double
        Get
            Return _enganche

        End Get
        Set(value As Double)
            _enganche = value
        End Set
    End Property
    Public Property plazo As Integer
        Get
            Return _plazo

        End Get
        Set(value As Integer)
            _plazo = value
        End Set
    End Property
End Class
Public Class registrar_venta
    Private _folio As Integer
    Private _clave As Integer
    Private _nombre As String
    Private _total As Double
    Private _fecha As String
    Private _plazo As Integer

    Public Property folio As Integer
        Get
            Return _folio

        End Get
        Set(value As Integer)
            _folio = value
        End Set
    End Property
    Public Property clave As Integer
        Get
            Return _clave

        End Get
        Set(value As Integer)
            _clave = value
        End Set
    End Property
    Public Property nombre As String
        Get
            Return _nombre

        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property total As Double
        Get
            Return _total

        End Get
        Set(value As Double)
            _total = value
        End Set
    End Property
    Public Property fecha As String
        Get
            Return _fecha

        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property
    Public Property plazo As Integer
        Get
            Return _plazo

        End Get
        Set(value As Integer)
            _plazo = value
        End Set
    End Property
End Class
Public Class actualizar_existencia
    Private _cantidad As Integer
    Private _articulo As String
    Public Property articulo As String
        Get
            Return _articulo

        End Get
        Set(value As String)
            _articulo = value
        End Set
    End Property
    Public Property cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

End Class
Public Class actualizar_articulo
    Private _clave As Integer
    Private _articulo As String
    Private _modelo As String
    Private _precio As Double
    Private _existencia As Integer
    Public Property articulo As String
        Get
            Return _articulo

        End Get
        Set(value As String)
            _articulo = value
        End Set
    End Property
    Public Property clave As Integer
        Get
            Return _clave
        End Get
        Set(value As Integer)
            _clave = value
        End Set
    End Property
    Public Property modelo As String
        Get
            Return _modelo

        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property
    Public Property precio As Double
        Get
            Return _precio

        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property
    Public Property existencia As Integer
        Get
            Return _existencia

        End Get
        Set(value As Integer)
            _existencia = value
        End Set
    End Property
End Class
Public Class actualizar_cliente
    Private _clave As Integer
    Private _nombre As String
    Private _rfc As String

    Public Property clave As Integer
        Get
            Return _clave
        End Get
        Set(value As Integer)
            _clave = value
        End Set
    End Property
    Public Property nombre As String
        Get
            Return _nombre

        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property rfc As String
        Get
            Return _rfc

        End Get
        Set(value As String)
            _rfc = value
        End Set
    End Property
End Class