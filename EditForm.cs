using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Foodstuff
{
    public partial class EditForm : Form
    {
        public string EditedName
        {
            get
            {
                return this.nameTextBox.Text;
            }
        }

        public List<Ingredient> EditedIngredients
        {
            get
            {
                return this.ingredients.ToList();
            }
        }

        public string EditedInstructions
        {
            get
            {
                return this.instructionsTextBox.Text;
            }
        }

        private List<Fraction> fractions;
        private List<Unit> units;
        private BindingList<Ingredient> ingredients;

        public EditForm()
        {
            InitializeComponent();

            this.fractions = new List<Fraction>(Ingredient.GetFractions());
            this.units = new List<Unit>(Ingredient.GetUnits());
            this.ingredients = new BindingList<Ingredient>();
            //this.fractionComboBox.DataSource = this.fractions;
            //this.unitComboBox.DataSource = this.units;
            this.ingredientsListBox.DataSource = this.ingredients;
            this.SetCueText(this.ingredientNameTextBox, "Name");
            this.SetCueText(this.ingredientQuantityTextBox, "Quantity");
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.saveButton.Enabled = !string.IsNullOrWhiteSpace(this.nameTextBox.Text);
        }

        public void SetItem(Fooditem item)
        {
            if (item == null)
            {
                this.nameTextBox.Text = string.Empty;
                this.ingredients.Clear();
                this.instructionsTextBox.Text = string.Empty;
            }
            else
            {
                this.nameTextBox.Text = item.Name;
                this.ingredients.Clear();
                foreach (Ingredient ingredient in item.Ingredients)
                {
                    this.ingredients.Add(ingredient);
                }
                this.instructionsTextBox.Text = item.Instructions;
            }
        }

        private const int EM_SETCUEBANNER = 0x1501;
        private const int EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void SetCueText(Control control, string text)
        {
            SendMessage(control.Handle, EM_SETCUEBANNER, 0, text);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ingredientQuantityTextBox.Text) && !string.IsNullOrWhiteSpace(this.ingredientNameTextBox.Text))
            {
                this.ingredients.Add(new Ingredient(this.ingredientQuantityTextBox.Text, this.ingredientNameTextBox.Text));
                this.ingredientQuantityTextBox.Text = string.Empty;
                this.ingredientNameTextBox.Text = string.Empty;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (this.ingredientsListBox.SelectedIndex != -1)
            {
                this.ingredients.RemoveAt(this.ingredientsListBox.SelectedIndex);
            }
        }
    }
}
