/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
using com.adjust.sdk;
//using MoreMountains.NiceVibrations;

public class RatLadyTen : MonoBehaviour
{

    public static RatLadyTen instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string TurnWan;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string TurnGhostWan;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string TurnExciteWan;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string TurnWakeWan;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string TurnFecundWan;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string ZealSolo= "21277";
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]
    //channel渠道平台
#if UNITY_IOS
    public string Artisan= "iOS";
#elif UNITY_ANDROID
    public string Channel = "Android";
#else
    public string Channel = "Other";
#endif
    //工程包名
    private string BoulderHiss{ get { return Application.identifier; } }
    //登录url
    private string GhostWan= "";
    //配置url
    private string ExciteWan= "";
    //更新AdjustId url
    private string AdjustWan= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Million= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData ExciteShow;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init TactShow;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    public Game_Data ZealShow;
[UnityEngine.Serialization.FormerlySerializedAs("LevelConfigData")]    //public Task_Data TaskData;
    public List<LevelConfig> BelowExciteShow;
[UnityEngine.Serialization.FormerlySerializedAs("LevelList")]    public List<LevelInfo> BelowPuff;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADImagery
    public GameObject ByImagery;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Slam;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Rub;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Lush;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string ShowHeed; //数据来源 打点用
    int Disco_Reset= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Disco= false;
