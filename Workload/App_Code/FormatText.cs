using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;


namespace ClassLibrary
{
    public class FormatText
    {
        public string GetCheckValue(bool value)
        {
            string CheckValue;

            if (value == true)
            {
                CheckValue = "Y";
            }
            else
            {
                CheckValue = "N";
            }

            return CheckValue;
        }

        public bool SetCheckValue(string value)
        {
            bool CheckValue;

            if (value == "Y")
            {
                CheckValue = true;
            }
            else
            {
                CheckValue = false;
            }

            return CheckValue;
        }

        public DateTime FormatDate(string DateText)
        {
            DateTime date = new DateTime(1900, 1, 1);

            if (DateText != "" && DateText.Contains("/"))
            {
                // dd/MM/yyyy
                string[] d = DateText.Split('/'); 
                date = new DateTime(Convert.ToInt32(d[2]), Convert.ToInt32(d[1]), Convert.ToInt32(d[0]));
            }

            return date;
        }

        public DateTime FormatEndDate(string DateText)
        {
            DateTime date = new DateTime(1900, 12, 1, 23, 59, 59);

            if (DateText != "" && DateText.Contains("/"))
            {
                // dd/MM/yyyy
                string[] d = DateText.Split('/');
                date = new DateTime(Convert.ToInt32(d[2]), Convert.ToInt32(d[1]), Convert.ToInt32(d[0]), 23, 59, 59);
            }

            return date;
        }

        public string PrepText(string value)
        {
            value = value.Trim();
            if (value != "")
            {
                value = "N'" + FixQuote(value) + "'";
            }
            else
            {
                value = "Null";
            }
            return value;
        }

        public string FixQuote(string value)
        {
            if (value != "")
            {
                value = value.Replace("'", "''");
            }
            else
            {
                value = "";
            }
            return value;
        }

        public string PrepDate(string day, string month, string year)
        {
            string value;
            if (day == "" || month == "" || year == "" || day == "0" || month == "0" || year == "0")
            {
                value = "";
            }
            else
            {
                value = year + "-" + month + "-" + day;
            }
            return value;
        }

        public string CutInvalidChar(string StrMsg)
        {
            string[] InvalidChar = { "!", "@", "#", "$", "%", "^", "&", "=", ",", "'", ";", ".", "-", "_", "?", "/", "(", ")", " " };
            StrMsg = StrMsg.Trim();

            foreach (string Chars in InvalidChar)
            {
                StrMsg = StrMsg.Replace(Chars, "").ToLower();
            }
            return StrMsg;
        }

        public bool CheckFileName(string FN, Label lbl)
        {
            //string[] InvalidChar = { "!", "@", "#", "$", "%", "^", "&", "=", ",", "'", ";", " "};   
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-()[].";
            string InvalidList = "";

            //foreach (string Chars in InvalidChar)
            //{
            //    if (FN.Contains(Chars))
            //    {
            //        InvalidList += Chars.ToString() + " ";
            //    }
            //}

            foreach (char Chars in FN)
            {
                if (!allowedChars.Contains(Chars.ToString()))
                {
                    InvalidList += Chars.ToString() + " ";
                }
            }

            if (InvalidList != "")
            {
                lbl.Text += "File name allow only a-z, A-Z, 0-9, [ ], ( ), _ , -<br/>Your filename contain " + InvalidList + "<br/>Please, rename your file.<br />";
                return false;
            }

            return true;
        }

        // Allow space 
        public bool CheckFileNameSpace(string FN, Label lbl)
        {
            //string[] InvalidChar = { "!", "@", "#", "$", "%", "^", "&", "=", ",", "'", ";"};   
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-()[]. ";
            string InvalidList = "";

            //foreach (string Chars in InvalidChar)
            //{
            //    if (FN.Contains(Chars))
            //    {
            //        InvalidList += Chars.ToString() + " ";
            //    }
            //}

            foreach (char Chars in FN)
            {
                if (!allowedChars.Contains(Chars.ToString()))
                {
                    InvalidList += Chars.ToString() + " ";
                }
            }

            if (InvalidList != "")
            {
                lbl.Text += "File name allow only a-z, A-Z, 0-9, [ ], ( ), _ , -<br/>Your filename contain " + InvalidList + "<br/>Please, rename your file.<br />";
                return false;
            }

            return true;
        }
    }
}