﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18051
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.17929.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlRootAttribute("tod", [Namespace]:="", IsNullable:=False)> _
Partial Public Class BvrdType

    Private transaccionField() As transaccion

    Private rncField As String

    Private fechaField As Date

    Private versionField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("transaccion", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> _
    Public Property transaccion() As transaccion()
        Get
            Return Me.transaccionField
        End Get
        Set(value As transaccion())
            Me.transaccionField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property rnc() As String
        Get
            Return Me.rncField
        End Get
        Set(value As String)
            Me.rncField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
    Public Property fecha() As Date
        Get
            Return Me.fechaField
        End Get
        Set(value As Date)
            Me.fechaField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property version() As String
        Get
            Return Me.versionField
        End Get
        Set(value As String)
            Me.versionField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code")>  _
Partial Public Class transaccion
    
    Private rnc_puestoField As String
    
    Private rnc_emisorField As String
    
    Private cod_siv_emisionField As String
    
    Private cod_isinField As String
    
    Private serieField As String
    
    Private cod_monedaField As String
    
    Private num_operacionField As String
    
    Private tasasField As tipotasa
    
    Private fechasField As tipofecha
    
    Private unidad_valor_nominalField As Decimal
    
    Private valor_nominalField As Decimal
    
    Private cant_valor_nominalField As Decimal
    
    Private precio_mercadoField As Decimal
    
    Private valor_mercadoField As Decimal
    
    Private tipo_transaccionField As tipotransaccion
    
    Private tipo_transaccionFieldSpecified As Boolean
    
    Private tipo_contratoField As tipocontrato
    
    Private tipo_contratoFieldSpecified As Boolean
    
    Private tipo_mercadoField As tipomercado
    
    Private tipo_mercadoFieldSpecified As Boolean
    
    Private tipo_operacionField As tipooperacion
    
    Private tipo_operacionFieldSpecified As Boolean
    
    Private clasif_operacionField As clasifoperacion
    
    Private clasif_operacionFieldSpecified As Boolean
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property rnc_puesto() As String
        Get
            Return Me.rnc_puestoField
        End Get
        Set
            Me.rnc_puestoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property rnc_emisor() As String
        Get
            Return Me.rnc_emisorField
        End Get
        Set
            Me.rnc_emisorField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property cod_siv_emision() As String
        Get
            Return Me.cod_siv_emisionField
        End Get
        Set
            Me.cod_siv_emisionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property cod_isin() As String
        Get
            Return Me.cod_isinField
        End Get
        Set
            Me.cod_isinField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property serie() As String
        Get
            Return Me.serieField
        End Get
        Set
            Me.serieField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property cod_moneda() As String
        Get
            Return Me.cod_monedaField
        End Get
        Set
            Me.cod_monedaField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property num_operacion() As String
        Get
            Return Me.num_operacionField
        End Get
        Set
            Me.num_operacionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property tasas() As tipotasa
        Get
            Return Me.tasasField
        End Get
        Set
            Me.tasasField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property fechas() As tipofecha
        Get
            Return Me.fechasField
        End Get
        Set
            Me.fechasField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property unidad_valor_nominal() As Decimal
        Get
            Return Me.unidad_valor_nominalField
        End Get
        Set
            Me.unidad_valor_nominalField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property valor_nominal() As Decimal
        Get
            Return Me.valor_nominalField
        End Get
        Set
            Me.valor_nominalField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property cant_valor_nominal() As Decimal
        Get
            Return Me.cant_valor_nominalField
        End Get
        Set
            Me.cant_valor_nominalField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property precio_mercado() As Decimal
        Get
            Return Me.precio_mercadoField
        End Get
        Set
            Me.precio_mercadoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property valor_mercado() As Decimal
        Get
            Return Me.valor_mercadoField
        End Get
        Set
            Me.valor_mercadoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property tipo_transaccion() As tipotransaccion
        Get
            Return Me.tipo_transaccionField
        End Get
        Set
            Me.tipo_transaccionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>  _
    Public Property tipo_transaccionSpecified() As Boolean
        Get
            Return Me.tipo_transaccionFieldSpecified
        End Get
        Set
            Me.tipo_transaccionFieldSpecified = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property tipo_contrato() As tipocontrato
        Get
            Return Me.tipo_contratoField
        End Get
        Set
            Me.tipo_contratoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>  _
    Public Property tipo_contratoSpecified() As Boolean
        Get
            Return Me.tipo_contratoFieldSpecified
        End Get
        Set
            Me.tipo_contratoFieldSpecified = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property tipo_mercado() As tipomercado
        Get
            Return Me.tipo_mercadoField
        End Get
        Set
            Me.tipo_mercadoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>  _
    Public Property tipo_mercadoSpecified() As Boolean
        Get
            Return Me.tipo_mercadoFieldSpecified
        End Get
        Set
            Me.tipo_mercadoFieldSpecified = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property tipo_operacion() As tipooperacion
        Get
            Return Me.tipo_operacionField
        End Get
        Set
            Me.tipo_operacionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>  _
    Public Property tipo_operacionSpecified() As Boolean
        Get
            Return Me.tipo_operacionFieldSpecified
        End Get
        Set
            Me.tipo_operacionFieldSpecified = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property clasif_operacion() As clasifoperacion
        Get
            Return Me.clasif_operacionField
        End Get
        Set
            Me.clasif_operacionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>  _
    Public Property clasif_operacionSpecified() As Boolean
        Get
            Return Me.clasif_operacionFieldSpecified
        End Get
        Set
            Me.clasif_operacionFieldSpecified = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code")>  _
Partial Public Class tipotasa
    
    Private tasa_int_facialField As Decimal
    
    Private tasa_int_rendimientoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property tasa_int_facial() As Decimal
        Get
            Return Me.tasa_int_facialField
        End Get
        Set
            Me.tasa_int_facialField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
    Public Property tasa_int_rendimiento() As Decimal
        Get
            Return Me.tasa_int_rendimientoField
        End Get
        Set
            Me.tasa_int_rendimientoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code")>  _
Partial Public Class tipofecha
    
    Private fecha_valorField As Date
    
    Private fecha_venc_mutuoField As Date
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType:="date")>  _
    Public Property fecha_valor() As Date
        Get
            Return Me.fecha_valorField
        End Get
        Set
            Me.fecha_valorField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType:="date")>  _
    Public Property fecha_venc_mutuo() As Date
        Get
            Return Me.fecha_venc_mutuoField
        End Get
        Set
            Me.fecha_venc_mutuoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute()>  _
