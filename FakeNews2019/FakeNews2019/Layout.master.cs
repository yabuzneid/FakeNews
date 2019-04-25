using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace FakeNews2019 {
    public partial class Layout : System.Web.UI.MasterPage
    {
        bool showSearch = true;
        public bool ShowSearch { get { return showSearch; } set { showSearch = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            SearchBlock.Visible = ShowSearch;
            if(IsPostBack && hfAction.Contains("search")) {
                Session["query"] = Search.Text;
                Response.Redirect("~/Pages/Search.aspx");
            }
        }

        protected void NavMenu_ItemClick(object source, MenuItemEventArgs e)
        {

        }
    }
}