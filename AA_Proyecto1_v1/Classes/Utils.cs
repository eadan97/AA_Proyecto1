using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_Proyecto1_v1.Classes
{
    class Utils
    {
        public Bitmap array2image(int[,] array)
        {
            int width = array.GetLength(0),
                height= array.GetLength(1);
            Bitmap res=new Bitmap(width,height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    res.SetPixel(i,j,Color.FromArgb(array[i,j]));
                }
            }

            return res;
        }
    }
}
