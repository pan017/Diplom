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
    public partial class EducationLookupForm : BaseLookupForm
    {
        public EducationLookupForm()
        {
            InitializeComponent();
        }

        private void EducationLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.Education.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.Education.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            Education newEducation = new Education();
            newEducation.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newEducation.Name))
            {
                db.Education.Add(newEducation);
                db.SaveChanges();

                reloadDataSource();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Education edit = db.Education.First(x => x.id == ((Education)LookupBindingSource.Current).id);

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
            Education removed = db.Education.First(x => x.id == ((Education)LookupBindingSource.Current).id);
            try
            {
                db.Education.Remove(removed);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Удалите все связи с данной формой образавания, а потом удалите саму запись", "Ошибка");
            }
            reloadDataSource();
        }
    }
}
