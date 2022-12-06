using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Test.Models;
using Erp.Lib;
using TGSG;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace App_Test
{
    public partial class WebForm1Input : System.Web.UI.Page

    {
        TGSGDatabaseEntities ctx = new TGSGDatabaseEntities();
        private string IDName
        {
            get
            {
                if (ViewState["IDName"] == null)
                    ViewState["IDName"] = "";
                return ViewState["IDName"] as string;
            }
            set
            {
                ViewState["IDName"] = value;
            }
        }

        public string No { get; private set; }
        public string No999 { get; private set; }
        public string Total { get; private set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            IDName = Request.QueryString["IDName"];

            if (!IsPostBack)
            {
                GetData(IDName);

            }
        }

        public void GetData(string id)
        {
            var dt = ctx.TGSG_TestGetData(MyConvert.ToInt32(IDName)).FirstOrDefault();
            if (dt != null)
            {
                txtBD.Text = Convert.ToDateTime(dt.BD.ToString()).ToString("dd/mm/yyyy");
                txtName.Text = dt.Name;
                txtLastName.Text = dt.Lastname;
                txtTel.Text = dt.Tel;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }

            var gvdt = ctx.TGSG_TestSearch("").ToList();
            gvInsert.DataSource = gvdt;
            gvInsert.DataBind();

        }

        public void Clear()
        {
            txtBD.Text = "";
            txtLastName.Text = "";
            txtName.Text = "";
            txtTel.Text = "";

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var dt = ctx.TGSG_TestInsert(null, txtName.Text, txtLastName.Text, txtTel.Text, MyConvert.ToDateTime(txtBD.Text), null, 0, null).FirstOrDefault();
            if (dt != null)
            {
                IDName = dt.id.ToString();

            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('บันทึกข้อมูลเรียบร้อยแล้ว')", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var dt = ctx.TGSG_TestInsert(MyConvert.ToInt32(IDName), txtName.Text, txtLastName.Text, txtTel.Text, MyConvert.ToDateTime(txtBD.Text), null, 1, null).FirstOrDefault();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('บันทึกข้อมูลเรียบร้อยแล้ว')", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var dt = ctx.TGSG_TestInsert(MyConvert.ToInt32(IDName), txtName.Text, txtLastName.Text, txtTel.Text, MyConvert.ToDateTime(txtBD.Text), null, 2, null).FirstOrDefault();
            Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('บันทึกข้อมูลเรียบร้อยแล้ว')", true);
        }

        protected void txtBD_TextChanged(object sender, EventArgs e)
        {
            if (MyConvert.ToDateTime(txtBD.Text) > DateTime.Now)
            {
                txtBD.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Date Lower')", true);
            }

        }

        protected void btnEditDetail_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            TextBox txtNameVar = row.FindControl("txtName") as TextBox;
            TextBox txtLastNameVar = row.FindControl("txtLastName") as TextBox;
            TextBox txtBDVar = row.FindControl("txtBD") as TextBox;
            TextBox txtTelVar = row.FindControl("txtTel") as TextBox;

            LinkButton btnEditDetailVar = row.FindControl("btnEditDetail") as LinkButton;
            LinkButton btnUpdateDetailVar = row.FindControl("btnUpdateDetail") as LinkButton;
            LinkButton btnCancelDetailVar = row.FindControl("btnCancelDetail") as LinkButton;

            txtNameVar.ReadOnly = false;
            txtNameVar.BackColor = System.Drawing.Color.Empty;
            txtNameVar.BorderStyle = BorderStyle.Inset;

            txtLastNameVar.ReadOnly = false;
            txtLastNameVar.BackColor = System.Drawing.Color.Empty;
            txtLastNameVar.BorderStyle = BorderStyle.Inset;

            txtBDVar.ReadOnly = false;
            txtBDVar.BackColor = System.Drawing.Color.Empty;
            txtBDVar.BorderStyle = BorderStyle.Inset;

            txtTelVar.ReadOnly = false;
            txtTelVar.BackColor = System.Drawing.Color.Empty;
            txtTelVar.BorderStyle = BorderStyle.Inset;

            btnUpdateDetailVar.Visible = true;
            btnCancelDetailVar.Visible = true;
            btnEditDetailVar.Visible = false;


        }

        protected void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            TextBox txtNameVar = row.FindControl("txtName") as TextBox;
            TextBox txtLastNameVar = row.FindControl("txtLastName") as TextBox;
            TextBox txtBDVar = row.FindControl("txtBD") as TextBox;
            TextBox txtTelVar = row.FindControl("txtTel") as TextBox;
            Label lblidVar = row.FindControl("lblid") as Label;

            LinkButton btnEditDetailVar = row.FindControl("btnEditDetail") as LinkButton;
            LinkButton btnUpdateDetailVar = row.FindControl("btnUpdateDetail") as LinkButton;
            LinkButton btnCancelDetailVar = row.FindControl("btnCancelDetail") as LinkButton;

            ctx.TGSG_TestInsert(MyConvert.ToInt32(lblidVar.Text), txtNameVar.Text, txtLastNameVar.Text, txtTelVar.Text, MyConvert.ToDateTime(txtBDVar.Text), null, 1, null);

            GetData(IDName);
            btnUpdateDetailVar.Visible = false;
            btnCancelDetailVar.Visible = false;
            btnEditDetailVar.Visible = true;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('แก้ไขข้อมูลเรียบร้อย')", true);
        }

        protected void btnPrintPDF_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                             , "newWindow", "window.open('WebForm1PrintPDF.aspx?Search=" + txtName.Text + "&IDName=" + IDName + "');", true);
        }

        protected void btnReportViewer_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                            , "newWindow", "window.open('WebForm1ReportViewer.aspx');", true);
        }

        protected void btnCancelDetail_Click(object sender, EventArgs e)
        {
            GetData(IDName);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            TextBox txtNameVar = gvInsert.FooterRow.FindControl("txtName") as TextBox;
            TextBox txtLastNameVar = gvInsert.FooterRow.FindControl("txtLastname") as TextBox;
            TextBox txtBDVar = gvInsert.FooterRow.FindControl("txtBD") as TextBox;
            TextBox txtTelVar = gvInsert.FooterRow.FindControl("txtTel") as TextBox;

            ctx.TGSG_TestInsert(null, txtNameVar.Text, txtLastNameVar.Text, txtTelVar.Text, MyConvert.ToDateTime(txtBDVar.Text), null, 0, null);
            GetData(IDName);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('บันทึกข้อมูลเรียบร้อย')", true);
        }

        protected void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

            Label lblidVar = row.FindControl("lblid") as Label;

            ctx.TGSG_TestInsert(MyConvert.ToInt32(lblidVar.Text), null, null, null, null, null, 2, null);
            GetData(IDName);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบแก้ไขข้อมูลเรียบร้อย')", true);
        }


        protected void btnReportViewer2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                , "newWindow", "window.open('WebForm1ReportViewer2.aspx');", true);
        }



        protected void btnAutomail_Click(object sender, EventArgs e)
        {

            SendMail mail = new SendMail(25, "192.168.87.5");

             var checkData = ctx.TGSG_TestSearch("macc").ToList();
             if (checkData.Count > 0)
            {
                GridView1.DataSource = checkData;
                GridView1.DataBind();

            }
                var Mail = ctx.TGSG_TestSearch("macc").FirstOrDefault();
                if (Mail != null)
            {
                
                string Body = "<html><head><title></title>" + "<style>"
                + "body { color:#000; font-family:Tahoma; font-size:11pt;}"
                + "</style>"
                + "</head><body ><br/>" + "<br/><p><dd> " + "เรียน ผู้ที่เกี่ยวข้อง" + "<br/><br/>"
                + "<p><dd>" + "แจ้งการรับเงิน SC" + " " + No + " " + "Receipt No." + " " + No999 + " " + "จำนวนเงิน" + " " + Total + " " + "บาท" + "</dd></p>"
                + "<p><dd>" + GetGridviewData(GridView1) + "</dd></p>"
                + "<br/><br/><br/>"
                + "</body></html>";
                //mail.onSend("sumet@funny.tgsgmail", "nathchaya@funny.tgsgmail,sumeta@funny.tgsgmail", "sumet@funny.tgsgmail", "แจ้งการรับเงิน SC" + " " + orderNo + " " + "(ทดสอบ)", Body + "<br/>" + Mail.MailTo + Mail.MailFrom + Mail.MailCC, "sumet@funny.tgsgmail");
                mail.onSend("sumet@funny.tgsgmail", "nathchaya@funny.tgsgmail", "sumet@funny.tgsgmail", "test" + " " + "No 99" + " " + "(ทดสอบ)", Body + "<br/>" + Mail.MailTo + Mail.MailFrom + Mail.MailCC, "sumet@funny.tgsgmail");
                      ScriptManager.RegisterStartupScript(this, this.GetType()
                         , "newWindow", "window.open('Mail.aspx');", true);



            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            StringWriter strWriter = new StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }
        

        private class Mail
        {
            public static string MailTo { get; internal set; }
            public static string MailFrom { get; internal set; }
            public static string MailCC { get; internal set; }
        }
    }

   
}