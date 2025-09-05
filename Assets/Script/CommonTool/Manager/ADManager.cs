using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.adjust.sdk;
using LitJson;

public class ADManager : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool DyGrit= false;
    public static ADManager Cambrian{ get; private set; }

    private int retryVeteran;   // 广告加载失败后，重新加载广告次数
    private bool DyPutrefyMe;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int OhioCorpWakeEclipse{ get; private set; }   // 距离上次广告的时间间隔
    public int Chemist101{ get; private set; }     // 定时插屏(101)计数器
    public int Chemist102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Chemist103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string ExhaleNowhereHiss;
    private Action<bool> ExhalePairSiltDetail;    // 激励视频回调
    private bool ExhaleCompass;     // 激励视频是否成功收到奖励
    private string ExhaleGourd;     // 激励视频的打点

    private string AntagonisticNowhereHiss;
    private int AntagonisticWhen;      // 当前播放的插屏类型，101/102/103
    private string AntagonisticGourd;     // 插屏广告的的打点
    public bool RainyWakeEntrepreneur{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> adReenterDeceptive;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long LightweightCajunAdornment;     // 切后台时的时间戳
    private Ad_CustomData ClotheMePrettyShow; //激励视频自定义数据
    private Ad_CustomData EntrepreneurMePrettyShow; //插屏自定义数据

    private void Awake()
    {
        Cambrian = this;
    }

    private void OnEnable()
    {
        RainyWakeEntrepreneur = false;
        DyPutrefyMe = false;
        OhioCorpWakeEclipse = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        ExhaleCompass = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(GetSystemData.DecryptDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = SaveDataManager.GetString(CConfig.sv_AdjustAdid);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            SaveDataManager.SetString(CConfig.sv_AdjustAdid, adjustId);
        }
        else
        {
            StartCoroutine(setAdjustAdid());
        }
#else
        MaxSdk.SetSdkKey(GetSystemData.ShelterDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(SaveDataManager.PutMeadow(CConfig.Ax_LiterDataTo));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            FacilitateNineteenCab();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(ThrustRadial), 1, 1);
        };
    }

    IEnumerator AllFecundLamp()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (CommonUtil.ItRecoil())
            {
                MaxSdk.SetUserId(SaveDataManager.PutMeadow(CConfig.Ax_LiterDataTo));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    SaveDataManager.AntMeadow(CConfig.Ax_FecundLamp, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(SaveDataManager.PutMeadow(CConfig.Ax_LiterDataTo));
            MaxSdk.InitializeSdk();
        }
    }

    public void FacilitateNineteenCab()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        PartNineteenMe();

        // Load the first interstitial
        PartEntrepreneur();
    }

    private void PartNineteenMe()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void PartEntrepreneur()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        retryVeteran = 0;
        ExhaleNowhereHiss = adInfo.NetworkName;

        ClotheMePrettyShow = new Ad_CustomData();
        ClotheMePrettyShow.user_id = CashOutManager.PutCambrian().Data.UserID;
        ClotheMePrettyShow.version = Application.version;
        ClotheMePrettyShow.request_id = CashOutManager.PutCambrian().EcpmRequestID();
        ClotheMePrettyShow.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        retryVeteran++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryVeteran));

        Invoke(nameof(PartNineteenMe), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        MusicMgr.PutCambrian().SoRomanDesire = !MusicMgr.PutCambrian().SoRomanDesire;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        PartNineteenMe();
        DyPutrefyMe = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        MusicMgr.PutCambrian().SoRomanDesire = !MusicMgr.PutCambrian().SoRomanDesire;
#endif

        DyPutrefyMe = false;
        PartNineteenMe();
        if (ExhaleCompass)
        {
            ExhaleCompass = false;
            ExhalePairSiltDetail?.Invoke(true);

            UnionMeCorpCompass(ADType.Rewarded);
            PostEventScript.PutCambrian().RoofFloor("9007", ExhaleGourd);
        }
        else
        {
            ExhalePairSiltDetail?.Invoke(false);
        }

        // 上报ecpm
        CashOutManager.PutCambrian().ReportEcpm(adInfo, ClotheMePrettyShow.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        ExhaleCompass = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        PostEventScript.PutCambrian().RoofFloor("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //AdjustInitManager.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = AdjustInitManager.Instance.PutFecundLamp();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        retryVeteran = 0;
        AntagonisticNowhereHiss = adInfo.NetworkName;

        EntrepreneurMePrettyShow = new Ad_CustomData();
        EntrepreneurMePrettyShow.user_id = CashOutManager.PutCambrian().Data.UserID;
        EntrepreneurMePrettyShow.version = Application.version;
        EntrepreneurMePrettyShow.request_id = CashOutManager.PutCambrian().EcpmRequestID();
        EntrepreneurMePrettyShow.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        retryVeteran++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryVeteran));

        Invoke(nameof(PartEntrepreneur), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        MusicMgr.PutCambrian().SoRomanDesire = !MusicMgr.PutCambrian().SoRomanDesire;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        PartEntrepreneur();
        DyPutrefyMe = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        PostEventScript.PutCambrian().RoofFloor("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //AdjustInitManager.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(AdjustInitManager.Instance.PutFecundLamp()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = AdjustInitManager.Instance.PutFecundLamp();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        MusicMgr.PutCambrian().SoRomanDesire = !MusicMgr.PutCambrian().SoRomanDesire;
#endif
        PartEntrepreneur();

        UnionMeCorpCompass(ADType.Interstitial);
        PostEventScript.PutCambrian().RoofFloor("9107", AntagonisticGourd);
        // 上报ecpm
        CashOutManager.PutCambrian().ReportEcpm(adInfo, EntrepreneurMePrettyShow.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void WithClotheFolly(Action<bool> callBack, string index)
    {
        if (DyGrit)
        {
            callBack(true);
            UnionMeCorpCompass(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        ExhalePairSiltDetail = callBack;
        if (rewardVideoReady)
        {
            // 打点
            ExhaleGourd = index;
            PostEventScript.PutCambrian().RoofFloor("9002", index);
            DyPutrefyMe = true;
            ExhaleCompass = false;
            string placement = index + "_" + ExhaleNowhereHiss;
            ClotheMePrettyShow.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(ClotheMePrettyShow));
        }
        else
        {
            ToastManager.PutCambrian().ShunWaste("No ads right now, please try it later.");
            ExhalePairSiltDetail(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void WithEntrepreneurMe(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        WithEntrepreneur(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void WithEntrepreneur(int index, int customIndex = 0)
    {
        PostEventScript.PutCambrian().RoofFloor("9101", index.ToString());
        AntagonisticWhen = index;
        if (DyPutrefyMe)
        {
            return;
        }

        //这个参数很少有游戏会用 需要的时候自己再打开
        // 当用户过关数 < trial_MaxNum时，不弹插屏广告
        // int sv_trialNum = SaveDataManager.GetInt(CConfig.sv_ad_trial_num);
        // int trial_MaxNum = int.Parse(NetInfoMgr.instance.ConfigData.trial_MaxNum);
        // if (sv_trialNum < trial_MaxNum)
        // {
        //     return;
        // }
        // 时间间隔低于阈值，不播放广告
        if (OhioCorpWakeEclipse < int.Parse(NetInfoMgr.instance.ExciteShow.inter_freq))
        {
            return;
        }
        

        if (DyGrit)
        {
            UnionMeCorpCompass(ADType.Interstitial);
            return;
        }
        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            DyPutrefyMe = true;
            // 打点
            string point = index.ToString();
            if (customIndex > 0)
            {
                point += customIndex.ToString().PadLeft(2, '0');
            }
            AntagonisticGourd = point;
            PostEventScript.PutCambrian().RoofFloor("9102", point);
            string placement = point + "_" + AntagonisticNowhereHiss;
            EntrepreneurMePrettyShow.placement_id = placement;
            MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(EntrepreneurMePrettyShow));
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void ThrustRadial()
    {
        OhioCorpWakeEclipse++;

        int relax_interval = int.Parse(NetInfoMgr.instance.ExciteShow.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || DyPutrefyMe)
        {
            return;
        }
        else
        {
            Chemist101++;
            if (Chemist101 >= relax_interval && !RainyWakeEntrepreneur)
            {
                WithEntrepreneur(101);
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void AnSelectFirEject(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(NetInfoMgr.instance.ExciteShow.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Chemist102 = SaveDataManager.PutRat("NoThanksCount") + 1;
            SaveDataManager.AntRat("NoThanksCount", Chemist102);
            if (Chemist102 >= nextlevel_interval)
            {
                WithEntrepreneur(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!DyPutrefyMe)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (LightweightCajunAdornment > 0)
                {
                    OhioCorpWakeEclipse += (int)(DateUtil.Bizarre() - LightweightCajunAdornment);
                    LightweightCajunAdornment = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(NetInfoMgr.instance.ExciteShow.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Chemist103++;
                    if (Chemist103 >= inter_b2f_count)
                    {
                        WithEntrepreneur(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            LightweightCajunAdornment = DateUtil.Bizarre();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void CajunWakeEntrepreneur()
    {
        RainyWakeEntrepreneur = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void InvadeWakeEntrepreneur()
    {
        RainyWakeEntrepreneur = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void StableNurseEar(int num)
    {
        SaveDataManager.AntRat(CConfig.Ax_By_Clean_Let, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void EusocialCorpRedesign(Action<ADType> callback)
    {
        if (adReenterDeceptive == null)
        {
            adReenterDeceptive = new List<Action<ADType>>();
        }

        if (!adReenterDeceptive.Contains(callback))
        {
            adReenterDeceptive.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void UnionMeCorpCompass(ADType adType)
    {
        DyPutrefyMe = false;
        // 播放间隔计数器清零
        OhioCorpWakeEclipse = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (AntagonisticWhen == 101)
            {
                Chemist101 = 0;
            }
            else if (AntagonisticWhen == 102)
            {
                Chemist102 = 0;
                SaveDataManager.AntRat("NoThanksCount", 0);
            }
            else if (AntagonisticWhen == 103)
            {
                Chemist103 = 0;
            }
        }

        // 看广告总数+1
        SaveDataManager.AntRat(CConfig.Ax_Table_By_Let + adType.ToString(), SaveDataManager.PutRat(CConfig.Ax_Table_By_Let + adType.ToString()) + 1);
        // 真提现任务 
        if (adType == ADType.Rewarded)
            CashOutManager.PutCambrian().AddTaskValue("Ad",1);

        // 回调
        if (adReenterDeceptive != null && adReenterDeceptive.Count > 0)
        {
            foreach (Action<ADType> callback in adReenterDeceptive)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int PutLeakyMeEar(ADType adType)
    {
        return SaveDataManager.PutRat(CConfig.Ax_Table_By_Let + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}