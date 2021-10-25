using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Windows.Forms;

namespace RSSFeed
{
    public class RSSFeedLIB
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public static void RssFeed(Panel tgt, EventHandler clicklink)
        {
            //string rssurl = "http://static.userland.com/gems/backend/rssTwoExample2.xml";
            string rssurl = "https://s.ch9.ms/Shows/This+Week+On+Channel+9/feed";
            XmlReader myReader = XmlReader.Create(rssurl);
            SyndicationFeed feed = SyndicationFeed.Load(myReader);

            //MessageBox.Show(feed.Items.Count().ToString());
            int count = feed.Items.Count();
            tgt.Controls.Clear();

            Label[] lbl = new Label[count];
            LinkLabel[] linklbl = new LinkLabel[count];

            int i = 0;
            int x = 20, y = 20;
            int width = 150;
            int height = 20;

            foreach (SyndicationItem item in feed.Items)
            {
                lbl[i] = new Label();
                lbl[i].Text = item.Title.Text;
                lbl[i].Location = new System.Drawing.Point(x, y * (i+1));
                lbl[i].Width = width;
                lbl[i].Height = height;
                lbl[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lbl[i].AutoEllipsis = true;
                tgt.Controls.Add(lbl[i]);

                linklbl[i] = new LinkLabel();
                linklbl[i].Text = item.Links[0].Uri.ToString();
                linklbl[i].Location = new System.Drawing.Point(x + 160, y * (i + 1));
                linklbl[i].Width = width * 2;
                linklbl[i].Height = height;
                linklbl[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                linklbl[i].AutoEllipsis = true;
                linklbl[i].Click += new EventHandler(clicklink);
                tgt.Controls.Add(linklbl[i]);
                
                if (i < count)
                { i++; }
            }
        }

        
    }
}