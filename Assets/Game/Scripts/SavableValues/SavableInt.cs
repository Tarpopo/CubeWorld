public class SavableInt : SavableValue<int>
{
    public SavableInt(string saveKey, JSONSaver jsonSaver) : base(saveKey, jsonSaver)
    {
    }

    protected override void SaveValue(int value)
    {
        _jsonSaver.SetInt("DataValue " + SaveKey, value);
    }

    protected override int GetSaveValue()
    {
        return _jsonSaver.GetInt("DataValue " + SaveKey);
    }
}