using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp12
{
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }
        List<ListViewItem> Orderlist = new List<ListViewItem>();
        private void OrderList_Load(object sender, EventArgs e)
        {
           
            foreach (var item in Order.OrderList)
            {
                if (item.OrderTime.Date == item.ArriveTime.Date)
                {
                    ListViewItem viewItem = new ListViewItem(new string[] {item.Client,item.Products,item.ProdQuantity.ToString(),
                item.OrderTime.ToString(),item.ArriveTime.ToString(),"Arrived"});
                    listView1.Items.Add(viewItem);
                }
                else
                {
                    ListViewItem viewItem = new ListViewItem(new string[] {item.Client,item.Products,item.ProdQuantity.ToString(),
                item.OrderTime.ToString(),item.ArriveTime.ToString(),"Not Arrived"});
                    listView1.Items.Add(viewItem);
                }
            }
            foreach (ListViewItem item in listView1.Items)
            {
                Orderlist.Add(item);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text.Length >= textBox1.Text.Length &&
                   listView1.Items[i].SubItems[1].Text.Length >= textBox1.Text.Length &&
                   listView1.Items[i].SubItems[2].Text.Length >= textBox1.Text.Length)
                    {
                        if (!(listView1.Items[i].SubItems[0].Text.ToLower().Substring(0, textBox1.Text.Length) == textBox1.Text.ToLower() ||
                   listView1.Items[i].SubItems[1].Text.ToLower().Substring(0, textBox1.Text.Length) == textBox1.Text.ToLower() ||
                   listView1.Items[i].SubItems[2].Text.ToLower().Substring(0, textBox1.Text.Length) == textBox1.Text.ToLower()))
                        {

                            listView1.Items.Remove(listView1.Items[i]);
                            i--;
                        }
                    }
                    else
                    {
                        listView1.Items[i].SubItems[0].Text += " ";
                        listView1.Items[i].SubItems[1].Text += " ";
                        listView1.Items[i].SubItems[2].Text += " ";
                        i--;
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    listView1.Items.Remove(item);
                }
                foreach (ListViewItem item in Orderlist)
                {
                    listView1.Items.Add(item);
                }
            }
        }
    }
}