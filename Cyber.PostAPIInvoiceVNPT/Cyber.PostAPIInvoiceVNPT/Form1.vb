Public Class Form1
    Dim _supportInvoiceVNPT As New supportInvoiceVNPT
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim tbconfig As New DataTable
        'Dim tbPH As New DataTable
        'Dim tbCT As New DataTable

        'tbconfig.Columns.Add("Stt_rec")
        'tbconfig.Columns.Add("Stt_rec_TTDC")
        'tbconfig.Columns.Add("Account")
        'tbconfig.Columns.Add("ACPass")
        'tbconfig.Columns.Add("User_name")
        'tbconfig.Columns.Add("password")

        'tbconfig.Columns.Add("Mau_So")
        'tbconfig.Columns.Add("So_Seri")
        'tbconfig.Rows.Add(Guid.NewGuid.ToString.Replace("-", ""), "", "saigonotocanthoadmin", "Einv@oi@vn#pt20", "saigonotocanthoservice", "123456aA@", "01GTKT0/001", "CT/20E")

        'tbPH.Columns.Add("CusCode")
        'tbPH.Columns.Add("Buyer")
        'tbPH.Columns.Add("CusName")
        'tbPH.Columns.Add("CusAddress")
        'tbPH.Columns.Add("CusPhone")
        'tbPH.Columns.Add("CusTaxCode")
        'tbPH.Columns.Add("PaymentMethod")
        'tbPH.Columns.Add("KindOfService")

        'tbPH.Columns.Add("Products")
        'tbPH.Columns.Add("Total")
        'tbPH.Columns.Add("DiscountAmount")
        'tbPH.Columns.Add("VATRate")
        'tbPH.Columns.Add("VATAmount")
        'tbPH.Columns.Add("Amount")
        'tbPH.Columns.Add("AmountInWords")
        'tbPH.Columns.Add("Extra")
        'tbPH.Columns.Add("ArisingDate")
        'tbPH.Columns.Add("PaymentStatus")
        'tbPH.Columns.Add("ResourceCode")
        'tbPH.Columns.Add("type")

        'tbPH.Rows.Add("Ma_kh", "Đào Chí Minh", "CÔNG TY CỔ PHẦN PHẦN MỀM QUẢN TRỊ DOANH NGHIỆP", " Tầng 5, Tòa Nhà Viện Công Nghệ, Số 25 Vũ Ngọc phan, P.Láng Hạ, Quận Đống Đa", "0356900077", "0101419580", "TM", "09", "", "800000", "0", "10", "80000", "880000", "Tám trăm tám mươi tám ngàn đồng", "", "", "1", "", 0)

        'tbCT.Columns.Add("ProdName")
        'tbCT.Columns.Add("ProdUnit")
        'tbCT.Columns.Add("ProdQuantity")
        'tbCT.Columns.Add("ProdPrice")
        'tbCT.Columns.Add("Total")

        'tbCT.Rows.Add("Sản phẩm 01", "Cái", "1", "100000", "100000")
        'tbCT.Rows.Add("Sản phẩm 02", "Cái", "3", "100000", "300000")
        'tbCT.Rows.Add("Sản phẩm 03", "Cái", "4", "100000", "400000")


        'TextBox1.Text = Guid.NewGuid.ToString.Replace("-", "")
        'tbconfig.Rows(0)("Stt_rec") = TextBox1.Text
        'Dim str As DataSet = _supportInvoiceVNPT.V_TaoHoaDon(tbconfig.Rows(0), tbPH.Rows(0), tbCT)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Dim tbconfig As New DataTable
        'Dim tbPH As New DataTable
        'Dim tbCT As New DataTable
        'tbconfig.Columns.Add("Stt_rec")
        'tbconfig.Columns.Add("Stt_rec_TTDC")
        'tbconfig.Columns.Add("Account")
        'tbconfig.Columns.Add("ACPass")
        'tbconfig.Columns.Add("User_name")
        'tbconfig.Columns.Add("password")
        'tbconfig.Columns.Add("Mau_So")
        'tbconfig.Columns.Add("So_Seri")

        'tbconfig.Rows.Add(Guid.NewGuid.ToString, "", "saigonotocanthoadmin", "Einv@oi@vn#pt20", "saigonotocanthoservice", "123456aA@", "01GTKT0/001", "CT/20E")

        'tbPH.Columns.Add("CusCode")
        'tbPH.Columns.Add("Buyer")
        'tbPH.Columns.Add("CusName")
        'tbPH.Columns.Add("CusAddress")
        'tbPH.Columns.Add("CusPhone")
        'tbPH.Columns.Add("CusTaxCode")
        'tbPH.Columns.Add("PaymentMethod")
        'tbPH.Columns.Add("KindOfService")
        'tbPH.Columns.Add("Products")
        'tbPH.Columns.Add("Total")
        'tbPH.Columns.Add("DiscountAmount")
        'tbPH.Columns.Add("VATRate")
        'tbPH.Columns.Add("VATAmount")
        'tbPH.Columns.Add("Amount")
        'tbPH.Columns.Add("AmountInWords")
        'tbPH.Columns.Add("Extra")
        'tbPH.Columns.Add("EmailDeliver")
        'tbPH.Columns.Add("ArisingDate")
        'tbPH.Columns.Add("PaymentStatus")
        'tbPH.Columns.Add("ResourceCode")
        'tbPH.Columns.Add("type")
        'tbPH.Rows.Add("Ma_kh", "Đào Chí Minh", "CÔNG TY CỔ PHẦN PHẦN MỀM QUẢN TRỊ DOANH NGHIỆP", " Tầng 5, Tòa Nhà Viện Công Nghệ, Số 25 Vũ Ngọc phan, P.Láng Hạ, Quận Đống Đa", "0356900077", "0101419580", "TM", "09", "", "800000", "0", "10", "80000", "880000", "Tám trăm tám mươi tám ngàn đồng", "", "", "1", "", 0)

        'tbCT.Columns.Add("ProdName")
        'tbCT.Columns.Add("ProdUnit")
        'tbCT.Columns.Add("ProdQuantity")
        'tbCT.Columns.Add("ProdPrice")
        'tbCT.Columns.Add("Total")

        'tbCT.Rows.Add("Sản phẩm 0111", "Cái", "1", "100000", "100000")
        'tbCT.Rows.Add("Sản phẩm 0222", "Cái", "3", "100000", "300000")
        'tbCT.Rows.Add("Sản phẩm 0333", "Cái", "4", "100000", "400000")

        'tbconfig.Rows(0)("Stt_rec_TTDC") = TextBox1.Text
        'TextBox1.Text = Guid.NewGuid.ToString.Replace("-", "")
        'tbconfig.Rows(0)("Stt_rec") = TextBox1.Text
        'Dim str As DataSet = _supportInvoiceVNPT.V_ThayTheHoaDon(tbconfig.Rows(0), tbPH.Rows(0), tbCT)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim tbconfig As New DataTable
        'Dim tbPH As New DataTable
        'Dim tbCT As New DataTable
        'tbconfig.Columns.Add("Stt_rec")
        'tbconfig.Columns.Add("Stt_rec_TTDC")
        'tbconfig.Columns.Add("Account")
        'tbconfig.Columns.Add("ACPass")
        'tbconfig.Columns.Add("User_name")
        'tbconfig.Columns.Add("password")
        'tbconfig.Columns.Add("Mau_So")
        'tbconfig.Columns.Add("So_Seri")

        'tbconfig.Rows.Add(Guid.NewGuid.ToString, "", "saigonotocanthoadmin", "Einv@oi@vn#pt20", "saigonotocanthoservice", "123456aA@", "01GTKT0/001", "CT/20E")

        'tbPH.Columns.Add("CusCode")
        'tbPH.Columns.Add("Buyer")
        'tbPH.Columns.Add("CusName")
        'tbPH.Columns.Add("CusAddress")
        'tbPH.Columns.Add("CusPhone")
        'tbPH.Columns.Add("CusTaxCode")
        'tbPH.Columns.Add("PaymentMethod")
        'tbPH.Columns.Add("KindOfService")
        'tbPH.Columns.Add("Products")
        'tbPH.Columns.Add("Total")
        'tbPH.Columns.Add("DiscountAmount")
        'tbPH.Columns.Add("VATRate")
        'tbPH.Columns.Add("VATAmount")
        'tbPH.Columns.Add("Amount")
        'tbPH.Columns.Add("AmountInWords")
        'tbPH.Columns.Add("Extra")
        'tbPH.Columns.Add("ArisingDate")
        'tbPH.Columns.Add("PaymentStatus")
        'tbPH.Columns.Add("ResourceCode")
        'tbPH.Columns.Add("type")
        'tbPH.Rows.Add("Ma_kh", "Đào Chí Minh", "CÔNG TY CỔ PHẦN PHẦN MỀM QUẢN TRỊ DOANH NGHIỆP", " Tầng 5, Tòa Nhà Viện Công Nghệ, Số 25 Vũ Ngọc phan, P.Láng Hạ, Quận Đống Đa", "0356900077", "0101419580", "TM", "09", "", "800000", "0", "10", "80000", "880000", "Tám trăm tám mươi tám ngàn đồng", "", "", "1", "", 0)

        'tbCT.Columns.Add("ProdName")
        'tbCT.Columns.Add("ProdUnit")
        'tbCT.Columns.Add("ProdQuantity")
        'tbCT.Columns.Add("ProdPrice")
        'tbCT.Columns.Add("Total")

        'tbCT.Rows.Add("Sản phẩm 0111", "Cái", "1", "100000", "100000")
        'tbCT.Rows.Add("Sản phẩm 0222", "Cái", "3", "100000", "300000")
        'tbCT.Rows.Add("Sản phẩm 0333", "Cái", "4", "100000", "400000")

        'tbconfig.Rows(0)("Stt_rec_TTDC") = TextBox1.Text
        'TextBox1.Text = Guid.NewGuid.ToString.Replace("-", "")
        'tbconfig.Rows(0)("Stt_rec") = TextBox1.Text
        'Dim str As DataSet = _supportInvoiceVNPT.V_DieuChinhHoaDon(tbconfig.Rows(0), tbPH.Rows(0), tbCT)
    End Sub
End Class
