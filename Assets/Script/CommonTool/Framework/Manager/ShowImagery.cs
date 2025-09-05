using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShuiState
{
    None,
    Daoshui,
    Beidaoshui
}
public enum PopupType
{
    Vase,
    Remind,
    RollBack,
    Game,
    Home
}

public enum BasePointData
{
    home_app_level_start_20001 = 20001,
    home_app_level_end_20002 = 20002,
    home_item_item_obatin_20003 = 20003,
    home_item_item_use_20004 = 20004,
    home_app_get_coins_20005 = 20005,
    home_app_use_coins_20006 = 20006,
}

public class BaseStartGame
{
    public int Auger_On;
    public int Collagen_Thin;
    public int Sign_Thin;
    public int Ute_Thin;
}

public class BaseEndGame
{
    public int Auger_On;
    public string Auger_Brutal;
    public int Wee_Collagen_Thin;
    public int Wee_Sign_Thin;
    public int Wee_Ute_Thin;
    public int Only;
    public int Plan;
}

public class BaseGetProp
{
    public string type;
    public int Bemoan;
    public string Bee;
}
public class BaseUseProp
{
    public string type;
    public int Bemoan;
    public int Daunt;
}
public class BaseGetCoin
{
    public int Reset;
    public string Bee;
    public int Auger_On;
}
public class BaseUseCoin
{
    public int Reset;
    public string Daunt;
    public int Auger_On;
}

public static class MessageCode
{
    public static string PostwarVanishBlame= "10001";
    public static string RiskFollyTinge= "10002";
    public static string FirBring= "10003";
    public static string TextileBard= "10004";
    public static string SkiFomentBard= "10005";
    public static string BelowClick= "10006";
    public static string PostwarDistance= "10007";
    public static string XenonTireInvest= "10008";
    public static string TariffVanishReckon= "10009";
    public static string PostwarFoment= "10010";
    public static string TariffClothe= "10011";
    public static string PostwarClotheMat= "10012";
}


/// <summary>
/// 数据管理器
/// </summary>

public class ShowImagery
{
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

    public static void AntPuff(string key, int ListCount, int Number)
    {
        PlayerPrefs.SetInt(key + ListCount, Number);
        PlayerPrefs.SetInt(key, ListCount + 1);
    }

    public static List<int> PutPuff(string key)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < PlayerPrefs.GetInt(key); i++)
        {
            list.Add(PlayerPrefs.GetInt(key + i));
        }
        return list;
    }

}

public class JsonName
{
    public static string Below= "levelconfig";
    public static string Blockage= "constant";
    public static string Workweek= "Languageconfig";
    public static string Coin= "shop";
    public static string User= "colorconfig";
}

public class ConstantName
{
    public static string Rv_Bubbly= "rv_config";
    public static string Rat_Bubbly= "int_config";
    public static string Rat_cd= "int_cd";
    public static string Rat_Sift_To= "int_back_cd";
    public static string Fad_Trout= "win_coins";
    public static string FBy_By_Trout= "win_ad_coins";
    public static string Grecian_Coin_lv= "unclock_shop_lv";
    public static string Gentility_Thin= "withdrawn_nums";
    public static string Spit_Thin= "Hint_nums";
    public static string Fir_Treetop_Thin= "add_bottles_nums";
    public static string Gentility_By_Thin= "withdrawn_ad_nums";
    public static string Spit_By_Thin= "Hint_ad_nums";
    public static string Treetop_By_Thin= "bottles_ad_nums";
    public static string Gentility_Mural= "withdrawn_price";
    public static string Spit_Mural= "Hint_price";
    public static string Plaster_Mural= "bottles_price";
    public static string Suspect_Fusion= "Privacy_Policy";
    public static string Luck_Us= "Rate_Us";
    public static string Leaning_Area= "initial_coin";
    public static string Solidarity= "rateconfig";
}

public class LevelGuideInfo
{
    public class LevelGuideData
    {
        public int ClickArmyID;
    }

    public static Dictionary<int, LevelGuideData> ClickWax= new Dictionary<int, LevelGuideData>()
    {
        {0,new LevelGuideData{ClickArmyID = 0} },
        {1,new LevelGuideData{ClickArmyID = 1} }
    };
}

public class GameConfigData
{
    public int Transplant;
    public int College_Area;
    public string Tieback_Go;
    public string privacy_Seabed;
    public int Sign_Mural;
    public int Treetop_Mural;
    public int Waterfall_Mural;
    public int Lug_By_Trout;
    public int Lug_Trout;
    public int Be_Bubbly;
    public string Proportionally;
}


public class ColorConfigData
{
    public enum ConfigType
    {
        levelconfig,
        language,
        colorConfig
    }
    public class configData
    {
        public string Hiss;
        public ConfigType When;
    }

    public static List<configData> YarnPuff= new List<configData>()
    {
        new configData{Hiss = "colorconfig.json" , When = ConfigType.colorConfig},
        new configData{Hiss = "language.json" , When = ConfigType.language},
        new configData{Hiss = "levelconfig.json" , When = ConfigType.levelconfig }
    };
}
