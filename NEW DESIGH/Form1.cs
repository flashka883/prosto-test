using NEW_DESIGH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_DESIGH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MemberDbContext memberDbContext = new MemberDbContext();
     //  public ProductDbContext productDbContext = new ProductDbContext();
        PaymentForm PaymentForm;
        AddMemberForm AddMemberForm;
        MembersForm MembersForm;
        bool choosedItem = true;
        int quantity = 1;
        double price = 0.00, currentPrice = 0.00, totalPrice = 0.00;

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMemberForm = new AddMemberForm();
            MembersForm = new MembersForm();
            PaymentForm = new PaymentForm();

            // panel4.BackColor = DefaultBackColor;
            textBox1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string selectedProduct = comboBox1.Items[index].ToString();
            if (choosedItem)
            {
                listBox1.Items.Add(selectedProduct);
                listBox3.Items.Add("x 1");
                comboBox1.Text = "Products";
                textBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                choosedItem = false;

                if (index == 0)
                {
                    price = 1.00;
                }
                if (index == 1)
                {
                    price = 2.00;
                }
                if (index == 2)
                {
                    price = 4.00;
                }

                currentPrice = price * quantity;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //TODO ADD
            totalPrice += currentPrice;
            label4.Text = $"$ {totalPrice}";

            listBox2.Items.Add(listBox1.Items[0]);
            listBox4.Items.Add(listBox3.Items[0]);
            listBox5.Items.Add($"$ {currentPrice}");

            listBox1.Items.Clear();
            listBox3.Items.Clear();

           // textBox1.Text = "";
            textBox1.PlaceholderText = "Enter quantity:";
            button5.Enabled = false;
            button6.Enabled = false;
            choosedItem = true;

            quantity = 1;
            price = 0.00;

            button9.Enabled = true;
            button11.Enabled = true;
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items != null)
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                //textBox1.Text = "";
                textBox1.PlaceholderText = "Enter quantity:";
                textBox1.Enabled = false;
                choosedItem = true;
                button5.Enabled = false;
                button6.Enabled = false;
                quantity = 1;
                price = 0.00;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (choosedItem)
            {
                listBox1.Items.Add("training");
                listBox3.Items.Add("x 1");
                comboBox1.Text = "Products";
                textBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                choosedItem = false;

                price = 3.00;
                currentPrice = price * quantity;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            label4.Text = "$ 0.00";
            label5.Text = "$ 0.00";
            label6.Text = "$ 0.00";

            currentPrice = 0.00;
            totalPrice = 0.00;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        /// <summary>
        /// Open Members form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MembersForm.ShowDialog();
        }

        /// <summary>
        /// Open the form to fill the new member information (member)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            AddMemberForm.ShowDialog();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Products";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // validation - enter only numbers
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            if (!choosedItem)
            {
                quantity = int.Parse(textBox1.Text);
                currentPrice = price * quantity;

                listBox3.Items.Clear();
                listBox3.Items.Add($"x {textBox1.Text}");
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Open the PaymentForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            PaymentForm.ShowDialog();
            double cashMoney = PaymentForm.cash;
            label5.Text = $"$ {cashMoney}";
            label6.Text = $"$ {cashMoney - totalPrice}";

            button10.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < listBox4.Items.Count; i++)
            //{
            //    string productSale = listBox2.Items[i].ToString();

            //    string qSale = listBox4.Items[i].ToString();
            //    int quantitySale = int.Parse(qSale.Split(' ')[1].ToString());

            //    string tSale = listBox5.Items[i].ToString();
            //    double totalSale = double.Parse(tSale.Split(' ')[1].ToString());

            //    Sale sale = new Sale();
            //    sale.Product = productSale;
            //    sale.Quantity = quantitySale;
            //    sale.Total = totalSale;
              
            //    memberDbContext.Sales.Add(sale); 

            //    memberDbContext.SaveChanges();
            //}
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
