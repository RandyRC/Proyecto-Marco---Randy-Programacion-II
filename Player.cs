using System;
using System.Collections.Generic;

namespace Domino
{
    public class Player<T> : IPlayer<T>
    {
        public List<Ficha<T>> Hand { get; }
        public List<Ficha<T>> Possible { get; }
        public int[] Count { get; }

        public Player(List<Ficha<T>> hand, List<Ficha<T>> possible, int Length)
        {
            Hand = hand;
            Possible = possible;
            Count = new int[Length + 1];
        }

        public void Search(T left, T right)
        {
            Possible.Clear();

            foreach (var ficha in Hand)
            {
                if (ficha.Contains(left) || ficha.Contains(right))
                {
                    Possible.Add(ficha);
                }
            }
        }
        public virtual Ficha<T> Play(Values<T> Translator)
        {
            Ficha<T> tmp = Possible[0];
            Hand.Remove(tmp);
            return tmp;
        }
        public virtual (Ficha<T>, T) PlayWT(T left, T right, Values<T> Translator)
        {
            Ficha<T> tmp = Play(Translator);

            if (tmp.Contains(left))
            {
                return (tmp, left);
            }
            return (tmp, right);
        }
        public virtual void Load(Values<T> Translator) { }
        public virtual void Load(T left, T right, Values<T> Translator) { }
        public void Clean()
        {
            for (int i = 0; i < Count.Length; i++)
            {
                Count[i] = 0;
            }
        }

        public virtual List<Ficha<T>> ReSort()
        {
            int size = Hand.Count / 2;
            List<Ficha<T>> returned = new List<Ficha<T>>();

            for (int i = 0; i < Hand.Count;)
            {
                if (size == returned.Count) break;

                returned.Add(Hand[i]);
                Hand.Remove(Hand[i]);
            }

            return returned;
        }
    }

    public class ThrowFat<T> : Player<T>
    {
        public ThrowFat(List<Ficha<T>> hand, List<Ficha<T>> possible, int Length) : base(hand, possible, Length) { }

        public override Ficha<T> Play(Values<T> Translator)
        {
            Ficha<T> tmp = Possible[0];
            int max = 0;

            foreach (var ficha in Possible)
            {
                if (max < ficha.Suma)
                {
                    max = ficha.Suma;
                    tmp = ficha;
                }
            }

            Hand.Remove(tmp);
            return tmp;
        }

        public override List<Ficha<T>> ReSort()
        {
            List<Ficha<T>> returned = new List<Ficha<T>>();
            int size = Hand.Count / 2;

            for (int i = 0; i < size; i++)
            {
                int suma = 0;
                int index = 0;

                for (int j = 0; j < Hand.Count; j++)
                {
                    if (suma < Hand[j].Suma)
                    {
                        suma = Hand[j].Suma;
                        index = j;
                    }
                }

                returned.Add(Hand[index]);
                Hand.Remove(Hand[index]);
            }

            return returned;
        }
    }

    public class Reserved<T> : Player<T>
    {
        public Reserved(List<Ficha<T>> hand, List<Ficha<T>> possible, int Length) : base(hand, possible, Length) { }

        public override void Load(Values<T> Translator)
        {
            foreach (var ficha in Hand)
            {
                Count[Translator.Converter[ficha.LeftImg]] += 1;
                if (!ficha.LeftImg.Equals(ficha.RightImg))
                {
                    Count[Translator.Converter[ficha.RightImg]] += 1;
                }
            }
        }

        public override Ficha<T> Play(Values<T> Translator)
        {
            Ficha<T> tmp = Possible[0];
            int max = 0;

            foreach (var ficha in Possible)
            {
                if (max < (Count[Translator.Converter[ficha.LeftImg]] + Count[Translator.Converter[ficha.RightImg]]))
                {
                    max = Count[Translator.Converter[ficha.LeftImg]] + Count[Translator.Converter[ficha.RightImg]];
                    tmp = ficha;
                }
            }

            Hand.Remove(tmp);
            Count[Translator.Converter[tmp.LeftImg]] -= 1;

            if (!tmp.LeftImg.Equals(tmp.RightImg))
            {
                Count[Translator.Converter[tmp.RightImg]] -= 1;
            }

            return tmp;
        }

        public override List<Ficha<T>> ReSort()
        {
            List<Ficha<T>> returned = new List<Ficha<T>>();
            int size = Hand.Count / 2;
            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                int tmp = r.Next(0, Hand.Count);
                returned.Add(Hand[tmp]);
                Hand.Remove(Hand[tmp]);
            }

            return returned;
        }
    }

    public class PassMaker<T> : Player<T>
    {
        public PassMaker(List<Ficha<T>> hand, List<Ficha<T>> possible, int Length) : base(hand, possible, Length) { }

        public override void Load(T left, T right, Values<T> Translator)
        {
            Count[Translator.Converter[left]] += 1;
            if (Translator.Converter[left] != Translator.Converter[right])
            {
                Count[Translator.Converter[right]] += 1;
            }
        }

        public override (Ficha<T>, T) PlayWT(T left, T right, Values<T> Translator)
        {
            int max = 0;
            (Ficha<T>, T) tmp = (Possible[0].Contains(left)) ? (Possible[0], left) : (Possible[0], right);

            for (int i = 0; i < Count.Length; i++)
            {
                if (Count[i] > max)
                {
                    foreach (var ficha in Possible)
                    {
                        if (ficha.Equals(new Ficha<T>(Translator.Key[i], left, Translator)))
                        {
                            tmp = (ficha, left);
                            max = Count[i];
                        }
                        else if (ficha.Equals(new Ficha<T>(Translator.Key[i], right, Translator)))
                        {
                            tmp = (ficha, right);
                            max = Count[i];
                        }
                    }
                }
            }

            Hand.Remove(tmp.Item1);
            return tmp;
        }

        public override List<Ficha<T>> ReSort()
        {
            List<Ficha<T>> returned = new List<Ficha<T>>();
            int size = Hand.Count / 2;
            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                int tmp = r.Next(0, Hand.Count);
                returned.Add(Hand[tmp]);
                Hand.Remove(Hand[tmp]);
            }

            return returned;
        }
    }
}