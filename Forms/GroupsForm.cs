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

namespace Diplom.Forms
{
    public partial class GroupsForm : Form
    {
        public GroupsForm()
        {
            InitializeComponent();
        }
        List<Group> groups;
        ViewModel db = new ViewModel();
        private void LookupsForm_Load(object sender, EventArgs e)
        {
            db.Group.Load();
            groupBindingSource.DataSource = db.Group.Local.ToBindingList();
        }


        private void LookupsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.SaveChanges();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
