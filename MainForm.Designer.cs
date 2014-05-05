namespace Foodstuff
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainListBox = new System.Windows.Forms.ListBox();
            this.selectionListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.newItemButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.sortUpButton = new System.Windows.Forms.Button();
            this.sortDownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainListBox
            // 
            this.mainListBox.FormattingEnabled = true;
            this.mainListBox.Location = new System.Drawing.Point(12, 12);
            this.mainListBox.Name = "mainListBox";
            this.mainListBox.Size = new System.Drawing.Size(237, 212);
            this.mainListBox.TabIndex = 0;
            // 
            // selectionListBox
            // 
            this.selectionListBox.FormattingEnabled = true;
            this.selectionListBox.Location = new System.Drawing.Point(336, 12);
            this.selectionListBox.Name = "selectionListBox";
            this.selectionListBox.Size = new System.Drawing.Size(237, 212);
            this.selectionListBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(255, 43);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "->";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(255, 72);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "<-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(336, 230);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(498, 230);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "Summary";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // newItemButton
            // 
            this.newItemButton.Location = new System.Drawing.Point(12, 230);
            this.newItemButton.Name = "newItemButton";
            this.newItemButton.Size = new System.Drawing.Size(75, 23);
            this.newItemButton.TabIndex = 6;
            this.newItemButton.Text = "Add";
            this.newItemButton.UseVisualStyleBackColor = true;
            this.newItemButton.Click += new System.EventHandler(this.newItemButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(93, 230);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(174, 230);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Remove";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // sortUpButton
            // 
            this.sortUpButton.Location = new System.Drawing.Point(579, 43);
            this.sortUpButton.Name = "sortUpButton";
            this.sortUpButton.Size = new System.Drawing.Size(75, 23);
            this.sortUpButton.TabIndex = 9;
            this.sortUpButton.Text = "/\\";
            this.sortUpButton.UseVisualStyleBackColor = true;
            this.sortUpButton.Click += new System.EventHandler(this.sortUpButton_Click);
            // 
            // sortDownButton
            // 
            this.sortDownButton.Location = new System.Drawing.Point(579, 72);
            this.sortDownButton.Name = "sortDownButton";
            this.sortDownButton.Size = new System.Drawing.Size(75, 23);
            this.sortDownButton.TabIndex = 10;
            this.sortDownButton.Text = "\\/";
            this.sortDownButton.UseVisualStyleBackColor = true;
            this.sortDownButton.Click += new System.EventHandler(this.sortDownButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 266);
            this.Controls.Add(this.sortDownButton);
            this.Controls.Add(this.sortUpButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newItemButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.selectionListBox);
            this.Controls.Add(this.mainListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Foodstuff";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox mainListBox;
        private System.Windows.Forms.ListBox selectionListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button newItemButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button sortUpButton;
        private System.Windows.Forms.Button sortDownButton;
    }
}

