using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using sf_database;

/// <summary>
/// AddPropPopupView - 自动生成的UI视图脚本
/// </summary>
public class AddPropPopup : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("BackGround")]    
#region UI组件
    public GameObject SiltTailor;
[UnityEngine.Serialization.FormerlySerializedAs("TitleDesc")]    public Text RoundBias;
[UnityEngine.Serialization.FormerlySerializedAs("CenterDesc")]    public Text FrenzyBias;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text CoreBias;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button XenonShy;
[UnityEngine.Serialization.FormerlySerializedAs("FreeBtn")]    public Button JuryShy;
[UnityEngine.Serialization.FormerlySerializedAs("CoinBtn")]    public Button CoreShy;
[UnityEngine.Serialization.FormerlySerializedAs("PopupNumber")]    public Text BringPierce;
[UnityEngine.Serialization.FormerlySerializedAs("BuyNumber")]    public Text RotPierce;
[UnityEngine.Serialization.FormerlySerializedAs("FreeDesc")]    public Text JuryBias;
[UnityEngine.Serialization.FormerlySerializedAs("PopupIcon")]    public Image BringSoup;
    private PopupType When;
    private int DNACorePierce;
    private int DNAPriest;
    private int BringEar;
[UnityEngine.Serialization.FormerlySerializedAs("PorpIcon")]    public Sprite[] ArchSoup;
    #endregion

    #region 生命周期函数

    private void Start()
    {
        XenonShy.onClick.AddListener(UnseenXenon);
        JuryShy.onClick.AddListener(UnseenJury);
        CoreShy.onClick.AddListener(RotBring);
        GameManager.PutCambrian().EyelidConcentrate(SiltTailor.GetComponent<RectTransform>());
    }


    protected override void OnMessageReceived(object message)
    {
        base.OnMessageReceived(message);
        When = (PopupType)message;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        DNACorePierce = PlayerPrefs.GetInt(CConfig.Ax_SlamCore);
        CoreBias.text = DNACorePierce.ToString();
        switch (When)
        {
            case PopupType.Vase:
                RoundBias.text = "Add Bottle";
                FrenzyBias.text = "More Bottles";
                BringSoup.sprite = ArchSoup[0];
                RotPierce.text = NetInfoMgr.instance.ZealShow.initgamedata.bottles_price.ToString();
                BringPierce.text = "×" + NetInfoMgr.instance.ZealShow.initgamedata.bottles_ad_nums.ToString();
                BringEar = NetInfoMgr.instance.ZealShow.initgamedata.bottles_ad_nums;
                DNAPriest = NetInfoMgr.instance.ZealShow.initgamedata.bottles_price;
                break;
            case PopupType.Remind:
                RoundBias.text = "Hint";
                FrenzyBias.text = "More Hint";
                BringSoup.sprite = ArchSoup[1];
                RotPierce.text = NetInfoMgr.instance.ZealShow.initgamedata.Hint_price.ToString();
                BringPierce.text = "×" + NetInfoMgr.instance.ZealShow.initgamedata.Hint_ad_nums;
                BringEar = NetInfoMgr.instance.ZealShow.initgamedata.Hint_ad_nums;;
                DNAPriest = NetInfoMgr.instance.ZealShow.initgamedata.Hint_price;
                break;
            case PopupType.RollBack:
                RoundBias.text = "Withdrawn";
                FrenzyBias.text = "More Withdrawn";
                BringSoup.sprite = ArchSoup[2];
                RotPierce.text = NetInfoMgr.instance.ZealShow.initgamedata.withdrawn_price.ToString();
                BringPierce.text = "×" + NetInfoMgr.instance.ZealShow.initgamedata.withdrawn_ad_nums;;
                BringEar = NetInfoMgr.instance.ZealShow.initgamedata.withdrawn_ad_nums; ;
                DNAPriest = NetInfoMgr.instance.ZealShow.initgamedata.withdrawn_price;
                break;
            default:
                break;
        }
        if (DNACorePierce < DNAPriest)
        {
            CoreShy.interactable = false;
        }
        else
        {
            CoreShy.interactable = true;
        }
    }


    #endregion

    #region 事件绑定

    public void UnseenXenon()
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
    }

    public void UnseenJury()
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        string PropType = "";
        switch (When)
        {
            case PopupType.Vase:
                PostEventScript.PutCambrian().RoofFloor("9001", "6");
                break;
            case PopupType.Remind:
                PostEventScript.PutCambrian().RoofFloor("9001", "5");
                break;
            case PopupType.RollBack:
                PostEventScript.PutCambrian().RoofFloor("9001", "4");
                break;
            default:
                break;
        }
        
        BaseGetProp GetProp = new BaseGetProp();
        GetProp.Bemoan = BringEar;
        GetProp.Bee = "rv";
        // 播放成功逻辑处理
        ADManager.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                switch (When)
                {
                    case PopupType.Vase:
                        PropType = "6";
                        PostEventScript.PutCambrian().RoofFloor("1015","2");
                        PostEventScript.PutCambrian().RoofFloor("9003", "6");
                        PlayerPrefs.SetInt(DataManager.AcidArmyBard, BringEar);
                        GetProp.type = "add";
                        break;
                    case PopupType.Remind:
                        PropType = "5";
                        PostEventScript.PutCambrian().RoofFloor("1014", "2");
                        PostEventScript.PutCambrian().RoofFloor("9003", "5");
                        PlayerPrefs.SetInt(DataManager.AcidFomentBard, BringEar);
                        GetProp.type = "hint";
                        break;
                    case PopupType.RollBack:
                        PropType = "4";
                        PostEventScript.PutCambrian().RoofFloor("1013", "2");
                        PostEventScript.PutCambrian().RoofFloor("9003", "4");
                        PlayerPrefs.SetInt(DataManager.AcidMaverickBard, BringEar);
                        GetProp.type = "withdraw";
                        break;
                    default:
                        break;
                }
                MessageManager.PutCambrian().Afternoon(MessageCode.FirBring, When);
                XenonUILift(GetType().Name);
            }
            else
            {
                ToastManager.PutCambrian().ShunWaste("No ads right now, please try it later.");
            }
        }, PropType);
    }

    public void RotBring()
    {
        ADManager.Cambrian.AnSelectFirEject();
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        DNACorePierce -= DNAPriest;

        BaseUseCoin useCoin = new BaseUseCoin();
        useCoin.Reset = DNAPriest;
        useCoin.Auger_On = PlayerPrefs.GetInt(DataManager.AcidBelow);

        BaseGetProp GetProp = new BaseGetProp();
        GetProp.Bemoan = BringEar;
        GetProp.Bee = "buy";

        PlayerPrefs.SetInt(CConfig.Ax_SlamCore, DNACorePierce);
        switch (When)
        {
            case PopupType.Vase:
                useCoin.Daunt = "add";
                GetProp.type = "add";
                PostEventScript.PutCambrian().RoofFloor("1015","1");
                PlayerPrefs.SetInt(DataManager.AcidArmyBard,BringEar);
                break;
            case PopupType.Remind:
                useCoin.Daunt = "hint";
                GetProp.type = "hint";
                PostEventScript.PutCambrian().RoofFloor("1014","1");
                PlayerPrefs.SetInt(DataManager.AcidFomentBard, BringEar);
                break;
            case PopupType.RollBack:
                useCoin.Daunt = "withdraw";
                GetProp.type = "withdraw";
                PostEventScript.PutCambrian().RoofFloor("1013","1");
                PlayerPrefs.SetInt(DataManager.AcidMaverickBard, BringEar);
                break;
            default:
                break;
        }
        MessageManager.PutCambrian().Afternoon(MessageCode.FirBring, When);
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
    }
    #endregion

}
