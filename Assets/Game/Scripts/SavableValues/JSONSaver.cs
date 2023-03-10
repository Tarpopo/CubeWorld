using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class JSONSaver : MonoBehaviour
{
    private SaveData _data;
    private const string FileName = "Save.txt";

    public void SetInt(string key, int value)
    {
        var element = _data.Ints.FirstOrDefault(item => item.Key == key);
        if (element == default)
        {
            var intStruct = new IntStruct
            {
                Key = key,
                Value = value
            };
            _data.Ints.Add(intStruct);
        }
        else
        {
            element.Value = value;
        }
    }

    public int GetInt(string key) => _data.Ints.FirstOrDefault(item => item.Key == key)?.Value ?? 0;

    [Button]
    private void Load()
    {
        _data = new SaveData();
        var json = ReadFromFIle(FileName);
        JsonUtility.FromJsonOverwrite(json, _data);
    }

    [Button]
    private void Save()
    {
        var json = JsonUtility.ToJson(_data);
        WriteToFile(FileName, json);
    }

    private void Awake() => Load();

    private void WriteToFile(string fileName, string json)
    {
        var path = GetFilePath(fileName);
        var fileStream = new FileStream(path, FileMode.Create);
        using var writer = new StreamWriter(fileStream);
        writer.Write(json);
    }

    private string ReadFromFIle(string fileName)
    {
        var path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using var reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            return json;
        }

        return string.Empty;
    }

    private string GetFilePath(string fileName) => Application.persistentDataPath + "/" + fileName;

    private void OnApplicationPause(bool pause)
    {
        if (pause) Save();
    }
#if UNITY_EDITOR
    private void OnDisable() => Save();

#endif
}