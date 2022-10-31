using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Tensor
    {
        public int Length { get { return tensorOneDimension.Length; } }
        private int[] Dimensions { get; set; }
        
        private int[] DimensionsMain
        {
            get
            {
                int[] arr = new int[Dimensions.Length];
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (i == arr.Length - 1) arr[i] = 1;
                    else if (i == arr.Length - 2) arr[i] = Dimensions[Dimensions.Length - 1];
                    else arr[i] = arr[i + 1] * Dimensions[i+1];
                }
                return arr;
            }
        }
        private int[] tensorOneDimension;

        
        public int LenghtTensorOneDimension()
        {
            int lenght1 = 1;
            foreach (var item in Dimensions)
            {
                lenght1 *= item;
            }
            return lenght1;
        }

        
        public Tensor(params int[] dimensions)
        {
            Dimensions = new int[dimensions.Length];
            dimensions.CopyTo(Dimensions, 0);
            tensorOneDimension = new int[LenghtTensorOneDimension()];
        }

        public int this[params int[] indices]
        {
            get
            {
                int index = 0;
                if (indices.Length != DimensionsMain.Length) return 0;
                else
                {
                    for (int i = 0; i < indices.Length; i++)
                    {
                        index += indices[i] * DimensionsMain[i];
                    }
                    return tensorOneDimension[index];
                }
            }

            set
            {
                int index = 0;
                for (int i = 0; i < indices.Length; i++)
                {
                    index += indices[i] * DimensionsMain[i];
                }
                tensorOneDimension[index] = value;
            }
        }

    }
}
