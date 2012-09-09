using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;

namespace Pharmacy
{
    public partial class ExcelExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            //string arr = "[{'SiteDrugId':39076,'SiteDrugCode':'2237','SiteDrugName':'ALBUMIN HUMAN 5 % IV SOLN','MappedPharmacyDrug':'albumin','Strength':'500','Units':'mL','MappedPharmacyUnit':'ML','InsertedLDT':null,'MappedLDT':null,'isReleased':true,'isReviewed':false}]";
            string arr = Request.Params["SubmittedData"].ToString();
            //var data = js.Deserialize <List<SiteDrug>>(Request.Params["Data"]);
            var data = js.Deserialize<List<PharmacyDrug>>(arr);
            GridView gv = new GridView();
            gv.DataSource = data;
            gv.DataBind();
            
            string attachment = "attachment; filename=Data.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition",attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stw);
            gv.RenderControl(htw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}
