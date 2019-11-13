using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoadScore
{
    public static void Save()
    {
        if (ScoreManager.score > 0)
        {
            ScoreManager.savedScores.Add(ScoreManager.score);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savedScores.gd");
            bf.Serialize(file, ScoreManager.savedScores);
            file.Close();
        }
    }


    public static void Clear()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/savedScores.gd", FileMode.Open);

        /* 
         * Set the length of filestream to 0 and flush it to the physical file.
         *
         * Flushing the stream is important because this ensures that
         * the changes to the stream trickle down to the physical file.
         * 
        */
        file.SetLength(0);
        file.Close();
    }


    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedScores.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedScores.gd", FileMode.Open);
            if(file.Length != 0)
            {
                ScoreManager.savedScores = (List<int>)bf.Deserialize(file);
            }
            file.Close();
        }
    }
}
