using AutoFixture;

namespace HW_11;

public class OtusDictionary
{
    private Dictionary<int, string> _array;

    public OtusDictionary(int i)
    {
        Fixture autoFixture = new Fixture();
        _array = autoFixture
            .CreateMany<KeyValuePair<int, string>>(i)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    public void Add(int keyToAdd, string? valueToAdd)
    {
        foreach (var element in _array)
        {
            if (element.Key == keyToAdd | element.Value == valueToAdd)
                throw new Exception();

            //не знаю, как иначе осуществить поиск коллизий, поэтому сделал реализацию через GetHashCode()
            if (element.Key.GetHashCode() == keyToAdd.GetHashCode())
            {
                //еще и не понимаю, как передать значения старого словаря в новый с большим размером.
                //Пытался и через foreach, но все перебираемые в нем элементы неизменяемые,
                //а через for нельзя обратиться к конретному индексу словаря
                var i = _array.Count;
                _array = new Dictionary<int, string>(i * 2);
            }

            _array.Add(keyToAdd, valueToAdd);
        }
    }

    public string? Get(int key)
    {
        foreach (var i in _array)
        {
            if (i.Key == key)
                return i.Value;
        }

        Console.WriteLine("Элемент с таким ключом отстутствует");
        return null;
    }

    public bool this[int result]
    {
        get { throw new NotImplementedException(); }
    }
}