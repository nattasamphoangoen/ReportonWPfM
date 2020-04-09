using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Account_Default : System.Web.UI.Page
{
    string initLDAPPath = "dc=slri, dc=or, dc=th";
    string initLDAPServer = "10.1.10.100";
    string initShortDomainName = "slri";
    string strErrMsg;

    public string MD5(string strString)
    {
        ASCIIEncoding ASCIIenc = new ASCIIEncoding();
        string strReturn;
        byte[] ByteSourceText = ASCIIenc.GetBytes(strString);
        MD5CryptoServiceProvider Md5Hash = new MD5CryptoServiceProvider();
        byte[] ByteHash = Md5Hash.ComputeHash(ByteSourceText);
        strReturn = "";
        foreach (byte b in ByteHash)
        {
            strReturn = (strReturn + b.ToString("x2"));
        }
        return strReturn;
    }

   protected void Page_Load(object sender, EventArgs e)
    {
    }



    protected void btnLogin_Click(object sender, System.EventArgs e)
    {
        string DomainAndUsername = "";
        string strCommu;
        bool flgLogin = false;
        strCommu = ("LDAP://"
                    + (initLDAPServer + ("/" + initLDAPPath)));
        DomainAndUsername = (initShortDomainName + ("\\" + txtUser.Text));
        DirectoryEntry entry = new DirectoryEntry(strCommu, DomainAndUsername, txtPwd.Text);
        object obj;
        try
        {
            obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            SearchResult result;
            search.Filter = ("(SAMAccountName="
                        + (txtUser.Text + ")"));
            search.PropertiesToLoad.Add("cn");
            result = search.FindOne();
            if ((result == null))
            {
                flgLogin = false;
                strErrMsg = "Please check user/password";
            }
            else
            {
                flgLogin = true;
            }
        }
        catch (Exception ex)
        {
            flgLogin = false;
            strErrMsg = "Please check user/password";
        }
        if ((flgLogin == true))
        {
            this.lbDisplay.Text = ("Welcome " + txtUser.Text);
        }
        else
        {
            this.lbDisplay.Text = strErrMsg;
        }
    }
}



