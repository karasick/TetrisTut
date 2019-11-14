using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomModePanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenu;

    [SerializeField]
    private Button[] checkBoxButtons = null;

    // Start is called before the first frame update
    void Start()
    {
        //name = "customMode";

        AddListernersToCheckboxes();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void AddListernersToCheckboxes()
    {
        for (int i = 0; i < checkBoxButtons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            checkBoxButtons[closureIndex].onClick.AddListener(() => CheckboxButtonClick(closureIndex));
        }
    }


    public void CheckboxButtonClick(int index)
    {
        if (checkBoxButtons[index].GetComponent<Image>().sprite.name == "activeCheckbox")
        {
            checkBoxButtons[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/old/deactivatedCheckbox");
        }
        else
        {
            checkBoxButtons[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/old/activeCheckbox");
        }
        mainMenu.CheckboxButtonClick(index);
    }


    public void StartGameButtonClick()
    {
        mainMenu.StartGameButtonClick();
    }


    public void BackButtonClick()
    {
        mainMenu.BackButtonClick();
    }
}
