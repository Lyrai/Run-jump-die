using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Saver
{
    public static void SaveScore(int score)
    {
        if (Directory.Exists(Application.persistentDataPath + "/saves/save.bin") == false)
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        
        using (var fileStream = new FileStream(Application.persistentDataPath + "/saves/save.bin", FileMode.OpenOrCreate))
        using (var writer = new BinaryWriter(fileStream))
        {
            writer.Write(score);
        }
    }

    public static int GetSavedScore()
    {
        if (Directory.Exists(Application.persistentDataPath + "/saves") == false)
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        
        if (File.Exists(Application.persistentDataPath + "/saves/save.bin") == false)
            return 0;
        
        using (var fileStream = new FileStream(Application.persistentDataPath + "/saves/save.bin", FileMode.Open))
        using (var reader = new BinaryReader(fileStream))
        {
            return reader.ReadInt32();
        }
    }
}
