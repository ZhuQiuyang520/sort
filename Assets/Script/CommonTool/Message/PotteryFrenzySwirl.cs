using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class PotteryFrenzySwirl:BeerZoologist<PotteryFrenzySwirl>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<PotteryShow>> LeafcutterPottery;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private PotteryFrenzySwirl()
    {
        TactShow();
    }

    private void TactShow()
    {
        //初始化消息字典
        LeafcutterPottery = new Dictionary<string, Action<PotteryShow>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Eusocial(string key, Action<PotteryShow> action)
    {
        if (!LeafcutterPottery.ContainsKey(key))
        {
            LeafcutterPottery.Add(key, null);
        }
        LeafcutterPottery[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Slowly(string key, Action<PotteryShow> action)
    {
        if (LeafcutterPottery.ContainsKey(key) && LeafcutterPottery[key] != null)
        {
            LeafcutterPottery[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Roof(string key, PotteryShow data = null)
    {
        if (LeafcutterPottery.ContainsKey(key) && LeafcutterPottery[key] != null)
        {
            LeafcutterPottery[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Vague()
    {
        LeafcutterPottery.Clear();
    }
}
