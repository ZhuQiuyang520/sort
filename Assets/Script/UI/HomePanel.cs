using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// HomePanelView - 自动生成的UI视图脚本
/// </summary>
public class HomePanel : BaseUIForms
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
        MessageManager.PutCambrian().FirChapbook(MessageCode.PostwarDistance, PostwarDistance);
        MessageManager.PutCambrian().FirChapbook(MessageCode.XenonTireInvest, TaskInvest);
    }

    private void Start()
    {
        ReferShy.onClick.AddListener(ReferZeal);
        StepperShy.onClick.AddListener(TaskStepper);
        for (int i = 0; i < CalendarCut.Length; i++)
        {
            GameManager.PutCambrian().EyelidConcentrate(CalendarCut[i].GetComponent<RectTransform>());
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        CoreBias.text = PlayerPrefs.GetInt(CConfig.Ax_SlamCore).ToString();
        PostwarDistance();
    }

    private void OnDestroy()
    {
        MessageManager.PutCambrian().SlowlyChapbook(MessageCode.PostwarDistance, PostwarDistance);
        MessageManager.PutCambrian().SlowlyChapbook(MessageCode.XenonTireInvest, TaskInvest);
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
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
        UIManager.PutCambrian().ShunUIShiny(nameof(GamePanel));
    }
    public void TaskStepper()
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        Invest.SetActive(false);
        //UIManager.GetInstance().CacheUIMessage(UINames.SettingPanel, PopupType.Home);
        UIManager.PutCambrian().ShunUIShiny(nameof(SettingPanel), PopupType.Home);
    }

    private void PostwarDistance()
    {
        //LevelDesc.text = string.Format(I18NManager.Instance.GetText("Level_Limit{0}"), PlayerPrefs.GetInt(DataManager.SaveLevel));
        BelowBias.text = "Level " + PlayerPrefs.GetInt(DataManager.AcidBelow);
    }

    private void TaskInvest()
    {
        Invest.SetActive(true);
    }
}
