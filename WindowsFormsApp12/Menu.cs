﻿using System;
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

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ShowDialog();
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.ShowDialog();
        }

        private void предварительныйпросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Customer.CustomersList.Count != 0)
            {
                foreach (var item in Customer.CustomersList)
                {
                    ListViewItem items = new ListViewItem(new string[] { item.Name, item.Surname, item.Email, item.Phone ,item.Address});
                    listView1.Items.Add(items);
                }
            }
            else MessageBox.Show("Your Customer list is empty");
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Product.productList.Count != 0)
            {
                foreach (var item in Product.productList)
                {
                    ListViewItem items = new ListViewItem(new string[] { item.Name, item.Price, item.Quantity.ToString(),item.Description });
                    listView2.Items.Add(items);
                }
            }
            else MessageBox.Show("Your Stock is empty");
        }

        private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OrderList orderList = new OrderList();
            orderList.ShowDialog();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
