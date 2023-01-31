using HW_11;
                       
OtusDictionary dict = new OtusDictionary();
for(int i = 0; i < 35; i++) {
    dict.Add(i, String.Format("Element. Index: {0}", i));
}
		
int n = 90; 
for(int i = 0; i < 5; i++) {
    dict.Add(n, String.Format("Element. Index: {0}", n));
    n += 23;
}

for (int i = 0; i < dict.Size; i++)
{
    string str = "";
    Console.Write("Index {0}: ", i);
    if (dict.TryGet(i, out str))
    {
        Console.WriteLine("[{0}]", str);
    }
    else
    {
        Console.WriteLine(" - no");
    }
}