
//"." means the current directory, i.e., the folder where your program is running.
DirectoryInfo currDir = new DirectoryInfo(".");
// Will print the Folder name 
Console.WriteLine(currDir.Name);
// Will print the Path of the Folder 
Console.WriteLine(currDir.FullName);
Console.WriteLine(currDir.CreationTime);
//Checks if the folder actually exists (returns true or false).
Console.WriteLine(currDir.Exists);


