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
            products.Name = textBox1.Text;
            products.Price = textBox2.Text;
            products.Quantity =Convert.ToDouble( numericUpDown1.Value.ToString()) ;
            products.Description = richTextBox1.Text;
            productList.Add(products);
            Hide();
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
