

Friend Class AppMgr
    <STAThread()>
    Shared Sub Main(ByVal args() As String)
        Dim frm1 As Form1

        ''  Codigo para probar jc
        frm1 = New Form1("e")
        'Application.Run(frm1)
        'Application.EnableVisualStyles()

        'frm1 = New Form1("")
        'Application.Run(frm1)

        'MELVIN 27052019 
        If args.Length = 0 Then
            Return
        Else
            For Each s As String In args
                'MsgBox(s)
                frm1 = New Form1(s)
                'frm1 = New Form1("")
                Application.Run(frm1)
            Next
        End If

        ''  Codigo para probar 
        'frm1 = New Form1("instrumentos")
        'Application.Run(frm1)

    End Sub
End Class
