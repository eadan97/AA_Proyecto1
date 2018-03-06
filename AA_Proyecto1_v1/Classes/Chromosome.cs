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