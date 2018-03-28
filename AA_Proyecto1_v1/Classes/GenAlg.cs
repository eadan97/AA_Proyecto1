using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AA_Proyecto1_v1.Classes;

namespace AA_Proyecto1_v1
{
    public class GenAlg
    {
        public Chromosome[] population;
        private Chromosome fitest;
        private int totalPopulation;
        static Random random = new Random();
        bool histoC, distM;

        public GenAlg(int totalPopulation, Bitmap image, bool histoC, bool distM)
        {
            this.totalPopulation = totalPopulation;
            this.population = new Chromosome[totalPopulation];
            this.fitest = new Chromosome(image);
            this.histoC = histoC;
            this.distM = distM;
        }


        public void crossover(int numeroCruces, int porcentajeGenesMutar)
        {
            for (int i = 0; i < numeroCruces; i++)
            {
                int p1 = getParent(), p2 = getParent();
                Bitmap[] bitmaps = GenOffs(population[p1].bm, population[p2].bm, porcentajeGenesMutar);
                int offsLength = bitmaps.Length;
                Chromosome[] offs = new Chromosome[offsLength];
                for (int j = 0; j < offsLength; j++)
                {
                    offs[j]= new Chromosome(bitmaps[j]);
                    //population[totalPopulation-1-j - i * offsLength] =new Chromosome(bitmaps[j]);
                    if (distM)
                    {
                        //population[totalPopulation - 1 - j - i * offsLength].CalculateManhattanDistance(fitest.histogram, histoC);
                        offs[j].CalculateManhattanDistance(fitest.histogram, histoC);
                    }
                    else
                    {
                        //population[totalPopulation - 1 - j - i * offsLength].CalculateOtherDistance(fitest.histogram, histoC);
                        offs[j].CalculateOtherDistance(fitest.histogram, histoC);
                    }
                }

                population[totalPopulation - i - 1] = offs.OrderBy(o => o.distance).First();
                /*Chromosome tempC1 =
                    //new Chromosome(population[p1], population[p2], porcentajeGenesMutar);
                    new Chromosome(offs[0]);

                Chromosome tempC2 = new Chromosome(offs[1]);
                if (distM)
                {
                    tempC1.CalculateManhattanDistance(fitest.histogram, histoC);
                    tempC2.CalculateManhattanDistance(fitest.histogram, histoC);
                }
                else
                {
                    tempC1.CalculateOtherDistance(fitest.histogram, histoC);
                    tempC2.CalculateOtherDistance(fitest.histogram, histoC);
                }
                population[totalPopulation - 1] = tempC1;
                population[totalPopulation - 2] = tempC2;*/
            }

            population = population.OrderBy(o => o.distance).ToArray();
        }

        private int getParent()
        {
           
             int[] ins = new int[(int) (3)];
            for (int i = 0; i < ins.Length; i++)
            {
                int p = random.Next(totalPopulation);
                ins[i] = p;
            }

            return ins.Min();

        }

