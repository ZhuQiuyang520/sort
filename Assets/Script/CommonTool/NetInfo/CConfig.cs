/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CConfig
{
    #region 常量字段
    //登录url
    public const string GhostWan= "/api/client/user/getId?gameCode=";
    //配置url
    public const string ExciteWan= "/api/client/config?gameCode=";
    //时间戳url
    public const string WakeWan= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string AdjustWan= "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string Ax_LiterDataTo= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string Ax_LiterLizardTo= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string Ax_ItTowRecall= "sv_IsNewPlayer";

    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string Ax_FightBounsPutEject= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string Ax_FightDiverTuna= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string Ax_TowDataGoat= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string Ax_SlamCore= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string Ax_UniformitySlamCore= "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string Ax_Chimp= "sv_Token";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string Ax_UniformityChimp= "sv_CumulativeToken";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string Ax_Native= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string Ax_UniformityNative= "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string Ax_LeakyZealWake= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string Ax_GessoPutChimp= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string Ax_DayShunLuckPinon= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string Ax_UniformitySurmise= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string Ax_MortiseMindBiotic= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string Ax_TowDataGoatReckon= "sv_NewUserStepFinish";
    public const string Ax_Kind_Auger_Reset= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string Ax_GessoSite= "sv_FirstSlot";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string Ax_FecundLamp= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string Ax_By_Clean_Let= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string Ax_Table_By_Let= "sv_total_ad_num";
    /// <summary>
    /// 语言
    /// </summary>
    public const string Lid_Workweek= "Language";

    //存储当前关卡
    public const string AcidBelow= "SaveLevel";
    //存储关卡障碍色
    public const string AcidTentacleBelow= "SaveObstacleLevel";
    //存储游戏关卡轮数
    public const string AcidBelowBuck= "SaveLevelBout";
    //存储当前使用的皮肤id
    public const string AcidDNAUser= "SaveCurSkin";
    //存储已经拥有的所有颜色皮肤
    public const string AcidWetBlameUser= "SaveColorSkin";
    //存储已经拥有的所有瓶子皮肤
    public const string AcidWetArmyUser= "SaveAllVaseSkin";
    //存储当前使用的瓶子皮肤
    public const string AcidArmyUser= "SaveVaseSkin";
    //金币数量
    public const string AcidCorePierce= "SaveCoinNumber";
    //瓶子道具数量
    public const string AcidArmyBard= "SaveVaseProp";
    //提示道具数量
    public const string AcidFomentBard= "SaveRemindProp";
    //回退道具数量
    public const string AcidMaverickBard= "SaveRollbackProp";
    //是否开启商店引导
    public const string AcidOfTextClub= "SaveUnLockShop";
    //保存当前是否开启震动
    public const string AcidDepositor= "SaveVibration";
    //保存当前是否开启音乐
    public const string AcidJudge= "SaveSound";
    //保存当前是否开启音效
    public const string AcidRoman= "SaveMusic";
    //保存当前语言
    public const string AcidDistance= "SaveLanguage";
    //已完成权重关卡
    public const string ReckonEntombBelow= "FinishWeightLevel";

    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string mg_JoinerTask= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string So_JoinerXenon= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string So_ui_Technological= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string So_Ox_Alcohol= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string So_Ox_Pathogen= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string So_Ox_Perfectly= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string So_ZealForeleg= "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string So_RaftUnseen_= "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string So_HydrogenNoiseUnseen_= "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string So_BelowGinBelowUnseen= "mg_LevelMaxLevelChange";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Tang_SlamCore_Herald= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Tang_Chimp_Herald_Osprey= "Art/Tex/UI/jiangli4";

    #endregion
}
