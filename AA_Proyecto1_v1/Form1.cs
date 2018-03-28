using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA_Proyecto1_v1
{
    public partial class Form1 : Form
    {
        private Bitmap bm;
        private int generaciones;
        private int porcentajeCruce;
        private int totalPopulation;
        private int porcentajeGenesMutar;
        private List<String> ds;
        private int[] genImageSaved;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = @"Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog1.FileName = "";
            ds=new List<string>();
            lstData.DataSource = ds;
            
            
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lblDireccionImagen.Text = openFileDialog1.FileName;
            pbMeta.ImageLocation = openFileDialog1.FileName;

            // Get your image in a bitmap; this is how to get it from a picturebox
            bm = (Bitmap)Image.FromFile(pbMeta.ImageLocation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                btnPaint.Enabled = false;
                totalPopulation = (int)spnTotalPopulation.Value;
                porcentajeCruce = (int)spnPorcentCruce.Value;
                porcentajeGenesMutar = (int)spnGenesMutar.Value;
                generaciones = (int)spnGeneraciones.Value;
                genImageSaved = new int[11] {
                    1,
                    (int) (generaciones * 0.10),
                    (int) (generaciones * 0.20),
                    (int) (generaciones * 0.30),
                    (int) (generaciones * 0.40),
                    (int) (generaciones * 0.50),
                    (int) (generaciones * 0.60),
                    (int) (generaciones * 0.70),
                    (int) (generaciones * 0.80),
                    (int) (generaciones * 0.90),
                    generaciones};


                ds.Clear();
                bgwPaint.RunWorkerAsync();
            }
            
        }


        private void bgwPaint_DoWork(object sender, DoWorkEventArgs e)
        {
            float numeroCrucesPorGen = (float)((totalPopulation * porcentajeCruce) / 100.0);

            GenAlg alg = new GenAlg((int)spnTotalPopulation.Value, bm, rdBtnHistoColor.Checked, rdBtnDistManhattan.Checked);
            alg.initializePopulation();
            //rdBtnHistoColor.Checked, rdBtnDistManhattan.Checked
            alg.findFitness();

            bgwPaint.ReportProgress(0, new ReportData(new Bitmap(alg.population[0].bm), alg.population[0].distance, 0));
          
            for (int i = 0; i < generaciones; i++)
            {
                alg.crossover((int) numeroCrucesPorGen, porcentajeGenesMutar);
                //alg.findFitness();

                bgwPaint.ReportProgress(0, new ReportData(new Bitmap(alg.population[0].bm),
                    alg.population[0].distance,
                    i+1));
            }
        }

        private void bgwPaint_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int gen=((ReportData)e.UserState).generation;
            float dm =((ReportData)e.UserState).distance;
            Bitmap copiedBitmap = ((ReportData) e.UserState).bm;

            this.Text = gen.ToString() + " - " + dm;
            pbBest.Image = copiedBitmap;
            ds.Add(gen.ToString() + " - " + dm);
            lstData.DataSource = null;
            lstData.DataSource = ds;
            lblCurrentGen.Text = gen.ToString();
            lblDistanciaManhattan.Text = dm.ToString();

            if (genImageSaved.Contains(gen))
            {
                copiedBitmap.Save(gen.ToString()+"_img.bmp");
            }
            //Guardar log en txt
            if (gen == generaciones)
            {
                this.Text = "Done!";
                TextWriter tw = new StreamWriter("SavedList.txt");
                foreach (String s in ds)
                    tw.WriteLine(s);
                tw.Close();
            }
        }

        private void bgwPaint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnPaint.Enabled = true;
        }
    }
}

class ReportData
{
    public Bitmap bm;
    public float distance;
    public int generation;

    public ReportData(Bitmap bm, float distance, int generation)
    {
        this.bm = bm;
        this.distance = distance;
        this.generation = generation;
    }
}