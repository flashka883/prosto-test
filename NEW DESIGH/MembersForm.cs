using NEW_DESIGH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_DESIGH
{
    public partial class MembersForm : Form
    {
        // private MemberBusiness MemberBusiness = new MemberBusiness();
        private MemberDbContext PersonDbContext = new MemberDbContext();

        private void Members_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        public MembersForm()
        {
            InitializeComponent();
            foreach (var member in PersonDbContext.MemberInfos)
            {
                listBox1.Items.Add($"{member.MemberInfoId}");
                listBox3.Items.Add($"{member.FirstName} {member.SecondName} {member.ThirdName}");
            }
            foreach (var member in PersonDbContext.Members)
            {
                listBox2.Items.Add($"{(member.DateExpiration - DateTime.Now).Days}");
            }
        }

        
        /// <summary>
        /// Search member by card id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int cardId = int.Parse(textBox1.Text);
            Member member = PersonDbContext.Members.Find(cardId);

            if (member != null)
            {
                listBox1.SelectedIndex = cardId;
                listBox2.SelectedIndex = cardId;
                listBox3.SelectedIndex = cardId;
            }
            else
            {
                MessageBox.Show($"В базата данни не конфигурира карта с ид: {textBox1.Text}");
            }

            textBox1.Text = "";
        }
    }
}
