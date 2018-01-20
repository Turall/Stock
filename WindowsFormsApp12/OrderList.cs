using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }
        List<ListViewItem> listesas = new List<ListViewItem>();
        List<ListViewItem> lisremoves = new List<ListViewItem>();
        private void OrderList_Load(object sender, EventArgs e)
        {
            foreach (var item in Order.OrderList)
            {
                if (item.OrderTime == item.ArriveTime)
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text.Contains(textBox1.Text) ||
               listView1.Items[i].SubItems[1].Text.Contains(textBox1.Text) ||
               listView1.Items[i].SubItems[2].Text.Contains(textBox1.Text))
                {
                    listesas.Add(listView1.Items[i]);
                }
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) == false)
            {


                foreach (ListViewItem item in listView1.Items)
                {
                    if (listesas.Find(x => x == item) == null)
                    {
                        lisremoves.Add(item);
                        listView1.Items.Remove(item);
                    }
                }
                
            }
            else
            {
                try
                {
                    foreach (var item in lisremoves)
                    {
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception) { };
            }
        }
    }
}
