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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();


        }

        Product product = null;
        Customer customer = null;
        Order order = null;
        OrderList orderList = null;
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {

                customer = new Customer();
                customer.StartPosition = FormStartPosition.CenterParent;
                customer.FormClosed += Customer_FormClosed;
                customer.ShowDialog();

            }
            else customer.Activate();
        }

        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            customer = null;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                product = new Product();
                product.FormClosed += Product_FormClosed;
                product.ShowDialog();
            }
            else
                product.Activate();
        }

        private void Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            product = null;
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (order == null)
            {
                if (Customer.CustomersList.Count != 0)
                {
                    order = new Order();
                    order.FormClosed += Order_FormClosed;
                    order.ShowDialog();
                }
                else MessageBox.Show("You don't have customer or product");
            }
            else order.Activate();
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = null;
        }

        private void предварительныйпросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Customer.CustomersList.Count != 0)
            {
                listView1.Items.Clear();
                foreach (var item in Customer.CustomersList)
                {
                    ListViewItem items = new ListViewItem(new string[] { item.Name, item.Surname, item.Email, item.Phone, item.Address });
                    listView1.Items.Add(items);
                }
            }
            else MessageBox.Show("Your Customer list is empty");
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (Product.productList.Count != 0)
            {
                listView2.Items.Clear();
                foreach (var item in Product.productList)
                {
                    ListViewItem items = new ListViewItem(new string[] { item.Name, item.Price, item.Quantity.ToString(), item.Description });
                    listView2.Items.Add(items);
                }
            }
            else MessageBox.Show("Your Stock is empty");
        }

        private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (orderList == null)
            {
                orderList = new OrderList();
                orderList.FormClosed += OrderList_FormClosed;
                orderList.ShowDialog();
            }
            else orderList.Activate();
        }

        private void OrderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderList = null;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
