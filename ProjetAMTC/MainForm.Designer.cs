namespace ProjetAMTC
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

        private void InitializeComponent()
        {
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.pictureModified = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.RainbowFiltercheckBox = new System.Windows.Forms.CheckBox();
            this.NightFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.BlackWhiteFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.LaplacianXRadioButton = new System.Windows.Forms.RadioButton();
            this.Kirsch3x3HXRadioButton = new System.Windows.Forms.RadioButton();
            this.Kirsch3x3VXRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LaplacianYRadioButton = new System.Windows.Forms.RadioButton();
            this.Kirsch3x3HYRadioButton = new System.Windows.Forms.RadioButton();
            this.Kirsch3x3VYRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModified)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(12, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(512, 283);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(12, 310);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(512, 48);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // pictureModified
            // 
            this.pictureModified.BackColor = System.Drawing.SystemColors.Info;
            this.pictureModified.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureModified.Location = new System.Drawing.Point(12, 373);
            this.pictureModified.Name = "pictureModified";
            this.pictureModified.Size = new System.Drawing.Size(512, 283);
            this.pictureModified.TabIndex = 2;
            this.pictureModified.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filters";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(12, 672);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(512, 48);
            this.buttonSave.TabIndex = 52;
            this.buttonSave.Text = "Save Image";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // RainbowFiltercheckBox
            // 
            this.RainbowFiltercheckBox.AutoSize = true;
            this.RainbowFiltercheckBox.Location = new System.Drawing.Point(557, 59);
            this.RainbowFiltercheckBox.Name = "RainbowFiltercheckBox";
            this.RainbowFiltercheckBox.Size = new System.Drawing.Size(93, 17);
            this.RainbowFiltercheckBox.TabIndex = 61;
            this.RainbowFiltercheckBox.Text = "Rainbow Filter";
            this.RainbowFiltercheckBox.UseVisualStyleBackColor = true;
            this.RainbowFiltercheckBox.CheckedChanged += new System.EventHandler(this.RainbowFiltercheckBox_CheckedChanged);
            // 
            // NightFilterCheckBox
            // 
            this.NightFilterCheckBox.AutoSize = true;
            this.NightFilterCheckBox.Location = new System.Drawing.Point(557, 85);
            this.NightFilterCheckBox.Name = "NightFilterCheckBox";
            this.NightFilterCheckBox.Size = new System.Drawing.Size(76, 17);
            this.NightFilterCheckBox.TabIndex = 62;
            this.NightFilterCheckBox.Text = "Night Filter";
            this.NightFilterCheckBox.UseVisualStyleBackColor = true;
            this.NightFilterCheckBox.CheckedChanged += new System.EventHandler(this.NightFilterCheckBox_CheckedChanged);
            // 
            // BlackWhiteFilterCheckBox
            // 
            this.BlackWhiteFilterCheckBox.AutoSize = true;
            this.BlackWhiteFilterCheckBox.Location = new System.Drawing.Point(557, 111);
            this.BlackWhiteFilterCheckBox.Name = "BlackWhiteFilterCheckBox";
            this.BlackWhiteFilterCheckBox.Size = new System.Drawing.Size(109, 17);
            this.BlackWhiteFilterCheckBox.TabIndex = 63;
            this.BlackWhiteFilterCheckBox.Text = "Black White Filter";
            this.BlackWhiteFilterCheckBox.UseVisualStyleBackColor = true;
            this.BlackWhiteFilterCheckBox.CheckedChanged += new System.EventHandler(this.BlackWhiteFilterCheckBox_CheckedChanged);
            // 
            // LaplacianXRadioButton
            // 
            this.LaplacianXRadioButton.AutoSize = true;
            this.LaplacianXRadioButton.Location = new System.Drawing.Point(37, 21);
            this.LaplacianXRadioButton.Name = "LaplacianXRadioButton";
            this.LaplacianXRadioButton.Size = new System.Drawing.Size(91, 17);
            this.LaplacianXRadioButton.TabIndex = 71;
            this.LaplacianXRadioButton.Text = "Laplacian 3x3";
            this.LaplacianXRadioButton.UseVisualStyleBackColor = true;
            this.LaplacianXRadioButton.CheckedChanged += new System.EventHandler(this.LaplacianXRadioButton_CheckedChanged);
            // 
            // Kirsch3x3HXRadioButton
            // 
            this.Kirsch3x3HXRadioButton.AutoSize = true;
            this.Kirsch3x3HXRadioButton.Location = new System.Drawing.Point(37, 47);
            this.Kirsch3x3HXRadioButton.Name = "Kirsch3x3HXRadioButton";
            this.Kirsch3x3HXRadioButton.Size = new System.Drawing.Size(124, 17);
            this.Kirsch3x3HXRadioButton.TabIndex = 72;
            this.Kirsch3x3HXRadioButton.Text = "Kirsch 3x3 Horizontal";
            this.Kirsch3x3HXRadioButton.UseVisualStyleBackColor = true;
            this.Kirsch3x3HXRadioButton.CheckedChanged += new System.EventHandler(this.Kirsch3x3HXRadioButton_CheckedChanged);
            // 
            // Kirsch3x3VXRadioButton
            // 
            this.Kirsch3x3VXRadioButton.AutoSize = true;
            this.Kirsch3x3VXRadioButton.Location = new System.Drawing.Point(37, 70);
            this.Kirsch3x3VXRadioButton.Name = "Kirsch3x3VXRadioButton";
            this.Kirsch3x3VXRadioButton.Size = new System.Drawing.Size(112, 17);
            this.Kirsch3x3VXRadioButton.TabIndex = 73;
            this.Kirsch3x3VXRadioButton.Text = "Kirsch 3x3 Vertical";
            this.Kirsch3x3VXRadioButton.UseVisualStyleBackColor = true;
            this.Kirsch3x3VXRadioButton.CheckedChanged += new System.EventHandler(this.Kirsch3x3VXRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LaplacianXRadioButton);
            this.groupBox1.Controls.Add(this.Kirsch3x3HXRadioButton);
            this.groupBox1.Controls.Add(this.Kirsch3x3VXRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(548, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edge Detection X axis";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LaplacianYRadioButton);
            this.groupBox2.Controls.Add(this.Kirsch3x3HYRadioButton);
            this.groupBox2.Controls.Add(this.Kirsch3x3VYRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(548, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edge Detection Y axis";
            // 
            // LaplacianYRadioButton
            // 
            this.LaplacianYRadioButton.AutoSize = true;
            this.LaplacianYRadioButton.Location = new System.Drawing.Point(37, 21);
            this.LaplacianYRadioButton.Name = "LaplacianYRadioButton";
            this.LaplacianYRadioButton.Size = new System.Drawing.Size(91, 17);
            this.LaplacianYRadioButton.TabIndex = 71;
            this.LaplacianYRadioButton.Text = "Laplacian 3x3";
            this.LaplacianYRadioButton.UseVisualStyleBackColor = true;
            this.LaplacianYRadioButton.CheckedChanged += new System.EventHandler(this.LaplacianYRadioButton_CheckedChanged);
            // 
            // Kirsch3x3HYRadioButton
            // 
            this.Kirsch3x3HYRadioButton.AutoSize = true;
            this.Kirsch3x3HYRadioButton.Location = new System.Drawing.Point(37, 47);
            this.Kirsch3x3HYRadioButton.Name = "Kirsch3x3HYRadioButton";
            this.Kirsch3x3HYRadioButton.Size = new System.Drawing.Size(124, 17);
            this.Kirsch3x3HYRadioButton.TabIndex = 72;
            this.Kirsch3x3HYRadioButton.Text = "Kirsch 3x3 Horizontal";
            this.Kirsch3x3HYRadioButton.UseVisualStyleBackColor = true;
            this.Kirsch3x3HYRadioButton.CheckedChanged += new System.EventHandler(this.Kirsch3x3HYRadioButton_CheckedChanged);
            // 
            // Kirsch3x3VYRadioButton
            // 
            this.Kirsch3x3VYRadioButton.AutoSize = true;
            this.Kirsch3x3VYRadioButton.Location = new System.Drawing.Point(37, 70);
            this.Kirsch3x3VYRadioButton.Name = "Kirsch3x3VYRadioButton";
            this.Kirsch3x3VYRadioButton.Size = new System.Drawing.Size(112, 17);
            this.Kirsch3x3VYRadioButton.TabIndex = 73;
            this.Kirsch3x3VYRadioButton.Text = "Kirsch 3x3 Vertical";
            this.Kirsch3x3VYRadioButton.UseVisualStyleBackColor = true;
            this.Kirsch3x3VYRadioButton.CheckedChanged += new System.EventHandler(this.Kirsch3x3VYRadioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(849, 732);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BlackWhiteFilterCheckBox);
            this.Controls.Add(this.NightFilterCheckBox);
            this.Controls.Add(this.RainbowFiltercheckBox);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureModified);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.picPreview);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModified)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.PictureBox pictureModified;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox RainbowFiltercheckBox;
        private System.Windows.Forms.CheckBox NightFilterCheckBox;
        private System.Windows.Forms.CheckBox BlackWhiteFilterCheckBox;
        private System.Windows.Forms.RadioButton LaplacianXRadioButton;
        private System.Windows.Forms.RadioButton Kirsch3x3HXRadioButton;
        private System.Windows.Forms.RadioButton Kirsch3x3VXRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton LaplacianYRadioButton;
        private System.Windows.Forms.RadioButton Kirsch3x3HYRadioButton;
        private System.Windows.Forms.RadioButton Kirsch3x3VYRadioButton;
    }
}

