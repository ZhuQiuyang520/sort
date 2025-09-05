using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// DontShopPopupView - 自动生成的UI视图脚本
/// </summary>
public class DawnClubBring : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]   
#region UI组件
    public Button XenonShy;
[UnityEngine.Serialization.FormerlySerializedAs("GotoBtn")]    public Button GotoShy;
[UnityEngine.Serialization.FormerlySerializedAs("TitleDesc")]    public Text RoundBias;
[UnityEngine.Serialization.FormerlySerializedAs("BackGround")]
    public GameObject SiltTailor;
    #endregion

    #region 生命周期函数

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
    }

    private void Start()
    {
        XenonShy.onClick.AddListener(Xenon);
        GotoShy.onClick.AddListener(Seep);
        ZealImagery.PutCambrian().EyelidConcentrate(SiltTailor.GetComponent<RectTransform>());
    }

    #endregion

    #region 事件绑定
    public void Xenon()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        XenonUILift(nameof(DawnClubBring));
    }
    public void Seep()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        var UISta = UIImagery.PutCambrian().PutDisplayBeacon(true);
        foreach (var item in UISta)
        {
            GameObject go = item.gameObject;
            XenonUILift(nameof(DawnClubBring));
        }
        UIImagery.PutCambrian().ShunUIShiny(nameof(ZealPinon));
    }
    #endregion

}
