using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace complain.app
{
    public partial class CustomerComplainUI : Form
    {
        public CustomerComplainUI()
        {
            InitializeComponent();
        }

        Queue<customer> customerQueue = new Queue<customer>();


        customer aCustomer = new customer();
        private void enqueueButton_Click(object sender, EventArgs e)
        {
           
            aCustomer.name = nameTextBox.Text;
            aCustomer.complain = complainTextBox.Text;

            nameTextBox.Text =String.Empty;
            complainTextBox.Text =String.Empty;
           
            customerQueue.Enqueue(aCustomer);

            ListViewItem item =new ListViewItem(aCustomer.serialNo.ToString());
            item.SubItems.Add(aCustomer.name);
            item.SubItems.Add(aCustomer.complain);
            queueListView.Items.Add(item);
            aCustomer.serialNo ++;
        }

        private void deQueueButton_Click(object sender, EventArgs e)
        {
            if (customerQueue.Count == 0)
            {
                MessageBox.Show(@"Empty Quque");

            }

            else
            {

               
                customer aCustomer =new customer(); 
                aCustomer= customerQueue.Dequeue();


                serialNoTextBox.Text = aCustomer.serialNo.ToString();
                nameDequeueTextBox.Text = aCustomer.name.ToString();
                complainDequeueTextBox.Text = aCustomer.complain.ToString();
                queueListView.Items[0].Remove();

            }
            

        }
    }
}
