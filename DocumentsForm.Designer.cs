namespace Lev_Documents
{
    partial class DocumentsForm
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
            this.labelLoggedInUser = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.richTextBoxContract = new System.Windows.Forms.RichTextBox();
            this.comboBoxPhysPer = new System.Windows.Forms.ComboBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLoggedInUser
            // 
            this.labelLoggedInUser.AutoSize = true;
            this.labelLoggedInUser.ForeColor = System.Drawing.Color.White;
            this.labelLoggedInUser.Location = new System.Drawing.Point(744, 9);
            this.labelLoggedInUser.Name = "labelLoggedInUser";
            this.labelLoggedInUser.Size = new System.Drawing.Size(44, 16);
            this.labelLoggedInUser.TabIndex = 0;
            this.labelLoggedInUser.Text = "label1";
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(641, 370);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(147, 31);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Распечатать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(641, 407);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(147, 31);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить в txt";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(641, 296);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(147, 31);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Создать";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonClean.ForeColor = System.Drawing.Color.White;
            this.buttonClean.Location = new System.Drawing.Point(641, 333);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(147, 31);
            this.buttonClean.TabIndex = 4;
            this.buttonClean.Text = "Очистить";
            this.buttonClean.UseVisualStyleBackColor = false;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // richTextBoxContract
            // 
            this.richTextBoxContract.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxContract.Name = "richTextBoxContract";
            this.richTextBoxContract.Size = new System.Drawing.Size(623, 426);
            this.richTextBoxContract.TabIndex = 5;
            this.richTextBoxContract.Text = "";
            // 
            // comboBoxPhysPer
            // 
            this.comboBoxPhysPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhysPer.FormattingEnabled = true;
            this.comboBoxPhysPer.Location = new System.Drawing.Point(641, 74);
            this.comboBoxPhysPer.Name = "comboBoxPhysPer";
            this.comboBoxPhysPer.Size = new System.Drawing.Size(147, 24);
            this.comboBoxPhysPer.TabIndex = 6;
            this.comboBoxPhysPer.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhysPer_SelectedIndexChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(641, 164);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(147, 24);
            this.comboBoxCourse.TabIndex = 7;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(641, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Курс";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(641, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Физ. лицо";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.comboBoxPhysPer);
            this.Controls.Add(this.richTextBoxContract);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.labelLoggedInUser);
            this.Name = "DocumentsForm";
            this.Text = "DocumentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLoggedInUser;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.RichTextBox richTextBoxContract;
        private System.Windows.Forms.ComboBox comboBoxPhysPer;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}