using System;
using System.ComponentModel.DataAnnotations;

namespace Collections_and_Enumerators
{
    public class MyList<T> //Requirements in Commments
    {
        //Contains Ts
        T[] backingStore = new T[1];

        //Track the number of Ts currently stored
        public int Length { get; private set; } = 0;
        public int Capacity => backingStore.Length;

        //Grow the backing array when needed
        private void GrowBackingArrayIfNeededToAddOneElement()
        {
            //Determine whether the array needs to be grown
            if (Length == backingStore.Length)
            {

                //If so, make a new, larger array
                var tmp = new T[backingStore.Length * 2];

                //Copy the values from the old array into the new array
                for (int i = 0; i < backingStore.Length; i++)
                {
                    tmp[i] = backingStore[i];
                }

                //Replace the old array
                backingStore = tmp;
            }

        }


        //Indexer
        public T this[int index]
        {
            //Get and set value at index
            get => index < Length ? backingStore[index] : throw new IndexOutOfRangeException();
            set
            {
                if(index < Length)
                {
                    backingStore[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        //Add value at index
        public void AddAtIndex(int index, T value)
        {
            //Only if the index is within the bounds of the current list,
            if(index < Length)
            {
                // Move all the elements in or after the index to the "right"
                GrowBackingArrayIfNeededToAddOneElement();

                for (int i = Length; i > index; i--)
                {
                    backingStore[i] = backingStore[i - 1];
                }
                  //Put the new value in the array
                backingStore[index] = value;
                Length += 1;
            }
            
        }
        public void Shrink()
        {
            var tmp = new T[Length];

            Array.Copy(backingStore, tmp, Length);

            backingStore = tmp;

        }
        //Remove value at index
        public void RemoveAtIndex(int index)
        {
            while(index + 1 < Length)
            {
                backingStore[index++] = backingStore[index + 1];
                index += 1;
            }

            Length -= 1;
        }




        //Add value to end
        public void Add(T value)
        {
            GrowBackingArrayIfNeededToAddOneElement();
            backingStore[Length++] = value;
        }
        //Enumerable
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
