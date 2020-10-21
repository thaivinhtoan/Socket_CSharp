using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProxyServer
{
    public partial class ProxyServer : Form
    {
        Proxy _MyProxy;
        public ProxyServer()
        {
            InitializeComponent();

            _MyProxy = new Proxy();

            ShowBlockSite();
        }

        private void ShowBlockSite()
        {
            //Dia chi Proxy Server
            string LocalConnect = "LOCAL CONNECT: " + _MyProxy.GetLocal();
            lbShow.Text = LocalConnect;

            //In Block Link
            foreach (var item in Data._BlockedSite)
            {
                lvBackList.Items.Add(new ListViewItem() { Text = item });
            }
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            //Check empty
            if (tbBlockLink.Text != "")
            {
                //Link handler
                string link = tbBlockLink.Text.ToLower()
                    .Substring(0, tbBlockLink.Text.IndexOf('/') != -1 ?
                    tbBlockLink.Text.IndexOf('/') : tbBlockLink.Text.Length);

                //Add in listview
                lvBackList.Items.Add(new ListViewItem() { Text = link });

                //Add in Data
                Data._BlockedSite.Add(link);

                //Add in file
                using (StreamWriter sw = new StreamWriter(Data._FileBlackList))
                    foreach (var item in Data._BlockedSite)
                        sw.WriteLine(item);

                tbBlockLink.Clear();
            }
        }

        private void BtRemove_Click(object sender, EventArgs e)
        {
            if (tbBlockLink.Text != "")
            {
                string link = tbBlockLink.Text.ToLower()
                    .Substring(0, tbBlockLink.Text.IndexOf('/')!= -1 ? 
                    tbBlockLink.Text.IndexOf('/') : tbBlockLink.Text.Length);

                //Remove in ListView
                foreach (ListViewItem item in lvBackList.Items)
                    if (link == item.Text)
                        lvBackList.Items.Remove(item);

                //Remove in data
                Data.RemoveBlockSite(link);

                //Write file
                using (StreamWriter sw = new StreamWriter(Data._FileBlackList))
                    foreach (var item in Data._BlockedSite)
                        sw.WriteLine(item);

                tbBlockLink.Clear();
            }
        }

        private void ProxyServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _MyProxy.CloseServer();
        }

        private void BtGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.Nhập DOMAIN vào textbox\n" +
                "2.Nhấn ADD để thêm BlockLink\n hoặc REMOVE để xoá",
                "Hướng dẫn", MessageBoxButtons.OK);
        }

        private void ProxyServer_Load(object sender, EventArgs e)
        {

        }
    }
}
