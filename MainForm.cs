using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Foodstuff
{
    public partial class MainForm : Form
    {
        private BindingList<Fooditem> itemPool;
        private BindingList<SelectedItem> selectedItems;
        private EditForm editForm;
        private SummaryForm summaryForm;
        private bool selectionChanged;

        private string DataDir { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foodstuff"); } }
        private string SaveFile { get { return Path.Combine(this.DataDir, "state.xml"); } }
        private string BackupSaveFile { get { return Path.Combine(this.DataDir, "state.bak"); } }

        public MainForm()
        {
            InitializeComponent();

            this.editForm = new EditForm();
            this.summaryForm = new SummaryForm();
            this.itemPool = new BindingList<Fooditem>();
            this.selectedItems = new BindingList<SelectedItem>();
            this.LoadItems();
            this.mainListBox.DataSource = this.itemPool;
            this.selectionListBox.DataSource = this.selectedItems;
            this.selectionChanged = false;
        }

        private void newItemButton_Click(object sender, EventArgs e)
        {
            this.editForm.SetItem(null);
            if (this.editForm.ShowDialog() == DialogResult.OK)
            {
                Fooditem item = new Fooditem();
                item.Name = this.editForm.EditedName;
                item.Ingredients = this.editForm.EditedIngredients;
                item.Instructions = this.editForm.EditedInstructions;
                this.itemPool.Add(item);

                this.SortPool();

                this.SaveItems();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.mainListBox.SelectedIndex != -1)
            {
                Fooditem item = this.itemPool[this.mainListBox.SelectedIndex];
                this.editForm.SetItem(item);
                if (this.editForm.ShowDialog() == DialogResult.OK)
                {
                    bool changedName = item.Name != this.editForm.EditedName;
                    item.Name = this.editForm.EditedName;
                    item.Ingredients = this.editForm.EditedIngredients;
                    item.Instructions = this.editForm.EditedInstructions;
                    this.itemPool.ResetItem(this.mainListBox.SelectedIndex);
                    if (changedName)
                    {
                        for (int x = 0; x < this.selectedItems.Count; x++)
                        {
                            if (selectedItems[x].Id == item.Id)
                            {
                                selectedItems[x].Name = item.Name;
                                this.selectedItems.ResetItem(x);
                            }
                        }

                        this.SortPool();
                    }
                    this.SaveItems();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.mainListBox.SelectedIndex != -1)
            {
                Fooditem item = this.itemPool[this.mainListBox.SelectedIndex];
                if (MessageBox.Show(string.Format("The item \"{0}\" will be removed from all lists. Are you sure you want to continue?", item.ToString()), "Foodstuff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.itemPool.RemoveAt(this.mainListBox.SelectedIndex);
                    for (int x = this.selectedItems.Count - 1; x >= 0; x--)
                    {
                        if (this.selectedItems[x].Id == item.Id)
                        {
                            this.selectedItems.RemoveAt(x);
                        }
                    }
                    this.SaveItems();
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.mainListBox.SelectedIndex != -1)
            {
                Fooditem selectedItem = this.itemPool[this.mainListBox.SelectedIndex];
                this.selectedItems.Add(new SelectedItem(selectedItem.Name, selectedItem.Id));
                this.selectionChanged = true;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (this.selectionListBox.SelectedIndex != -1)
            {
                this.selectedItems.RemoveAt(this.selectionListBox.SelectedIndex);
                this.selectionChanged = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.selectedItems.Clear();
            this.selectionChanged = true;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (this.selectedItems.Count > 0)
            {
                this.summaryForm.SetList(this.itemPool, this.selectedItems);
                this.summaryForm.ShowDialog();
                if (this.selectionChanged)
                {
                    this.SaveItems();
                }
            }
        }

        private void sortUpButton_Click(object sender, EventArgs e)
        {
            if (this.selectionListBox.SelectedIndex != -1 && this.selectionListBox.SelectedIndex != 0)
            {
                int oldIndex = this.selectionListBox.SelectedIndex;
                SelectedItem item = this.selectedItems[oldIndex];
                this.selectedItems.RemoveAt(oldIndex);
                this.selectedItems.Insert(oldIndex - 1, item);
                this.selectionListBox.SelectedIndex = oldIndex - 1;
                this.selectionChanged = true;
            }
        }

        private void sortDownButton_Click(object sender, EventArgs e)
        {
            if (this.selectionListBox.SelectedIndex != -1 && this.selectionListBox.SelectedIndex != this.selectedItems.Count - 1)
            {
                int oldIndex = this.selectionListBox.SelectedIndex;
                SelectedItem item = this.selectedItems[oldIndex];
                this.selectedItems.RemoveAt(oldIndex);
                this.selectedItems.Insert(oldIndex + 1, item);
                this.selectionListBox.SelectedIndex = oldIndex + 1;
                this.selectionChanged = true;
            }
        }

        private void LoadItems()
        {
            bool loadBackup = false;
            try
            {
                if (File.Exists(this.SaveFile))
                {
                    string stateXml = File.ReadAllText(this.SaveFile);
                    this.LoadXml(stateXml);
                    
                }
                else if (File.Exists(this.BackupSaveFile))
                {
                    loadBackup = true;
                }
            }
            catch
            {
                loadBackup = true;
            }
            if (loadBackup)
            {
                if (File.Exists(this.BackupSaveFile))
                {
                    try
                    {
                        string stateXml = File.ReadAllText(this.BackupSaveFile);
                        this.LoadXml(stateXml);
                        MessageBox.Show(string.Format("There was an error loading from the normal state file. Data has been loaded from the backup instead. Changes since {0} have been lost.", File.GetLastWriteTime(this.BackupSaveFile).ToString()), "Foodstuff", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch
                    {
                        MessageBox.Show("There was an error loading saved data. All data has been lost.", "Foodstuff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (File.Exists(this.SaveFile))
            {
                File.Copy(this.SaveFile, this.BackupSaveFile, true);
            }
        }

        private void LoadXml(string stateXml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(stateXml);
            foreach (XmlNode itemNode in document["foodstuffState"]["items"])
            {
                Fooditem item = Fooditem.FromXml(itemNode);
                if (item != null)
                {
                    this.itemPool.Add(item);
                }
            }
            string[] selected = new string[int.Parse(document["foodstuffState"]["selected"].Attributes["count"].InnerText)];
            foreach (XmlNode itemNode in document["foodstuffState"]["selected"])
            {
                if (itemNode.Name == "selectedItem")
                {
                    selected[int.Parse(itemNode.Attributes["index"].InnerText)] = itemNode.Attributes["id"].InnerText;
                }
            }
            foreach (string id in selected)
            {
                foreach (Fooditem item in this.itemPool)
                {
                    if (item.Id == id)
                    {
                        this.selectedItems.Add(new SelectedItem(item.Name, item.Id));
                        break;
                    }
                }
            }
        }

        private void SaveItems()
        {
            if (!Directory.Exists(this.DataDir))
            {
                Directory.CreateDirectory(this.DataDir);
            }
            using (StringWriter outputXml = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(outputXml))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("foodstuffState");
                    writer.WriteStartElement("items");
                    foreach (Fooditem item in this.itemPool)
                    {
                        writer.WriteRaw(item.ToXml());
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("selected");
                    writer.WriteAttributeString("count", this.selectedItems.Count.ToString());
                    for (int x = 0; x < this.selectedItems.Count; x++)
                    {
                        writer.WriteStartElement("selectedItem");
                        writer.WriteAttributeString("index", x.ToString());
                        writer.WriteAttributeString("id", this.selectedItems[x].Id);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                File.WriteAllText(this.SaveFile, outputXml.ToString());
            }
            this.selectionChanged = false;
        }

        private void SortPool()
        {
            List<Fooditem> tempList = this.itemPool.ToList();
            tempList.Sort();
            this.itemPool.Clear();
            foreach (Fooditem item in tempList)
            {
                this.itemPool.Add(item);
            }
        }
    }
}
