﻿/*
Реализуйте класс OtusDictionaryWithoutBuckets,
который позволяет оперировать int-овыми значениями в качестве ключей и строками в качестве значений.
Для добавления используйте метод void Add(int key, string value),
а для получения элементов - string Get(int key).
Внутреннее хранилище реализуйте через массив.
При нахождении коллизий, создавайте новый массив в два раза больше и
не забывайте пересчитать хеши для всех уже вставленных элементов.
Метод GetHashCode использовать не нужно и массив/список объектов по одному адресу
создавать тоже не нужно (только один объект по одному индексу).
Словарь не должен давать сохранить null в качестве строки, соответственно,
проверять заполнен элемент или нет можно сравнивая строку с null.


Описание/Пошаговая инструкция выполнения домашнего задания:
1. Реализуйте метод Add с неизменяемым массивом размером 32 элемента (исключение, если уже занято место).
2. Реализуйте метод Get.
3. Реализуйте увеличение массива в два раза при нахождении коллизий.
4. Убедитесь, что класс работает без ошибок (например, Get несуществующего элемента) не бросает исключений,
помимо заданных вами. Если это не так, то доработайте.
5. Добавьте к классу возможность работы с индексатором.
*/

internal class OtusDictionaryWithoutBuckets
{
    private (int key, string value)[] _body;
    private bool _isDemoModeOn;
    
    public OtusDictionaryWithoutBuckets(bool isDemoModeOn = false)
    {
        _isDemoModeOn = isDemoModeOn;
        _body = new (int key, string value)[32];        
    }

    public void Print()
    {
        foreach(var (key, value) in _body)
        {
            if (value == null)
                Console.WriteLine((key, "null"));
            else 
                Console.WriteLine((key, value));
        }
    }

    public void Add(int key, string value)
    {
        
        if (_body[key % _body.Length].value == null)
        {
            _body[key % _body.Length] = (key, value);
        }
        else
        {
            if (_isDemoModeOn)
            {
                throw new Exception($"Демо режим работы OtusDictionary не позволяет добавить ({key}, {value})");
            }
            else
            {
                int factor = 1;
                while (true)
                {
                    factor *= 2;                    
                    var _bodyTmp = new (int key, string value)[_body.Length * factor];
                    Console.WriteLine($"Произошла коллизия, база словаря увеличена, новый размер {_bodyTmp.Length}");
                    
                    bool hasNotCollison = true;
                    _bodyTmp[key % _bodyTmp.Length] = (key, value);
                    foreach (var element in _body)
                    {
                        if (element.value == null) continue;
                        
                        if (_bodyTmp[element.key % _bodyTmp.Length].value == null)
                        {
                            _bodyTmp[element.key % _bodyTmp.Length] = element;
                        }
                        else
                        {
                            hasNotCollison = false;
                            break;
                        }
                    }
                    if(hasNotCollison)
                    {                        
                        _body = _bodyTmp;
                        break;
                    }
                }
            }
        }

    }

    public string? Get(int key)
    {
        return _body[key % _body.Length].value;
    }

    public string this [int key]
    {
        get
        {            
            if (_body[key % _body.Length].value == null)
            {
                throw new KeyNotFoundException($"Ключ {key} не найден в словаре");
            }
            return _body[key % _body.Length].value;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Значение не может быть null");
            }
            var element = _body[key % _body.Length];
            if (element.value == null || element.key == key)
            {
                _body[key % _body.Length] = (key, value);
            }
            else
            {
                Add(key, value);
            }
        }
    }
}