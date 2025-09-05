using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnateWine
{
    [HideInInspector] public static string Fecund_ContactHiss; //归因渠道名称 由NetInfoMgr的CheckAdjustNetwork方法赋值
    static string Acid_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string SchistForeHiss= "pie"; //正常模式名称
    static string Enjoyment; //距离黑名单位置的距离 打点用
    static string Policy; //进审理由 打点用
    [HideInInspector] public static string GoatLog= ""; //判断流程 打点用

    public static bool ItOxide()
    {
        //测试
        // return true;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Acid_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Acid_AP)) //无本地存档 读取网络数据
            PellaPotashShow();

        if (Acid_AP != "P")
            return true;
        else
            return false;
    }

    public static void PellaPotashShow() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Acid_AP = "P";
        if (RatLadyTen.instance.ExciteShow.apple_pie != SchistForeHiss) //审模式 
        {
            OtherChance = "YES";
            Acid_AP = "A";
            if (string.IsNullOrEmpty(Policy))
                Policy = "ApplePie";
        }
        GoatLog = "0:" + Acid_AP;
        //判断运营商信息
        if (RatLadyTen.instance.DataShow != null && RatLadyTen.instance.DataShow.IsHaveApple)
        {
            Acid_AP = "A";
            if (string.IsNullOrEmpty(Policy))
                Policy = "HaveApple";
            GoatLog += "1:" + Acid_AP;
        }
        if (RatLadyTen.instance.PanelMess != null)
        {
            //判断经纬度
            LocationData[] LocationDatas = RatLadyTen.instance.PanelMess.LocationList;
            if (LocationDatas != null && LocationDatas.Length > 0 && RatLadyTen.instance.DataShow != null && RatLadyTen.instance.DataShow.lat != 0 && RatLadyTen.instance.DataShow.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = PutChicopee((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)RatLadyTen.instance.DataShow.lat, (float)RatLadyTen.instance.DataShow.lon);
                    Enjoyment += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Acid_AP = "A";
                        if (string.IsNullOrEmpty(Policy))
                            Policy = "Location";
                        break;
                    }
                }
            }
            GoatLog += "2:" + Acid_AP;
            //判断城市
            string[] HeiCityList = RatLadyTen.instance.PanelMess.CityList;
            if (!string.IsNullOrEmpty(RatLadyTen.instance.DataShow.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == RatLadyTen.instance.DataShow.regionName
                    || HeiCityList[i] == RatLadyTen.instance.DataShow.city)
                    {
                        Acid_AP = "A";
                        if (string.IsNullOrEmpty(Policy))
                            Policy = "City";
                        break;
                    }
                }
            }
            GoatLog += "3:" + Acid_AP;
            //判断黑名单
            string[] HeiIPs = RatLadyTen.instance.PanelMess.IPList;
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(RatLadyTen.instance.DataShow.query))
            {
                string[] IpNums = RatLadyTen.instance.DataShow.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Acid_AP = "A";
                        if (string.IsNullOrEmpty(Policy))
                            Policy = "IP";
                        break;
                    }
                }
            }
            GoatLog += "4:" + Acid_AP;
        }
        //判断自然量
        if (!string.IsNullOrEmpty(RatLadyTen.instance.PanelMess.fall_down))
        {
            //if (RatLadyTen.instance.BlockRule.fall_down == "bottom") //仅判断Organic
            //{
            //    if (Adjust_TrackerName == "Organic") //打开自然量 且 归因渠道是Organic 审模式
            //    {
            //        Save_AP = "A";
            //        if (string.IsNullOrEmpty(Reason))
            //            Reason = "FallDown";
            //    }
            //}
            //else if (RatLadyTen.instance.BlockRule.fall_down == "down") //判断Organic + NoUserConsent
            //{
            //    if (Adjust_TrackerName == "Organic" || Adjust_TrackerName == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
            //    {
            //        Save_AP = "A";
            //        if (string.IsNullOrEmpty(Reason))
            //            Reason = "FallDown";
            //    }
            //}
        }
        GoatLog += "5:" + Acid_AP;


        //安卓平台特殊屏蔽策略
        if (Application.platform == RuntimePlatform.Android && RatLadyTen.instance.PanelMess != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");

            //判断是否使用VPN
            if (RatLadyTen.instance.PanelMess.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "VPN";
                }
            }
            GoatLog += "6:" + Acid_AP;

            //是否使用模拟器
            if (RatLadyTen.instance.PanelMess.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "Simulator";
                }
            }
            GoatLog += "7:" + Acid_AP;
            //是否root
            if (RatLadyTen.instance.PanelMess.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "Root";
                }
            }
            GoatLog += "8:" + Acid_AP;
            //是否使用开发者模式
            if (RatLadyTen.instance.PanelMess.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "Developer";
                }
            }
            GoatLog += "9:" + Acid_AP;

            //是否使用USB调试
            if (RatLadyTen.instance.PanelMess.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "UsbDebug";
                }
            }
            GoatLog += "10:" + Acid_AP;

            //是否使用sim卡
            if (RatLadyTen.instance.PanelMess.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                {
                    Acid_AP = "A";
                    if (string.IsNullOrEmpty(Policy))
                        Policy = "SimCard";
                }
            }
            GoatLog += "11:" + Acid_AP;
        }
        PlayerPrefs.SetString("Save_AP", Acid_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);

        //打点
        if (!string.IsNullOrEmpty(AcidShowImagery.PutMeadow(CExcite.Ax_LiterLizardTo)))
            RoofFloor();
    }
    static float PutChicopee(float lat1, float lon1, float lat2, float lon2)
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void RoofFloor()
    {
        //打点
        if (RatLadyTen.instance.DataShow != null)
        {
            string Info1 = "[" + (Acid_AP == "A" ? "审" : "正常") + "] [" + Policy + "]";
            string Info2 = "[" + RatLadyTen.instance.DataShow.lat + "," + RatLadyTen.instance.DataShow.lon + "] [" + RatLadyTen.instance.DataShow.regionName + "] [" + Enjoyment + "]";
            string Info3 = "[" + RatLadyTen.instance.DataShow.query + "] [Null]";  // [" + Adjust_TrackerName + "]";
            MeetFloorGently.PutCambrian().RoofFloor("3000", Info1, Info2, Info3);
        }
        else
            MeetFloorGently.PutCambrian().RoofFloor("3000", "No UserData");
        MeetFloorGently.PutCambrian().RoofFloor("3001", (Acid_AP == "A" ? "审" : "正常"), GoatLog, RatLadyTen.instance.ShowHeed);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }

    // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
    public static bool DraperyPanelPella()
    {
        if (Application.platform == RuntimePlatform.Android && RatLadyTen.instance.PanelMess != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            string Info = "";
            if (RatLadyTen.instance.PanelMess.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                    Info = "Please turn off your VPN, restart the game and try again.";
            }
            if (RatLadyTen.instance.PanelMess.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                    Info = "This game cannot be run on emulators.";
            }
            if (RatLadyTen.instance.PanelMess.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                    Info = "This game cannot be played on rooted devices.";
            }
            if (RatLadyTen.instance.PanelMess.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                    Info = "Please switch off Developer Option, restart the game and try again.";
            }
            if (RatLadyTen.instance.PanelMess.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                    Info = "Please switch off USB debugging, restart the game and try again.";
            }
            if (RatLadyTen.instance.PanelMess.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                    Info = "Please check if the SIM card is inserted, then restart the game and try again.";
            }
            if (!string.IsNullOrEmpty(Info))
            {
                UIImagery.PutCambrian().ShunUIShiny(nameof(PanelPinon)).GetComponent<PanelPinon>().ShunLady(Info);
                return true;
            }
        }
        return false;
    }

    public static bool ItRecoil()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool ItLikewise()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 LiterInput2EyelidInput(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 EyelidInput2LiterInput(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 PutStudyEsotericOfReadLifeblood(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
