﻿using Diplom.Model;
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

namespace Diplom.Forms
{
    public partial class TesteeForm : Form
    {
        public TesteeForm()
        {
            InitializeComponent();
        }


        ViewModel db = new ViewModel();
        private void TesteeForm_Load(object sender, EventArgs e)
        {
            db.Profile.Load();
            profileBindingSource.ResetBindings(false);
            profileBindingSource.DataSource = db.Profile.Local.ToBindingList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TesteeForm_Activated(object sender, EventArgs e)
        {
            db = new ViewModel();
            db.Profile.Load();
            profileBindingSource.ResetBindings(false);

            profileBindingSource.DataSource = db.Profile.Local.ToBindingList();
        }

        private void AddTesteeButton_Click(object sender, EventArgs e)
        {
            TesteeEditForm testeeEditForm = new TesteeEditForm();
            testeeEditForm.ShowDialog();
        }

        private void EditTesteeButton_Click(object sender, EventArgs e)
        {
            TesteeEditForm testeeEditForm = new TesteeEditForm((Profile)profileBindingSource.Current);
            testeeEditForm.ShowDialog();
        }
    }
}
