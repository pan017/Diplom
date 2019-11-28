using Diplom.Model;
using Diplom.Model.Lookups;
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
    public partial class TestTypesLookupForm : BaseLookupForm
    {
        public TestTypesLookupForm()
        {
            InitializeComponent();
        }
        
        private void TestTypesLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
            AddButton.Enabled = false;
            RemoveButton.Enabled = false;
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.TestType.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.TestType.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
            LookupDataGridView.Columns[0].Visible = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            TestType newTestType = new TestType();
            newTestType.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newTestType.Name))
            {
                db.TestType.Add(newTestType);
                db.SaveChanges();

                reloadDataSource();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LookupBindingSource.Current == null)
                return;
            TestType edit = db.TestType.First(x => x.id == ((TestType)LookupBindingSource.Current).id);
            InputBox inputBox = new InputBox();
            edit.Name = inputBox.getString(edit.Name);
            if (!String.IsNullOrEmpty(edit.Name))
            {
                edit.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                reloadDataSource();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (db.TestType.Count() == 0)
                return;
            TestType removed = db.TestType.First(x => x.id == ((TestType)LookupBindingSource.Current).id);
            try
            {
                db.TestType.Remove(removed);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Удалите все связи с даным семейным положением, а потом удалите саму запись", "Ошибка");
            }
            reloadDataSource();
        }
    }
}
