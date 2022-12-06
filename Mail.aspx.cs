using App_Test.Models;
using System;
using System.Reflection;
using System.Net.Mail;
using Erp.Lib;
using App_Test;
using System.Linq;

//namespace App_Test
//{
   // public class Class1
   // {
       // TGSGDatabaseEntities ctx = new TGSGDatabaseEntities();

       // private void SendMailMIS(string RecNo, string orderNo, string Total)
        //{
            //SendMail mail = new SendMail(25, "192.168.87.5");

            // var checkData = ctx.TGSG_TestGetData("1", RecNo).ToList();
            //if (checkData.Count > 0)
            //{
            //    GridView1.DataSource = checkData;
            //     GridView1.DataBind();
            // }
            //  var Mail = ctxg.Tgsg_usp_ReceiptConfrimApproveMIS(orderNo, EmpID).FirstOrDefault();
            //  if (Mail != null)
            //{
              //  string Body = "<html><head><title></title>" + "<style>"
               // + "body { color:#000; font-family:Tahoma; font-size:11pt;}"
               // + "</style>"
              //  + "</head><body ><br/>" + "<br/><p><dd> " + "เรียน ผู้ที่เกี่ยวข้อง" + "<br/><br/>"
              //  + "<p><dd>" + "แจ้งการรับเงิน SC" + " " + orderNo + " " + "Receipt No." + " " + RecNo + " " + "จำนวนเงิน" + " " + Total + " " + "บาท" + "</dd></p>"
                //   + "<p><dd>" + GetGridviewData(GridView1) + "</dd></p>"
              //  + "<br/><br/><br/>"
              //  + "</body></html>";
                //mail.onSend("sumet@funny.tgsgmail", "nathchaya@funny.tgsgmail,sumeta@funny.tgsgmail", "sumet@funny.tgsgmail", "แจ้งการรับเงิน SC" + " " + orderNo + " " + "(ทดสอบ)", Body + "<br/>" + Mail.MailTo + Mail.MailFrom + Mail.MailCC, "sumet@funny.tgsgmail");
              //  mail.onSend("sumet@funny.tgsgmail", "nathchaya@funny.tgsgmail", "sumet@funny.tgsgmail", "test" + " " + "No 99"  + " " + "(ทดสอบ)", Body + "<br/>" + Mail.MailTo+Mail.MailFrom+Mail.MailCC, "sumet@funny.tgsgmail");
           // }
      //  }
  //  }
//}