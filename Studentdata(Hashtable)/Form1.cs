using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;


namespace Studentdata_Hashtable_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         Hashtable hs= new Hashtable();
        int count=0;
        private void button1_Click(object sender, EventArgs e)
        { 
            Class1 cs = new Class1();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != ""
             && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                if (hs.ContainsKey(cs.roll))
                {
                    MessageBox.Show("Duplicate key is not allowed");
                    return;
                }
                cs.roll = Convert.ToInt32(textBox1.Text);
                cs.name = Convert.ToString(textBox2.Text);
                cs.dob = Convert.ToString(textBox3.Text);
                cs.phy = Convert.ToInt32(textBox4.Text);
                cs.che = Convert.ToInt32(textBox5.Text);
                cs.mth = Convert.ToInt32(textBox6.Text);
                cs.hi = Convert.ToInt32(textBox7.Text);
                cs.en = Convert.ToInt32(textBox8.Text);
                cs.obtain = cs.phy + cs.che + cs.mth + cs.hi + cs.en;
                cs.per = (cs.obtain * 100) / 500;
                hs.Add(cs.roll, cs);
                Data();
                count++;
                label9.Text = "total student " + count.ToString();
            }
            else
            {
                MessageBox.Show("Fill all the Box");
            }
            ClearTextBoxes();
            textBox1.Focus();
        }

        void Data()
        {
              listBox1.Items.Clear();
          ICollection ic=  hs.Keys;
            foreach(object i in ic)
            {
             Class1 cs=(Class1)hs[i];
                listBox1.Items.Add("roll: "+cs.roll+" name: "+cs.name+" Dob: "+cs.dob  +" total: 500"+ " obtain: " + cs.obtain + " per: " + cs.per);
            }
        }
       
            void ClearTextBoxes()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            int key= Convert.ToInt32(textBox10.Text);
            Class1 cs = (Class1)hs[key];
            textBox1.Text = cs.roll.ToString();
            textBox2.Text = cs.name.ToString();
            textBox3.Text = cs.dob.ToString();
            textBox4.Text = cs.phy.ToString();
            textBox5.Text = cs.che.ToString();
            textBox6.Text = cs.mth.ToString();
            textBox7.Text = cs.hi.ToString();
            textBox8.Text = cs.en.ToString();
            MessageBox.Show("You get " + cs.per.ToString()+"% ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
             hs.Clear();
            listBox1.Items.Clear();
           
        }
    }
}
