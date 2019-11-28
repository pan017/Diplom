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
using Diplom.Model;
using Diplom.Model.Lookups;

namespace Diplom.Forms.Lookups
{
    public partial class GenderLookupForm : BaseLookupForm
    {
        public GenderLookupForm()
        {
            InitializeComponent();
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.Gender.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.Gender.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
        }
        private void GenderLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            Gender newGender = new Gender();
            newGender.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newGender.Name))
            {
                db.Gender.Add(newGender);
                db.SaveChanges();

                reloadDataSource();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LookupBindingSource.Current == null)
                return;
            Gender edit = db.Gender.First(x => x.id == ((Gender)LookupBindingSource.Current).id);

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
            if (db.Gender.Count() == 0)
                return;
            Gender removed = db.Gender.First(x => x.id == ((Gender)LookupBindingSource.Current).id);
            try
            {
                db.Gender.Remove(removed);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Удалите все связи с данной записью, а потом удалите саму запись", "Ошибка");
            }
            reloadDataSource();
        }
    }
}
