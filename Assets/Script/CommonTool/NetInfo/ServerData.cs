using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//登录服务器返回数据
public class RootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public ServerData data { get; set; }
}
//用户登录信息
public class ServerUserData
{
    public int code { get; set; }
    public string msg { get; set; }
    public int data { get; set; }
}

public class UserRootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public string data { get; set; }
}

public class LocationData
{
    public double X;
    public double Y;
    public double Radius;
}

public class UserInfoData
{
    public double lat;
    public double lon;
    public string query; //ip地址
    public string regionName; //地区名称
    public string city; //城市名称
    public bool IsHaveApple; //是否有苹果
}

public class BlockRuleData //屏蔽规则
{
    public LocationData[] LocationList; //屏蔽位置列表
    public string[] CityList; //屏蔽城市列表
    public string[] IPList; //屏蔽IP列表
    public string fall_down; //自然量
    public bool BlockVPN; //屏蔽VPN
    public bool BlockSimulator; //屏蔽模拟器
    public bool BlockRoot; //屏蔽root
    public bool BlockDeveloper; //屏蔽开发者模式
    public bool BlockUsb; //屏蔽USB调试
    public bool BlockSimCard; //屏蔽SIM卡
}

//服务器的数据
public class ServerData
{
    public string BlockRule { get; set; } //屏蔽规则
    public string fall_down { get; set; }
    public string HeiNameList { get; set; } //IP黑名单列表
    public string LocationList { get; set; } //黑位置列表
    public string HeiCity { get; set; } //城市黑名单列表

    public string init { get; set; }
    public string init_ru { get; set; }
    public string init_br { get; set; }
    public string init_jp { get; set; }
    public string init_us { get; set; }
    public string version { get; set; }

    public string apple_pie { get; set; }
    public string inter_b2f_count { get; set; }
    public string inter_freq { get; set; }
    public string relax_interval { get; set; }
    public string trial_MaxNum { get; set; }
    public string nextlevel_interval { get; set; }
    public string adjust_init_rate_act { get; set; }
    public string adjust_init_act_position { get; set; }
    public string adjust_init_adrevenue { get; set; }
    public string soho_shop { get; set; }
    public string soho_shop_jp { get; set; }
    public string soho_shop_br { get; set; }
    public string soho_shop_ru { get; set; }
    public string soho_shop_us { get; set; }
    public string GameData { get; set; }

    public string LevelData { get; set; }

    public string level_change { get; set; }

    public string task_data { get; set; }
    public string task_data_jp { get; set; }
    public string task_data_br { get; set; }
    public string task_data_ru { get; set; }
    public string task_data_us { get; set; }

    public string CashOut_Data { get; set; } //真提现数据
    public string CashOut_MoneyName { get; set; } //货币名称
    public string CashOut_Description { get; set; } //玩法描述
    public string convert_goal { get; set; } //兑换目标

}

public class CashOutData //提现
{
    public string MoneyName; //货币名称
    public string Description; //玩法描述
    public string convert_goal; //兑换目标
    public List<CashOut_TaskData> TaskList; //任务列表
}

public class CashOut_TaskData
{
    public string Name; //任务名称
    public float NowValue; //当前值
    public double Target; //目标值
    public string Description; //任务描述
    public bool IsDefault; //是否默认（循环）任务
}

public class TurnRewardData
{
    public string type;
    public double weight;
    public double num;
}

public class RewardData
{
    public string type; // 奖励类型（如"Cash"）
    public int reward_num; // 奖励数量
}

public class Init
{
    public List<SlotItem> slot_group { get; set; }

    public double[] cash_random { get; set; }
    public MultiGroup[] cash_group { get; set; }
    public MultiGroup[] gold_group { get; set; }
    public MultiGroup[] amazon_group { get; set; }
}

public class SlotItem
{
    public double multi { get; set; }
    public int weight { get; set; }
}

public class MultiGroup
{
    public int max { get; set; }
    public int multi { get; set; }
    public double weight_multi { get; set; }
}

public class TaskItemData
{
    public string type { get; set; }
    public int num { get; set; }
    public string des { get; set; }
    public string reward_type { get; set; }
    public double rewad_num { get; set; }

}

public class Task_Data
{
    public List<List<TaskItemData>> task_list { get; set; }
    public List<int> reset_time_list { get; set; }
    public List<int> reset_now_ad_list { get; set; }
}

public class LevelConfig
{
    public int ID; // 主键id
    public string Layout; // 种子
    public int Mask; // 屏蔽关卡
    public string Reward_Position; // 奖励位置
    public double Reward_Mult; // 奖励系数
}

public class LevelInfo
{
    public int LevelID;
    public int LevelData;
}

public class ShopConfig
{
    public int type; // 商品类型
    public int id; // 商品序列
    public int unclock_lv; // 解锁等级
    public int price; // 价格
    public string pic; // 资源名
    public int colorgroup; // 颜色组别
}

public class ConstantConfig
{
    public int id; // 主键id
    public string key; // 标识
    public string value; // 值
    public string desc; // 描述
}

public class Game_Data
{
    public int coin_fly_count;
    public int diamond_fly_count;
    public int bubble_cd;
    public RewardData bubbledata; // 气泡奖励列表
    public RewardData vaildData;  //有效操作

    public RewardData rewardvaseData;  //奖励瓶子
  
    
    public List<TurnRewardData> wheel_reward_weight_group;
    public WheelMultiGroup wheel_reward_multi;

    public List<ShopConfig> shop;

    public InitGameData initgamedata;

}

public class InitGameData
{
    public int TurntableValue;
    public double win_coins;
    public double Win_Diamonds;
    public string Privacy_Policy;
    public int unclock_shop_lv;
    public int withdrawn_nums;
    public int Hint_nums;
    public int add_bottles_nums;
    public int withdrawn_ad_nums;
    public int Hint_ad_nums;
    public int bottles_ad_nums;
    public int withdrawn_price;
    public int Hint_price;
    public int bottles_price;
    public string Contact_Us;
    public int initial_coin;
    public int rateconfig;
    //过关奖励现金金额
    public double level_complete_cash_num
    {
        get
        {
            return Win_Diamonds * GameUtil.GetCashMulti();
        }
        set
        {
            Win_Diamonds = value;
        }
    }
}

public class WheelMultiGroup
{
    public WheelMultiItem[] diamand;
    public WheelMultiItem[] gold;
    public WheelMultiItem[] add;
    public WheelMultiItem[] roll;
    public WheelMultiItem[] remind;
}

public class WheelMultiItem
{
    public double weight;
    public double multi;
    public int num;
}
