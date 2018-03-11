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
        public Chromosome[] population;
        private Chromosome fitest;
        private int totalPopulation;
        static Random random = new Random();
        public GenAlg(int totalPopulation, Bitmap image)
        {
            this.totalPopulation = totalPopulation;
            this.population = new Chromosome[totalPopulation];
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

        public void crossover(int numeroCruces, int porcentajeGenesMutar)
        {
            
            for (int i = 0; i < numeroCruces; i++)
            {
                Chromosome tempChromosome = new Chromosome(population[2*i], population[2*i+1], porcentajeGenesMutar);
                population[totalPopulation- (i+1)] = tempChromosome;
            }
            
        }

        public void initializePopulation()
        {
            int height = fitest.bm.Size.Height;
            int width = fitest.bm.Size.Width;
            for (int i = 0; i < totalPopulation; i++)
            {
                Bitmap temp = new Bitmap(width,height);
                
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        
                        temp.SetPixel(k,j, GenerateRandomColor());
                    }
                }
                population[i]=(new Chromosome(temp));
            }
        }

        public void findFitness()

        {
            foreach (var chromosome in population)
            {
                chromosome.calculateColorHistogram();
                chromosome.calculateManhattanDistance(fitest.colorHistogram);
            }
            population= population.OrderBy(o => o.manhattanDistance).ToArray();


        }

        public static Color GenerateRandomColor()
        {
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);
            return Color.FromArgb(r, g, b);
        }
    }

}
