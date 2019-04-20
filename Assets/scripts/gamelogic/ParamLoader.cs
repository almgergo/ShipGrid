using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ParamLoader : MonoBehaviour
{
    private string gameDataFilename = "data.json";

    public GameData GameData;

    void Start()
    {
        this.LoadGameData();
    }


    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, this.gameDataFilename);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Debug.Log(dataAsJson);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            loadedData.ArrangeData();
            this.GameData = loadedData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

}
