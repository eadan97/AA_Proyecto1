namespace AA_Proyecto1_v1
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.spnTotalPopulation = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.spnPorcentCruce = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupImagenMeta = new System.Windows.Forms.GroupBox();
            this.pbMeta = new System.Windows.Forms.PictureBox();
            this.lblDireccionImagen = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbBest = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spnGeneraciones = new System.Windows.Forms.NumericUpDown();
            this.spnMenosAptos = new System.Windows.Forms.NumericUpDown();
            this.spnGenesMutar = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCurrentGen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDistanciaManhattan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPaint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPorcentCruce)).BeginInit();
            this.groupImagenMeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBest)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnGeneraciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMenosAptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGenesMutar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Población inicial:";
            // 
            // spnTotalPopulation
            // 
            this.spnTotalPopulation.Location = new System.Drawing.Point(126, 20);
            this.spnTotalPopulation.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.spnTotalPopulation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnTotalPopulation.Name = "spnTotalPopulation";
            this.spnTotalPopulation.Size = new System.Drawing.Size(120, 20);
            this.spnTotalPopulation.TabIndex = 1;
            this.spnTotalPopulation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "% de cruce:";
            // 
            // spnPorcentCruce
            // 
            this.spnPorcentCruce.Location = new System.Drawing.Point(126, 44);
            this.spnPorcentCruce.Name = "spnPorcentCruce";
            this.spnPorcentCruce.Size = new System.Drawing.Size(120, 20);
            this.spnPorcentCruce.TabIndex = 3;
            this.spnPorcentCruce.Tag = "";
            this.spnPorcentCruce.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Porcentaje de genes a mutar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "% individuos menos aptos:";
            // 
            // groupImagenMeta
            // 
            this.groupImagenMeta.Controls.Add(this.pbMeta);
            this.groupImagenMeta.Controls.Add(this.lblDireccionImagen);
            this.groupImagenMeta.Controls.Add(this.button1);
            this.groupImagenMeta.Location = new System.Drawing.Point(10, 111);
            this.groupImagenMeta.Name = "groupImagenMeta";
            this.groupImagenMeta.Size = new System.Drawing.Size(382, 119);
            this.groupImagenMeta.TabIndex = 9;
            this.groupImagenMeta.TabStop = false;
            this.groupImagenMeta.Text = "Imagen Meta";
            this.groupImagenMeta.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pbMeta
            // 
            this.pbMeta.Location = new System.Drawing.Point(99, 48);
            this.pbMeta.Name = "pbMeta";
            this.pbMeta.Size = new System.Drawing.Size(185, 64);
            this.pbMeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMeta.TabIndex = 9;
            this.pbMeta.TabStop = false;
            // 
            // lblDireccionImagen
            // 
            this.lblDireccionImagen.Location = new System.Drawing.Point(5, 22);
            this.lblDireccionImagen.Name = "lblDireccionImagen";
            this.lblDireccionImagen.ReadOnly = true;
            this.lblDireccionImagen.Size = new System.Drawing.Size(279, 20);
            this.lblDireccionImagen.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cargar imagen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbBest
            // 
            this.pbBest.Location = new System.Drawing.Point(6, 19);
            this.pbBest.Name = "pbBest";
            this.pbBest.Size = new System.Drawing.Size(180, 64);
            this.pbBest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBest.TabIndex = 10;
            this.pbBest.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spnGeneraciones);
            this.groupBox1.Controls.Add(this.spnMenosAptos);
            this.groupBox1.Controls.Add(this.spnGenesMutar);
            this.groupBox1.Controls.Add(this.groupImagenMeta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.spnPorcentCruce);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.spnTotalPopulation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros iniciales";
            // 
            // spnGeneraciones
            // 
            this.spnGeneraciones.Location = new System.Drawing.Point(328, 13);
            this.spnGeneraciones.Name = "spnGeneraciones";
            this.spnGeneraciones.Size = new System.Drawing.Size(64, 20);
            this.spnGeneraciones.TabIndex = 12;
            this.spnGeneraciones.Tag = "";
            this.spnGeneraciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spnMenosAptos
            // 
            this.spnMenosAptos.Location = new System.Drawing.Point(144, 93);
            this.spnMenosAptos.Name = "spnMenosAptos";
            this.spnMenosAptos.Size = new System.Drawing.Size(120, 20);
            this.spnMenosAptos.TabIndex = 11;
            this.spnMenosAptos.Tag = "";
            this.spnMenosAptos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spnGenesMutar
            // 
            this.spnGenesMutar.Location = new System.Drawing.Point(159, 69);
            this.spnGenesMutar.Name = "spnGenesMutar";
            this.spnGenesMutar.Size = new System.Drawing.Size(120, 20);
            this.spnGenesMutar.TabIndex = 10;
            this.spnGenesMutar.Tag = "";
            this.spnGenesMutar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCurrentGen);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblDistanciaManhattan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pbBest);
            this.groupBox2.Location = new System.Drawing.Point(418, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 236);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // lblCurrentGen
            // 
            this.lblCurrentGen.AutoSize = true;
            this.lblCurrentGen.Location = new System.Drawing.Point(118, 216);
            this.lblCurrentGen.Name = "lblCurrentGen";
            this.lblCurrentGen.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentGen.TabIndex = 14;
            this.lblCurrentGen.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Generación";
            // 
            // lblDistanciaManhattan
            // 
            this.lblDistanciaManhattan.AutoSize = true;
            this.lblDistanciaManhattan.Location = new System.Drawing.Point(118, 90);
            this.lblDistanciaManhattan.Name = "lblDistanciaManhattan";
            this.lblDistanciaManhattan.Size = new System.Drawing.Size(13, 13);
            this.lblDistanciaManhattan.TabIndex = 12;
            this.lblDistanciaManhattan.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Distancia Manhattan";
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(529, 255);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(75, 23);
            this.btnPaint.TabIndex = 2;
            this.btnPaint.Text = "Paint!";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 284);
            this.Controls.Add(this.btnPaint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPorcentCruce)).EndInit();
            this.groupImagenMeta.ResumeLayout(false);
            this.groupImagenMeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnGeneraciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMenosAptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGenesMutar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown spnTotalPopulation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown spnPorcentCruce;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupImagenMeta;
        private System.Windows.Forms.TextBox lblDireccionImagen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbMeta;
        private System.Windows.Forms.PictureBox pbBest;
        private System.Windows.Forms.NumericUpDown spnGeneraciones;
        private System.Windows.Forms.NumericUpDown spnMenosAptos;
        private System.Windows.Forms.NumericUpDown spnGenesMutar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDistanciaManhattan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCurrentGen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPaint;
    }
}

