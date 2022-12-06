using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Tgsg;
using App_Test.Models;

namespace Login
{
    public partial class chkAuthorized : System.Web.UI.Page
    {
        private TGSGDatabaseEntities ctx = new TGSGDatabaseEntities();
        private string EmpID
        {
            get
            {
                if (ViewState["EmpID"] == null)
                    ViewState["EmpID"] = "";
                return ViewState["EmpID"] as string;
            }
            set
            {
                ViewState["EmpID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string uCode = Request.QueryString["ValidUser"];
                string page = Request.QueryString["page"];
                string Value = Request.QueryString["Value"];
                EmpID = Request.QueryString["ValidUser"];
                //SessionLogin login = new Authorized().GetPermissionAccess(uCode);
                var status = ctx.Tgsg_usp_AppRoute(uCode, "appTest").FirstOrDefault();
                if (status == "True")
                {
                    var login = ctx.Tgsg_usp_AppRama3Login(uCode, "appTest").FirstOrDefault();
                    if (login != null)
                    {

                        Response.Cookies["myCookietest"]["EmpID"] = login.TGSGempID.ToString();

                        Response.Cookies["myCookieTest"].Expires = DateTime.Now.AddDays(6);


                        Response.Redirect("WebForm1Search.aspx");
                        //Response.Redirect("Order_Entry.aspx?oKey=97748");
                        //Response.Redirect("Order_New.aspx");
                    }
                }
                else
                {
                    Response.Redirect("noRightToAccess.aspx");
                }


            }
            //string uCode = Request.QueryString["ValidUser"];
            //    string page = Request.QueryString["page"];
            //    string Value = Request.QueryString["Value"];
            //    dtA = Authorized.GetPermission(uCode, "INVOICE");
            //    SessionLogin login = new Authorized().GetPermissionAccess(uCode);
            //    if (dtA.Rows[0].Field<string>("appGrp").ToString() == "True")
            //    {
            //        dtP = Authorized.GetDataEmp(uCode);
            //        if (dtP != null)
            //        {
            //            string CoreID = dtP.Rows[0].Field<string>("CoreID").ToString(); //Column Area From Table TGSG_Username
            //            string UserName = dtP.Rows[0].Field<string>("UserName").ToString();
            //            string Acc = dtP.Rows[0].Field<string>("BgtAcc").ToString();
            //            string EmpID = dtP.Rows[0].Field<string>("TGSGempID").ToString();
            //            string MarketGroup = dtP.Rows[0].Field<Int32>("MarketGroup").ToString();
            //            string Dept = dtP.Rows[0].Field<string>("Dept").ToString();
            //            string UserMail = dtP.Rows[0].Field<string>("CoreID").ToString(); //Column Area From Table TGSG_Username
            //            string sectionDesc = dtP.Rows[0].Field<string>("sectionDesc").ToString();
            //            string unitDesc = dtP.Rows[0].Field<string>("unitDesc").ToString();
            //            string posLevel = dtP.Rows[0].Field<Int32>("posLevel").ToString();
            //            string GrpMail = dtP.Rows[0].Field<string>("GrpMail").ToString();
            //            string AREA = dtP.Rows[0].Field<string>("AREA").ToString();

            //        if (Acc == "810")
            //            Acc = "Account";

            //        Session["Acc"] = Acc.ToString();
            //        Session["CoreID"] = CoreID.ToString();
            //        Session["EmpID"] = EmpID.ToString();
            //        Session["Dept"] = Dept.ToString();
            //        Session["AREA"] = AREA.ToString();
            //        Session["Route"] = login.UserRoutID;

            //        Session.Timeout = 480;
            //            Session["login"] = dtP;

                
            //        //Response.Redirect("Invoice_Search.aspx");
            //    }
            //    }

            //    else
            //    {
            //        Response.Redirect("noRightToAccess.aspx");
            //    }
            //    //if (login != null)
            //    //{
            //    //    string EmpID = login.TGSGEmpID;
            //    //    string CoreID = login.CoreID; //Column Area From Table TGSG_Username
            //    //    string MarketGroup = login.Dept;
            //    //    string Acc = login.BgtAcc;
            //    //    string Dept = login.Dept;

            //    //    if (CoreID == "C")
            //    //        CoreID = "2";
            //    //    else
            //    //        CoreID = "1";

            //    //    if (Acc == "810")
            //    //        Acc = "Account";
            //    //    else

            //    //    Session["Acc"] = Acc.ToString();

            //    //    Session["CoreID"] = CoreID.ToString();
            //    //    Session["EmpID"] = EmpID.ToString();
            //    //    Session["Dept"] = Dept.ToString();

            //    //    Session.Timeout = 480;
            //    //    Session["login"] = login;

            //    //    if (page == "ImportTax")
            //    //        Response.Redirect("frmImportTax.aspx");
            //    //    else if (page == "APBill")
            //    //        Response.Redirect("frmBill.aspx");
            //    //    else if (page == "APBuyTax")
            //    //        Response.Redirect("frmBuyTax.aspx");
            //    //    else if (page == "ReportSumAPBill")
            //    //        Response.Redirect("rptSumAPBill.aspx");
            //    //    else if (page == "ReportBuyTax")
            //    //        Response.Redirect("rptBuyTax.aspx");
            //    //    else if (page == "ImportOil")
            //    //        Response.Redirect("frmImpOil.aspx");
            //    //    else if (page == "CancelDO")
            //    //        Response.Redirect("CancelDO.aspx");
            //    //    else
            //    //        Response.Redirect("frmEditEmployee.aspx");
            //    //}
            //    //else
            //    //{
            //    //    Response.Redirect("noRightToAccess.aspx");
            //    //}

        }      
    }
}