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
    public partial class CognitiveLoadLookupForm : BaseLookupForm
    {
        public CognitiveLoadLookupForm()
        {
            InitializeComponent();
        }

        private void CognitiveLoadLookupForm_Load(object sender, EventArgs e)
        {
            reloadDataSource();
        }
        void reloadDataSource()
        {
            db = new ViewModel();
            db.CognitiveLoad.Load();
            LookupBindingSource.ResetBindings(false);
            LookupBindingSource.DataSource = db.CognitiveLoad.Local.ToBindingList();
            LookupDataGridView.DataSource = LookupBindingSource;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            CognitiveLoad newCognitiveLoad = new CognitiveLoad();
            newCognitiveLoad.Name = inputBox.getString();
            if (!String.IsNullOrEmpty(newCognitiveLoad.Name))
            {
                db.CognitiveLoad.Add(newCognitiveLoad);
                db.SaveChanges();

                reloadDataSource();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            CognitiveLoad edit = db.CognitiveLoad.First(x => x.id == ((CognitiveLoad)LookupBindingSource.Current).id);

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
            CognitiveLoad removed = db.CognitiveLoad.First(x => x.id == ((CognitiveLoad)LookupBindingSource.Current).id);
            try
            {
                db.CognitiveLoad.Remove(removed);
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
