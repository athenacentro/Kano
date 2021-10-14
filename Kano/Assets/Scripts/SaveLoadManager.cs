using UnityEngine;

public static class SaveLoadManager
{
    public static void SaveData(string dataName, int dataValue)
    {
        PlayerPrefs.SetInt(dataName, dataValue);
    }

    public static int LoadData(string dataName, int defaultValue)
    {
        return PlayerPrefs.GetInt(dataName, defaultValue);
    }
}
