using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using sf_database;
using System;
using Spine.Unity;
using Spine;

public class AnimationGroup : MonoBehaviour
{   
    /// <summary>
    /// 瓶子完成动画
    /// </summary>
    /// <param name="Bottle">瓶子</param>
    /// <param name="Plug">插头</param>
    /// <param name="SceenEffect">屏幕特效</param>
    /// <param name="RibbonEffect">彩带特效</param>
    public static void PlasterReckonPut(GameObject Bottle,GameObject Plug,ParticleSystem SceenEffect,ParticleSystem RibbonEffect,System.Action finish)
    {
        SceenEffect.gameObject.SetActive(true);
        RibbonEffect.gameObject.SetActive(true);
        // 获取瓶子的大小
        Vector3 StartPos = Plug.transform.position;
        Vector3 StartPlugScale = Plug.transform.localScale;
        Vector3 StartPosBottle = Bottle.GetComponent<RectTransform>().position;
        float StartScale = Bottle.transform.localScale.y;
        Sequence seq = DOTween.Sequence();
        // 获取瓶子的RectTransform
        RectTransform rectTransform = Bottle.GetComponent<RectTransform>();
        Plug.GetComponent<Image>().color = new Color(1,1,1,0);
        Plug.transform.position = new Vector3(StartPos.x,StartPos.y+0.1f,StartPos.z);
        // 插头从StartPos.x,StartPos.y+500,StartPos.z移动到StartPos.x,StartPos.y,StartPos.z
        seq.Append(Plug.transform.DOMove(StartPos,0.3f));
        seq.Insert(0,Plug.GetComponent<Image>().DOFade(1, 0.3f));
        seq.Append(rectTransform.DOScaleY(StartScale*0.9f, 0.1f));
        seq.Append(rectTransform.DOScaleY(StartScale,0.1f));
        seq.Append(Plug.transform.DOScale(new Vector3(StartPlugScale.x*1.2f,StartPlugScale.y*0.8f,StartPlugScale.z),0.1f));
        seq.Append(Plug.transform.DOScale(new Vector3(StartPlugScale.x,StartPlugScale.y,StartPlugScale.z),0.1f));
        seq.AppendCallback(()=>
        {
            finish?.Invoke(); // x和y的值在0-1之间
        });
    }
    /// <summary>
    /// 关卡完成动画
    /// </summary>
    /// <param name="Cat">猫动画</param>
    /// <param name="Welldone">完成</param>
    /// <param name="SceenEffect">屏幕特效</param>
    /// <param name="RibbonEffect">彩带特效</param>
    /// <param name="ShowList">显示列表</param>
    /// <param name="finish"></param>
    public static IEnumerator BelowReckonPut(SkeletonGraphic Cat,SkeletonGraphic Welldone,ParticleSystem SceenEffect,ParticleSystem RibbonEffect,List<GameObject> ShowList,System.Action finish)
    {
        RibbonEffect.gameObject.SetActive(false);
        Welldone.AnimationState.ClearTracks();
        // 设置屏幕特效和彩带特效
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.win_2);
        SceenEffect.gameObject.SetActive(true);
        SceenEffect.Play();
        yield return new WaitForSeconds(0.8f);
        
