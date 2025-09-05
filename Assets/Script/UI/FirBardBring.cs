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
public class FirBardBring : TurnUIShiny
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
        ZealImagery.PutCambrian().EyelidConcentrate(SiltTailor.GetComponent<RectTransform>());
    }


    protected override void OnMessageReceived(object message)
    {
        base.OnMessageReceived(message);
        When = (PopupType)message;
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        DNACorePierce = PlayerPrefs.GetInt(CExcite.Ax_SlamCore);
        CoreBias.text = DNACorePierce.ToString();
        switch (When)
        {
            case PopupType.Vase:
                RoundBias.text = "Add Bottle";
                FrenzyBias.text = "More Bottles";
                BringSoup.sprite = ArchSoup[0];
                RotPierce.text = RatLadyTen.instance.ZealShow.initgamedata.bottles_price.ToString();
                BringPierce.text = "×" + RatLadyTen.instance.ZealShow.initgamedata.bottles_ad_nums.ToString();
                BringEar = RatLadyTen.instance.ZealShow.initgamedata.bottles_ad_nums;
                DNAPriest = RatLadyTen.instance.ZealShow.initgamedata.bottles_price;
                break;
            case PopupType.Remind:
                RoundBias.text = "Hint";
                FrenzyBias.text = "More Hint";
                BringSoup.sprite = ArchSoup[1];
                RotPierce.text = RatLadyTen.instance.ZealShow.initgamedata.Hint_price.ToString();
                BringPierce.text = "×" + RatLadyTen.instance.ZealShow.initgamedata.Hint_ad_nums;
                BringEar = RatLadyTen.instance.ZealShow.initgamedata.Hint_ad_nums;;
                DNAPriest = RatLadyTen.instance.ZealShow.initgamedata.Hint_price;
                break;
            case PopupType.RollBack:
                RoundBias.text = "Withdrawn";
                FrenzyBias.text = "More Withdrawn";
                BringSoup.sprite = ArchSoup[2];
                RotPierce.text = RatLadyTen.instance.ZealShow.initgamedata.withdrawn_price.ToString();
                BringPierce.text = "×" + RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums;;
                BringEar = RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums; ;
                DNAPriest = RatLadyTen.instance.ZealShow.initgamedata.withdrawn_price;
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
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        //UIImagery.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
    }

    public void UnseenJury()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        string PropType = "";
        switch (When)
        {
            case PopupType.Vase:
                MeetFloorGently.PutCambrian().RoofFloor("9001", "6");
                break;
            case PopupType.Remind:
                MeetFloorGently.PutCambrian().RoofFloor("9001", "5");
                break;
            case PopupType.RollBack:
                MeetFloorGently.PutCambrian().RoofFloor("9001", "4");
                break;
            default:
                break;
        }
        
        BaseGetProp GetProp = new BaseGetProp();
        GetProp.Bemoan = BringEar;
        GetProp.Bee = "rv";
        // 播放成功逻辑处理
        ADImagery.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                switch (When)
                {
                    case PopupType.Vase:
                        PropType = "6";
                        MeetFloorGently.PutCambrian().RoofFloor("1015","2");
                        MeetFloorGently.PutCambrian().RoofFloor("9003", "6");
                        PlayerPrefs.SetInt(ShowImagery.AcidArmyBard, BringEar);
                        GetProp.type = "add";
                        break;
                    case PopupType.Remind:
                        PropType = "5";
                        MeetFloorGently.PutCambrian().RoofFloor("1014", "2");
                        MeetFloorGently.PutCambrian().RoofFloor("9003", "5");
                        PlayerPrefs.SetInt(ShowImagery.AcidFomentBard, BringEar);
                        GetProp.type = "hint";
                        break;
                    case PopupType.RollBack:
                        PropType = "4";
                        MeetFloorGently.PutCambrian().RoofFloor("1013", "2");
                        MeetFloorGently.PutCambrian().RoofFloor("9003", "4");
                        PlayerPrefs.SetInt(ShowImagery.AcidMaverickBard, BringEar);
                        GetProp.type = "withdraw";
                        break;
                    default:
                        break;
                }
                PotteryImagery.PutCambrian().Afternoon(MessageCode.FirBring, When);
                XenonUILift(GetType().Name);
            }
            else
            {
                WasteImagery.PutCambrian().ShunWaste("No ads right now, please try it later.");
            }
        }, PropType);
    }

    public void RotBring()
    {
        ADImagery.Cambrian.AnSelectFirEject();
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        DNACorePierce -= DNAPriest;

        BaseUseCoin useCoin = new BaseUseCoin();
        useCoin.Reset = DNAPriest;
        useCoin.Auger_On = PlayerPrefs.GetInt(ShowImagery.AcidBelow);

        BaseGetProp GetProp = new BaseGetProp();
        GetProp.Bemoan = BringEar;
        GetProp.Bee = "buy";

        PlayerPrefs.SetInt(CExcite.Ax_SlamCore, DNACorePierce);
        switch (When)
        {
            case PopupType.Vase:
                useCoin.Daunt = "add";
                GetProp.type = "add";
                MeetFloorGently.PutCambrian().RoofFloor("1015","1");
                PlayerPrefs.SetInt(ShowImagery.AcidArmyBard,BringEar);
                break;
            case PopupType.Remind:
                useCoin.Daunt = "hint";
                GetProp.type = "hint";
                MeetFloorGently.PutCambrian().RoofFloor("1014","1");
                PlayerPrefs.SetInt(ShowImagery.AcidFomentBard, BringEar);
                break;
            case PopupType.RollBack:
                useCoin.Daunt = "withdraw";
                GetProp.type = "withdraw";
                MeetFloorGently.PutCambrian().RoofFloor("1013","1");
                PlayerPrefs.SetInt(ShowImagery.AcidMaverickBard, BringEar);
                break;
            default:
                break;
        }
        PotteryImagery.PutCambrian().Afternoon(MessageCode.FirBring, When);
        //UIImagery.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
    }
    #endregion

}
