
using Guna.UI2.WinForms;
using DLMS.EntitiesNamespace;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace DesktopApp.PersonControl
{
    public partial class ShowPersonWithFilter : UserControl
    {
      
        public ShowPersonWithFilter()
        {
            InitializeComponent();
        }
        public class PersonSelectedEventArgs
        {
            public int PersonID { get; }
            public DateTime FountAt;
            public PersonSelectedEventArgs(int PersonID)
            {
                this.PersonID = PersonID;
                this.FountAt = DateTime.Now;
            }
        }
        public event EventHandler<PersonSelectedEventArgs> OnPersonSelected= delegate { };
        //public event Action<object, PersonSelectedEventArgs> TestOnPersonSelected; //we can achieve same with this line but it's better to prevent it for readability
        public delegate void Onselect(int ID);
        private void RaiseOnPersonSelected(int PersonID)
        {
            RaiseOnPersonSelected(new PersonSelectedEventArgs(PersonID));
        }
        protected virtual void RaiseOnPersonSelected(PersonSelectedEventArgs e)
        {
            this.OnPersonSelected?.Invoke(this,e);
        }

        public int PersonID
        {
            get
            {
                return this.showInfoInControl1.PersonID;
            }
        }
        public Entities.ClsPerson? Person
        {
            get
            {
                return this.showInfoInControl1.Person;
            }
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterChoices.SelectedIndex == 0 && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
                FindButton.PerformClick();
        }

        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {

            if (FilterChoices.SelectedIndex == 0 && !int.TryParse(((Guna2TextBox)sender).Text, out int res))
            {
                FilterValueTextBox.Text = "";
            }

        }

        public void FindByID(int PersonID)
        {
            this.FilterChoices.SelectedIndex = 0;
            this.FilterValueTextBox.Text = PersonID.ToString();
            FilterGroupBox.Enabled = false;
            this.FindButton.PerformClick();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (this.FilterValueTextBox.Text == "")
            {
                MessageBox.Show("Filter cannot be empty", "Invalid Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FilterChoices.SelectedIndex == 0)
            {
                int ID = Convert.ToInt32(this.FilterValueTextBox.Text);
                this.showInfoInControl1.FillDataInControl(ID);
                this.RaiseOnPersonSelected(ID);
                if (showInfoInControl1.PersonID == -1)
                    MessageBox.Show($"Person With ID={ID} Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (this.FilterChoices.SelectedIndex == 1)
            {
                string N_No = this.FilterValueTextBox.Text.Trim();
                this.showInfoInControl1.FillDataInControl(NationalNo: N_No);
                this.RaiseOnPersonSelected(showInfoInControl1.PersonID);             
                if(showInfoInControl1.PersonID==-1)
                    MessageBox.Show($"Person With National Number ={N_No} Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPersonWithFilter_Load(object sender, EventArgs e)
        {
            this.FilterChoices.SelectedIndex = 0;
        }
    }
}
