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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        Orders orders = new Orders();
        public static List<Orders> OrderList = new List<Orders>();
        private void Order_Load(object sender, EventArgs e)
        {
            if(Customer.CustomersList.Count != 0 )
            {
                foreach (var item in Customer.CustomersList)
                {
                    comboBox1.Items.Add(item.Name + "  " + item.Surname);
                }
                
            }
            else
            {
                MessageBox.Show("You don't have client ");
            }
            if(Product.productList.Count != 0)
            {
                foreach (var item in Product.productList)
                {
                    comboBox2.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("You don't have  products ");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orders.Client = comboBox1.Text;
            orders.Products = comboBox2.Text;
            orders.ProdQuantity =Convert.ToInt32( numericUpDown1.Value.ToString());
            orders.ArriveTime = dateTimePicker1.Value;
            orders.OrderTime = DateTime.Now;
            OrderList.Add(orders);
            foreach (var item in Product.productList)
            {
                if (item.Quantity > orders.ProdQuantity && item.Name == orders.Products)
                {
                    item.Quantity = item.Quantity - orders.ProdQuantity;
                }
                else
                {
                    MessageBox.Show("there are not so many goods in stock");
                }
            }
            Hide();
        }
    }
   public class Orders
    {
        public string Client { get; set; }
        public string Products { get; set; }
        public int ProdQuantity { get; set; }
        public DateTime ArriveTime { get; set; }
        public DateTime OrderTime { get; set; }
       
    }
}
