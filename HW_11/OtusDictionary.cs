using AutoFixture;

namespace HW_11;

public class OtusDictionary
{
    class DictItem
    {
        public int Key = 0;
        public string Value = null;
    }

    DictItem[] dictItems = new DictItem[32];

    public int Size => dictItems.Length;

    public void Add(int keyToAdd, string valueToAdd)
    {
        int index = keyToAdd % dictItems.Length;

        var dictItem = new DictItem();
        dictItem.Key = keyToAdd;
        dictItem.Value = valueToAdd;

        //resharper предлагает убрать проверку на нул, потому что, как я понимаю, класс DictItem не может быть нулевым
        if (dictItems[index] != null)
        {
            if (dictItems[index].Key == keyToAdd)
                throw new Exception(String.Format("Элемент с индексом " + keyToAdd + " существует"));

            _resize();
            index = keyToAdd % dictItems.Length;
        }

        dictItems[index] = dictItem;
    }

    public string Get(int key)
    {
        int index = key % dictItems.Length;
        DictItem item = dictItems[index];
        if (item == null)
            throw new Exception("Элемент с таким ключом отсутствует");
        return item.Value;
    }
    
    public bool TryGet(int key, out string vle) {
        vle = "";
        int index = key % dictItems.Length;
        DictItem item = dictItems[index];
        if (item == null)
            return false;
        vle = item.Value;
        return true;
    }
    
    private void _resize()
    {
        DictItem[] newDictItems = new DictItem[dictItems.Length*2];
        
        foreach (var di in dictItems)
        {
            if (di != null) {
                int index = di.Key % newDictItems.Length;
                newDictItems[index] = di;
            }
        }
        
        dictItems = newDictItems;
    }
}
    