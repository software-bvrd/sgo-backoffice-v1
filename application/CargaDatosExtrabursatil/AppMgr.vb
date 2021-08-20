Imports System.IO

Friend Class AppMgr
    <STAThread()> _
    Shared Sub Main(ByVal args() As String)
        Dim frm1 As CargadorBursatil


        'Application.EnableVisualStyles()


        'If args.Length = 0 Then
        '    Return
        'Else
        '    For Each s As String In args
        '        frm1 = New CargadorBursatil(s)
        '        Application.Run(frm1)
        '    Next
        'End If


        ' Codigo para probar 
        frm1 = New CargadorBursatil("CEVALDOM")
        Application.Run(frm1)





    End Sub
End Class
