using System;
using System.Collections.Generic;
using System.Drawing;

namespace AA_Proyecto1_v1
{
    public class Chromosome
    {
        public Bitmap bm;
        public Dictionary<Color, int> colorHistogram;
        public float manhattanDistance;

        public Chromosome(Bitmap bm)
        {
            this.bm = bm;
        }

        public Chromosome(Chromosome father, Chromosome mother)
        {
            //foreach color, take pixel from father and from mother, add them, and then divide by 2
            Bitmap temp = new Bitmap(father.bm.Width, father.bm.Height);
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    int r = (father.bm.GetPixel(i, j).R + father.bm.GetPixel(i, j).R) / 2;
                    int g = (father.bm.GetPixel(i, j).G + father.bm.GetPixel(i, j).G) / 2;
                    int b = (father.bm.GetPixel(i, j).B + father.bm.GetPixel(i, j).B) / 2;
                    temp.SetPixel(i,j,Color.FromArgb(r,g,b));

                }
            }
        }

        public void calculateColorHistogram()
        {
            colorHistogram = new Dictionary<Color, int>();
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    // Get pixel color 
                    Color c = bm.GetPixel(x, y);

                    // If it exists in our 'histogram' increment the corresponding value, or add new
                    if (colorHistogram.ContainsKey(c))
                        colorHistogram[c] = colorHistogram[c] + 1;
                    else
                        colorHistogram.Add(c, 1);
                }
            }
        }


        public void calculateManhattanDistance(Dictionary<Color, int> fit)
        {
            manhattanDistance = 0;
            //TODO: Esto se podria hacer recorriendo solo los colores que tienen valores y no todos los que existen
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        int x = fit.ContainsKey(Color.FromArgb(i, j, k)) ? fit[Color.FromArgb(i, j, k)] : 0;
                        int y = colorHistogram.ContainsKey(Color.FromArgb(i, j, k)) ? colorHistogram[Color.FromArgb(i, j, k)] : 0;

                        manhattanDistance += Math.Abs(x-y);
                    }
                }
            }

        }
    }
}