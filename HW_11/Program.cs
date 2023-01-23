using HW_11;
                       
var otusDictionary = new OtusDictionary(32);

//я, наверное, плохо понял момент с индексатором, потому что это какой-то очень простой способ решения
Console.WriteLine("Введите ключ элемента словаря: ");
int.TryParse(Console.ReadLine(), out int n);
Console.WriteLine(otusDictionary[n-1]);