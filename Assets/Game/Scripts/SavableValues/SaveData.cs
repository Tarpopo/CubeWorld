using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public List<IntStruct> Ints;

    public SaveData()
    {
        Ints = new List<IntStruct>(10);
    }
}

[Serializable]
public class IntStruct
{
    public string Key;
    public int Value;
}