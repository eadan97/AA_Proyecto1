using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA_Proyecto1_v1
{
    public class GenAlg
    {
        public List<Chromosome> population;
        private Chromosome fitest;
        private int totalPopulation;
        public GenAlg(int totalPopulation, Bitmap image)
        {
            this.totalPopulation = totalPopulation;
            this.population = new List<Chromosome>();
            this.fitest = new Chromosome(image);
            fitest.calculateColorHistogram();
        }

        public void paint()
        {
            initializePopulation();
            Debug.WriteLine("Finnished the initialization process!!");
            findFitness();
            /*
             *  find fitness of population
               
               while (termination criteria is reached) do
               parent selection
               crossover with probability pc
               mutation with probability pm
               decode and fitness calculation
               survivor selection
               find best
               return best
             */
        }

        public void crossover()
        {

        }

        public void initializePopulation()
        {
            int height = fitest.bm.Size.Height;
            int width = fitest.bm.Size.Width;
            for (int i = 0; i < totalPopulation; i++)
            {
                Bitmap temp = new Bitmap(width,height);
                Random random = new Random();
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        int r = random.Next(256);
                        int g = random.Next(256);
                        int b = random.Next(256);
                        temp.SetPixel(k,j, Color.FromArgb(r,g,b));
                    }
                }
                population.Add(new Chromosome(temp));
            }
        }

        public void findFitness()

        {
            foreach (var chromosome in population)
            {
                chromosome.calculateColorHistogram();
                chromosome.calculateManhattanDistance(fitest.colorHistogram);
            }
            population=population.OrderBy(o => o.manhattanDistance).ToList();


        }
    }
}
