using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
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
            
            dateTimePicker1.MinDate = DateTime.Now;
           
                foreach (var item in Customer.CustomersList)
                {
                    comboBox1.Items.Add(item.Name + "  " + item.Surname);
                }
           
                foreach (var item in Product.productList)
                {
                    comboBox2.Items.Add(item.Name);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text)
                || numericUpDown1.Value == 0))
            {
                orders.Client = comboBox1.Text;
                orders.Products = comboBox2.Text;
                orders.ProdQuantity = Convert.ToInt32(numericUpDown1.Value.ToString());
                orders.ArriveTime = dateTimePicker1.Value;
                orders.OrderTime = DateTime.Now;
                foreach (var item in Product.productList)
                {
                    if (item.Quantity >= orders.ProdQuantity && item.Name == orders.Products)
                    {
                        item.Quantity = item.Quantity - orders.ProdQuantity;
                        OrderList.Add(orders);
                    }
                    else if (item.Quantity < orders.ProdQuantity && item.Name == orders.Products)
                    {
                        MessageBox.Show("there are not so many goods in stock");
                    }
                }
               Product.ProductsToXML();
                OrdersToXML();
                Close();
            }
            else MessageBox.Show("Text box is empty");
        }

        public static void OrdersToXML()
        {
            using (FileStream stream = new FileStream("Orderlist.xml", FileMode.OpenOrCreate))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<Orders>));
                serializer.Serialize(stream, OrderList);

            }
            
        }
        public static void OrdersFromXML()
        {
            if (!File.Exists("Orderlist.xml"))
            {
                return ;
            }
            else
            {
                try
                {
                    using (FileStream stream = new FileStream("Orderlist.xml", FileMode.OpenOrCreate))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Orders>));
                        OrderList = (List<Orders>)serializer.Deserialize(stream);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in Product.productList)
            {
                if (item.Name == comboBox2.Text)
                {
                    label5.Text = "Max Quantity" + " " + item.Quantity.ToString();
                    numericUpDown1.Maximum = Convert.ToDecimal(item.Quantity);
                    break;
                }
            }
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
