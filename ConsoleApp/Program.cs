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

//а) про то, что надо максимально плотно надо расположить значения не было условия, поэтому допускаем, что код:
//dict.Add(65, "65");
//dict.Add(33, "33");
//dict.Add(1, "1");
//2 раза пересоздает массивы
//б) добавить 2 раза элементы с одинаковыми ключами (а кто мне запретит).
//если вы не будете запускать и скажете (глядя на код) что произойдет - будет круто!
//в) добавление элемента с отрицательным значением ключа (в задании не сказано, что такое не допускается)

Console.WriteLine("\nДополнительные тесты ОтусСловаря!");
dict = new OtusDictionaryWithoutBuckets(isDemoModeOn: false);
// а
dict.Add(65, "65");
dict.Add(33, "33");
dict.Add(1, "1");
// в
dict.Add(-777, "-777");
// б
dict.Add(666, "первый");
dict.Add(666, "второй");