using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;


namespace ClassLibrary
{
    public class EmailContent
    {
        Email E = new Email();
        SqlConnection con = new SqlConnection();
        string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

        protected string Sender = "noreply@slri.or.th";


        public bool EmailVerification(string MemberID, string Email, string FullName, string UserName, string Password)
        {
            string Code = MemberID;

            string Domain = HttpContext.Current.Request.Url.ToString();
            Domain = Domain.ToLower();
            Domain = Domain.Replace("registration.aspx", "activate.aspx");
            Domain = Domain.Replace("login.aspx", "activate.aspx");
            string[] tempDomain = Domain.Split('?');
            Domain = tempDomain[0];

            string Receiver = Email;
            string Subject = "Welcome to Double A Point Collection Program";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for participating as part of Double A Point Collection program, a program that will provide various privileges more than others.<br/><br/>"
                + "To continued your subscribe Please click the link below to check your email.<br/><br/>"
                + "<a href='" + Domain + "?code=" + Code + "'>" + Domain + "?code=" + Code + "</a><br/><br/><br/><br/>"
                + "Your User ID and Password :<br/><br/>"
                + "User ID : " + UserName + "<br/>"
                + "Password : " + Password + "<br/><br/>"
                + "Thank you once again for being a part of Double A Point Collection program<br/><br/>"
                + "Best Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool Welcome(string Receiver, string FullName)
        {
            string Subject = "Welcome To Double A Point Collection Program";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Welcome to Double A Point Collection Program.<br/><br/>"
                + "You can change your password at http://thailand.doubleapointcollection.com <br/><br/>"
                + "To activate your account, please log in and select 'points collection', follow the steps that offered and send the tax invoice to collect your points.<br/><br/>"
                + "Note : Please sned your documents within 15 days for complete your subscription.<br/><br/>"
                + "For more information please contact us by e-mail at thailand@DoubleApointcollection.net or 1759 Double A Hotline. For the faster contaction please enter your account everytime.<br/><br/>"
                + "Thank you once again for being a part of Double A Point Collection program<br/><br/>"
                + "Best Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ForgetPassword(string MemberID, string Receiver, string Pass, string Name)
        {
            string Subject = "Receive System - Password Requested";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + Name + "<br/><br/>"
                + "Thank you for visiting us at Receive System. You have requested for your password to be sent to you.<br/><br/>"
                + "Your Member ID: " + MemberID + "<br/>"
                + "Your Password: " + Pass + "<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Receive System. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool MemberInactive(string Receiver, string FullName)
        {
            string Subject = "Double A Point Collection - Inactive Member";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for participating with Double A Point Collection Program as a value member. Now your account is upon setting 'Inactive' status due to lost connect from our program for 6 months. Please contact us for any inconvenience on our program to better serve you the best in the future.<br/><br/>"
                + "If you have any questions, please send your queries to thailand@DoubleApointcollection.net or call 1759 Double A Hotline. Please remember to quote your personal User ID in all your communications so we can serve you better.<br/><br/>"
                + "We appreciate having you as a customer.<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ClaimsSubmissionInvoice(string Receiver, string FullName, string ClaimNumber, string ClaimDate, string ClaimStatus, string ClaimPoints)
        {
            string Subject = "Double A Point Collection - Acknowledge of receipt of Claim Fax Document";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for using the online point collection service in the Double A Point Collection program. Your documents are being sent  the details are as follows:<br/><br/>"
                + "<b>Claim Number: " + ClaimNumber + "</b><br/>"
                + "<b>Submission Date: " + ClaimDate + "</b><br/>"
                + "<b>Overall Claim Status: " + ClaimStatus + "</b><br/>"
                + "<b>Overall Claim Points: " + ClaimPoints + "</b><br/><br/>"
                + "When your document has been approved. You will be notified your latest points Via your email.<br/><br/>"
                + "For more information please contact us by e-mail at thailand@DoubleApointcollection.net or 1759 Double A Hotline. For the faster contaction please enter your account everytime.<br/><br/>"
                + "Thank you for joining Double A Point Collection program. Many privileges and are waiting for you!<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ClaimsSubmissionFax(string Receiver, string FullName, string ClaimNumber, string ClaimDate, string ClaimStatus, string ClaimPoints)
        {
            string Subject = "Double A Point Collection - Acknowledge of receipt of Claim Fax Document";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for using the online point collection service in the Double A Point Collection program. Your documents have the following details:<br/><br/>"
                + "<b>Claim Number: " + ClaimNumber + "</b><br/>"
                + "<b>Submission Date: " + ClaimDate + "</b><br/>"
                + "<b>Overall Claim Status: " + ClaimStatus + "</b><br/>"
                + "<b>Overall Claim Points: " + ClaimPoints + "</b><br/><br/>"
                + "Please fax your tax invoice with the specified User ID  to 0-2659-1320 When your document has been approved. You will be notified your latest points  via your email.<br/><br/>"
                + "For more information please contact us by e-mail at thailand@DoubleApointcollection.net or 1759 Double A Hotline. For the faster contaction please enter your account everytime.<br/><br/>"
                + "Thank you for joining Double A Point Collection program. Many privileges and are waiting for you!<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ClaimsApproved(string Receiver, string FullName, string ClaimNumber, string ClaimDate, string ClaimStatus, string ClaimPoints, string BalancePoints)
        {
            string Subject = "Double A Point  Collection - Tax Invoice Approved";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for submitting the Online Claims form with Double A Point Collection. You can check the tax invoice has been added points. The details are as follows:<br/><br/>"
                + "<b>Claim Number: " + ClaimNumber + "</b><br/>"
                + "<b>Submission Date: " + ClaimDate + "</b><br/>"
                + "<b>Overall Claim Status: " + ClaimStatus + "</b><br/>"
                + "<b>Overall Claim Points: " + ClaimPoints + "</b><br/><br/>"
                + "The following Tax Invoice has been approved and the points have been awarded to you.<br/><br/>"
                + "Points awarded is <b>" + ClaimPoints + " points</b>."
                + "You now have a Total Balance of <b> " + BalancePoints + " points</b> in your account.<br/><br/>"
                + "For more information please contact us by e-mail at thailand@DoubleApointcollection.net or 1759 Double A Hotline. For the faster contaction please enter your account everytime.<br/><br/>"
                + "Thank you for joining Double A Point Collection program. Many privileges and are waiting for you!<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ClaimsRejection(string Receiver, string FullName, string ClaimNumber, string ClaimDate, string ClaimStatus, string ClaimPoints, string BalancePoints)
        {
            string Subject = "Double A Point  Collection - Tax Invoice Rejected";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for submitting the Online Claims form with Double A Point Collection. The details are as follows:<br/><br/>"
                + "<b>Claim Number: " + ClaimNumber + "</b><br/>"
                + "<b>Submission Date: " + ClaimDate + "</b><br/>"
                + "<b>Overall Claim Status: " + ClaimStatus + "</b><br/>"
                + "<b>Overall Claim Points: " + ClaimPoints + "</b><br/><br/>"
                + "We regret to inform you that the following Tax Invoice has been rejected because we did not receive any invoice and/or this invoice has been submited already.<br/><br/>"
                + "You now have a Total Balance of <b> " + BalancePoints + " points</b> in your account.<br/><br/>"
                + "For more information please contact us by e-mail at thailand@DoubleApointcollection.net or 1759 Double A Hotline. For the faster contaction please enter your account everytime.<br/><br/>"
                + "Thank you for joining Double A Point Collection program. Many privileges and are waiting for you!<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool ClaimsDocsNotClear(string Receiver, string FullName, string ClaimNumber, string ClaimDate, string ClaimStatus, string ClaimPoints, string BalancePoints, string InvoiceDate, string Supplier, string TaxInvoiceNo)
        {
            string Subject = "Double A Point  Collection - Documents are not clear";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for submitting tax invoices to Double A Point Collection program for points. The scrutiny of the documents have been found to hold:<br/><br/>"
                + "<b>Date : " + InvoiceDate + "   Supplier : " + Supplier + "    Tax Invoice No : " + TaxInvoiceNo + "</b><br/<br/>"
                + "The details are as follows:<br/>"
                + "<b>Claim Number: " + ClaimNumber + "</b><br/>"
                + "<b>Submission Date: " + ClaimDate + "</b><br/>"
                + "<b>Overall Claim Status: " + ClaimStatus + "</b><br/>"
                + "<b>Overall Claim Points: " + ClaimPoints + "</b><br/><br/>"
                + "Due to your documents are not complete and clear. Please send your documents again. To clarify your documents, please contact thailand@DoubleApointcollection.net or call 1759 Double A Hotline.<br/><br/>"
                + "You now have a Total Balance of <b> " + BalancePoints + " points</b> in your account.<br/><br/>"
                + "If you have any questions, please send your queries to thailand@DoubleApointcollection.net or call 1759 Double A Hotline. Please remember to quote your personal User ID in all your communications so we can serve you better.<br/><br/>"
                + "Thank you for joining Double A Point Collection program. Many privileges and are waiting for you!<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool RedemptionSubmission(string Receiver, string FullName, string RedeemPoints, string ShippingAddress, string BalancePoints, DataSet CartItem)
        {
            string Subject = "Double A Point Collection - Redemption Confirmation Email";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for participating with Double A Point Collection."
                + "On <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> you have redeemed the following items:<br/><br/>"
                + "<Table width='600px' border='0'><tr><td width='80px'>Redemption ID</td><td width='200px'>Reward Name</td><td width='120px'>Points Required</td><td width='100px'>Quantity</td><td width='100px'>Total Points</td></tr>";
            for (int i = 0; i < CartItem.Tables["Data"].Rows.Count - 1; i++)
            {
                Body += "<tr>"
                    + "<td>" + CartItem.Tables["Data"].Rows[i]["tempid"].ToString() + "</td>"
                    + "<td>" + CartItem.Tables["Data"].Rows[i]["reward_name"].ToString() + "</td>"
                    + "<td>" + CartItem.Tables["Data"].Rows[i]["reward_point"].ToString() + "</td>"
                    + "<td>" + CartItem.Tables["Data"].Rows[i]["reward_qty"].ToString() + "</td>"
                    + "<td>" + CartItem.Tables["Data"].Rows[i]["total_point"].ToString() + "</td>"
                    + "</tr>";
            }

            Body += "</Table>"
                + "<br/><br/>"
                + "You have used&nbsp;<b>" + RedeemPoints + "&nbsp;points</b>  for the redemption.<br/><br/>"
                + "The specified Delivery Address is:<br/><br/>"
                + ShippingAddress
                + "<br/><br/>"
                + "You now have a balance of&nbsp;<b>" + BalancePoints + "&nbsp;points</b> in your account.<br/><br/>"
                + "Please send documents to confirm redemption as below:<br/>"
                + "1. If you redeem for personal , please send a copy of ID card or<br/>"
                + "2. If you redeem for company name, please send a copy of your  ID card and company certificate.<br/>"
                + "Please fax the documents  to 0-2659-1320 . Rewards will be sent within 3-4 weeks  after 25th of  the month.<br/><br/>"
                + "Thank you once again for participating in Double A Point Collection. We look forward to serving you again!<br/><br/>"
                + "We appreciate having you as our customer.<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool RedemptionRejection(string Receiver, string FullName, string RedeemPoints, string BalancePoints, string RedemptionID, string SubmissionDate)
        {
            string Subject = "Double A Point Collection - Reward Redemption Reject";
            string Body;
            Body = "<head></head>";
            Body += "Dear " + FullName + "<br/><br/>"
                + "Thank you for participating with Double A Point Collection."
                + "On <b>" + SubmissionDate + "</b> you have redeemed the following items:<br/><br/>"
                + "You have used&nbsp;<b>" + RedeemPoints + "&nbsp;points</b>  for the redemption.<br/><br/>"
                + "Your redemption number is <b>" + RedemptionID + "</b>.<br/><br/>"
                + "We are sorry to inform you that the redemption has been rejected. Your points will be credited back to your account. If you have any questions, please send your question to thailand@DoubleApointcollection.net or call 1759 Double A Hotline<br/>"
                + "You now have a balance of&nbsp;<b>" + BalancePoints + "&nbsp;points</b> in your account.<br/><br/>"
                + "Thank you once again for participating in Double A Point Collection. We look forward to serving you again!<br/><br/>"
                + "We appreciate having you as our customer.<br/><br/>"
                + "Warmest Regards,<br/>"
                + "Double A Point Collection<br/>"
                + "Customer Service Centre<br/><br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool RedemptionDeliveryDate(string Receiver, string FullName, string RedemptionID, string RewardName, string Carrier, string DeliveryDate)
        {
            string Subject = "Double A Point Collection - Reward Redemption - Delivery detail";
            string Body;
            Body = "<head></head>";
            Body += "Dear Member,<br/><br/>"
                + "Thank you very much for your gift redemption. We would like to notify you that we have already shipped<br/>"
                + "out your gift item. The detail of shipment is as follow.<br/><br/>"
                + "Redemption number: <b>" + RedemptionID + "</b><br/>"
                + "Reward Name: <b>" + RewardName + "</b><br/>"
                + "Courier: <b>" + Carrier + "</b><br/>"
                + "Ship Out Date: <b>" + DeliveryDate + "</b><br/><br/>"
                + "If you have any problems, please contact us by email thailand@DoubleApointcollection.com or call 1759 Double A Hotline<br/>"
                + "Once again, thank you very much and hope your are enjoying Double A Point Collection.<br/><br/>"
                + "Regards,<br/>"
                + "Double A Point Collection Team<br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }

        public bool RedemptionDeliveryCode(string Receiver, string FullName, string RedemptionID, string RewardName, string Carrier, string TrackingCode)
        {
            string Subject = "Double A Point Collection - Reward Redemption - Delivery detail";
            string Body;
            Body = "<head></head>";
            Body += "Dear Member,<br/><br/>"
                + "Thank you very much for your gift redemption. We would like to notify you that we have already shipped<br/>"
                + "out your gift item. The detail of shipment is as follow.<br/><br/>"
                + "Redemption number: <b>" + RedemptionID + "</b><br/>"
                + "Reward Name: <b>" + RewardName + "</b><br/>"
                + "Courier: <b>" + Carrier + "</b><br/>"
                + "Tracking Number: <b>" + TrackingCode + "</b><br/><br/>"
                + "You may visit the courier website to track the shipment status. If you have any problems, please send the<br/>"
                + "email to thailand@DoubleApointcollection.com or call 1759 Double A Hotline.<br/>"
                + "Once again, thank you very much and hope your are enjoying Double A Point Collection.<br/><br/>"
                + "Regards,<br/>"
                + "Double A Point Collection Team<br/>"
                + "This is an auto-generated service e-mail related to your use of Double A Point Collection. No signatures will be published.<br/>";
            Body += "</body>";

            if (E.SendEmailHTML_Format(Sender, Receiver, Subject, Body))
            {
                return true;
            }
            return false;
        }
    }
}