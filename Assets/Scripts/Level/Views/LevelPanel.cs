using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    protected Level Level;


    public void ToMenuButtonClick()
    {
        Level.ToMenuButtonClick();
    }
}
