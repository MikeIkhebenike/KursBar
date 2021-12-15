using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KursBar.EF;

namespace KursBar
{
    public partial class FormAuth : Form
    {
        public static Autorization USR { get; set; }
        public static FormAuth FORMA { get; set; }
        Model1 db = new Model1();
        public FormAuth()
        {
            InitializeComponent();
            textBoxPassword.Controls.Add(pictureBoxEye);
            pictureBoxEye.BackColor = Color.Transparent;
            pictureBoxEye.Location = new Point(115, -2);
            textBoxPassword.UseSystemPasswordChar = true;


            pictureBoxEye.MouseDown += new MouseEventHandler(pictureBoxEye_MouseDown);
            pictureBoxEye.MouseUp += new MouseEventHandler(pictureBoxEye_MouseUp);

        }
        private void pictureBoxEye_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;

        }

        private void pictureBoxEye_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {

        }

        private void ButLogin_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
            Autorization UsersFind = db.Autorization.Find(textBoxLogin.Text);
            if ((UsersFind != null) && (UsersFind.Пароль == textBoxPassword.Text))
            {
                USR = UsersFind;
                FORMA = this;
                if (USR.User.Роль == "Администратор")
                {
                    FormAdmin frAdmin = new FormAdmin();
                    frAdmin.Show();
                    this.Hide();
                }
                else // если такой роли нет
                {
                    // если данные введены неправильно, то показываем сообщение
                    MessageBox.Show($"Роли {USR.User.Роль} в системе нет!");
                    return;
                }


            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно!");
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
