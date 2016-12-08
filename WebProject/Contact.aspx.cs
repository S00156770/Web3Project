﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HeaderText = "Contact Us";

            Master.AddBreadcrumbLink("/Default.aspx", "Home");
            Master.AddCurrentPage("Contact Us");
        }
    }
}