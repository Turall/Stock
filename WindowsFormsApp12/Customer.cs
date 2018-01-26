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
            if (!(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(richTextBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text) ))
            {
                customers.Name = textBox1.Text;
                customers.Surname = textBox2.Text;
                customers.Email = textBox3.Text;
                customers.Phone = maskedTextBox1.Text;
                customers.Address = richTextBox1.Text;
                CustomersList.Add(customers);
                CustomersToXML();
                Close();
            }
            else MessageBox.Show("Text Box is empty");
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
        public static void CustomersToXML ()
        {
            using (FileStream stream = new FileStream("Customers.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customers>));
                serializer.Serialize(stream, CustomersList);
            }
        
        }
        public static void CustomersFromXML()
        {
            if (!File.Exists("Customers.xml"))
            {
                return;
            }
            using (FileStream stream = new FileStream("Customers.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Customers>));
                CustomersList = (List<Customers>)deserializer.Deserialize(stream);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false)
            {
                return;

            }
            e.Handled = true;
            return;
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
