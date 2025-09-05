using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using sf_database;
using DG.Tweening;

/// <summary>
/// ShopPanelView - 自动生成的UI视图脚本
/// </summary>
public class ShopPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CoinNumber")]    
#region UI组件
    public Text CorePierce;
[UnityEngine.Serialization.FormerlySerializedAs("ShopObj")]    public GameObject ClubCut;
[UnityEngine.Serialization.FormerlySerializedAs("ColorGroup")]    public ToggleGroup BlameGroup;
[UnityEngine.Serialization.FormerlySerializedAs("ColorScroll")]    public GameObject BlameDetach;
[UnityEngine.Serialization.FormerlySerializedAs("ColorContent")]    public Transform BlameKinetic;
[UnityEngine.Serialization.FormerlySerializedAs("TubeGroup")]    public ToggleGroup SageBelow;
[UnityEngine.Serialization.FormerlySerializedAs("TubeScroll")]    public GameObject SageDetach;
[UnityEngine.Serialization.FormerlySerializedAs("TubeContent")]    public Transform SageKinetic;
[UnityEngine.Serialization.FormerlySerializedAs("ColorTog")]    public Toggle BlameGem;
[UnityEngine.Serialization.FormerlySerializedAs("TubeTog")]    public Toggle SageGem;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button XenonShy;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public GameObject Erie;
    private bool ItClubClick= false;
    private List<ShopConfig> ClubPuff= new List<ShopConfig>();
    private int DNACorePierce;
    #endregion

    #region 生命周期函数

    protected override void Awake()
    {
        ClubPuff = NetInfoMgr.instance.ZealShow.shop;
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        PostEventScript.PutCambrian().RoofFloor("1005");
        DNACorePierce = PlayerPrefs.GetInt(CConfig.Ax_SlamCore);
        CorePierce.text = DNACorePierce.ToString();
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) >= NetInfoMgr.instance.ZealShow.initgamedata.unclock_shop_lv && PlayerPrefs.GetInt(DataManager.AcidOfTextClub) == 0)
        {
            ItClubClick = true;
            PlayerPrefs.SetInt(DataManager.AcidOfTextClub, 1);
        }
        UnseenBlame(true);
    }

    private void Start()
    {
        BlameGem.onValueChanged.AddListener(UnseenBlame);
        SageGem.onValueChanged.AddListener(UnseenSage);
        XenonShy.onClick.AddListener(Xenon);
        GameManager.PutCambrian().EyelidConcentrate(BlameKinetic.GetComponent<RectTransform>());
        GameManager.PutCambrian().EyelidConcentrate(SageKinetic.GetComponent<RectTransform>());
        GameManager.PutCambrian().EyelidConcentrate(Erie.GetComponent<RectTransform>());
        
    }

    #endregion

    public void UnseenBlame(bool open)
    {
        BlameDetach.gameObject.SetActive(open);
        if (open)
        {
            BlameGem.isOn = true;
            if (BlameKinetic.childCount == 0)
            {
                foreach (var item in ClubPuff)
                {
                    if (item.type == 2)
                    {
                        ClubLack(BlameKinetic).Init(BlameGroup, item , UnseenRotUserCore , ClubClick);
                    }
                }
            }
        }
    }

    public void ClubClick(ShopConfig shop , Vector3 Pos)
    {
        if (ItClubClick)
        {
            if (shop.price <= DNACorePierce && shop.unclock_lv != 0 && shop.unclock_lv <= PlayerPrefs.GetInt(DataManager.AcidBelow))
            {
                Erie.transform.position = Pos;
                Erie.SetActive(true);
                AnimationGroup.EriePut(Erie, Pos, true);
            }
        }
    }
    public void UnseenSage(bool open)
    {
        SageDetach.gameObject.SetActive(open);
        if (open)
        {
            if (ItClubClick)
            {
                ItClubClick = false;
                Erie.SetActive(false);
                DOTween.Kill("handanimation");
            }

            SageGem.isOn = true;
            if (SageKinetic.childCount == 0)
            {
                foreach (var item in ClubPuff)
                {
                    if (item.type == 1 || item.type == 3)
                    {
                        ClubLack(SageKinetic).Init(SageBelow, item, UnseenRotUserCore, ClubClick);
                    }
                }
            }
        }
        
    }

    public void Xenon()
    {
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
        MessageManager.PutCambrian().Afternoon(MessageCode.PostwarVanishBlame);
    }

    public void UnseenRotUserCore(ShopConfig Data)
    {
        if (ItClubClick)
        {
            ItClubClick = false;
            DOTween.Kill("handanimation");
            Erie.SetActive(false);
        }
        
        DNACorePierce -= Data.price;
        PlayerPrefs.SetInt(CConfig.Ax_SlamCore, DNACorePierce);
        CorePierce.text = DNACorePierce.ToString();

        //购买之后存储购买数据
        if (Data.type == 1)
        {
            PlayerPrefs.SetInt(DataManager.AcidArmyUser, Data.id);
            List<int> VaseList = DataManager.PutPuff(DataManager.AcidWetArmyUser);
            DataManager.AntPuff(DataManager.AcidWetArmyUser, VaseList.Count, Data.id);
        }
        else if(Data.type == 2)
        {
            PlayerPrefs.SetInt(DataManager.AcidDNAUser, Data.id);
            List<int> ColorList = DataManager.PutPuff(DataManager.AcidWetBlameUser);
            DataManager.AntPuff(DataManager.AcidWetBlameUser, ColorList.Count, Data.id);
        }
    }

    ShopColorCell ClubLack(Transform Content)
    {
        GameObject Go = Instantiate<GameObject>(ClubCut);
        Go.transform.SetParent(Content, false);
        ShopColorCell cell = Go.GetComponent<ShopColorCell>();
        return cell;
    }
}
