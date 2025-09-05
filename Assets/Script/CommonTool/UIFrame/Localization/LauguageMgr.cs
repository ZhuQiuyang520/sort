/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauguageMgr 
{
    public static LauguageMgr _Sectional;
    //语言翻译的缓存集合
    private Dictionary<string, string> _WaxMedicineStand;

    private LauguageMgr()
    {
        _WaxMedicineStand = new Dictionary<string, string>();
        //初始化语言缓存集合
        TactMedicineStand();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static LauguageMgr PutCambrian()
    {
        if (_Sectional == null)
        {
            _Sectional = new LauguageMgr();
        }
        return _Sectional;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string ShunHand(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_WaxMedicineStand!=null && _WaxMedicineStand.Count >= 1)
        {
            _WaxMedicineStand.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void TactMedicineStand()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        IConfigManager config = new ConfigManagerByJson("LauguageJSONConfig");
        if (config != null)
        {
            _WaxMedicineStand = config.IceStepper;
        }
    }
}
