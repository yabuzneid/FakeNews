using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FakeNews2019.Code;

namespace FakeNews2019 {
    public partial class BlogTimeline : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            PrepareDataView();
        }
        void PrepareDataView() {
            int? year = Request.Params["year"] != null ? int.Parse(Request.Params["year"]) : (int?)null;
            int? month = Request.Params["month"] != null ? int.Parse(Request.Params["month"]) : (int?)null;
            BlogPostsDataView.DataSource = BlogPostsProvider.GetBlogPosts(year, month);
            BlogPostsDataView.DataBind();
        }
    }
}