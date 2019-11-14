using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{

    public static void saveMenuSprite(string menuSprite)
    {
        PlayerPrefs.SetString("menuSprite", menuSprite);
    }


    public static string loadMenuSprite()
    {
        return PlayerPrefs.GetString("menuSprite");
    }

    public static void SaveScore()
    {
        if (ScoreManager.Score > 0)
        {
            ScoreManager.SavedScores.Add(ScoreManager.Score);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SavedScores.gd");
            bf.Serialize(file, ScoreManager.SavedScores);
            file.Close();
        }
    }


    public static void ClearScore()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/SavedScores.gd", FileMode.Open);

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


    public static void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedScores.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedScores.gd", FileMode.Open);
            if (file.Length != 0)
            {
                ScoreManager.SavedScores = (List<int>)bf.Deserialize(file);
            }
            file.Close();
        }
    }
}
