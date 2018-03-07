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
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog1.FileName = "";
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
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
            int porcentCruce = (int)spnPorcentCruce.Value;
            lblDireccionImagen.Text = openFileDialog1.FileName;
            pbMeta.ImageLocation = openFileDialog1.FileName;

            // Get your image in a bitmap; this is how to get it from a picturebox
            Bitmap bm = (Bitmap)Image.FromFile(pbMeta.ImageLocation);

            GenAlg alg = new GenAlg((int)spnTotalPopulation.Value, bm);
            alg.initializePopulation();
            alg.findFitness();
            pbBest.Image = alg.population[0].bm;
            for (int i = 0; i < (int)spnGeneraciones.Value; i++)
            {
                alg.crossover(porcentCruce);
                //TODO:Mutation
                alg.findFitness();
                pbBest.Image = alg.population[0].bm;
                lblDistanciaManhattan.Text = alg.population[0].manhattanDistance.ToString();
                lblCurrentGen.Text = (i + 1).ToString();
            }
        }
    }
}
