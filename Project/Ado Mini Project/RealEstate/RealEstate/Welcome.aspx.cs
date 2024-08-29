using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RealEstate
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUsername.Text = Session["Username"].ToString();
            }
        }

        protected void btnAddProperty_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProperty.aspx");
        }

        protected void btnUpdateDeleteProperties_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateDeleteProperties.aspx");
        }
        protected void btnShowClientProperties_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgentProperties.aspx"); 
        }
    }
}
