using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace RealEstate
{
    public partial class ClientWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the client name from session
                string clientName = Session["Username"] != null ? Session["Username"].ToString() : "Client";
                ltlClientName.Text = clientName;
            }
        }

        protected void btnExploreProperties_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientViewProperties.aspx");
        }

        protected void btnOwnedProperties_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientOwnedProperties.aspx");
        }
    }
}