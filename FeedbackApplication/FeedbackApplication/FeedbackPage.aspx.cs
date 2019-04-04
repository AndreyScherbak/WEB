using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FeedbackApplication
{
    public partial class FeedbackPage : System.Web.UI.Page
    {
        private static string counterKey = "counter";
        private static string feedbackKey = "feedback";
        public int Counter // счетчик входа с логикой установки и извлечения данных из сессии
        {
            get
            {
                object obj = Session[counterKey];
                if (obj == null)
                {
                    Session[counterKey] = 0;
                    return 0;
                }
                return (int)obj;
            }
            set
            {
                Session[counterKey] = value;
            }
        }
        public string Feedback
        {
            get
            {
                object obj = Session[feedbackKey];
                return obj.ToString();
            }
            set
            {
                Session[feedbackKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Counter++;
        }
        protected void btnSendFeedback_Click(object sender, EventArgs e)
        {
            Feedback = txtBoxFeedback.Text;
        } 
    }
}