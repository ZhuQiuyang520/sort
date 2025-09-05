/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloorBiologyChapbook : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onCheep;
    public VoidDelegate UpBeak;
    public VoidDelegate UpApril;
    public VoidDelegate UpFeat;
    public VoidDelegate UpUp;
    public VoidDelegate UpWooden;
    public VoidDelegate UpStableWooden;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static FloorBiologyChapbook Put(GameObject go)
    {
        FloorBiologyChapbook listener = go.GetComponent<FloorBiologyChapbook>();
        if (listener == null)
        {
            listener = go.AddComponent<FloorBiologyChapbook>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onCheep != null)
        {
            onCheep(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (UpBeak != null)
        {
            UpBeak(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (UpApril != null)
        {
            UpApril(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (UpFeat != null)
        {
            UpFeat(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (UpUp != null)
        {
            UpUp(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (UpWooden != null)
        {
            UpWooden(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (UpStableWooden != null)
        {
            UpStableWooden(gameObject);
        }
    }
}