Public Enum tipotransaccion
    
    '''<remarks/>
    CPR
    
    '''<remarks/>
    VNT
    
    '''<remarks/>
    MNT
    
    '''<remarks/>
    MTR
    
    '''<remarks/>
    OTR
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute()>  _
Public Enum tipocontrato
    
    '''<remarks/>
    SPT
    
    '''<remarks/>
    FRW
    
    '''<remarks/>
    MTO
    
    '''<remarks/>
    HEREN
    
    '''<remarks/>
    DIVHE
    
    '''<remarks/>
    SPSCC
    
    '''<remarks/>
    DONAC
    
    '''<remarks/>
    DIVPP
    
    '''<remarks/>
    FUSES
    
    '''<remarks/>
    FUNFM
    
    '''<remarks/>
    EFCDP
    
    '''<remarks/>
    MNDLJ
    
    '''<remarks/>
    TRCOP
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute()>  _
Public Enum tipomercado
    
    '''<remarks/>
    PRI
    
    '''<remarks/>
    SEC
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute()>  _
Public Enum tipooperacion
    
    '''<remarks/>
    CPROP
    
    '''<remarks/>
    CTER
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute()>  _
Public Enum clasifoperacion
    
    '''<remarks/>
    PRP
    
    '''<remarks/>
    REQ
    
    '''<remarks/>
    ND
End Enum
