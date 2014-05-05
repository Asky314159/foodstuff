using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Foodstuff
{
    public partial class SummaryForm : Form
    {
        private Queue<string> linesToPrint;

        public SummaryForm()
        {
            InitializeComponent();
            this.linesToPrint = new Queue<string>();
        }

        public void SetList(IEnumerable<Fooditem> itemPool, IEnumerable<SelectedItem> selectedList)
        {
            this.instructionsRichTextBox.Text = string.Empty;
            this.ingredientsRichTextBox.Text = string.Empty;
            Dictionary<string, Fooditem> indexedPool = new Dictionary<string, Fooditem>();
            foreach (Fooditem item in itemPool)
            {
                indexedPool.Add(item.Id, item);
            }
            List<Ingredient> totalIngredients = new List<Ingredient>();
            foreach (SelectedItem item in selectedList)
            {
                totalIngredients.AddRange(indexedPool[item.Id].Ingredients);
                if (!string.IsNullOrWhiteSpace(this.instructionsRichTextBox.Text)) this.instructionsRichTextBox.Text += Environment.NewLine + Environment.NewLine;
                this.instructionsRichTextBox.Text += indexedPool[item.Id].Name + Environment.NewLine + Environment.NewLine + indexedPool[item.Id].Instructions;
            }
            totalIngredients.Sort();
            foreach (Ingredient ingredient in totalIngredients)
            {
                if (!string.IsNullOrWhiteSpace(this.ingredientsRichTextBox.Text)) this.ingredientsRichTextBox.Text += Environment.NewLine;
                this.ingredientsRichTextBox.Text += ingredient.ToString();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (this.printDialog.ShowDialog() == DialogResult.OK)
            {
                this.printDocument.Print();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.linesToPrint.Clear();
            string[] lines = this.ingredientsRichTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                this.linesToPrint.Enqueue(line);
            }
            this.linesToPrint.Enqueue(null);
            lines = this.instructionsRichTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                this.linesToPrint.Enqueue(line);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 12);

            while (this.linesToPrint.Count > 0)
            {
                string line = this.linesToPrint.Dequeue();
                if (line == null)
                {
                    e.HasMorePages = true;
                    return;
                }
                e.Graphics.DrawString(line, font, brush, x, y);
                y += (int)e.Graphics.MeasureString(line, font).Height;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (RichTextBox tempTextBox = new RichTextBox())
                {
                    string newRtf = string.Empty;
                    string lastLine = this.ingredientsRichTextBox.Text.Substring(this.ingredientsRichTextBox.Text.LastIndexOf('\n') + 1);
                    newRtf += this.ingredientsRichTextBox.Rtf.Substring(0, this.ingredientsRichTextBox.Rtf.LastIndexOf(lastLine) + lastLine.Length);
                    newRtf += @"\page ";
                    string firstLine = this.instructionsRichTextBox.Text.Substring(0, this.instructionsRichTextBox.Text.IndexOf('\n'));
                    newRtf += this.instructionsRichTextBox.Rtf.Substring(this.instructionsRichTextBox.Rtf.IndexOf(firstLine));
                    tempTextBox.Rtf = newRtf;// ingredientsRichTextBox.Rtf + @" \par \page " + instructionsRichTextBox.Rtf;
                    tempTextBox.SaveFile(this.saveFileDialog.FileName);
                }
            }
        }
    }
}
