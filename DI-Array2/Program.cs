// Arrays can be initialized after the declaration. It is not necessary to declare and initialize at the same time using the new keyword.
// Declaration of the array 
string[] str1, str2; 

// Initialization of array 
str1 = new string[5]{ "Element1", "Element2", "Element3", "Element4", "Element5" }; 

//Console.Write(str1.Length);

for (int i = 0; i < str1.Length; i++)
{
    Console.WriteLine(str1[i]);
}

str2 = new string[5]{ "Element11", "Element12", "Element13", "Element14", "Element15" };
foreach (string item in str2)
{
    Console.WriteLine(item);
}
