Module variable
    Public dosrepertoire As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\CLM\"
    Public dosprogramefile As String = dosrepertoire & "\Programmes\"
    Public dosinstall As String = dosrepertoire & "\install\"
    Public dostemp As String = dosrepertoire & "\tmp\"
    Public dosthéme As String = dosrepertoire & "\théme\"
    Public théme As String = dosthéme & "\théme.txt"
    Public dosconnextion As String = dosrepertoire & "\connextion\"
    Public connecter As String = dosconnextion & "\connecter.txt"
    Public testazazazaza As Integer = 0
    Public nom As String = "Centre logiciel"
    Public versionlogi = 0.1
    Public clescrypte As String = ""
    Public CLMPipserveur As String = ""
    Public CLMipsite As String = ""
    Public CLMid As String = ""
    Public CLMpass As String = ""
    Public CLMprofil As String = "default"
End Module
