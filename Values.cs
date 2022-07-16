using System.Collections.Generic;

namespace Domino
{
    public class Values<T>
    {
        public Dictionary<T, int> Converter {get; }
        public T[] Key {get; }

        public Values(Dictionary<T, int> Val, T[] key)
        {
            Converter = Val;
            Key = key;
        }
        public void Charge()
        {
            for (int i = 0; i < Key.Length; i++)
            {
                Converter.Add(Key[i], i);
            }
        }
    }
}