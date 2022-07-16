using System.Collections.Generic;

namespace Domino
{ 
    public class Ficha<T>
    {
        public T LeftImg {get; set; }
        public T RightImg {get; set; }
        public int Suma {get; }

        public Ficha(T left, T right, Values<T> Translator)
        {
            LeftImg = left;
            RightImg = right;
            Suma = Translator.Converter[left] + Translator.Converter[right];
        }
        public bool Contains(T item)
        {
            if (LeftImg.Equals(item) || RightImg.Equals(item))
            {
                return true;
            }
            return false;       
        }
        public void Turn()
        {
            T tmp = LeftImg;
            LeftImg = RightImg;
            RightImg = tmp;       
        }

        public bool Equals(Ficha<T> item)
        {
            if ((LeftImg.Equals(item.LeftImg) && RightImg.Equals(item.RightImg)) || (LeftImg.Equals(item.RightImg) && RightImg.Equals(item.LeftImg)))
            {
                return true;
            }
            return false;       
        }

        public T Concat(T item)
        {
            if (LeftImg.Equals(item))
            {
                return RightImg;
            }
            return LeftImg;
        }
    }
}