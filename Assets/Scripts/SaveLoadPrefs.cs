using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void saveMenuSprite(string menuSprite)
    {
        PlayerPrefs.SetString("menuSprite", menuSprite);
    }


    public static string loadMenuSprite()
    {
        return PlayerPrefs.GetString("menuSprite");
    }
}
