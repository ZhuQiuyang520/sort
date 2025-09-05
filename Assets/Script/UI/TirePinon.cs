using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// HomePanelView - 自动生成的UI视图脚本
/// </summary>
public class TirePinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    
#region UI组件
    public Text CoreBias;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]    public Text BelowBias;
[UnityEngine.Serialization.FormerlySerializedAs("StartBtn")]    public Button ReferShy;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button StepperShy;
[UnityEngine.Serialization.FormerlySerializedAs("Effect")]    public GameObject Invest;
[UnityEngine.Serialization.FormerlySerializedAs("AdaptiveObj")]
    public GameObject[] CalendarCut;
    #endregion

    #region 生命周期函数

    protected override void Awake()
    {
        base.Awake();
        PotteryImagery.PutCambrian().FirChapbook(MessageCode.PostwarDistance, PostwarDistance);
        PotteryImagery.PutCambrian().FirChapbook(MessageCode.XenonTireInvest, TaskInvest);
    }

    private void Start()
    {
        ReferShy.onClick.AddListener(ReferZeal);
        StepperShy.onClick.AddListener(TaskStepper);
        for (int i = 0; i < CalendarCut.Length; i++)
        {
            ZealImagery.PutCambrian().EyelidConcentrate(CalendarCut[i].GetComponent<RectTransform>());
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        CoreBias.text = PlayerPrefs.GetInt(CExcite.Ax_SlamCore).ToString();
        PostwarDistance();
    }

    private void OnDestroy()
    {
        PotteryImagery.PutCambrian().SlowlyChapbook(MessageCode.PostwarDistance, PostwarDistance);
        PotteryImagery.PutCambrian().SlowlyChapbook(MessageCode.XenonTireInvest, TaskInvest);
    }

    protected override void OnMessageReceived(object message)
    {
        base.OnMessageReceived(message);
        Invest.SetActive(false);
        PostwarDistance();
    }

    #endregion

    #region 事件绑定
    /// <summary>
    /// 初始化UI事件
    /// </summary>
    private void FacilitateSweaty()
    {
        ReferShy.onClick.AddListener(ReferZeal);
        StepperShy.onClick.AddListener(TaskStepper);
    }
    #endregion

    public void ReferZeal()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        //UIImagery.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
        UIImagery.PutCambrian().ShunUIShiny(nameof(ZealPinon));
    }
    public void TaskStepper()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        Invest.SetActive(false);
        //UIImagery.GetInstance().CacheUIMessage(UINames.StepperPinon, PopupType.Home);
        UIImagery.PutCambrian().ShunUIShiny(nameof(StepperPinon), PopupType.Home);
    }

    private void PostwarDistance()
    {
        //LevelDesc.text = string.Format(I18NManager.Instance.GetText("Level_Limit{0}"), PlayerPrefs.GetInt(ShowImagery.SaveLevel));
        BelowBias.text = "Level " + PlayerPrefs.GetInt(ShowImagery.AcidBelow);
    }

    private void TaskInvest()
    {
        Invest.SetActive(true);
    }
}
