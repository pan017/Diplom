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
    public partial class FamilyStateLookupForm : BaseLookupForm
    {
        public FamilyStateLookupForm()
        {
            InitializeComponent();
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.FamilyState.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.FamilyState.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
        }
        private void FamilyStateLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            FamilyState newFamilyState = new FamilyState();
            newFamilyState.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newFamilyState.Name))
            {
                db.FamilyState.Add(newFamilyState);
                db.SaveChanges();

                reloadDataSource();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            FamilyState edit = db.FamilyState.First(x => x.id == ((FamilyState)LookupBindingSource.Current).id);

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
            FamilyState removed = db.FamilyState.First(x => x.id == ((FamilyState)LookupBindingSource.Current).id);
            try
            {
                db.FamilyState.Remove(removed);
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