[UnityEngine.Serialization.FormerlySerializedAs("BlockRule")]    public BlockRuleData PanelMess;
[UnityEngine.Serialization.FormerlySerializedAs("CashOut_Data")]    //提现相关后台数据
    public CashOutData DiscTed_Show;
    //ios 获取idfa函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif

    void Awake()
    {
        instance = this;
        GhostWan = TurnGhostWan + ZealSolo + "&channel=" + Artisan + "&version=" + Application.version;
        ExciteWan = TurnExciteWan + ZealSolo + "&channel=" + Artisan + "&version=" + Application.version;
        AdjustWan = TurnFecundWan + ZealSolo;
        Application.targetFrameRate = 60; // 锁定300帧 
    }
    private void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            //Login();
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            AcidShowImagery.AntMeadow("idfv", idfv);
#endif
        }
        else
        {
            Ghost();           //编辑器登录
        }
        //获取config数据
        PutExciteShow();
        //提现登录
        CashOutManager.PutCambrian().Login();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Slam = gaid_str;
        if (Slam == null || Slam == "")
        {
            Slam = AcidShowImagery.PutMeadow("gaid");
        }
        else
        {
            AcidShowImagery.AntMeadow("gaid", Slam);
        }
        Disco_Reset++;
        if (Disco_Reset == 2)
        {
            Ghost();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Rub = aid_str;
        if (Rub == null || Rub == "")
        {
            Rub = AcidShowImagery.PutMeadow("aid");
        }
        else
        {
            AcidShowImagery.AntMeadow("aid", Rub);
        }
        Disco_Reset++;
        if (Disco_Reset == 2)
        {
            Ghost();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        Lush = message;
        AcidShowImagery.AntMeadow("idfa", Lush);
        Ghost();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Lush = AcidShowImagery.PutMeadow("idfa");
        Ghost();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Ghost()
    {
        //提现登录
        //CashOutManager.GetInstance().Login();
        //获取本地缓存的Local用户ID
        string localId = AcidShowImagery.PutMeadow(CExcite.Ax_LiterDataTo);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            AcidShowImagery.AntMeadow(CExcite.Ax_LiterDataTo, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = GhostWan + "&" + "randomKey" + "=" + localId + "&idfa=" + Lush + "&packageName=" + BoulderHiss;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = GhostWan + "&" + "randomKey" + "=" + localId + "&gaid=" + Slam + "&androidId=" + Rub + "&packageName=" + BoulderHiss;
        }
        else //编辑器
        {
            url = GhostWan + "&" + "randomKey" + "=" + localId + "&packageName=" + BoulderHiss;
        }

        //获取国家信息
        RobCheapen(() => {
            url += "&country=" + Million;
            //登录请求
            RatWarpImagery.PutCambrian().RushPut(url,
                (data) => {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    AcidShowImagery.AntMeadow("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    AcidShowImagery.AntMeadow(CExcite.Ax_LiterLizardTo, serverUserData.data.ToString());

                    RoofFecundLamp();
                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(InnateWine.GoatLog))
                        InnateWine.RoofFloor();
                },
                () => {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void RobCheapen(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Million))
        {
            ////获取国家超时返回
            //StartCoroutine(NetWorkTimeOut(() =>
            //{
            //    if (!callBackReady)
            //    {
            //        country = "";
            //        callBackReady = true;
            //        cb?.Invoke();
            //    }
            //}));
            RatWarpImagery.PutCambrian().RushPut("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Million = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Million);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () => {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Million = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void PutExciteShow()
    {
        Debug.Log("GetConfigData:" + ExciteWan);
        //StartCoroutine(NetWorkTimeOut(() =>
        //{
        //    GetLoactionData();
        //}));

        //获取并存入Config
        RatWarpImagery.PutCambrian().RushPut(ExciteWan,
        (data) => {
            ShowHeed = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            AcidShowImagery.AntMeadow("OnlineData", data.downloadHandler.text);
            AntExciteShow(data.downloadHandler.text);
        },
        () => {
            Debug.Log("ConfigData 失败");
            PutIronworkShow();
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void PutIronworkShow()
    {
        //是否有缓存
        if (AcidShowImagery.PutMeadow("OnlineData") == "" || AcidShowImagery.PutMeadow("OnlineData").Length == 0)
        {
            ShowHeed = "LocalData_Updated"; //已联网更新过的数据

            Debug.Log("本地数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            AntExciteShow(json.text);
        }
        else
        {
            ShowHeed = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            AntExciteShow(AcidShowImagery.PutMeadow("OnlineData"));
        }
    }


    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void AntExciteShow(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (ExciteShow == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            ExciteShow = rootData.data;
            switch (AcidShowImagery.PutMeadow(CExcite.Lid_Workweek))
            {
                case "Russian":
                    TactShow = JsonMapper.ToObject<Init>(ExciteShow.init_ru);
                    //TaskData = JsonMapper.ToObject<Task_Data>(ConfigData.task_data_ru);
                    break;
                case "Portuguese (Brazil)":
                    TactShow = JsonMapper.ToObject<Init>(ExciteShow.init_br);
                    //TaskData = JsonMapper.ToObject<Task_Data>(ConfigData.task_data_br);
                    break;
                case "Japanese":
                    TactShow = JsonMapper.ToObject<Init>(ExciteShow.init_jp);
                    //TaskData = JsonMapper.ToObject<Task_Data>(ConfigData.task_data_jp);
                    break;
                case "English":
                    TactShow = JsonMapper.ToObject<Init>(ExciteShow.init_us);
                    //TaskData = JsonMapper.ToObject<Task_Data>(ConfigData.task_data_us);
                    break;
                default:
                    TactShow = JsonMapper.ToObject<Init>(ExciteShow.init);
                    //TaskData = JsonMapper.ToObject<Task_Data>(ConfigData.task_data);
                    break;
            }
            ZealShow = JsonMapper.ToObject<Game_Data>(ExciteShow.GameData);
            BelowExciteShow = JsonMapper.ToObject<List<LevelConfig>>(ExciteShow.LevelData);
            BelowPuff = JsonMapper.ToObject<List<LevelInfo>>(ExciteShow.level_change);
            DiscTed_Show = JsonMapper.ToObject<CashOutData>(ExciteShow.CashOut_Data);
            if (!string.IsNullOrEmpty(ExciteShow.BlockRule))
                PanelMess = JsonMapper.ToObject<BlockRuleData>(ExciteShow.BlockRule);
            if (!string.IsNullOrEmpty(ExciteShow.CashOut_Data))
                DiscTed_Show = JsonMapper.ToObject<CashOutData>(ExciteShow.CashOut_Data);
            PutDataLady();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void ZealSolar()
    {
        //打开admanager
        ByImagery.SetActive(true);
        //进度条可以继续
        Disco = true;
    }



    ///// <summary>
    ///// 超时处理
    ///// </summary>
    ///// <param name="finish"></param>
    ///// <returns></returns>
    //IEnumerator NetWorkTimeOut(Action finish)
    //{
    //    yield return new WaitForSeconds(TIMEOUT);
    //    finish();
    //}

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void RoofFecundLamp()
    {
        string serverId = AcidShowImagery.PutMeadow(CExcite.Ax_LiterLizardTo);
        string adjustId = FecundTactImagery.Instance.PutFecundLamp();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = AdjustWan + "&serverId=" + serverId + "&adid=" + adjustId;
        RatWarpImagery.PutCambrian().RushPut(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
        CashOutManager.PutCambrian().ReportAdjustID();
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]
    ////轮询检查Adjust归因信息
    //int CheckCount = 0;
    //[HideInInspector] public string Event_TrackerName; //打点用参数
    //bool _CheckOk = false;
    //[HideInInspector]
    //public bool AdjustTracker_Ready //是否成功获取到归因信息
    //{
    //    get
    //    {
    //        if (Application.isEditor) //编译器跳过检查
    //            return true;
    //        return _CheckOk;
    //    }
    //}
    //public void CheckAdjustNetwork() //检查Adjust归因信息
    //{
    //    if (Application.isEditor) //编译器跳过检查
    //        return;
    //    if (!string.IsNullOrEmpty(Event_TrackerName)) //已经拿到归因信息
    //        return;


    //    CancelInvoke(nameof(CheckAdjustNetwork));
    //    if (!string.IsNullOrEmpty(ConfigData.fall_down) && ConfigData.fall_down == "fall")
    //    {
    //        print("Adjust 无归因相关配置或未联网 跳过检查");
    //        _CheckOk = true;
    //    }
    //    try
    //    {
    //        AdjustAttribution Info = Adjust.getAttribution();
    //        print("Adjust 获取信息成功 归因渠道：" + Info.trackerName);
    //        Event_TrackerName = "TrackerName: " + Info.trackerName;
    //        InnateWine.Adjust_TrackerName = Info.trackerName;
    //        _CheckOk = true;
    //    }
    //    catch (System.Exception e)
    //    {
    //        CheckCount++;
    //        Debug.Log("Adjust 获取信息失败：" + e.Message + " 重试次数：" + CheckCount);
    //        if (CheckCount >= 10)
    //            _CheckOk = true;
    //        Invoke(nameof(CheckAdjustNetwork), 1);
    //    }
    //}


    //获取用户信息
    public string DataShowSea= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData DataShow;
    int PutDataLadyEject= 0;
    void PutDataLady()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            ZealSolar();
            return;
        }

        //检查归因渠道信息
        //CheckAdjustNetwork();
        //获取用户信息
        string CheckUrl = TurnWan + "/api/client/user/checkUser";
        RatWarpImagery.PutCambrian().RushPut(CheckUrl,
        (data) =>
        {
            DataShowSea = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + DataShowSea);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(DataShowSea);
            DataShow = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (DataShowSea.Contains("apple")
            || DataShowSea.Contains("Apple")
            || DataShowSea.Contains("APPLE"))
                DataShow.IsHaveApple = true;
            ZealSolar();
        }, () => { });
        Invoke(nameof(OxPutDataLady), 1);
    }
    void OxPutDataLady()
    {
        if (!Disco)
        {
            PutDataLadyEject++;
            if (PutDataLadyEject < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + PutDataLadyEject);
                PutDataLady();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                ZealSolar();
            }
        }
    }
}
