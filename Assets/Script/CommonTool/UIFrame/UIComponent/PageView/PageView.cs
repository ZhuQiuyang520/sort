/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PageView : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Rosy;
    //求出每页的临界角，页索引从0开始
    List<float> TonPuff= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool DyRend= false;
    bool stopPile= true;
    //滑动的起始坐标  
    float FlywayProjection= 0;
    float ZebraRendProjection;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Platform= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Susceptible= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> OrScatUnseen;
    //当前页面下标
    int FestiveScatGourd= -1;
    void Start()
    {
        Rosy = this.GetComponent<ScrollRect>();
        float horizontalLength = Rosy.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        TonPuff.Add(0);
        for(int i = 1; i < Rosy.content.childCount - 1; i++)
        {
            TonPuff.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        TonPuff.Add(1);
    }

    
    void Update()
    {
        if(!DyRend && !stopPile)
        {
            startTime += Time.deltaTime;
            float t = startTime * Platform;
            Rosy.horizontalNormalizedPosition = Mathf.Lerp(Rosy.horizontalNormalizedPosition, FlywayProjection, t);
            if (t >= 1)
            {
                stopPile = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void AntScatGourd(int index)
    {
        if (FestiveScatGourd != index)
        {
            FestiveScatGourd = index;
            if (OrScatUnseen != null)
            {
                OrScatUnseen(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        DyRend = true;
        ZebraRendProjection = Rosy.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Rosy.horizontalNormalizedPosition;
        posX += ((posX - ZebraRendProjection) * Susceptible);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(TonPuff[index] - posX);
        for(int i = 0; i < TonPuff.Count; i++)
        {
            float temp = Mathf.Abs(TonPuff[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        AntScatGourd(index);
        FlywayProjection = TonPuff[index];
        DyRend = false;
        startTime = 0f;
        stopPile = false;
    }
}
