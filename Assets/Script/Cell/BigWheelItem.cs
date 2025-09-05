using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigWheelItem : MonoBehaviour
{
    public Text text;
    public Image DiamandIcon;
    public Image goldIcon;
    public Image RollIcon;
    public Image AddIcon;
    public Image RemindIcon;
    
    public void initIcon(string type)
    {
        DiamandIcon.gameObject.SetActive(false);
        goldIcon.gameObject.SetActive(false);
        RollIcon.gameObject.SetActive(false);
        AddIcon.gameObject.SetActive(false);
        RemindIcon.gameObject.SetActive(false);
        switch (type)
        {
            case "diamand":
                DiamandIcon.gameObject.SetActive(true);
                break;
            case "gold":
                goldIcon.gameObject.SetActive(true);
                break;
            case "roll":
                RollIcon.gameObject.SetActive(true);
                break;
            case "add":
                AddIcon.gameObject.SetActive(true);
                break;
            case "remind":
                RemindIcon.gameObject.SetActive(true);
                break;
        }

    }
}
