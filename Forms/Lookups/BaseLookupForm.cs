using Diplom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        string type;
        public BaseLookupForm(string type)
        {
            this.type = type;
            
            InitializeComponent();
        }
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

        //private void AddButton_Click(object sender, EventArgs e)
        //{
        //    InputBox inputBox = new InputBox();

        //    dynamic newCognitiveLoad = Type.GetType(type);
        //    newCognitiveLoad.Name = inputBox.getString();
        //    if (!String.IsNullOrEmpty(newCognitiveLoad.Name))
        //    {
        //        db.CognitiveLoad.Add(newCognitiveLoad);
        //        db.SaveChanges();

        //        reloadDataSource();
        //    }
        //}
        //void reloadDataSource()
        //{
        //    db = new ViewModel();
        //    dynamic newCognitiveLoad = Type.GetType(type);
        // //   db. //newCognitiveLoad.Load();
        // //   LookupBindingSource.ResetBindings(false);
        //    LookupBindingSource.DataSource = db.CognitiveLoad.Local.ToBindingList();
        //    LookupDataGridView.DataSource = LookupBindingSource;
        //}
    }
}
