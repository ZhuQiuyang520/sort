using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MaskControl : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform York;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public PageView Programmer;
    private void Awake()
    {
        Programmer.OrScatUnseen = Netherland;
    }

    void Netherland(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        York.GetComponent<RectTransform>().position = pos;
    }
}
