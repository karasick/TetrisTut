using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Level Level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BackButtonClick()
    {
        Level.BackButtonClick();
    }


    public void ToMenuButtonClick()
    {
        Level.ToMenuButtonClick();
    }
}
