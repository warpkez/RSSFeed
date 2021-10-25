using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeed
{
    public partial class RSSFeed : Form
    {
        public RSSFeed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RSSFeedLIB.RssFeed(textBox1);
            RSSFeedLIB.RssFeed(this.panel1, clicklink);           
        }

        private void clicklink(object sender, EventArgs e)
        {
            LinkLabel l = (LinkLabel)sender;
            System.Uri uri = new Uri(l.Text);
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

            psi.UseShellExecute = true;
            string url = uri.Host + uri.PathAndQuery;
            psi.FileName = url;

            try
            {
                System.Diagnostics.Process.Start(psi);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
