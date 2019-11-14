using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomModePanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu MainMenu;

    [SerializeField]
    private Button[] CheckBoxButtons = null;

    // Start is called before the first frame update
    void Start()
    {
        //name = "customMode";

        AddListernersToCheckboxes();
    }


    private void AddListernersToCheckboxes()
    {
        for (int i = 0; i < CheckBoxButtons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            CheckBoxButtons[closureIndex].onClick.AddListener(() => CheckboxButtonClick(closureIndex));
        }
    }


    public void CheckboxButtonClick(int index)
    {
        if (CheckBoxButtons[index].GetComponent<Image>().sprite.name == "activeCheckbox")
        {
            CheckBoxButtons[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/old/deactivatedCheckbox");
        }
        else
        {
            CheckBoxButtons[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/old/activeCheckbox");
        }
        MainMenu.CheckboxButtonClick(index);
    }


    public void StartGameButtonClick()
    {
        MainMenu.StartGameButtonClick();
    }


    public void BackButtonClick()
    {
        MainMenu.BackButtonClick();
    }
}
