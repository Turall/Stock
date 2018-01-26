using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        public static List<Products> productList = new List<Products>();
        Products products = new Products();
        private void Product_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrWhiteSpace(richTextBox1.Text) || numericUpDown1.Value == 0))
            {
                products.Name = textBox1.Text;
                products.Price = textBox2.Text;
                products.Quantity = Convert.ToDouble(numericUpDown1.Value.ToString());
                products.Description = richTextBox1.Text;
                productList.Add(products);
                Close();
            }
            else MessageBox.Show("Text box is empty");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
        public static void ProductsToXML()
        {
            using(FileStream stream = new FileStream("Products.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Products>));
                serializer.Serialize(stream, productList);
            }
        }
       public static void ProductsFromXML()
        {
            if (!File.Exists("Products.xml"))
            {
                return;
            }
            using(FileStream stream = new FileStream("Products.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer deserilizer = new XmlSerializer(typeof(List<Products>));
                productList = (List<Products>)deserilizer.Deserialize(stream);
            }
        }
    }
    public class Products
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
    }
}
