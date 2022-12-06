using App_Test.Models;
using System;
using System.Reflection;
using System.Net.Mail;

namespace SendHTMLMail
{
    public class Class1
    {
        private static string macc;

        public static string Total { get; private set; }
        public static object GridView1 { get; private set; }
        public static object mail { get; private set; }
        public static object Body { get; private set; }

        public static int Main(string[] args)
        {
            TGSGDatabaseEntities ctx = new TGSGDatabaseEntities();
           
            try
            {
                // Create the Outlook application.
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();

                // Get the NameSpace and Logon information.
                Microsoft.Office.Interop.Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

                // Log on by using a dialog box to choose the profile.
                oNS.Logon(Missing.Value, Missing.Value, true, true);

                // Alternate logon method that uses a specific profile.
                // TODO: If you use this logon method, 
                //  change the profile name to an appropriate value.
                //oNS.Logon("YourValidProfile", Missing.Value, false, true); 

                // Create a new mail item.
                Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                // Set the subject.
                oMsg.Subject = "Send Using OOM in C#";

                // Set HTMLBody.
                String sHtml;
                sHtml = "<html><head><title></title>" + "<style>"
                            + "body { color:#000; font-family:Tahoma; font-size:11pt;}"
                            + "</style>"
                            + "</head><body ><br/>" + "<br/><p><dd> " + "เรียน ผู้ที่เกี่ยวข้อง" + "<br/><br/>"
                            + "<p><dd>" + "แจ้งการรับเงิน SC" + " " + macc + " " + " No." + " " + macc + " " + "จำนวนเงิน" + " " + Total + " " + "บาท" + "</dd></p>"
                             + "<p><dd>" + GetGridviewData(GridView1) + "</dd></p>"
                            + "<br/><br/><br/>"
                            + "</body></html>";
                //mail.onSend("sarinee@funny.tgsgmail", "nathchaya@funny.tgsgmail,janejira@funny.tgsgmail","sarinee@funny.tgsgmail", "แจ้งการรับเงิน SC" + " " + orderNo + " " + "(ทดสอบ)", Body + "<br/>" + Mail.MailTo+Mail.MailFrom+Mail.MailCC, "sarinee@funny.tgsgmail");
                

                // Add a recipient.
                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;
                // TODO: Change the recipient in the next line if necessary.
                Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add("email address");
                oRecip.Resolve();

                // Send.
                oMsg.Send();

                // Log off.
                oNS.Logoff();

                // Clean up.
                oRecip = null;
                oRecips = null;
                oMsg = null;
                oNS = null;
                oApp = null;
            }

            // Simple error handling.
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            // Default return value.
            return 0;

        }

        private static string GetGridviewData(object gridView1)
        {
            throw new NotImplementedException();
        }
    }
}