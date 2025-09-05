using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// DontShopPopupView - 自动生成的UI视图脚本
/// </summary>
public class DontShopPopup : BaseUIForms
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
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
    }

    private void Start()
    {
        XenonShy.onClick.AddListener(Xenon);
        GotoShy.onClick.AddListener(Seep);
        GameManager.PutCambrian().EyelidConcentrate(SiltTailor.GetComponent<RectTransform>());
    }

    #endregion

    #region 事件绑定
    public void Xenon()
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        XenonUILift(nameof(DontShopPopup));
    }
    public void Seep()
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        var UISta = UIManager.PutCambrian().PutDisplayBeacon(true);
        foreach (var item in UISta)
        {
            GameObject go = item.gameObject;
            XenonUILift(nameof(DontShopPopup));
        }
        UIManager.PutCambrian().ShunUIShiny(nameof(GamePanel));
    }
    #endregion

}
