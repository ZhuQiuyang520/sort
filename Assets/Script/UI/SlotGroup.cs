using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGroup : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject TactBelow;
[UnityEngine.Serialization.FormerlySerializedAs("templateMultiObjectList")]
    public GameObject[] CongressCivilBranchPuff;

    private GameObject CongressCivilBranch;
    
    private float ManyAnvil= 215f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        float x = ManyAnvil * 3;
        int multiCount = NetInfoMgr.instance.TactShow.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                CongressCivilBranch = CongressCivilBranchPuff[UnityEngine.Random.Range(0, CongressCivilBranchPuff.Length)] ;
                GameObject fangkuai = Instantiate(CongressCivilBranch, TactBelow.transform);
                fangkuai.transform.localPosition = new Vector3(x + ManyAnvil * multiCount * i + ManyAnvil * j, CongressCivilBranch.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + NetInfoMgr.instance.TactShow.slot_group[j].multi;
            }
        }
    }

    public void GushCivil()
    {
        TactBelow.GetComponent<RectTransform>().localPosition = new Vector3(0, -10, 0);
    }

    public void Fair(int index, Action<int> finish)
    {
        AnimationController.ProjectionDetach(TactBelow, -(ManyAnvil * 2 + ManyAnvil * NetInfoMgr.instance.TactShow.slot_group.Count * 3 + ManyAnvil * (index + 1)), () =>
        {
            finish?.Invoke((int)NetInfoMgr.instance.TactShow.slot_group[index].multi);
        });
    }
}
