namespace Foodstuff
{
    partial class EditForm
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
            this.instructionsTextBox = new System.Windows.Forms.RichTextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ingredientsLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.ingredientsListBox = new System.Windows.Forms.ListBox();
            this.ingredientQuantityTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // instructionsTextBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.instructionsTextBox, 6);
            this.instructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsTextBox.Location = new System.Drawing.Point(3, 239);
            this.instructionsTextBox.Name = "instructionsTextBox";
            this.instructionsTextBox.Size = new System.Drawing.Size(560, 161);
            this.instructionsTextBox.TabIndex = 3;
            this.instructionsTextBox.Text = "";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(53, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(525, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name";
            // 
            // ingredientsLabel
            // 
            this.ingredientsLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.ingredientsLabel, 6);
            this.ingredientsLabel.Location = new System.Drawing.Point(3, 0);
            this.ingredientsLabel.Name = "ingredientsLabel";
            this.ingredientsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ingredientsLabel.Size = new System.Drawing.Size(59, 18);
            this.ingredientsLabel.TabIndex = 7;
            this.ingredientsLabel.Text = "Ingredients";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.instructionsLabel, 6);
            this.instructionsLabel.Location = new System.Drawing.Point(3, 216);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.instructionsLabel.Size = new System.Drawing.Size(61, 18);
            this.instructionsLabel.TabIndex = 8;
            this.instructionsLabel.Text = "Instructions";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(425, 447);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(506, 447);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Controls.Add(this.ingredientsLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.instructionsLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.instructionsTextBox, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.ingredientNameTextBox, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.addButton, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.removeButton, 5, 2);
            this.tableLayoutPanel.Controls.Add(this.ingredientsListBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.ingredientQuantityTextBox, 0, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 38);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(566, 403);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientNameTextBox.Location = new System.Drawing.Point(243, 189);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(260, 20);
            this.ingredientNameTextBox.TabIndex = 12;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(509, 189);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(24, 24);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeButton.Location = new System.Drawing.Point(539, 189);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(24, 24);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // ingredientsListBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.ingredientsListBox, 6);
            this.ingredientsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientsListBox.FormattingEnabled = true;
            this.ingredientsListBox.Location = new System.Drawing.Point(3, 23);
            this.ingredientsListBox.Name = "ingredientsListBox";
            this.ingredientsListBox.Size = new System.Drawing.Size(560, 160);
            this.ingredientsListBox.TabIndex = 15;
            // 
            // ingredientQuantityTextBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.ingredientQuantityTextBox, 3);
            this.ingredientQuantityTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientQuantityTextBox.Location = new System.Drawing.Point(3, 189);
            this.ingredientQuantityTextBox.Name = "ingredientQuantityTextBox";
            this.ingredientQuantityTextBox.Size = new System.Drawing.Size(234, 20);
            this.ingredientQuantityTextBox.TabIndex = 11;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 482);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.Text = "Edit Item";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox instructionsTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ingredientsLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox ingredientNameTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox ingredientsListBox;
        private System.Windows.Forms.TextBox ingredientQuantityTextBox;
    }
}