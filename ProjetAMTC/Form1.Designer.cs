namespace ProjetAMTC
{
    partial class Form1
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
            this.buttonRainbowFilter = new System.Windows.Forms.Button();
            this.buttonNightFilter = new System.Windows.Forms.Button();
            this.xEdgeDetection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNoFilter = new System.Windows.Forms.Button();
            this.yEdgeDetection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModified)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filters";
            // 
            // buttonRainbowFilter
            // 
            this.buttonRainbowFilter.Location = new System.Drawing.Point(548, 52);
            this.buttonRainbowFilter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRainbowFilter.Name = "buttonRainbowFilter";
            this.buttonRainbowFilter.Size = new System.Drawing.Size(279, 37);
            this.buttonRainbowFilter.TabIndex = 48;
            this.buttonRainbowFilter.Text = "Rainbow Filter";
            this.buttonRainbowFilter.UseVisualStyleBackColor = true;
            this.buttonRainbowFilter.Click += new System.EventHandler(this.buttonRainbowFilter_Click);
            // 
            // buttonNightFilter
            // 
            this.buttonNightFilter.Location = new System.Drawing.Point(548, 97);
            this.buttonNightFilter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNightFilter.Name = "buttonNightFilter";
            this.buttonNightFilter.Size = new System.Drawing.Size(279, 37);
            this.buttonNightFilter.TabIndex = 49;
            this.buttonNightFilter.Text = "Night Filter";
            this.buttonNightFilter.UseVisualStyleBackColor = true;
            this.buttonNightFilter.Click += new System.EventHandler(this.buttonNightFilter_Click);
            // 
            // xEdgeDetection
            // 
            this.xEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xEdgeDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEdgeDetection.FormattingEnabled = true;
            this.xEdgeDetection.Items.AddRange(new object[] {
            "None",
            "Laplacian 3x3",
            "Laplacian 5x5",
            "LaplacianOfGaussian",
            "Gaussian3x3",
            "Gaussian5x5Type1",
            "Gaussian5x5Type2",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.xEdgeDetection.Location = new System.Drawing.Point(548, 333);
            this.xEdgeDetection.Name = "xEdgeDetection";
            this.xEdgeDetection.Size = new System.Drawing.Size(279, 37);
            this.xEdgeDetection.TabIndex = 50;
            this.xEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.xEdgeDetection_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Edge Detection X axis";
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
            // buttonNoFilter
            // 
            this.buttonNoFilter.Location = new System.Drawing.Point(548, 142);
            this.buttonNoFilter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNoFilter.Name = "buttonNoFilter";
            this.buttonNoFilter.Size = new System.Drawing.Size(279, 37);
            this.buttonNoFilter.TabIndex = 53;
            this.buttonNoFilter.Text = "No Filter";
            this.buttonNoFilter.UseVisualStyleBackColor = true;
            this.buttonNoFilter.Click += new System.EventHandler(this.buttonNoFilter_Click);
            // 
            // yEdgeDetection
            // 
            this.yEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yEdgeDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yEdgeDetection.FormattingEnabled = true;
            this.yEdgeDetection.Items.AddRange(new object[] {
            "None",
            "Laplacian 3x3",
            "Laplacian 5x5",
            "LaplacianOfGaussian",
            "Gaussian3x3",
            "Gaussian5x5Type1",
            "Gaussian5x5Type2",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.yEdgeDetection.Location = new System.Drawing.Point(548, 409);
            this.yEdgeDetection.Name = "yEdgeDetection";
            this.yEdgeDetection.Size = new System.Drawing.Size(279, 37);
            this.yEdgeDetection.TabIndex = 54;
            this.yEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.yEdgeDetection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 382);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Edge Detection Y axis";
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(548, 477);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(279, 38);
            this.buttonApply.TabIndex = 56;
            this.buttonApply.Text = "Apply Edges Detection";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(869, 732);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yEdgeDetection);
            this.Controls.Add(this.buttonNoFilter);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xEdgeDetection);
            this.Controls.Add(this.buttonNightFilter);
            this.Controls.Add(this.buttonRainbowFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureModified);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.picPreview);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModified)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.PictureBox pictureModified;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRainbowFilter;
        private System.Windows.Forms.Button buttonNightFilter;
        private System.Windows.Forms.ComboBox xEdgeDetection;
        private System.Windows.Forms.ComboBox yEdgeDetection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonNoFilter;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonApply;
    }
}

