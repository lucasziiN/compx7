using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public partial class Form1 : Form
    {
        decimal current_balance = 0;
        public Form1()
        {
            InitializeComponent();
            textBoxTransferAmount.Select();
            textBoxBalance.Text = current_balance.ToString();
            textBoxBalance.ReadOnly = true;
        }
        private bool CheckDeposit(decimal deposit_amount)
        {
            if (deposit_amount < 20)
            {
                MessageBox.Show("Invalid deposit amount. Deposits must be equal to or greater than $20");
                return false;
            }
            else if (deposit_amount > 200)
            {
                MessageBox.Show("Invalid deposit amount. Deposits must not exceed $200");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckWithdraw(decimal withdraw_amount)
        {
            if (withdraw_amount<20)
            {
                MessageBox.Show("Invalid withdrawal amount. Withdrawals must not be lower than $20");
                return false;
            }
            else if (withdraw_amount>current_balance)
            {
                MessageBox.Show("Invalid withdrawal amount. Withdrawals must not be greater than your current balance");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            decimal transfer_amount = decimal.Parse(textBoxTransferAmount.Text);
            if (CheckDeposit(transfer_amount) == true)
            {
                current_balance += transfer_amount;
                textBoxBalance.Text = current_balance.ToString();
            }
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            decimal transfer_amount = decimal.Parse(textBoxTransferAmount.Text);
            if (CheckWithdraw(transfer_amount) == true)
            {
                current_balance -= transfer_amount;
                textBoxBalance.Text = current_balance.ToString();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
