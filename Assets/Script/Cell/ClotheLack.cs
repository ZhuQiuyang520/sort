using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotheLack : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Desc")]    public Text Bias;
    public void Tact(double RewardNumber)
    {
        Bias.text = RewardNumber.ToString("f2");
    }
}
