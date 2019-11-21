using Diplom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Forms.Lookups
{
    public partial class BaseLookupForm : Form
    {
        protected ViewModel db = new ViewModel();
        public BaseLookupForm()
        {
            InitializeComponent();
        }

        private void LookupDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            LookupDataGridView.Columns["id"].Visible = false;
            LookupDataGridView.Columns["CreatonDate"].Visible = false;
            LookupDataGridView.Columns["ModifiedDate"].Visible = false;
            LookupDataGridView.Columns["Name"].Width = 200;
            LookupDataGridView.Columns["Name"].HeaderText = "Название";
        }

        private void BaseLookupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
