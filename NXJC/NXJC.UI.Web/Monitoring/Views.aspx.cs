using NXJC.Model.ProcessDataFoundation.Repository;
using NXJC.Repository.ProcessDataFoundation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NXJC.UI.Web.Monitoring
{
    public partial class Views : System.Web.UI.Page
    {
        private IContrastTableRepository contrastTableRepository = new ContrastTableRepository();

        public IDictionary<string, string> ViewNameDictionary;

        protected void Page_Load(object sender, EventArgs e)
        {
            int productLineId = 0;
            int.TryParse(Request.QueryString["productLineId"], out productLineId);

            ViewNameDictionary = contrastTableRepository.GetViewNames(productLineId);
        }
    }
}