//Source: https://www.youtube.com/watch?v=5roZtuqZyuw
//Brackeys also
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SerializationManager 
{
    public static void Save(PlayerMain player) {
        Debug.Log("SaveGame");
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load() {
        Debug.Log("LoadGame");
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else {
            Debug.Log("Error getting file");
            return null;
        }
    }

    public static void DeleteAllSave() {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            Debug.Log("True");
            File.Delete(path);
        }
        else
        {
            Debug.Log("False");
        }
        /*
        try
        {
            //Debug.Log("DeleteAllSave");
            //File.Delete(path);
        }
        catch
        {
            //Debug.Log("Error");
        }
        */
     }
}