        private Bitmap[] GenOffs(Bitmap b1, Bitmap b2, int porcentajeGenesMutar)
        {
            Bitmap[] temp = new Bitmap[]
            {
                new Bitmap(b1.Width, b1.Height),
                //new Bitmap(b1.Width, b1.Height),
                //new Bitmap(b1.Width, b1.Height),
                new Bitmap(b1.Width, b1.Height)
            };
            Random rand = new Random();
            int width = temp[0].Width,
                height = temp[0].Height,
                randMutar = rand.Next(100);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color fatherColor = b1.GetPixel(i, j), motherColor = b2.GetPixel(i, j);
                    if (randMutar <= porcentajeGenesMutar)
                    {
                        /*temp[0].SetPixel(i, j, Color.FromArgb(
                            Math.Min(255, Math.Max(0, fatherColor.R + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, fatherColor.G + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, fatherColor.B + random.Next(-5, 6)*16))));
                        temp[1].SetPixel(i, j, Color.FromArgb(                  
                            Math.Min(255, Math.Max(0, motherColor.R + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, motherColor.G + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, motherColor.B + random.Next(-5, 6)*16))));
                        temp[2].SetPixel(i, j, Color.FromArgb(                      
                            Math.Min(255, Math.Max(0, fatherColor.R + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, fatherColor.G + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, fatherColor.B + random.Next(-5, 6)*16))));
                        temp[3].SetPixel(i, j, Color.FromArgb(                      
                            Math.Min(255, Math.Max(0, motherColor.R + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, motherColor.G + random.Next(-5, 6)*16)),
                            Math.Min(255, Math.Max(0, motherColor.B + random.Next(-5, 6)*16))));*/
                        temp[0].SetPixel(i,j,GenerateRandomColor());
                        temp[1].SetPixel(i, j, GenerateRandomColor());
                        //temp[2].SetPixel(i, j, GenerateRandomColor());
                        //temp[3].SetPixel(i, j, GenerateRandomColor());
                    }
                    else
                    {
                        if (rand.Next(2) == 0)
                        {
                            temp[0].SetPixel(i, j, fatherColor);
                            temp[1].SetPixel(i, j, motherColor);
                            //temp[2].SetPixel(i, j, fatherColor);
                            //temp[3].SetPixel(i, j, motherColor);
                        }
                        else
                        {
                            temp[1].SetPixel(i, j, fatherColor);
                            temp[0].SetPixel(i, j, motherColor);
                            //temp[3].SetPixel(i, j, fatherColor);
                            //temp[2].SetPixel(i, j, motherColor);
                        }
                        /*int r = (int)(0.7*fatherColor.R + 0.3*motherColor.R) ;
                        int g = (int)(0.7*fatherColor.G + 0.3*motherColor.G) ;
                        int b = (int)(0.7*fatherColor.B + 0.3*motherColor.B) ;
                        temp[0].SetPixel(i, j, Color.FromArgb(r,g,b));

                        r = (int)(0.3 * fatherColor.R + 0.7 * motherColor.R);
                        g = (int)(0.3 * fatherColor.G + 0.7 * motherColor.G);
                        b = (int)(0.3 * fatherColor.B + 0.7 * motherColor.B);
                        temp[1].SetPixel(i, j, Color.FromArgb(r,g,b));*/


                        /*int r = (int) Math.Sqrt(fatherColor.R * motherColor.R) ;
                        int g = (int) Math.Sqrt(fatherColor.G * motherColor.G) ;
                        int b = (int) Math.Sqrt(fatherColor.B * motherColor.B) ;*/
                    }
                }
            }

            return temp;
        }

        public void initializePopulation()
        {
            int height = fitest.bm.Size.Height;
            int width = fitest.bm.Size.Width;
            for (int i = 0; i < totalPopulation; i++)
            {
                Bitmap temp = new Bitmap(width, height);

                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        temp.SetPixel(k, j, GenerateRandomColor());
                    }
                }

                population[i] = (new Chromosome(temp));
            }
        }

        public void findFitness()

        {
            fitest.SaveHistogram(histoC);
            if (distM)
            {
                foreach (var chromosome in population)

                    //Task.Factory.StartNew(()=>startThreadsForFitness(chromosome));
                    //chromosome.saveColorHistogram();
                    chromosome.CalculateManhattanDistance(fitest.histogram,histoC);
            }
            else
            {
                foreach (var chromosome in population)

                    //Task.Factory.StartNew(()=>startThreadsForFitness(chromosome));
                    //chromosome.saveColorHistogram();
                    chromosome.CalculateOtherDistance(fitest.histogram,histoC);
            }

            population = population.OrderBy(o => o.distance).ToArray();
        }

        /*async Task<> (Chromosome a)
        {
            a.saveColorHistogram();
            a.calculateManhattanDistance(fitest.histogram);
        }*/

        public static Color GenerateRandomColor()
        {
            int r = 16 * random.Next(1, 16) - 1;
            int g = 16 * random.Next(1, 16) - 1;
            int b = 16 * random.Next(1, 16) - 1;
            /*int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);*/
            return Color.FromArgb(r, g, b);
        }
    }
}