var rng = new Random();

Console.WriteLine("Демо режим работы ОтусСловаря!");
var demoDict = new OtusDictionaryWithoutBuckets(isDemoModeOn:true);
try
{
    Console.WriteLine("Добавим в словарь 33 элемента с ключами от 0 до 32:");
    for (int i = 0; i < 33; i++)
    {        
        demoDict.Add(i, $"элемент {i}");     
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("\nНормальный режим работы ОтусСловаря!");
var dict = new OtusDictionaryWithoutBuckets(isDemoModeOn:false);

dict.Add(0, "Get работает");
Console.WriteLine(dict.Get(0));

dict[777] = "Индексатор работает";
Console.WriteLine(dict[777]);

Console.WriteLine("Добавим в словарь 10 элементов со случайными ключами:");
for (int i = 0; i < 5; i++)
{
    int key = rng.Next();
    dict.Add(key, $"элемент {key}");

    key = rng.Next();
    dict[key] = $"элемент {key}";
}