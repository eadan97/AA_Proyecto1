using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog1.FileName = "";
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
            totalPopulation = (int) spnTotalPopulation.Value;
            porcentajeCruce = (int) spnPorcentCruce.Value;
            porcentajeGenesMutar = (int) spnGenesMutar.Value;
            generaciones = (int) spnGeneraciones.Value;

            float numeroCrucesPorGen = (float) ((totalPopulation * porcentajeCruce) / 100.0);

            GenAlg alg = new GenAlg((int)spnTotalPopulation.Value, bm);
            alg.initializePopulation();
            alg.findFitness();

            pbBest.Image = alg.population[0].bm;
            pbBest.Update();

            for (int i = 0; i < generaciones; i++)
            {
                alg.crossover((int)numeroCrucesPorGen, porcentajeGenesMutar);
                alg.findFitness();
                pbBest.Image = alg.population[0].bm;
                lblDistanciaManhattan.Text = alg.population[0].manhattanDistance.ToString();
                lblCurrentGen.Text = (i + 1).ToString();
                pbBest.Update();
                lblDistanciaManhattan.Invalidate();
                lblCurrentGen.Update();

            }

        }

        void paint()
        {
            
        }
    }
}
