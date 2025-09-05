using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SolveSolo
{
    Success,
    GoldNotEnough,
    DiamondNotEnouth,
    OutOfStock,
    PurchaseFailed,
    ExpNotEnouth,
    HealthNotEnough
}

public static class ErrorCodeMessage
{
    private static readonly Dictionary<SolveSolo, string> Post= new Dictionary<SolveSolo, string>
    {
        { SolveSolo.Success, "操作成功" },
        { SolveSolo.GoldNotEnough, "金币不足" },
        { SolveSolo.DiamondNotEnouth, "钻石不足" },
        { SolveSolo.OutOfStock, "库存不足" },
        { SolveSolo.PurchaseFailed, "支付失败" },
        { SolveSolo.ExpNotEnouth, "经验不足" },
        { SolveSolo.HealthNotEnough, "体力不足" }
    };

    public static string PutPottery(SolveSolo errorCode)
    {
        if (Post.TryGetValue(errorCode, out string msg))
        {
            return msg;
        }
        return errorCode.ToString(); // 如果没有找到对应的描述，返回枚举值的字符串表示
    }
}
