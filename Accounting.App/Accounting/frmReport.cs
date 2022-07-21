using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class frmReport : Form
    {
        public int TypeID = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (TypeID == 1)
            {
                this.Text = "گزارش های دریافتی";
            }
            else
            {
                this.Text = "گزارش های پرداختی ها";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var Result = db.AccountingRepository.Get(a => a.TypeID == TypeID);
                //dgReport.AutoGenerateColumns = false;
                //dgReport.DataSource = Result;

                dgReport.Rows.Clear();

                foreach (var accounting in Result)
                {
                    string customerName = db.customerRepository.GetCustomerNameById(accounting.CustomerID);
                    dgReport.Rows.Add(accounting.ID, customerName, accounting.Amount, accounting.Date.ToShamci(), accounting.Description);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                if (RtlMessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (UnitOfWork db=new UnitOfWork())
                    {
                        db.AccountingRepository.Delete(id);
                        db.Save();
                        Filter();
                    }
                }
            }
        }
    }
}
