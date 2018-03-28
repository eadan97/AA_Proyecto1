using System;
using System.Drawing;

namespace AA_Proyecto1_v1.Classes
{
    public class Chromosome
    {
        public Bitmap bm;
        public float[] histogram;
        public float distance;

        public Chromosome(Bitmap bm)
        {
            this.bm = bm;
        }

        public Chromosome(Chromosome father, Chromosome mother, int porcentajeGenesMutar)
        {
            //foreach color, take pixel from father and from mother, add them, and then divide by 2

            Bitmap temp = new Bitmap(father.bm.Width, father.bm.Height);
            Random rand = new Random();
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    if (rand.Next(100) <= porcentajeGenesMutar)
                    {
                        temp.SetPixel(i, j, GenAlg.GenerateRandomColor());
                    }
                    else
                    {
                        Color fatherColor = father.bm.GetPixel(i, j), motherColor = mother.bm.GetPixel(i, j);
                        int r = (fatherColor.R + motherColor.R) / 2;
                        int g = (fatherColor.G + motherColor.G) / 2;
                        int b = (fatherColor.B + motherColor.B) / 2;
                        temp.SetPixel(i, j, Color.FromArgb(r, g, b));
                        /*int r = (int) Math.Sqrt(fatherColor.R * motherColor.R) ;
                        int g = (int) Math.Sqrt(fatherColor.G * motherColor.G) ;
                        int b = (int) Math.Sqrt(fatherColor.B * motherColor.B) ;*/
                        /*if (rand.Next(2)==0)
                            temp.SetPixel(i, j, fatherColor);
                        else
                            temp.SetPixel(i, j, motherColor);*/
                    }
                }
            }

            bm = temp;
        }

        public void SaveHistogram(bool histoC)
        {
            histogram = histoC ? GenerateColorHistogram() : GenerateOtherHistogram();
        }

        //public int[,,] GenerateColorHistogram()
        public float[] GenerateColorHistogram()

        {
            float[] res = new float[4096];

            //float[] res = new float[48];
            int width = bm.Width, height = bm.Height, totalPixels = width * height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Get pixel color 
                    Color c = bm.GetPixel(x, y);
                    //res[c.R, c.G, c.B] += 1;
                    res[(c.R / 16) << 8 | (c.G / 16) << 4 | (c.B / 16)] += 1;
                    //res[(c.R) / 16 ] += 1;
                    // res[(c.G)/16+16] += 1;
                    //res[(c.B)/16+32] += 1;                    
                }
            }
            /*/Normalizar*/
            for (int i = 0; i < res.Length; i++)
            {
                res[i] /= totalPixels;
                
            }

            /*Normalizar
            for (int i = 0; i < 48; i++)
            {
                res[i] /= totalPixels;
            }*/

            return res;
        }

        public void CalculateManhattanDistance(float[] fit, bool histoC)
            //public void CalculateManhattanDistance(float[] fit)

        {
            var _colorHistogram = histoC ? GenerateColorHistogram() : GenerateOtherHistogram();
            distance = 0;
            for (int i = 0; i < _colorHistogram.Length; i++)
            {
                distance += Math.Abs(fit[i] - _colorHistogram[i]);
            }
        }

        public void CalculateOtherDistance(float[] fit, bool histoC)
        {
            var _colorHistogram = histoC ? GenerateColorHistogram() : GenerateOtherHistogram();

            distance = 0;
            double _d = 0;
            for (int i = 0; i < _colorHistogram.Length; i++)
            {
                _d += Math.Pow(fit[i] - _colorHistogram[i], 2);
            }

            distance = (float) Math.Sqrt(_d);
        }

        public float[] GenerateOtherHistogram()
        {
            //int width = bm.Width, height = bm.Height, totalPixels = width * height, totalR, totalG, totalB;
            float[] res = new float[30], reds=new float[10],greens=new float[10],blues=new float[10];

            for (int x = 1; x < bm.Width-1; x++)
            {
                for (int y = 1; y < bm.Height-1; y++)
                {
                    Color c = bm.GetPixel(x, y);
                    int br = c.R, bg = c.G, bb = c.B;
                    Color[] n = new Color[]
                    {
                        bm.GetPixel(x - 1, y - 1),
                        bm.GetPixel(x, y - 1),
                        bm.GetPixel(x + 1, y - 1),
                        bm.GetPixel(x + 1, y),
                        bm.GetPixel(x + 1, y + 1),
                        bm.GetPixel(x, y + 1),
                        bm.GetPixel(x - 1, y + 1),
                        bm.GetPixel(x - 1, y),
                    };
                    int[] rs=new int[8],gs=new int[8], bs=new int[8];
                    for (int i = 0; i < 8; i++)
                    {
                        rs[i] = n[i].R;
                        gs[i] = n[i].G;
                        bs[i] = n[i].B;
                    }

                    res[lbpPixel(rs, br)]++;
                    res[lbpPixel(rs, br)+10]++;
                    res[lbpPixel(rs, br)+20]++;


                }
            }

            int pixels = (bm.Width - 2) * (bm.Height - 2);
            for (int i = 0; i < res.Length; i++)
            {
                res[i] /= pixels;

            }
            return res;
        }

        public int lbpPixel(int[] neights, int center)
        {
            int p = 8;

            int[] s=new int[8];
            for (int i = 0; i < p; i++)
            {
                s[i] = neights[i] - center >= 0 ? 1 : 0;
            }
            // Invarianza de escala
            int u = 0;
            for (int i = 0; i < p; i++)
            {
                u += s[i] == s[(i + 1) % p] ? 0 : 1;
            }
            // invarianza de rotacion
            if (u <= 2)
            {
                int sum = 0;
                for (int i = 0; i < p; i++)
                {
                    sum += s[i];
                }
                return sum;
            }
            else
            {
                return p + 1;
            }
        }
    }
}