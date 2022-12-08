using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using File = System.IO.File;

public class SaveSystem : MonoBehaviour
{
    private const string FileType = ".txt";
    private static string SavePath => Application.persistentDataPath + "/Saves/";
    private static string BackupSavePath => Application.persistentDataPath + "/BackUps/";

    private static int SaveCount;

    public static void SaveData<T> (T data, string FileName)
    {
        Directory.CreateDirectory(SavePath);
        Directory.CreateDirectory(BackupSavePath);

        if (SaveCount % 5 == 0) Save(BackupSavePath);
        {

        }
        Save(SavePath);

        SaveCount++;

        void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path + FileName + FileType))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream();
                formatter.Serialize(memoryStream,data);
                string dataToSave = Convert.ToBase64String(memoryStream.ToArray());
                writer.WriteLine(dataToSave);
            }
        }
    }

    public static T LoadData<T>(string fileName)
    {
        Directory.CreateDirectory(SavePath);
        Directory.CreateDirectory(BackupSavePath);

        bool backUpNeeded = false;
        T dataToReturn;

        Load(SavePath);

        return dataToReturn;

        if (backUpNeeded)
        {
            Load(BackupSavePath);
        }

        void Load(string path)
        {
            using (StreamReader reader = new StreamReader(path + fileName + FileType))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string dataToLoad = reader.ReadToEnd();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(dataToLoad));

                try
                {
                    dataToReturn = (T)formatter.Deserialize(memoryStream);
                }
                catch (Exception)
                {

                    backUpNeeded = true;
                    dataToReturn = default;
                }                
            }
        }
    }

    public static bool SaveExists(string fileName)
    {
        return File.Exists(BackupSavePath + fileName + FileType) || File.Exists(SavePath + fileName + FileType);
    }
}
