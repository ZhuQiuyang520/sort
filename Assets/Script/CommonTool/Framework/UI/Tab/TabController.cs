using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 导航插件
/// </summary>

[Serializable]
public class TabItem
{
    public string AntHiss;
    [SerializeField]
    private GameObject Cling= null;
    public GameObject Pinon{ get { return Cling; } }

    [SerializeField]
    private Button HitInnate= null;
    public Button AntInnate{ get { return HitInnate; } }

    public Sprite DevoidSoup;
    public Sprite IslanderSoup;
}

public class TabController : MonoBehaviour
{
    [SerializeField]
[UnityEngine.Serialization.FormerlySerializedAs("items")]    public List<TabItem> Smoke= null;
[UnityEngine.Serialization.FormerlySerializedAs("Content")]
    public GameObject Kinetic;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveAnimationObj")]    public GameObject DevoidCurvatureCut;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveBG")]    public Sprite DevoidBG;
[UnityEngine.Serialization.FormerlySerializedAs("InactiveBG")]    public Sprite IslanderBG;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveColor")]    public Color DevoidBlame;
[UnityEngine.Serialization.FormerlySerializedAs("InactiveColor")]    public Color IslanderBlame;
    [Header("初始选中Tab名称")]
[UnityEngine.Serialization.FormerlySerializedAs("ActiveTab")]    public GameObject DevoidAnt;

    private string GrowthAntHiss;

    private Dictionary<string, GameObject> HitBeacon;

    private Action<string, GameObject> DustRedesign;    // 打开tab回调

    // Start is called before the first frame update
    void Start()
    {
        HitBeacon = new Dictionary<string, GameObject>();

        // Tab按钮绑定点击事件
        foreach (TabItem tabItem in Smoke)
        {
            tabItem.AntInnate.onClick.AddListener(() =>
            {
                TaskAnt(tabItem.AntHiss);
            });
        }

        if (DevoidAnt != null)
        {
            foreach(TabItem tab in Smoke)
            {
                if (tab.AntInnate.gameObject == DevoidAnt)
                {
                    GrowthAntHiss = tab.AntHiss;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(GrowthAntHiss))
            {
                TaskAnt(GrowthAntHiss);
            }
        }
    }

    /// <summary>
    /// 打开tab页面
    /// </summary>
    /// <param name="_tabName"></param>
    public GameObject TaskAnt(string _tabName)
    {
        if (!string.IsNullOrEmpty(GrowthAntHiss) && HitBeacon.ContainsKey(GrowthAntHiss))
        {
            if (HitBeacon[GrowthAntHiss].GetComponent<BaseUIForms>() != null)
            {
                HitBeacon[GrowthAntHiss].GetComponent<BaseUIForms>().Hidding();
            }
            else
            {
                HitBeacon[GrowthAntHiss].SetActive(false);
            }
        }

        GameObject activeTabItem = null;
        foreach (TabItem tabItem in Smoke)
        {
            tabItem.AntInnate.GetComponent<TabItemController>().AntDevoidUI(tabItem.AntHiss.Equals(_tabName), this, tabItem);
            if (tabItem.AntHiss.Equals(_tabName))
            {
                activeTabItem = tabItem.AntInnate.gameObject;
                if (!HitBeacon.ContainsKey(_tabName) && tabItem.Pinon != null)
                {
                    GameObject tabItemPanel = Kinetic.transform.Find(tabItem.Pinon.name) == null ? Instantiate(tabItem.Pinon, Kinetic.transform) : tabItem.Pinon;
                    HitBeacon.Add(_tabName, tabItemPanel);
                }
            }
        }
        if (HitBeacon.ContainsKey(_tabName))
        {
            if (HitBeacon[_tabName].GetComponent<BaseUIForms>() != null)
            {
                HitBeacon[_tabName].GetComponent<BaseUIForms>().Display(null);
            }
            else
            {
                HitBeacon[_tabName]?.SetActive(true);
            }
        }

        GrowthAntHiss = _tabName;

        StartCoroutine(DevoidSoCurvature(activeTabItem));

        DustRedesign?.Invoke(_tabName, HitBeacon.ContainsKey(_tabName) ? HitBeacon[_tabName] : null);

        return HitBeacon.ContainsKey(_tabName) ? HitBeacon[_tabName] : null;
    }

    // tab背景动画
    private IEnumerator DevoidSoCurvature(GameObject activeTabItem)
    {
        yield return new WaitForEndOfFrame();
        if (activeTabItem != null && DevoidCurvatureCut != null)
        {
            DevoidCurvatureCut.transform.SetParent(activeTabItem.transform);
            DevoidCurvatureCut.transform.SetSiblingIndex(0);
            DevoidCurvatureCut.GetComponent<RectTransform>().DOMoveX(activeTabItem.GetComponent<RectTransform>().position.x, 0.3f).SetEase(Ease.OutBack);
        }
    }

    /// <summary>
    /// 注册打开tab回调事件
    /// </summary>
    /// <param name="_callback"></param>
    public void EusocialRedesign(Action<string, GameObject> _callback)
    {
        DustRedesign = _callback;
    }
}
