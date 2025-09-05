using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static RomanWhen;

/// <summary>
/// LogoutPanelView - 自动生成的UI视图脚本
/// </summary>
public class DetectPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("Title")]    
#region UI组件
    public Text Round;
[UnityEngine.Serialization.FormerlySerializedAs("Desc")]    public Text Bias;
[UnityEngine.Serialization.FormerlySerializedAs("Yes")]    public Button Mix;
[UnityEngine.Serialization.FormerlySerializedAs("No")]    public Button An;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button XenonShy;
[UnityEngine.Serialization.FormerlySerializedAs("BackGround")]
    public GameObject SiltTailor;

    private bool Magical= true;
    #endregion

    #region 生命周期函数

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ZealImagery.PutCambrian().EyelidConcentrate(SiltTailor.GetComponent<RectTransform>());
        ZealImagery.PutCambrian().StepperJudge(UIMusic.pop_up);
        Magical = true;
        Bias.text = "Do you want to delete all the data?";
    }
    private void Start()
    {
        XenonShy.onClick.AddListener(UnseenXenon);
        An.onClick.AddListener(UnseenXenon);
        Mix.onClick.AddListener(UnseenMix);
    }

    #endregion

    #region 事件绑定

    public void UnseenXenon()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        //UIImagery.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
    }
    public void UnseenMix()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        if (Magical)
        {
            Magical = false;
            Bias.text = "All your information will be cleared!";
        }
        else
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
            PlayerPrefs.DeleteAll();
        }

    }
    #endregion

}
