using System;
using System.ComponentModel.DataAnnotations;

namespace Collections_and_Enumerators
{
    class MyList //Requirements in Commments
    {
        //Contain integers
        int[] backingStore = new int [1];

        //Track the number of intergers currently stored
        public int Length { get; private set; } = 0;

        //Grow the backing array when needed
        private void GrowBackingArrayIfNeeded()
        {
            //Determine whether the array needs to be grown
            if (Length == backingStore.Length)
            {

                //If so, make a new, larger array
                var tmp = new int[backingStore.Length * 2];

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
        public int this[int index]
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
        public void AddAtIndex(int index, int value)
        {
            //Only if the index is within the bounds of the current list,
            if(index < Length)
            {
                // Move all the elements in or after the index to the "right"
                Length += 1;
                GrowBackingArrayIfNeeded();

                for (int i = Length; i > index; i--)
                {

                }
                  //Put the new value in the array
                  backingStore[index] = value;

            }
            
        }
        //Remove value at index

        //Add value to end

        //Enumerable
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList();

            myList[0] = 3;
        }
    }
}
