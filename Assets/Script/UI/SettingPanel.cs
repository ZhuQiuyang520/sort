using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using static MusicType;
using System.Runtime.InteropServices;

/// <summary>
/// SettingPanelView - 自动生成的UI视图脚本
/// </summary>
public class SettingPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Version")]    
#region UI组件
    public Text Persist;
[UnityEngine.Serialization.FormerlySerializedAs("Sound")]
    public Toggle Judge;
[UnityEngine.Serialization.FormerlySerializedAs("Music")]    public Toggle Roman;
[UnityEngine.Serialization.FormerlySerializedAs("VibraBtn")]    public Toggle VibraShy;
[UnityEngine.Serialization.FormerlySerializedAs("LanguageBtn")]    public Button DistanceShy;
[UnityEngine.Serialization.FormerlySerializedAs("ShopBtn")]    public Button ClubShy;
[UnityEngine.Serialization.FormerlySerializedAs("GoHomeBtn")]    public Button UpTireShy;
[UnityEngine.Serialization.FormerlySerializedAs("RateBtn")]    public Button LuckShy;
[UnityEngine.Serialization.FormerlySerializedAs("Privacy")]    public Button Suspect;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button SlabShy;
[UnityEngine.Serialization.FormerlySerializedAs("UnSubBtn")]    public Button OfSubShy;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    
    public Button XenonShy;
[UnityEngine.Serialization.FormerlySerializedAs("Setting")]
    public Button Stepper;
    private int SnipePierce= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ListBtn")]
    public GameObject[] PuffShy;
[UnityEngine.Serialization.FormerlySerializedAs("Content")]    public GameObject Kinetic;

    private int ClubDecode;
    private string SuspectURL;
    private PopupType When;

#if UNITY_IOS
    [DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif

    #endregion

    #region 生命周期函数

    protected override void OnMessageReceived(object message)
    {
        base.OnMessageReceived(message);
        When = (PopupType)message;
        if (When == PopupType.Game)
        {
            UpTireShy.gameObject.SetActive(true);
        }
        else if (When == PopupType.Home)
        {
            UpTireShy.gameObject.SetActive(false);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        ClubDecode = NetInfoMgr.instance.ZealShow.initgamedata.unclock_shop_lv;
    }

    private void Start()
    {
        Judge.onValueChanged.AddListener(UnseenJudge);
        Roman.onValueChanged.AddListener(UnseenRoman);
        VibraShy.onValueChanged.AddListener(UnseenTrail);
        DistanceShy.onClick.AddListener(UnseenDistance);

        ClubShy.onClick.AddListener(UnseenClub);
        UpTireShy.onClick.AddListener(UnseenTire);
        LuckShy.onClick.AddListener(UnseenLuck);
        Suspect.onClick.AddListener(UnseenSuspect);
        SlabShy.onClick.AddListener(UnseenFeat);

        OfSubShy.onClick.AddListener(UnseenOfBat);
        XenonShy.onClick.AddListener(Xenon);

        Stepper.onClick.AddListener(StepperSnipe);

#if UNITY_ANDROID
        Version.text = string.Format("Ver 0.{0}({1})", Application.version, PlayerSettings.Android.bundleVersionCode);
#elif UNITY_IOS
        Persist.text = string.Format("Ver 0.{0}({1})", Application.version, PlayerSettings.iOS.buildNumber);
#endif

        SuspectURL = NetInfoMgr.instance.ZealShow.initgamedata.Privacy_Policy;
        GameManager.PutCambrian().EyelidConcentrate(Kinetic.GetComponent<RectTransform>());
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) >= ClubDecode)
        {
            ClubShy.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt(DataManager.AcidRoman) == 1)
        {
            Roman.isOn = true;
        }
        else
        {
            Roman.isOn = false;
        }

        if (PlayerPrefs.GetInt(DataManager.AcidJudge) == 1)
        {
            Judge.isOn = true;
        }
        else
        {
            Judge.isOn = false;
        }

        if (PlayerPrefs.GetInt(DataManager.AcidDepositor) == 1)
        {
            VibraShy.isOn = true;
        }
        else
        {
            VibraShy.isOn = false;
        }
    }

#endregion

#region 事件绑定
    public void UnseenRoman(bool open)
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        Roman.isOn = open;
        GameManager.PutCambrian().ItRoman = open;
        if (open)
        {
            //继续播放，如果没有BGM就从头播放
            MusicMgr.PutCambrian().AllBudMexicanBagWake();
            PlayerPrefs.SetInt(DataManager.AcidRoman, 1);
        }
        else
        {
            //暂停
            MusicMgr.PutCambrian().AllBudXenonOneWake();
            PlayerPrefs.SetInt(DataManager.AcidRoman, 0);
        }
    }
    public void UnseenJudge(bool open)
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        Judge.isOn = open;
        GameManager.PutCambrian().ItJudge = open;
        if (open)
        {
            PlayerPrefs.SetInt(DataManager.AcidJudge, 1);
        }
        else
        {
            //AudioManager.Instance.StopAllSFX();
            PlayerPrefs.SetInt(DataManager.AcidJudge, 0);
        }
    }
    public void UnseenTrail(bool open)
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        VibraShy.isOn = open;
        GameManager.PutCambrian().ItTrail = open;
        if (open)
        {
            PlayerPrefs.SetInt(DataManager.AcidDepositor, 1);
        }
        else
        {
            PlayerPrefs.SetInt(DataManager.AcidDepositor, 0);
        }
    }
    public void UnseenDistance()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        //UIManager.GetInstance().ShowUIForms(nameof(LanguagePanel));
    }

    public void UnseenClub()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
        UIManager.PutCambrian().ShunUIShiny(nameof(ShopPanel));
    }
    public void UnseenTire()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(UIMusic.pop_up);
        UIManager.PutCambrian().VagueWetUI();
        UIManager.PutCambrian().ShunUIShiny(nameof(HomePanel));
    }
    public void UnseenLuck()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        string toMail = NetInfoMgr.instance.ZealShow.initgamedata.Contact_Us;
        string subject = "[USERFEED]wordfarmers v1.1.0";
        Uri uri = new Uri(string.Format("mailto:{0}?subject={1}&body={2}", toMail, subject,"你好"));
        Application.OpenURL(uri.AbsoluteUri);
    }
    public void UnseenSuspect()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        if (!string.IsNullOrEmpty(SuspectURL))
        {
            string url = SuspectURL;
#if UNITY_ANDROID || UNITY_EDITOR
            Application.OpenURL(url);
#elif UNITY_IOS
       openUrl(url);
#endif
        }
    }
    public void UnseenFeat()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void UnseenOfBat()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.pop_up);
        UIManager.PutCambrian().ShunUIShiny(nameof(LogoutPanel));
    }

    public void Xenon()
    {
        SnipePierce = 0;
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        //UIManager.GetInstance().CloseUI();
        XenonUILift(GetType().Name);
        MessageManager.PutCambrian().Afternoon(MessageCode.XenonTireInvest);
    }

    public void StepperSnipe()
    {
        SnipePierce++;
        if (SnipePierce >= 5)
        {
            SnipePierce = 0;
            XenonUILift(GetType().Name);
            //UIManager.GetInstance().ShowUIForms(nameof(DebugInfoPanel));
        }
    }

#endregion

//#if UNITY_EDITOR

//    [MenuItem("Tools/Update Version Number")]
//    public static void UpdateVersion()
//    {
//        int version =int.Parse(PlayerSettings.bundleVersion);
//        version++;
//        PlayerSettings.bundleVersion = version.ToString();
//    }
//#endif
}
