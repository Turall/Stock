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
    public partial class Login : Form
    {
        Menu mainMenu = null;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox1.TabIndex = 1;
            textBox1.TabStop = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tural" && textBox2.Text == "Muradov")
            {
            if (mainMenu == null)
            {
                Hide();
                mainMenu = new Menu();
                mainMenu.FormClosed += MainMenu_FormClosed;

                mainMenu.Show();

            }
            else
                mainMenu.Activate();
            }
            else MessageBox.Show("Wrong Username or Password");
            textBox1.Clear(); textBox2.Clear();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            mainMenu = null;
        }
    }
}
