// Declare a two dimensional array.

int[,] multiDimensionalArray1 = new int[2, 3];

// Row 0 has 3 elements → arr[0,0], arr[0,1], arr[0,2]
// Row 1 has 3 elements → arr[1,0], arr[1,1], arr[1,2]

//Console.WriteLine(multiDimensionalArray1.Length);
//Console.WriteLine(multiDimensionalArray1.GetLength(0));
//Console.WriteLine(multiDimensionalArray1.GetLength(1));

for(int i=0; i < multiDimensionalArray1.GetLength(0); i++)
{
    for(int j=0; j < multiDimensionalArray1.GetLength(1); j++)
    {
        //Console.WriteLine(multiDimensionalArray1[i,j]+"");
    }
    //Console.WriteLine();

}
    
// Declare and set array element values.
int[,] multiDimensionalArray2 = { { 11, 12, 13 }, { 44, 55, 66 } };

for(int i=0; i < multiDimensionalArray2.GetLength(0); i++)
{
    for(int j=0; j < multiDimensionalArray2.GetLength(1); j++)
    {
        //Console.WriteLine(multiDimensionalArray2[i,j]+"");
    }
    //Console.WriteLine();
}

/*
What is a jagged array?
A jagged array is an array of arrays.
Each element is itself an array.
Each inner array can have different lengths.
*/

int[][] jaggedArray = new int[3][];

jaggedArray[0] = new int[] { 1, 2, 3 };
jaggedArray[1] = new int[] { 4, 5 };
jaggedArray[2] = new int[] { 6, 7, 8, 9 };

for (int i = 0; i < jaggedArray.Length; i++)
{
    Console.WriteLine(string.Join(",", jaggedArray[i]));
}
