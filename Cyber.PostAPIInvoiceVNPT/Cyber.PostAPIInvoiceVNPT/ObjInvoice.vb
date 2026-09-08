Imports Newtonsoft.Json

Public Class InvoiceVatRequest

    <JsonProperty("type_cert")>
    Public Property type_cert As String

    <JsonProperty("serial_number")>
    Public Property serial_number As String

    <JsonProperty("KHMSHDon")>
    Public Property KHMSHDon As String

    <JsonProperty("KHHDon")>
    Public Property KHHDon As String

    <JsonProperty("HDons")>
    Public Property HDons As List(Of InvoiceVat)
End Class

Public Class InvoiceVat

    <JsonProperty("HDDThu")>
    Public Property HDDThu As String

    <JsonProperty("PTGuiHDon")>
    Public Property PTGuiHDon As String

    <JsonProperty("TrangThaiTToan")>
    Public Property TrangThaiTToan As Boolean?

    <JsonProperty("NLap")>
    Public Property NLap As String

    <JsonProperty("Fkey")>
    Public Property Fkey As String

    <JsonProperty("ExtTTChung")>
    Public Property ExtTTChung As List(Of ExtensionInfo)

    <JsonProperty("NBan")>
    Public Property NBan As SellerInfo

    <JsonProperty("NMua")>
    Public Property NMua As BuyerInfo

    <JsonProperty("BKe")>
    Public Property BKe As StatementInfo

    <JsonProperty("HHDVu")>
    Public Property HHDVu As List(Of ProductInfo)

    <JsonProperty("CKhau")>
    Public Property CKhau As DiscountInfo

    <JsonProperty("TToan")>
    Public Property TToan As PaymentInfo

    <JsonProperty("THTTLTSuat")>
    Public Property THTTLTSuat As List(Of TaxSummaryInfo)

    <JsonProperty("DSLPhi")>
    Public Property DSLPhi As List(Of FeeInfo)
End Class

Public Class InvoiceTraCuuPDF
    <JsonProperty("type")>
    Public Property type As String

    <JsonProperty("key")>
    Public Property key As String

End Class
Public Class InvoiceUpdateHD
    <JsonProperty("type")>
    Public Property type As String

    <JsonProperty("key")>
    Public Property key As String

End Class

Public Class ExtensionInfo

    <JsonProperty("name")>
    Public Property name As String

    <JsonProperty("value")>
    Public Property value As String
End Class

Public Class SellerInfo

    <JsonProperty("DChi")>
    Public Property DChi As String

    <JsonProperty("STKNHang")>
    Public Property STKNHang As String

    <JsonProperty("TNHang")>
    Public Property TNHang As String

    <JsonProperty("DCTDTu")>
    Public Property DCTDTu As String

    <JsonProperty("SDThoai")>
    Public Property SDThoai As String

    <JsonProperty("Fax")>
    Public Property Fax As String

    <JsonProperty("Website")>
    Public Property Website As String

    <JsonProperty("MCHang")>
    Public Property MCHang As String

    <JsonProperty("TCHang")>
    Public Property TCHang As String

    <JsonProperty("exten")>
    Public Property exten As List(Of ExtensionInfo)
End Class

Public Class BuyerInfo

    <JsonProperty("HVTNMHang")>
    Public Property HVTNMHang As String

    <JsonProperty("Ten")>
    Public Property Ten As String

    <JsonProperty("MST")>
    Public Property MST As String

    <JsonProperty("DChi")>
    Public Property DChi As String

    <JsonProperty("MKHang")>
    Public Property MKHang As String

    <JsonProperty("SDThoai")>
    Public Property SDThoai As String

    <JsonProperty("DCTDTu")>
    Public Property DCTDTu As String

    <JsonProperty("STKNHang")>
    Public Property STKNHang As String

    <JsonProperty("TNHang")>
    Public Property TNHang As String

    <JsonProperty("HTTToan")>
    Public Property HTTToan As String

    <JsonProperty("DVTTe")>
    Public Property DVTTe As String

    <JsonProperty("TGia")>
    Public Property TGia As Decimal?

    <JsonProperty("CCCDan")>
    Public Property CCCDan As String

    <JsonProperty("SHChieu")>
    Public Property SHChieu As String

    <JsonProperty("MDVQHNSach")>
    Public Property MDVQHNSach As String

    <JsonProperty("extens")>
    Public Property extens As List(Of ExtensionInfo)
