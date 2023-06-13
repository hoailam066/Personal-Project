using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class CSKH_TaoMoiCSKH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack) return;
        if (Request.Url.Query == "")
            Response.Redirect(Request.Url.AbsoluteUri + "?tab=Banve");
        //Load Quyền
        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenQuyen", typeof(string));
        dt.Columns.Add("Icon", typeof(string));
        dt.Rows.Add(new object[] { "../CSKH/LichSuCSKH.aspx", "Lịch sử phục vụ KH", "../image/iconBanve.png" });
        dt.Rows.Add(new object[] { "../CSKH/KhachHang.aspx", "In sơ đồ xe", "../image/iconBanveSodoxe.png" });
        dt.Rows.Add(new object[] { "../CSKH/ThongTinBanVe.aspx", "Thao tác nâng cao", "../image/iconBanveThaotacnangcao.png" });
        dt.Rows.Add(new object[] { "../CSKH/ChiTietCSKH.aspx", "Thống kê và tìm kiếm", "../image/iconBanveThongkevatimkiem.png" });
        ViewState.Add("TenTrang", "../CSKH/TTGiaoNhan.aspx");
        rptTrang.DataSource = dt;
        rpt_Quyen.DataSource = dt;
        rpt_Quyen.DataBind();
        rptTrang.DataBind();

    }
}