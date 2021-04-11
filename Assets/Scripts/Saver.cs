using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Saver
{
    public static void SaveScore(int score)
    {
        if (Directory.Exists(@"../saves") == false)
            Directory.CreateDirectory(@"../saves");
        
        using (var fileStream = new FileStream(@"../saves/save.bin", FileMode.OpenOrCreate))
        using (var writer = new BinaryWriter(fileStream))
        {
            writer.Write(score);
        }
    }

    public static int GetSavedScore()
    {
        if (Directory.Exists(@"../saves") == false)
            Directory.CreateDirectory(@"../saves");
        
        if (File.Exists(@"../saves/save.bin") == false)
            return 0;
        
        using (var fileStream = new FileStream(@"../saves/save.bin", FileMode.Open))
        using (var reader = new BinaryReader(fileStream))
        {
            return reader.ReadInt32();
        }
    }
}
