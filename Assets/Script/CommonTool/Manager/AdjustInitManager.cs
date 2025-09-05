using System;
using System.Collections;
using com.adjust.sdk;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdjustInitManager : MonoBehaviour
{
    public static AdjustInitManager Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string VirginID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string sv_ADTreeTactWhen= "sv_ADJustInitType";

    //adjust 时间戳
    private string Ax_ADTreeWake= "sv_ADJustTime";

    //adjust行为计数器
    public int _FestiveEject{ get; private set; }

    public double _FestiveCompost{ get; private set; }

    double VirginTactMeCompost= 0;


    private void Awake()
    {
        Instance = this;
        SaveDataManager.AntMeadow(Ax_ADTreeWake, DateUtil.Bizarre().ToString());

#if UNITY_IOS
        SaveDataManager.AntMeadow(sv_ADTreeTactWhen, AdjustStatus.OpenAsAct.ToString());
        FecundTact();
#endif
    }

    private void Start()
    {
        _FestiveEject = 0;
    }


    void FecundTact()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(VirginID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);

        StartCoroutine(AcidFecundLamp());
    }

    private IEnumerator AcidFecundLamp()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                SaveDataManager.AntMeadow(CConfig.Ax_FecundLamp, adjustAdid);
                NetInfoMgr.instance.RoofFecundLamp();
                yield break;
            }
        }
    }

    public string PutFecundLamp()
    {
        return SaveDataManager.PutMeadow(CConfig.Ax_FecundLamp);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string PutFecundMonoid()
    {
        return SaveDataManager.PutMeadow(sv_ADTreeTactWhen);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void TactFecundShow(bool isOldUser = false)
    {
        #if UNITY_IOS
            return;
        #endif
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(NetInfoMgr.instance.ExciteShow.adjust_init_act_position) || int.Parse(NetInfoMgr.instance.ExciteShow.adjust_init_act_position) <= 0)
        {
            SaveDataManager.AntMeadow(sv_ADTreeTactWhen, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + SaveDataManager.PutMeadow(sv_ADTreeTactWhen));
        //用户二次登录 根据标签初始化
        if (SaveDataManager.PutMeadow(sv_ADTreeTactWhen) == AdjustStatus.OldUser.ToString() || SaveDataManager.PutMeadow(sv_ADTreeTactWhen) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            FecundTact();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void FirAskEject(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (SaveDataManager.PutMeadow(sv_ADTreeTactWhen) != "") return;
        _FestiveEject++;
        print(" add up to :" + _FestiveEject);
        if (string.IsNullOrEmpty(NetInfoMgr.instance.ExciteShow.adjust_init_act_position) || _FestiveEject == int.Parse(NetInfoMgr.instance.ExciteShow.adjust_init_act_position))
        {
            PartFecundOrAsk(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void FirMeEject(string countryCode, double revenue)
    {
#if UNITY_IOS
            return;
#endif
        //if (SaveDataManager.GetString(sv_ADJustInitType) != "") return;

        _FestiveEject++;
        _FestiveCompost += revenue;
        print(" Ads count: " + _FestiveEject + ", Revenue sum: " + _FestiveCompost);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(NetInfoMgr.instance.ExciteShow.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(NetInfoMgr.instance.ExciteShow.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                VirginTactMeCompost = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(NetInfoMgr.instance.ExciteShow.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_FestiveEject == int.Parse(NetInfoMgr.instance.ExciteShow.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _FestiveCompost >= VirginTactMeCompost)
        )
        {
            PartFecundOrAsk();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void PartFecundOrAsk(string param2 = "")
    {
        if (SaveDataManager.PutMeadow(sv_ADTreeTactWhen) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(NetInfoMgr.instance.ExciteShow.adjust_init_rate_act) || int.Parse(NetInfoMgr.instance.ExciteShow.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            SaveDataManager.AntMeadow(sv_ADTreeTactWhen, AdjustStatus.OpenAsAct.ToString());
            FecundTact();

            // 上报点位 新用户达成 且 初始化
            PostEventScript.PutCambrian().RoofFloor("1091", PutFecundWake(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            SaveDataManager.AntMeadow(sv_ADTreeTactWhen, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            PostEventScript.PutCambrian().RoofFloor("1092", PutFecundWake(), param2);
        }
    }

    
    /*
     * API
     *  重置当前次数
     */
    public void AmpleAskEject()
    {
        print("clear current ");
        _FestiveEject = 0;
    }


    // 获取启动时间
    private string PutFecundWake()
    {
        return DateUtil.Bizarre() - long.Parse(SaveDataManager.PutMeadow(Ax_ADTreeWake)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}