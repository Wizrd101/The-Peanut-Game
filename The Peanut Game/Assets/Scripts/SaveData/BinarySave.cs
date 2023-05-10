using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Input-Output, which allows access to the computer data
using System.IO;
// As the game runs, allows the game to save in binary format
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySave : MonoBehaviour
{
    // Calling the game data from the lower class
    public GameData gameData;

    // IMPORTANT: saveFile is the name of the file, dataStream is the file itself

    // File to save data to
    string saveFile;

    // Opens the file and allows the reference
    FileStream dataStream;

    // Creates the BinaryFormatter
    BinaryFormatter converter = new BinaryFormatter();

    // Character Controller needs to be enabled and disabled
    public bool useCharCont;
    CharacterController cc;

    void Awake()
    {
        saveFile = Application.persistentDataPath + "/" + gameObject.name + "gamedata.data";
        //Debug.Log(saveFile);
        gameData = new GameData();
        if (useCharCont)
        {
            cc = GetComponent<CharacterController>();
        }
    }

    // Save-states style of saving
    private void Update()
    {
        // Save function. Make sure to set the variables before calling WriteFile.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameData.x = transform.position.x;
            gameData.y = transform.position.y;
            gameData.z = transform.position.z;
            WriteFile();
        }

        // Load function. Make sure to load the position after calling ReadFile.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReadFile();
            if (useCharCont)
            {
                cc.enabled = false;
            }
            Vector3 pos = new Vector3(gameData.x, gameData.y, gameData.z);
            transform.position = pos;
            if (useCharCont)
            {
                cc.enabled = true;
            }
        }
    }

    // Creates and saves the file
    public void WriteFile()
    {
        // Create fileStream to the save file path
        // FileStream (Where the file is, how to open the file)
        dataStream = new FileStream(saveFile, FileMode.Create);

        // Serialize data into the file
        // Serialize the gameData at dataStream
        converter.Serialize(dataStream, gameData);

        // Close the file
        dataStream.Close();
    }

    // Reads and loads the file
    public void ReadFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Open the fileStream
            dataStream = new FileStream(saveFile, FileMode.Open);

            // Deserialize the binary data, and casts it as GameData
            gameData = converter.Deserialize(dataStream) as GameData;

            // Close the file
            dataStream.Close();
        }
    }
}

// Time-Capsule. Not a mono behavior because it isn't a behavior, it just stores data
[System.Serializable]
public class GameData
{
    // Can only save primitive variables (int, float, bool), because it isn't mono. Instead, save X, Y, and Z to build a Vector3 later.
    public float x;
    public float y;
    public float z;
}