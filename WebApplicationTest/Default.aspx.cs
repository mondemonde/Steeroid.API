using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationTest._Repo;

namespace WebApplicationTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            MyDb.Results.Add(DateTime.Now.ToString());
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }
}