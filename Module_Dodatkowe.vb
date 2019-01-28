'https://github.com/ravibpatel/AutoUpdater.NET
Imports AutoUpdaterDotNET
Imports System.Runtime.InteropServices 'do procesu ktory blokuje plik
Module Module_Dodatkowe
    Public Sub Sprawdz_Aktualizacje()
        Try
            AutoUpdater.Start("http://www.excelsolutions.pl/pliki/PDF_To_FTP/Pdf-To_FTP.xml")
        Catch ex As Exception

        End Try

    End Sub

    'Poniższe do procesu, ktory blokuje
    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Unicode)>
    Private Function RmRegisterResources(pSessionHandle As UInteger, nFiles As UInt32, rgsFilenames As String(), nApplications As UInt32, <[In]> rgApplications As RM_UNIQUE_PROCESS(), nServices As UInt32,
       rgsServiceNames As String()) As Integer
    End Function

    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Auto)>
    Private Function RmStartSession(ByRef pSessionHandle As UInteger, dwSessionFlags As Integer, strSessionKey As String) As Integer
    End Function

    <DllImport("rstrtmgr.dll")>
    Private Function RmEndSession(pSessionHandle As UInteger) As Integer
    End Function

    <DllImport("rstrtmgr.dll")>
    Private Function RmGetList(dwSessionHandle As UInteger, ByRef pnProcInfoNeeded As UInteger, ByRef pnProcInfo As UInteger, <[In], Out> rgAffectedApps As RM_PROCESS_INFO(), ByRef lpdwRebootReasons As UInteger) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure RM_UNIQUE_PROCESS
        Public dwProcessId As Integer
        Public ProcessStartTime As System.Runtime.InteropServices.ComTypes.FILETIME
    End Structure

    Const RmRebootReasonNone As Integer = 0
    Const CCH_RM_MAX_APP_NAME As Integer = 255
    Const CCH_RM_MAX_SVC_NAME As Integer = 63

    Private Enum RM_APP_TYPE
        RmUnknownApp = 0
        RmMainWindow = 1
        RmOtherWindow = 2
        RmService = 3
        RmExplorer = 4
        RmConsole = 5
        RmCritical = 1000
    End Enum

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Private Structure RM_PROCESS_INFO
        Public Process As RM_UNIQUE_PROCESS

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_APP_NAME + 1)>
        Public strAppName As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_SVC_NAME + 1)>
        Public strServiceShortName As String

        Public ApplicationType As RM_APP_TYPE
        Public AppStatus As UInteger
        Public TSSessionId As UInteger
        <MarshalAs(UnmanagedType.Bool)>
        Public bRestartable As Boolean
    End Structure

    Dim LockedFileProcesses As New List(Of Process)
    Public Function WhoIsLocking(path As String) As List(Of Process)
        Dim handle As UInteger
        Dim key As String = Guid.NewGuid().ToString()
        Dim processes As New List(Of Process)()

        Dim res As Integer = RmStartSession(handle, 0, key)
        If res <> 0 Then
            Throw New Exception("Could not begin restart session.  Unable to determine file locker.")
        End If

        Try
            Const ERROR_MORE_DATA As Integer = 234
            Dim pnProcInfoNeeded As UInteger = 0, pnProcInfo As UInteger = 0, lpdwRebootReasons As UInteger = RmRebootReasonNone

            Dim resources As String() = New String() {path}
            ' Just checking on one resource.
            res = RmRegisterResources(handle, CUInt(resources.Length), resources, 0, Nothing, 0, Nothing)

            If res <> 0 Then
                Throw New Exception("Could not register resource.")
            End If

            'Note: there's a race condition here -- the first call to RmGetList() returns
            '      the total number of process. However, when we call RmGetList() again to get
            '      the actual processes this number may have increased.
            res = RmGetList(handle, pnProcInfoNeeded, pnProcInfo, Nothing, lpdwRebootReasons)

            If res = ERROR_MORE_DATA Then
                ' Create an array to store the process results
                Dim processInfo As RM_PROCESS_INFO() = New RM_PROCESS_INFO(CInt(pnProcInfoNeeded - 1)) {}
                pnProcInfo = pnProcInfoNeeded

                ' Get the list
                res = RmGetList(handle, pnProcInfoNeeded, pnProcInfo, processInfo, lpdwRebootReasons)
                If res = 0 Then
                    processes = New List(Of Process)(CInt(pnProcInfo))

                    ' Enumerate all of the results and add them to the 
                    ' list to be returned
                    For i As Integer = 0 To CInt(pnProcInfo - 1)
                        Try
                            processes.Add(Process.GetProcessById(processInfo(i).Process.dwProcessId))
                            ' catch the error -- in case the process is no longer running
                        Catch generatedExceptionName As ArgumentException
                        End Try
                    Next
                Else
                    Throw New Exception("Could not list processes locking resource.")
                End If
            ElseIf res <> 0 Then
                Throw New Exception("Could not list processes locking resource. Failed to get size of result.")
            End If
        Finally
            RmEndSession(handle)
        End Try

        Return processes
    End Function
End Module
