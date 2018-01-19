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

        private void OrderList_Load(object sender, EventArgs e)
        {
            foreach (var item in Order.OrderList)
            {
                if (item.OrderTime == item.ArriveTime)
                {
                    ListViewItem viewItem = new ListViewItem(new string[] {item.Client,item.Products,item.ProdQuantity.ToString(),
                item.OrderTime.ToString(),item.ArriveTime.ToString(),"Arrived"});
                    listView1.Items.Add(viewItem);
                } else
                {
                    ListViewItem viewItem = new ListViewItem(new string[] {item.Client,item.Products,item.ProdQuantity.ToString(),
                item.OrderTime.ToString(),item.ArriveTime.ToString(),"Not Arrived"});
                    listView1.Items.Add(viewItem);
                }
            }
        }
    }
}
