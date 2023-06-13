using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class MasterPage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //lblUser.Text = Membership.GetUser().ProviderName;
        
        
        //Dữ liệu demo
        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenMenu", typeof(string));
        dt.Columns.Add("keys", typeof(string));
        dt.Rows.Add(new object[] { "../HangHoa/HangDi.aspx?tab=trangchu", "TRANG CHỦ","trangchu" });
        dt.Rows.Add(new object[] { "../NhanHang/NhanHang.aspx?tab=nhanhang", "NHẬN HÀNG", "nhanhang" });
        dt.Rows.Add(new object[] { "../HangDi/HangDi.aspx?tab=hangdi", "HÀNG ĐI", "hangdi" });
        dt.Rows.Add(new object[] { "#", "HÀNG VỀ", "hangve" });
        dt.Rows.Add(new object[] { "#", "GIAO HÀNG", "giaohang" });
        dt.Rows.Add(new object[] { "../ThongKe/ThongKe.aspx?tab=thongke", "THỐNG KÊ", "thongke" });
        dt.Rows.Add(new object[] { "#", "DANH MỤC", "danhmuc" });
        dt.Rows.Add(new object[] { "#", "NGƯỜI DÙNG", "nguoidung" });
        rptmenu.DataSource = dt;
        rptmenu.DataBind();
    }

    protected void rptmenu_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
