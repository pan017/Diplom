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
    public partial class GroupsLookupForm : BaseLookupForm
    {
        public GroupsLookupForm()
        {
            InitializeComponent();

        }
        private void GroupsLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            Group newGroup = new Group();
            newGroup.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newGroup.Name))
            {
                db.Group.Add(newGroup);
                db.SaveChanges();

                reloadDataSource();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LookupBindingSource.Current == null)
                return;
            Group edit =db.Group.First(x => x.id == ((Group)LookupBindingSource.Current).id);

            InputBox inputBox = new InputBox();
            edit.Name = inputBox.getString(edit.Name);
            if (!String.IsNullOrEmpty(edit.Name))
            {
                edit.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                reloadDataSource();
                
            }
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.Group.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.Group.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (db.Group.Count() == 0)
                return;
            Group removedGroup = db.Group.First(x => x.id == ((Group)LookupBindingSource.Current).id);
            try
            {
                db.Group.Remove(removedGroup);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Удалите все связи с данной группой, а потом удалите саму группу", "Ошибка");
            }
            reloadDataSource();
        }
    }
}
