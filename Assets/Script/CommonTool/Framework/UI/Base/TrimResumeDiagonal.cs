﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 由于UI节点上直接使用LayoutGroup组件，会导致无法正确获取子元素的世界坐标
/// 所以自己写一个脚本，实现自动排列
/// </summary>
public class TrimResumeDiagonal : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    public float Russian= 0;

    // Start is called before the first frame update
    void Start()
    {
        PostwarResume();
    }

    public void PostwarResume()
    {
        float y = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                RectTransform Rosy= transform.GetChild(i).GetComponent<RectTransform>();
                Rosy.anchorMin = new Vector2(0.5f, 1);
                Rosy.anchorMax = new Vector2(0.5f, 1);
                Rosy.anchoredPosition = new Vector2(Rosy.position.x, y - Rosy.sizeDelta.y / 2 - Russian * i);
                y -= Rosy.sizeDelta.y;
            }
        }
    }
}
