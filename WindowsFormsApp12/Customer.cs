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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        Customers customers =new Customers();
        public static List<Customers> CustomersList = new List<Customers>();
        private void Customer_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customers.Name = textBox1.Text;
            customers.Surname = textBox2.Text;
            customers.Email = textBox3.Text;
            customers.Phone = maskedTextBox1.Text;
            customers.Address = richTextBox1.Text;
            CustomersList.Add(customers);
            Hide();
        }
    }
    public class Customers
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
