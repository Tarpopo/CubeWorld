public abstract class SavableValue<T>
{
    private T _value;
    protected readonly string SaveKey;
    protected readonly JSONSaver _jsonSaver;

    protected SavableValue(string saveKey, JSONSaver jsonSaver)
    {
        _jsonSaver = jsonSaver;
        SaveKey = saveKey;
        _value = GetSaveValue();
    }

    public T Value
    {
        get => _value;

        set
        {
            _value = value;
            Save();
        }
    }

    public void Save() => SaveValue(_value);
    protected abstract void SaveValue(T value);
    protected abstract T GetSaveValue();
}