        // 设置Cat动画
        Cat.gameObject.SetActive(true);
        TrackEntry catEntry = Cat.AnimationState.SetAnimation(0,"Show",false);
        catEntry.Complete += (test) =>
        {
           Cat.AnimationState.SetAnimation(0,"Loops",true);
        };
        yield return new WaitForSeconds(0.6f);
        RibbonEffect.gameObject.SetActive(true);
        // 设置Welldone动画
        Welldone.gameObject.SetActive(true);
        Welldone.AnimationState.SetAnimation(0,"animation",false);
        yield return new WaitForSeconds(0.2f);
        // 设置ShowList动画
        //AudioManager.Instance.PlaySFX(SFX.win_2);
        float Only= 0;
        for (int i = 0; i < ShowList.Count; i++)
        {
            int index = i;
            GameObject Bat= ShowList[i];
            Bat.transform.DOScale(new Vector3((float)Screen.width / 1080, (float)Screen.width / 1080, (float)Screen.width / 1080),0.3f).SetEase(Ease.OutBack).SetDelay(Only).OnComplete(()=>
            {
                if(index == ShowList.Count-1)
                {
                    finish?.Invoke();
                }
            });
            Only += 0.1f;
        }
    }
    /// <summary>
    /// 瓶子点击抬起
    /// </summary>
    /// <param name="Bottle"></param>
    /// <param name="StartPos"></param>
    /// <param name="AC"></param>
    public static void EntityByPut(GameObject Bottle,Vector3 StartPos,System.Action AC)
    {
        Bottle.GetComponent<RectTransform>().DOMoveY(StartPos.y+0.3f,0.3f).SetEase(Ease.OutSine).OnComplete(()=>
        {
            AC?.Invoke();
        });
    }
    /// <summary>
    /// 瓶子点击落下
    /// </summary>
    /// <param name="Playing"></param>
    /// <param name="Bottle"></param>
    /// <param name="StartPos"></param>
    /// <param name="AC"></param>
    public static void EntityBeakPut(bool Playing,GameObject Bottle,Vector3 StartPos,System.Action AC)
    {
        Bottle.GetComponent<RectTransform>().DOMoveY(StartPos.y,0.3f).SetEase(Ease.OutSine).OnComplete(()=> 
        {
            AC?.Invoke();
        });
    }
    /// <summary>
    /// 准备倒水
    /// </summary>
    /// <param name="Item"></param>
    /// <param name="StartPos"></param>
    /// <param name="EndPos"></param>
    /// <param name="A"></param>
    /// <param name="Finish"></param>
    public static void StretcherCoalTitlePut(GameObject Item,float A ,Vector3 EndPos,Image[] color, GameObject Plug,System.Action Finish) 
    {
        //瓶子
        A = A > 0 ? 40 : -40;
        EndPos.y += 0.5f;
        float Time = 0.2f;
        Item.transform.DOMove(EndPos, Time);
        Item.transform.DORotate(new Vector3(0, 0, A), Time).OnComplete(()=> 
        {
            Finish?.Invoke();
        });
        //水面
        Plug.transform.DOLocalRotate(new Vector3(0, 0, -A), Time);
        Plug.transform.DOScaleX(Mathf.Abs(A / 20)-0.5f, Time);
        //水
        for (int i = 0; i < color.Length; i++)
        {
            float targetTop = 210f - i * 70f;
            GameObject ColorItem = color[i].gameObject;

            ColorItem.transform.DOLocalRotate(new Vector3(0, 0, -A), Time);
            ColorItem.transform.DOScaleX(Mathf.Abs(A/20), Time);
        }     
    }
    /// <summary>
    /// 正在倒水
    /// </summary>
    /// <param name="Item"></param>
    /// <param name="A"></param>
    /// <param name="color"></param>
    /// <param name="Plug"></param>
    /// <param name="Finish"></param>
    public static void CoalTitlePutInProfound(GameObject Item,float A, Image[] color, GameObject Plug, float FristCurVolme, System.Action Finish)
    {
        //瓶子
        float AToIndax = (Mathf.Abs(A) - 60) / 10;
        float watertime = (4 - FristCurVolme) * 0.1f;
        float Time = 0.35f+(AToIndax * 0.05f);
        Item.transform.DORotate(new Vector3(0, 0, A), Time).OnComplete(() =>
        {
            Finish?.Invoke();
        });
        //Item.transform.DOMoveY(Item.GetComponent<RectTransform>().position.y + (AToIndax*0.003f), Time);
        //水面
        float AngleAdd = A > 0 ? 10 : -10;
        Plug.transform.DOLocalRotate(new Vector3(0, 0, -A +AngleAdd), Time);
        Plug.transform.DOLocalMoveY(0, Time);
        Plug.transform.DOScaleX(AToIndax+1.3f, Time);
        //水
        for (int i = 0; i < color.Length; i++)
        {
            float targetTop = 210f - i * 70f;
            GameObject ColorItem = color[i].gameObject;

            ColorItem.transform.DOLocalRotate(new Vector3(0, 0, -A +AngleAdd), Time);
            ColorItem.transform.DOScaleX(Mathf.Abs(A / 20), Time);
            RectTransform rt = ColorItem.GetComponent<RectTransform>();
            DOTween.To(() => rt.offsetMax, value => rt.offsetMax = value, new Vector2(rt.offsetMax.x, -Mathf.Clamp(210 - (AToIndax * 70) - (i * 70), 0, 210)), Time);
        }
        
    }
    /// <summary>
    /// 倒水结束
    /// </summary>
    /// <param name="Item"></param>
    /// <param name="EndPos"></param>
    /// <param name="A"></param>
    /// <param name="color"></param>
    /// <param name="Gray"></param>
    /// <param name="Plug"></param>
    /// <param name="Finish"></param>
    public static void CoalTitlePutLowa(GameObject Item, Vector3 EndPos,int CurVolume, int ReadyNumber, float A, Image[] color, Image[] Gray, GameObject Plug, System.Action Finish) 
    {
        float BackTime = 0.3f;
        //瓶子
        float AToIndax = (Mathf.Abs(A) - 60) / 10;
        Item.transform.DORotate(new Vector3(0, 0, 0), BackTime);
        Item.transform.DOMove(EndPos, BackTime);
        //水面
        if (AToIndax == 4) 
        {
            Plug.SetActive(false);
        }
        Plug.transform.DOLocalRotate(new Vector3(0, 0, 0), BackTime).OnComplete(() =>
        {
            Finish?.Invoke();
        });
        Plug.transform.DOScaleX(1, BackTime);
        Plug.transform.DOLocalMoveY(-235+(60*(CurVolume- ReadyNumber - 1)), BackTime);
        //水
        for (int i = 0; i < color.Length; i++)
        {
            float targetTop = 210f - i * 70f;
            GameObject ColorItem = color[i].gameObject;
            GameObject GrayItem = Gray[i].gameObject;

            ColorItem.transform.DOLocalRotate(new Vector3(0, 0, 0), BackTime);
            ColorItem.transform.DOScaleX(1, BackTime);

            Color FadeColor = ColorItem.GetComponent<Image>().color;
            Color FadeGrayColor = ColorItem.GetComponent<Image>().color;
            ColorItem.GetComponent<Image>().color = new Color (FadeColor.r, FadeColor.g, FadeColor.b, Mathf.Clamp(210 - ((AToIndax - 1) * 70) - (i * 70), 0, 1));
            GrayItem.GetComponent<Image>().color = new Color(FadeGrayColor.r, FadeGrayColor.g, FadeGrayColor.b, Mathf.Clamp(210 - ((AToIndax - 1) * 70) - (i * 70), 0, 1));
            RectTransform rt = ColorItem.GetComponent<RectTransform>();
            DOTween.To(() => rt.offsetMax, value => rt.offsetMax = value, new Vector2(rt.offsetMax.x, -(240+(i*-60))), BackTime);
        }
    }
    /// <summary>
    /// 被倒水
    /// </summary>
    /// <param name="color"></param>
    /// <param name="Plug"></param>
    /// <param name="CurVolume"></param>
    /// <param name="A"></param>
    /// <param name="ReadyNumber"></param>
    public static void TheApplySymbolizeCoalTitle(int NotVolume, Image[] color, GameObject SelectObj, colorconfigDB WaterColor, GameObject Plug, int CurVolume, float A, int FristCurVolme, int ReadyNumber, Action<int> ChangeWaterColor)
    {
        Color ShuiColor = new Color();
        ShuiColor.a = 1;
        Color TopColor = new Color();
        TopColor.a = 1;
        ColorUtility.TryParseHtmlString(WaterColor.color, out ShuiColor);
        ColorUtility.TryParseHtmlString(WaterColor.topcolor, out TopColor);
        float AToIndax = (Mathf.Abs(A) - 60) / 10;
        float Time = 0.35f + (AToIndax * 0.05f);
        float watertime = (4 - FristCurVolme) * 0.1f;
        PingziCell WaterLineEffect = SelectObj.GetComponent<PingziCell>();
        SetMat(NotVolume, WaterLineEffect.TitleWhen, WaterLineEffect.TitleInvest.gameObject, () =>
        {
            Plug.SetActive(true);
            Plug.GetComponent<Image>().color = TopColor;
            if (CurVolume == 0)
            {
                Plug.transform.localPosition = new(Plug.transform.localPosition.x, -300, Plug.transform.localPosition.z);
            }
            //找到当前list当中的要上升的颜色 然后将上升1个 应用于list中   那几个要升
            for (int i = 0; i < color.Length; i++)
            {
                GameObject ColorItem = color[i].gameObject;
                if (CurVolume - 1 < i && i < CurVolume + ReadyNumber)
                {
                    RectTransform rt = ColorItem.GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -(240 + ((CurVolume - 1) * -60)));
                    DOTween.To(() => rt.offsetMax, value => rt.offsetMax = value, new Vector2(rt.offsetMax.x, -(240 + (i * -60))), Time).SetEase(Ease.Linear);
                    Vector3 StartPos = ColorItem.transform.localPosition;
                    ColorItem.GetComponent<Image>().color = ShuiColor;
                }
            }
            Plug.transform.DOLocalMoveY(-230 + (60 * (CurVolume + ReadyNumber - 1)), Time).SetEase(Ease.Linear);
        }, ShuiColor, ReadyNumber, Time, ChangeWaterColor);
    }
    /// <summary>
    /// 水柱
    /// </summary>
    /// <param name="WaterLine"></param>
    /// <param name="WaterEffect"></param>
    /// <param name="WaterColor"></param>
    public static void SetMat(int NotVolume, GameObject WaterLine, GameObject WaterLineEffect, Action waterup, Color WaterColor, int ReadyNumber, float movetime, Action<int> ChangeWaterColor)
    {
        WaterLine.GetComponent<Image>().material.SetColor("_Color", WaterColor);
        WaterLine.SetActive(true);
        Image lineitem = WaterLine.GetComponent<Image>();
        Material instanceMaterial = new Material(lineitem.material);
        WaterLine.GetComponent<Image>().material = instanceMaterial;
        var mainModule = WaterLineEffect.GetComponent<ParticleSystem>().main;
        var ParticleNum = WaterLineEffect.GetComponent<ParticleSystem>().emission;
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(0.6f + (ReadyNumber * 0.5f), 1f);
        ParticleNum.rateOverTime = 7 + ReadyNumber * 5;
        float DownValue = 1;
        float UpValue = 1;
        DOTween.To(() => DownValue, x =>
        {
            DownValue = x; instanceMaterial.SetFloat("_Down", x);
        }, 0, 0.15f).OnComplete(() =>
        {
            waterup();

            WaterLineEffect.gameObject.SetActive(true);
            WaterLine.GetComponent<Image>().DOFade(1, movetime - 0.3f).OnComplete(() =>
            {
                ChangeWaterColor(NotVolume);
            });
            DOTween.To(() => UpValue, x =>
            {
                UpValue = x; instanceMaterial.SetFloat("_Up", x);
            }, 0, 0.15f).OnComplete(() =>
            {
                WaterLine.SetActive(false);
                instanceMaterial.SetFloat("_Up", 1);
                instanceMaterial.SetFloat("_Down", 1);
            }).SetDelay(movetime - 0.3f);

        }).SetDelay(0);
    }
    /// <summary>
    /// 障碍色清除
    /// </summary>
    /// <param name="Item"></param>
    /// <param name="Fx_Star"></param>
    /// <param name="Finish"></param>
    public static void VagueTentacleBlame(GameObject Item,ParticleSystem Fx_Star,System.Action Finish)
    {
        Fx_Star.gameObject.SetActive(true);
        Item.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(()=> 
        {
            Finish?.Invoke();
        });
    }
    /// <summary>
    /// 新手引导小手动画
    /// </summary>
    /// <param name="HandItem"></param>
    /// <param name="EndPos"></param>
    /// <param name="UpOrDown"></param>
    public static void EriePut(GameObject HandItem,Vector3 EndPos,bool UpOrDown) 
    {
        DOTween.Kill("handanimation");
        Sequence HandAni = DOTween.Sequence();
        if (UpOrDown)
        {
            //HandItem.transform.localScale = new Vector3((float)Screen.width / 1080, (float)Screen.width / 1080, (float)Screen.width / 1080);
            HandAni.Append(HandItem.transform.DOMoveY(EndPos.y - 0.5f, 0.5f));
            HandAni.Append(HandItem.transform.DOMoveY(EndPos.y, 0.5f));
            HandAni.SetLoops(-1);
        }
        else 
        {
            //HandItem.transform.localScale = new Vector3((float)Screen.width / 1080, -(float)Screen.width / 1080, (float)Screen.width / 1080);
            HandAni.Append(HandItem.transform.DOMoveY(EndPos.y + 0.5f, 0.5f));
            HandAni.Append(HandItem.transform.DOMoveY(EndPos.y, 0.5f));
            HandAni.SetLoops(-1);
        }
        HandAni.SetId("handanimation");
    }
    /// <summary>
    /// 转场
    /// </summary>
    /// <param name="Left"></param>
    /// <param name="Right"></param>
    /// <param name="finish">此时应该加载界面了</param>
    /// <param name="Otherfinish">这个动画播完的回调</param>
    public static void PlutoPut(GameObject Left,GameObject Right,System.Action finish, System.Action Otherfinish)
    {
        Left.transform.DOMoveX(6, 0.5f).OnComplete(() =>
        {
            finish?.Invoke();
            Left.transform.DOMoveX(-3, 0.5f).SetDelay(0.3f).OnComplete(() =>
            {
                Otherfinish?.Invoke();
            });
        });
        Right.transform.DOMoveX(-6, 0.5f).OnComplete(() =>
        {
            Right.transform.DOMoveX(3, 0.5f).SetDelay(0.3f);
        });
    }

    public static void OfTextClubPut(GameObject Fx_Shoplock, GameObject shopitem,System.Action Unlock=null)
    {
        Sequence ShopLock = DOTween.Sequence();
        ShopLock.Append(shopitem.transform.DOScale(0.9f, 0.3f).OnComplete(() => 
        {
            Fx_Shoplock.SetActive(true);
            Unlock();
        }));
        ShopLock.Append(shopitem.transform.DOScale(1.2f, 0.2f));
        ShopLock.Append(shopitem.transform.DOScale(1f, 0.1f));
    }

    public static void ConsumePut(List<GameObject> loadingItems) 
    {
        float Only= 0.3f;
        for (int i = 0; i < loadingItems.Count; i++)
        {
            GameObject item = loadingItems[i];
            item.transform.localScale = new Vector3(0, 0, 0);
            item.transform.DOScale(1, 0.2f).SetDelay(Only).SetEase(Ease.OutBack);
            Only += 0.05f;
        }
    } 
}