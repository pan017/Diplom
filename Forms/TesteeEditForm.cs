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

namespace Diplom.Forms
{
    public partial class TesteeEditForm : Form
    {
        void initComboBoxs()
        {
            GroupsCombobBox.DataSource = db.Group.ToList();
            GroupsCombobBox.DisplayMember = "Name";

            FamilyStateComboBox.DataSource = db.FamilyState.ToList();
            FamilyStateComboBox.DisplayMember = "Name";

            EducationComboBox.DataSource = db.Education.ToList();
            EducationComboBox.DisplayMember = "Name";

            GenderComboBox.DataSource = db.Gender.ToList();
            GenderComboBox.DisplayMember = "Name";
        }
        public TesteeEditForm()
        {
            InitializeComponent();
            initComboBoxs();
        }
        Profile Profile;
        public TesteeEditForm(Profile profile)
        {
            InitializeComponent();
            initComboBoxs();
            var currentProfile = db.Profile.First(x => x.id == profile.id);
            Profile = currentProfile;

            FirstNameTextBox.Text = Profile.FirstName;
            SecondNameTextBox.Text = Profile.LastName;
            NameTextBox.Text = Profile.Name;
            PhoneTextBox.Text = Profile.Phone;
            EmailTextBox.Text = Profile.Email;
            BrithDate.Value = Profile.BrithDate;
            EducationComboBox.SelectedItem = Profile.Education;
            GroupsCombobBox.SelectedItem = Profile.Group;
            GenderComboBox.SelectedItem = Profile.Gender;
            FamilyStateComboBox.SelectedItem = Profile.FamilyState;
            if (Profile.DriversLicense != null)
            {
            //    CategoriesTextBox.Text = Profile.DriversLicense.Category;
                
                foreach (var item in Profile.DriversLicense.Category)
                {
                    CheckBox textBox = (CheckBox)this.Controls.Find(item + "CategoryCheckBox", true).First();
                    textBox.Checked = true;
                }
                GettindDate.Value = Profile.DriversLicense.GettingDate;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                GettindDate.Visible = false;
                //CategoriesTextBox.Text = "";
               // CategoriesTextBox.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
            }
                //    educationBindingSource.DataSource = profile.Education;
            }
        ViewModel db = new ViewModel();
        private void TesteeEditForm_Load(object sender, EventArgs e)
        {
            
        }
        bool checkSelectedCategories()
        {
            if (String.IsNullOrEmpty(getSelectedCategories()) && radioButton1.Checked)
                return false;
            else
                return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkSelectedCategories())
            {
                MessageBox.Show("Не выбранно не одной категории прав!", "Ошибка");
                return;
            }
            if (FirstNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Имя не может быть пустым!", "Ошибка");
                return;
            }
            if (NameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Фамилия не может быть пустой!", "Ошибка");
                return;
            }
            Group group;
            if (db.Group.Where(x => x.Name == GroupsCombobBox.Text).ToList().Count == 0)
            {
                group = new Group() { Name = GroupsCombobBox.Text };
                db.Group.Add(group);
                db.SaveChanges();
            }
            else
                group = (Group)GroupsCombobBox.SelectedItem;
            if (Profile != null)
            {
                var editedProfile = db.Profile.FirstOrDefault(x => x.id == Profile.id);
                editedProfile.BrithDate = BrithDate.Value;
                editedProfile.Education = (Education)EducationComboBox.SelectedItem;
                editedProfile.Gender = (Gender)GenderComboBox.SelectedItem;
                editedProfile.Group = group;
                editedProfile.FamilyState = (FamilyState)FamilyStateComboBox.SelectedItem;
                editedProfile.Name = NameTextBox.Text;
                editedProfile.FirstName = FirstNameTextBox.Text;
                editedProfile.LastName = SecondNameTextBox.Text;
                editedProfile.Phone = PhoneTextBox.Text;
                editedProfile.Email = EmailTextBox.Text;
                editedProfile.ModifiedDate = DateTime.Now;
                if (radioButton1.Checked)
                {

                    if (editedProfile.DriversLicense != null)
                    {
                        editedProfile.DriversLicense.Category = getSelectedCategories();
                        editedProfile.DriversLicense.GettingDate = GettindDate.Value;
                        editedProfile.ModifiedDate = DateTime.Now;
                    }
                    else
                        editedProfile.DriversLicense = addDriversLicense();
                }
                else
                {
                    if (editedProfile.DriversLicense != null)
                    {
                        db.DriversLicense.Remove(editedProfile.DriversLicense);
                        editedProfile.DriversLicense = null;
                        
                    }
                }
            }
            else
            {
                Profile profile = new Profile()
                {
                    BrithDate = BrithDate.Value,
                    Education = (Education)EducationComboBox.SelectedItem,
                    Gender = (Gender)GenderComboBox.SelectedItem,
                    Group = group,
                    FamilyState = (FamilyState)FamilyStateComboBox.SelectedItem,
                    Name = NameTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    LastName = SecondNameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Email = EmailTextBox.Text
                };
                if (radioButton1.Checked)
                    profile.DriversLicense = addDriversLicense();
                
                db.Profile.Add(profile);

            }

            db.SaveChanges();
            this.Close();
            this.Dispose();
            
        }
        DriversLicense addDriversLicense()
        {

            DriversLicense driversLicense = new DriversLicense() { GettingDate = GettindDate.Value, Category = getSelectedCategories() };
            db.DriversLicense.Add(driversLicense);
            db.SaveChanges();
            return driversLicense;
        }

        string getSelectedCategories()
        {

            string categories = "";
            foreach (var item in "ABCDE")
            {
                CheckBox checkBox = (CheckBox)this.Controls.Find(item + "CategoryCheckBox", true).First();
                if (checkBox.Checked)
                    categories = categories + this.Controls.Find(item + "CategoryCheckBox", true).First().Text;
            }
            return categories;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GettindDate.Visible = false;
            foreach (var item in "ABCDE")
            {
                this.Controls.Find(item + "CategoryCheckBox", true).First().Visible = false;     
            }
            label11.Visible = false;
            label12.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GettindDate.Visible = true;
            foreach (var item in "ABCDE")
            {
                this.Controls.Find(item + "CategoryCheckBox", true).First().Visible = true;
            }
            label11.Visible = true;
            label12.Visible = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void GroupsCombobBox_TextChanged(object sender, EventArgs e)
        {
          //  GroupsCombobBox.DataSource = db.Group.Where(d => d.Name.Contains(GroupsCombobBox.Text)).ToList();
        }

        private void GroupsCombobBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
