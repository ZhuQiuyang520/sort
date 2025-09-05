using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// FailPanelView - 自动生成的UI视图脚本
/// </summary>
public class RiskPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("FreeBtn")]    
#region UI组件
    public Button JuryShy;
[UnityEngine.Serialization.FormerlySerializedAs("SkipBtn")]    public Button ChicShy;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    public GameObject[] PuffBuyer;
    #endregion

    #region 生命周期函数

    private void Start()
    {
        JuryShy.onClick.AddListener(TaskJury);
        ChicShy.onClick.AddListener(Risk);
        for (int i = 0; i < PuffBuyer.Length; i++)
        {
            ZealImagery.PutCambrian().EyelidConcentrate(PuffBuyer[i].GetComponent<RectTransform>());
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.fail);
    }

    #endregion

    #region 事件绑定
    /// <summary>
    /// 初始化UI事件
    /// </summary>
    private void FacilitateSweaty()
    {
        JuryShy.onClick.AddListener(TaskJury);
        ChicShy.onClick.AddListener(Risk);
    }

    //打开激励视频
    public void TaskJury()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        ADImagery.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                // 播放成功逻辑处理
                //UIImagery.GetInstance().CloseUI();
                XenonUILift(GetType().Name);
                PotteryImagery.PutCambrian().Afternoon(MessageCode.RiskFollyTinge);
            }
            else
            {
                WasteImagery.PutCambrian().ShunWaste("No ads right now, please try it later.");
            }
        }, "");

    }
    //失败
    public void Risk()
    {
        ADImagery.Cambrian.AnSelectFirEject();
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        
        // 播放成功逻辑处理
        UIImagery.PutCambrian().VagueWetUI();
        UIImagery.PutCambrian().ShunUIShiny(nameof(TirePinon));
    }
    #endregion

}
