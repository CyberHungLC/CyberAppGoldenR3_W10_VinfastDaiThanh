Public Class RoimportDmVT
    Dim DrReturn As DataRow
    Dim DsLookup As DataSet
    Dim FileName As String
    Dim DsData As New DataSet
    Dim tbMaster, tbHeader As New DataTable
    Dim DvMaster, DvHeader As New DataView
    Private Sub RoimportDmVT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        V_AddHandler()
        CyberSupport.Translaste(Me, M_LAN, True)
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        DsData = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoGetListDmVT", M_Ma_Dvcs & "#" & M_User_Name)
        tbMaster = DsData.Tables(0)
        tbHeader = DsData.Tables(1)
        DvMaster = New DataView(tbMaster)
        DvHeader = New DataView(tbHeader)
        CyberFill.V_FillReports(Master1GRV, M_LAN, DvHeader, DvMaster)
        Master1GRV.GridControl.DataSource = DvMaster
    End Sub
    Private Sub V_AddHandler()
        AddHandler ButtOK.Click, AddressOf V_Nhan
        AddHandler CmdSelectFile.Click, AddressOf V_SelectFile
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = False
        '----------------------------------------------------------------------------
        For i As Integer = 0 To tbMaster.Rows.Count - 1
            tbMaster.Rows(i).BeginEdit()
            If tbMaster.Columns.Contains("Ma_Dvcs") Then tbMaster.Rows(i).Item("Ma_Dvcs") = M_Ma_Dvcs
            If tbMaster.Columns.Contains("Gia") And tbMaster.Columns.Contains("Gia_NT") Then tbMaster.Rows(i).Item("Gia") = tbMaster.Rows(i).Item("Gia_NT")
            If tbMaster.Columns.Contains("Gia2") And tbMaster.Columns.Contains("Gia_NT2") Then tbMaster.Rows(i).Item("Gia2") = tbMaster.Rows(i).Item("Gia_NT2")
            If tbMaster.Columns.Contains("Gia3") And tbMaster.Columns.Contains("Gia_NT3") Then tbMaster.Rows(i).Item("Gia3") = tbMaster.Rows(i).Item("Gia_NT3")
            tbMaster.Rows(i).EndEdit()
        Next
        '----------------------------------------------------------------------------  
        Dim strXML As String = ""
        strXML = CyberSmodb.V_ConvertDataToXML({"DmVT"}, {tbMaster})
        Dim dsChekUpdate As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoImportDmvt", strXML + "#" + M_Ma_Dvcs + "#" + M_User_Name)
        If Not CyberSupport.V_MsgChk(dsChekUpdate.Tables(0), Me.Sysvar, M_LAN) Then
            dsChekUpdate.Dispose()
            Exit Sub
        End If
       
        If CyberLoading.IsShowWaitFrom Then CyberLoading.V_CloseWailtForm()
        '----------------------------------------------------------------------------       
        MsgBox("Đã thực hiện xong", MsgBoxStyle.OkOnly, Sysvar("M_CYBER_VER"))
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
    Private Sub V_SelectFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tbImport As DataTable
        tbImport = CyberExport.V_ImportDataToGridview(AppConn, Sysvar, Para, Master1GRV, tbMaster, M_LAN)
        If tbImport Is Nothing Then Exit Sub
        tbMaster.Clear()
        For Each dr As DataRow In tbImport.Select("Ma_Phu1 <> ''")
            tbMaster.ImportRow(dr)
        Next
        tbMaster.AcceptChanges()
    End Sub
End Class
