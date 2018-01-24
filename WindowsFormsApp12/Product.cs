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
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false)
            {
                return;

            }
            e.Handled = true;
            return;
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
