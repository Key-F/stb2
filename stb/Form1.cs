using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Threading.Tasks;


namespace stb
{

    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 6000;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Enabled = false;
            
        }
       

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(object sender, Awesomium.Core.ShowCreatedWebViewEventArgs e)
        {
           
        }
        
       private void Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(object sender, Awesomium.Core.FrameEventArgs e)
        {
            if (e.IsMainFrame)
            {
                button1.Enabled = true;
                // чтобы не было этого: Cannot execute Javascript on the page, before the DOM is ready. Wait for the DocumentReady event before executing your Javascript.
            }
        } 

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (webControl1 == null || !webControl1.IsLive)
                return;
           
            var html = webControl1.ExecuteJavascriptWithResult("document.documentElement.outerHTML").ToString();
            //var doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var dataBlock = doc.DocumentNode.SelectSingleNode("//div[@class='pagecontent no_header']");
            var dataBlock1 = doc.DocumentNode.SelectSingleNode("//*[@id='searchResultsTable']");
            //listBox1.Items.Add(dataBlock1);
            HtmlNodeCollection elem = doc.DocumentNode.SelectNodes("//div[@class='market_content_block market_home_listing_table market_home_main_listing_table market_listing_table']");  
            HtmlNodeCollection NoAltElements = doc.DocumentNode.SelectNodes("//div[@class='item_desc_description']");  
            //var links = doc.DocumentNode.Descendants("a").Select(x => x.Attributes["href"].Value).ToArray();
            //for (int i = 0; i < links.Length; i++)
            //    MessageBox.Show(links[i]);
            var firstDivTitle = doc.DocumentNode.SelectSingleNode(".//h2");
            //foreach (var item in dataBlock.SelectNodes("//div[@class=\"market_table_value\"]"))
           // {
               // MessageBox.Show(item.InnerHtml + "\n");
           // }

            for (int i = 0; i < NoAltElements.Count; i++)
            {
                listBox1.Items.Add(NoAltElements[i].InnerText);
                
            }

            for (int i = 0; i < elem.Count; i++)
            {
                
                listBox1.Items.Add(elem[i].InnerText);
            }
            //var tNode = doc.DocumentNode.SelectSingleNode("//comment()[contains(., 'market_listing_price_with_fee')]");
           // listBox1.Items.Add(tNode);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='hover_item_name']");
            if (nodes == null)
                return;
            foreach (HtmlNode node in nodes)
            {
                listBox1.Items.Add(node.Attributes["href"].Value);
            }
            var patients = doc.DocumentNode.SelectNodes("//div[@class='market_listing_price_with_fee'");
            foreach (var patient in patients)
                patient.SetAttributeValue("style", "visibility: hidden");
        }

        private void button2_Click(object sender, EventArgs e) // кнопка включения и выключения обновления страницы
        {

            if (timer1.Enabled == false)
            {

                button2.Text = "refreshing";
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "../../play.png"); //на один уровень вверх из текущей дериктории

                string y = textBox1.Text;
                int x = Convert.ToInt32(y);
                timer1.Interval = Convert.ToInt32(this.textBox1.Text);
                timer1.Enabled = true;
            }
            else
            {
                button1.Text = "refresh";
                timer1.Enabled = false;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "../../pause.png");
            }

           // pictureBox1.Image = 
            
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            webControl1.Reload(true);          
        }
       
    }
}
