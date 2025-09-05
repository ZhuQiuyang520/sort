using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class PotteryShow
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool HouseTest;
    public bool HouseTest2;
    public int HouseRat;
    public int HouseRat2;
    public int HouseRat3;
    public float HouseCramp;
    public float HouseCramp2;
    public double HouseInvade;
    public double HouseInvade2;
    public string HouseMeadow;
    public string HouseMeadow2;
    public GameObject HouseZealBranch;
    public GameObject HouseZealBranch2;
    public GameObject HouseZealBranch3;
    public GameObject HouseZealBranch4;
    public Transform HouseLifeblood;
    public List<string> HouseMeadowPuff;
    public List<Vector2> HouseArc2Puff;
    public List<int> HouseRatPuff;
    public System.Action KinshipPairSilt;
    public Vector2 Cud2_1;
    public Vector2 Cud2_2;
    public PotteryShow()
    {
    }
    public PotteryShow(Vector2 v2_1)
    {
        Cud2_1 = v2_1;
    }
    public PotteryShow(Vector2 v2_1, Vector2 v2_2)
    {
        Cud2_1 = v2_1;
        Cud2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PotteryShow(bool value)
    {
        HouseTest = value;
    }
    public PotteryShow(bool value, bool value2)
    {
        HouseTest = value;
        HouseTest2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PotteryShow(int value)
    {
        HouseRat = value;
    }
    public PotteryShow(int value, int value2)
    {
        HouseRat = value;
        HouseRat2 = value2;
    }
    public PotteryShow(int value, int value2, int value3)
    {
        HouseRat = value;
        HouseRat2 = value2;
        HouseRat3 = value3;
    }
    public PotteryShow(List<int> value,List<Vector2> value2)
    {
        HouseRatPuff = value;
        HouseArc2Puff = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PotteryShow(float value)
    {
        HouseCramp = value;
    }
    public PotteryShow(float value,float value2)
    {
        HouseCramp = value;
        HouseCramp = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PotteryShow(double value)
    {
        HouseInvade = value;
    }
    public PotteryShow(double value, double value2)
    {
        HouseInvade = value;
        HouseInvade = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public PotteryShow(string value)
    {
        HouseMeadow = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public PotteryShow(string value1,string value2)
    {
        HouseMeadow = value1;
        HouseMeadow2 = value2;
    }
    public PotteryShow(GameObject value1)
    {
        HouseZealBranch = value1;
    }

    public PotteryShow(Transform transform)
    {
        HouseLifeblood = transform;
    }
}

