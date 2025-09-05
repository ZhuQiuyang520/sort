/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollView : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public ScrollViewItem ManyLack;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect CriticRead;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Ingoing;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Russian= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float TableAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float TableMotive;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int TextureEject;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool DyClac= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int ZebraGourd;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int OhioGourd;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float ManyMotive= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<ScrollViewItem> ManyPuff;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<ScrollViewItem> TexturePuff;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> RedPuff;

    void Start()
    {
        TableMotive = this.GetComponent<RectTransform>().sizeDelta.y;
        TableAnvil = this.GetComponent<RectTransform>().sizeDelta.x;
        Ingoing = CriticRead.content;
        TactShow();

    }
    //初始化
    public void TactShow()
    {
        TextureEject = Mathf.CeilToInt(TableMotive / WhenMotive) + 1;
        for (int i = 0; i < TextureEject; i++)
        {
            this.FirRaft();
        }
        ZebraGourd = 0;
        OhioGourd = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        AntShow(numberList);
    }
    //设置数据
    void AntShow(List<int> list)
    {
        RedPuff = list;
        ZebraGourd = 0;
        if (ShowEject <= TextureEject)
        {
            OhioGourd = ShowEject;
        }
        else
        {
            OhioGourd = TextureEject - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = ZebraGourd; i < OhioGourd; i++)
        {
            ScrollViewItem Bat= BagRaft();
            if (Bat == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                Bat.gameObject.name = i.ToString();

                Bat.gameObject.SetActive(true);
                Bat.transform.localPosition = new Vector3(0, -i * WhenMotive, 0);
                TexturePuff.Add(Bat);
                StableRaft(i, Bat);
            }

        }
        Ingoing.sizeDelta = new Vector2(TableAnvil, ShowEject * WhenMotive - Russian);
        DyClac = true;
    }
    //更新item
    public void StableRaft(int index, ScrollViewItem obj)
    {
        int d = RedPuff[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public ScrollViewItem BagRaft()
    {
        ScrollViewItem Bat= null;
        if (ManyPuff.Count > 0)
        {
            Bat = ManyPuff[0];
            Bat.gameObject.SetActive(true);
            ManyPuff.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return Bat;
    }
    //item进入itemlist
    public void LackRaft(ScrollViewItem obj)
    {
        ManyPuff.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int ShowEject    {
        get
        {
            return RedPuff.Count;
        }
    }
    //每一行的高
    public float WhenMotive    {
        get
        {
            return ManyMotive + Russian;
        }
    }
    //添加item到缓存列表中
    public void FirRaft()
    {
        GameObject Bat= Instantiate(ManyLack.gameObject);
        Bat.transform.SetParent(Ingoing);
        RectTransform Rosy= Bat.GetComponent<RectTransform>();
        Rosy.anchorMin = new Vector2(0.5f, 1);
        Rosy.anchorMax = new Vector2(0.5f, 1);
        Rosy.pivot = new Vector2(0.5f, 1);
        Bat.SetActive(false);
        Bat.transform.localScale = Vector3.one;
        ScrollViewItem o = Bat.GetComponent<ScrollViewItem>();
        ManyPuff.Add(o);
    }



    void Update()
    {
        if (DyClac)
        {
            Detach();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Detach()
    {
        float vy = Ingoing.anchoredPosition.y;
        float rollUpTop = (ZebraGourd + 1) * WhenMotive;
        float rollUnderTop = ZebraGourd * WhenMotive;

        if (vy > rollUpTop && OhioGourd < ShowEject)
        {
            //上边界移除
            if (TexturePuff.Count > 0)
            {
                ScrollViewItem Bat= TexturePuff[0];
                TexturePuff.RemoveAt(0);
                LackRaft(Bat);
            }
            ZebraGourd++;
        }
        float rollUpBottom = (OhioGourd - 1) * WhenMotive - Russian;
        if (vy < rollUpBottom - TableMotive && ZebraGourd > 0)
        {
            //下边界减少
            OhioGourd--;
            if (TexturePuff.Count > 0)
            {
                ScrollViewItem Bat= TexturePuff[TexturePuff.Count - 1];
                TexturePuff.RemoveAt(TexturePuff.Count - 1);
                LackRaft(Bat);
            }

        }
        float rollUnderBottom = OhioGourd * WhenMotive - Russian;
        if (vy > rollUnderBottom - TableMotive && OhioGourd < ShowEject)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            ScrollViewItem go = BagRaft();
            TexturePuff.Add(go);
            go.transform.localPosition = new Vector3(0, -OhioGourd * WhenMotive);
            StableRaft(OhioGourd, go);
            OhioGourd++;
        }


        if (vy < rollUnderTop && ZebraGourd > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            ZebraGourd--;
            ScrollViewItem go = BagRaft();
            TexturePuff.Insert(0, go);
            StableRaft(ZebraGourd, go);
            go.transform.localPosition = new Vector3(0, -ZebraGourd * WhenMotive);
        }

    }
}
