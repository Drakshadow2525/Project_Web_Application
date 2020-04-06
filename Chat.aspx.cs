using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPetey
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> saveChat;
            if (Application["chat"] != null) {
                saveChat = (List<string>)Application["chat"];
            foreach (string x in (List<string>) Application["chat"])
            {
                    ListBox1.Items.Add(x);
            } 
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> saveChat;
            if(Application["chat"] != null)
            {
                saveChat = (List<string>)Application["chat"];
            }
            else
            {
                saveChat = new List<string>();
            }
            saveChat.Add(TextBox2.Text + "  :  " + TextBox1.Text);
            Application["chat"] = saveChat;
            Response.RedirectPermanent("chat.aspx");
        }
    }
}