End Class

Public Class StatementInfo

    <JsonProperty("SBKe")>
    Public Property SBKe As String

    <JsonProperty("NBKe")>
    Public Property NBKe As String
End Class

Public Class ProductInfo

    <JsonProperty("STT")>
    Public Property STT As Integer?

    <JsonProperty("TChat")>
    Public Property TChat As String

    <JsonProperty("MHHDVu")>
    Public Property MHHDVu As String

    <JsonProperty("THHDVu")>
    Public Property THHDVu As String

    <JsonProperty("DVTinh")>
    Public Property DVTinh As String

    <JsonProperty("SLuong")>
    Public Property SLuong As Decimal?

    <JsonProperty("DGia")>
    Public Property DGia As Decimal?

    <JsonProperty("TLCKhau")>
    Public Property TLCKhau As Decimal?

    <JsonProperty("STCKhau")>
    Public Property STCKhau As Decimal?

    <JsonProperty("ThTien")>
    Public Property ThTien As Decimal?

    <JsonProperty("TSuat")>
    Public Property TSuat As String

    <JsonProperty("TThue")>
    Public Property TThue As Decimal?

    <JsonProperty("ExtThTienSThue")>
    Public Property ExtThTienSThue As Decimal?

    <JsonProperty("ExtTGTKCThue")>
    Public Property ExtTGTKCThue As Decimal?

    <JsonProperty("ExtTGThue")>
    Public Property ExtTGThue As Decimal?

    <JsonProperty("SKhung")>
    Public Property SKhung As String

    <JsonProperty("Smay")>
    Public Property Smay As String

    <JsonProperty("BKSPTVChuyen")>
    Public Property BKSPTVChuyen As String

    <JsonProperty("TNGHang")>
    Public Property TNGHang As String

    <JsonProperty("DCNGHang")>
    Public Property DCNGHang As String

    <JsonProperty("MSTNGHang")>
    Public Property MSTNGHang As String

    <JsonProperty("MDDNGHang")>
    Public Property MDDNGHang As String

    <JsonProperty("extens")>
    Public Property extens As List(Of ExtensionInfo)
End Class

Public Class DiscountInfo

    <JsonProperty("ExtTLCKhau")>
    Public Property ExtTLCKhau As Decimal?

    <JsonProperty("ExtThTienCKhau")>
    Public Property ExtThTienCKhau As Decimal?
End Class

Public Class PaymentInfo

    <JsonProperty("TTCKTMai")>
    Public Property TTCKTMai As Decimal?

    <JsonProperty("TgTCThue")>
    Public Property TgTCThue As Decimal

    <JsonProperty("ExtTgTienPhi")>
    Public Property ExtTgTienPhi As Decimal?

    <JsonProperty("TGTKCThue")>
    Public Property TGTKCThue As Decimal?

    <JsonProperty("TGTKhac")>
    Public Property TGTKhac As Decimal?

    <JsonProperty("TgTThue")>
    Public Property TgTThue As Decimal

    <JsonProperty("TgTTTBSo")>
    Public Property TgTTTBSo As Decimal

    <JsonProperty("TgTTTBChu")>
    Public Property TgTTTBChu As String

    <JsonProperty("QDoiTgTTTBSo")>
    Public Property QDoiTgTTTBSo As Decimal?

    <JsonProperty("exten")>
    Public Property exten As List(Of ExtensionInfo)
End Class

Public Class TaxSummaryInfo

    <JsonProperty("TSuat")>
    Public Property TSuat As String

    <JsonProperty("ThTien")>
    Public Property ThTien As Decimal

    <JsonProperty("TThue")>
    Public Property TThue As Decimal
End Class

Public Class FeeInfo

    <JsonProperty("STT")>
    Public Property STT As Integer?

    <JsonProperty("TLPhi")>
    Public Property TLPhi As String

    <JsonProperty("ExtTTienLPhi")>
    Public Property ExtTTienLPhi As Decimal?

    <JsonProperty("ExtTSuat")>
    Public Property ExtTSuat As String

    <JsonProperty("ExtTThue")>
    Public Property ExtTThue As Decimal?

    <JsonProperty("TPhi")>
    Public Property TPhi As Decimal?
End Class