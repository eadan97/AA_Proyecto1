using System;
using System.Collections.Generic;
using System.Drawing;

namespace AA_Proyecto1_v1
{
    public class Chromosome
    {
        public Bitmap bm;
        //public Dictionary<Color, int> colorHistogram;
        public int[,,] colorHistogram;
        public float manhattanDistance;

        public Chromosome(Bitmap bm)
        {
            this.bm = bm;
        }

        public Chromosome(Chromosome father, Chromosome mother, int porcentajeGenesMutar)
        {
            //foreach color, take pixel from father and from mother, add them, and then divide by 2
            Bitmap temp = new Bitmap(father.bm.Width, father.bm.Height);
            Random rand=new Random();
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    if (rand.Next() <= porcentajeGenesMutar)
                    {
                        temp.SetPixel(i,j, GenAlg.GenerateRandomColor());
                    }
                    else
                    {
                        int r = (father.bm.GetPixel(i, j).R + mother.bm.GetPixel(i, j).R) / 2;
                        int g = (father.bm.GetPixel(i, j).G + mother.bm.GetPixel(i, j).G) / 2;
                        int b = (father.bm.GetPixel(i, j).B + mother.bm.GetPixel(i, j).B) / 2;

                        temp.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
            }

            bm = temp;
        }

        public void calculateColorHistogram()
        {
            //colorHistogram = new Dictionary<Color, int>();
            colorHistogram=new int[256,256,256];
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    // Get pixel color 
                    Color c = bm.GetPixel(x, y);
                    colorHistogram[c.R, c.G, c.B] += 1;

                }
            }
        }


        //public void calculateManhattanDistance(Dictionary<Color, int> fit)
        public void calculateManhattanDistance(int[,,] fit)
        {
            manhattanDistance = 0;
            //TODO: Esto se podria hacer recorriendo solo los colores que tienen valores y no todos los que existen
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        /*int x = fit.ContainsKey(Color.FromArgb(i, j, k)) ? fit[Color.FromArgb(i, j, k)] : 0;
                        int y = colorHistogram.ContainsKey(Color.FromArgb(i, j, k)) ? colorHistogram[Color.FromArgb(i, j, k)] : 0;
                        */

                        manhattanDistance += Math.Abs(fit[i,j,k]-colorHistogram[i,j,k]);
                    }
                }
            }

        }
    }
}