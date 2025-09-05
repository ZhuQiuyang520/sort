using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Icon")]    public Image Soup;
[UnityEngine.Serialization.FormerlySerializedAs("NumText")]    public Text EarHand;

    public void Native(Sprite icon, int num = 0)
    {
        Soup.sprite = icon;
        if (num == 0) {
            EarHand.gameObject.SetActive(false);
        }
        else
        {
            EarHand.text = "+" + num.ToString();
            EarHand.gameObject.SetActive(true);
        }
    }
}
