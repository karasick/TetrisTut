using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenu;

    [SerializeField]
    private Sprite[] menuSprites = null;

    // Start is called before the first frame update
    void Start()
    {
        //name = "options";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Sprite[] GetMenuSprites()
    {
        return menuSprites;
    }


    public void ChangeStyleButtonClick()
    {
        mainMenu.ChangeStyleButtonClick();
    }


    public void BackButtonClick()
    {
        mainMenu.BackButtonClick();
    }
}
