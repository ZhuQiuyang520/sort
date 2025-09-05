using DG.Tweening;
using LitJson;
using Lofelt.NiceVibrations;
using Newtonsoft.Json;
using sf_database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    private List<LanguageconfigDB> DistancePuff= new List<LanguageconfigDB>();
    private Dictionary<int, colorconfigDB> UserWax= new Dictionary<int, colorconfigDB>();
    private List<colorconfigDB> UserPuff= new List<colorconfigDB>();

    private Stack<Action<int, string>> FirBloom= new Stack<Action<int, string>>();
    private Stack<Action<int>> SoftballBloom= new Stack<Action<int>>();
    private Stack<int> BloomWhigPierce= new Stack<int>();
    private Stack<string> BloomBlamePierce= new Stack<string>();

    public bool ItTrail{ get; set; }
    public bool ItRoman{ get; set; }
    public bool ItJudge{ get; set; }

    private void Start()
    {
        PartDistanceExcite(JsonName.Workweek);
        PartUserExcite(JsonName.User);
    }


    //判断是登陆进入还是从后台切换
    private bool ItFeat= false;
    private bool ItCompress= false;
    private GameObject CompressCut;
    private int CompressArmyGourd;
    private string CompressTitleBlame;
    private colorconfigDB CompressBlameShow;
    private int CompressSolarPierce;
    private int CompressDNAHealer;
    private Vector3 CompressTactEsoteric;
    private Action<int> CompressReckon;
    private Action CompressOfReckon;
    private Image[] CompressDiscoBuyer;
    private Image[] CompressExteriorBuyer;
    private GameObject[] CompressWormInca;
    private GameObject CompressWeb;
    private Action<int, string> CompressDetailEdgeSiltFir;
    private Action<int> CompressConnectWebBlame;
    private Action CompressVagueBlameHealer;

    //true 第一个瓶为空  false 第一个瓶不为空
    private bool ItGesso= true;

    private GameObject GessoCut;
    private int GessoArmyGourd;
    private string GessoTitleBlame;
    private colorconfigDB GessoBlameShow;
    private int GessoSolarPierce;
    private int GessoDNAHealer;
    private Vector3 GessoTactEsoteric;
    private Action<int> GessoReckon;
    private Action GessoOfReckon;
    private float Ridge;
    private Image[] GessoDiscoBuyer;
    private Image[] GessoWeekdayBuyer;
    private GameObject[] GessoWormInca;
    private GameObject GessoWeb;
    private Action<int, string> GessoDetailEdgeSiltFir;
    private Action<int> GessoConnectWebBlame;
    private Action GessoVagueBlameHealer;
    //private Action FirstActionReClick;

    private GameObject ConferWebInvest;

    private int GessoSkyMightyPierce;


    /// <summary>
    /// 瓶子倒水方法
    /// </summary>
    /// <param name="VaseIndex">瓶子序号</param>
    /// <param name="SelectObj">瓶子对象</param>
    /// <param name="ColorData">颜色数值</param>
    /// <param name="CurColor">颜色</param>
    /// <param name="ReadyNumber">预倒水值</param>
    /// <param name="CurVolume">被倒水瓶子当前容量</param>
    /// <param name="MaxVolume">瓶子最大容量</param>
    /// <param name="InitPosition">倒水瓶子位置</param>
    /// <param name="ImageArray">水图片数据</param>
    /// <param name="FanguangArray">水反光图片数组</param>
    /// <param name="QuesMark">障碍色问号数组</param>
    /// <param name="Top">水面</param>
    /// <param name="WaterLineEffect">水面特效</param>
    /// <param name="ClearColorVolume">清空颜色值回调</param>
    /// <param name="FinishDaoshui">倒水完成回调</param>
    /// <param name="FinishBeidaoshui">被倒水完成回调</param>
    /// <param name="Unfinish">未完成倒水回调</param>
    /// <param name="ReClick">动画期间不能执行其他点击操作</param>
    /// <param name="RollBackAdd">撤回倒水回调</param>
    /// <param name="RollBackSubtract">撤回被倒水回调</param>
    /// <param name="DisableProp">禁用道具回调</param>
    /// <param name="DaoshuiTopColor">倒水水面颜色值</param>
    public void ConnectRadial(int VaseIndex, GameObject SelectObj, colorconfigDB ColorData, string CurColor, int ReadyNumber, int CurVolume, int MaxVolume, Vector3 InitPosition, Image[] ImageArray, Image[] FanguangArray, GameObject[] QuesMark, GameObject Top, GameObject WaterLineEffect, Action ClearColorVolume, Action<int> FinishDaoshui, Action<int, string> FinishBeidaoshui, Action Unfinish, Action ReClick, Action<int, string> RollBackAdd, Action<int> RollBackSubtract, Action<bool> DisableProp, Action<int> DaoshuiTopColor)
    {
        if (ItCompress)
        {
            if (CurColor != null)
            {
                StepperJudge(MusicType.UIMusic.click_2);
                //瓶子抬起
                AnimationGroup.EntityByPut(SelectObj, InitPosition, () =>
                {
                    ReClick();
                });
                if (CompressCut != null)
                {
                    CompressOfReckon();
                }
                CompressCut = SelectObj;
                CompressArmyGourd = VaseIndex;
                CompressTitleBlame = CurColor;
                CompressBlameShow = ColorData;
                CompressTactEsoteric = InitPosition;
                CompressSolarPierce = ReadyNumber;
                CompressReckon = FinishDaoshui;
                CompressOfReckon = Unfinish;
                CompressDNAHealer = CurVolume;
                CompressDiscoBuyer = ImageArray;
                CompressExteriorBuyer = FanguangArray;
                CompressWormInca = QuesMark;
                CompressWeb = Top;
                CompressDetailEdgeSiltFir = RollBackAdd;
                CompressConnectWebBlame = DaoshuiTopColor;
                CompressVagueBlameHealer = ClearColorVolume;
            }
        }
        else
        {
            GessoSkyMightyPierce = 0;
            if (ItGesso)
            {
                //点击的第一个瓶子为空瓶 跳过操作
                if (CurColor != null)
                {
                    ItGesso = false;
                    GessoBlameShow = ColorData;
                    GessoCut = SelectObj;
                    GessoArmyGourd = VaseIndex;
                    GessoTitleBlame = CurColor;
                    GessoTactEsoteric = InitPosition;
                    GessoSolarPierce = ReadyNumber;
                    GessoReckon = FinishDaoshui;
                    GessoOfReckon = Unfinish;
                    GessoDNAHealer = CurVolume;
                    GessoDiscoBuyer = ImageArray;
                    GessoWeekdayBuyer = FanguangArray;
                    GessoWormInca = QuesMark;
                    GessoWeb = Top;
                    GessoDetailEdgeSiltFir = RollBackAdd;
                    GessoConnectWebBlame = DaoshuiTopColor;
                    GessoVagueBlameHealer = ClearColorVolume;

                    StepperJudge(MusicType.UIMusic.click_2);
                    //第一个瓶子抬起
                    AnimationGroup.EntityByPut(GessoCut, GessoTactEsoteric, () =>
                    {
                        ReClick();
                    }); ;
                }
            }
            else
            {
                if (GessoArmyGourd == VaseIndex)
                {
                    BeakThunder();
                    //第一个瓶子落下
                    GessoOfReckon();
                }
                else
                {
                    //第一个瓶子预倒水量 + 第二个瓶子当前已有容量 > 最大容量
                    //第二个瓶子当前容量 = 最大容量
                    if (CurVolume == MaxVolume)
                    {
                        //第一个瓶子落下
                        GessoOfReckon();
                        StepperJudge(MusicType.UIMusic.click_2);
                        //第二个瓶子抬起
                        AnimationGroup.EntityByPut(SelectObj, InitPosition, () =>
                        {
                            ReClick();
                        }); ;

                        //将第二个瓶子的数据赋值到第一个瓶子，并当做第一个瓶子处理
                        GessoCut = SelectObj;
                        ItGesso = false;
                        GessoArmyGourd = VaseIndex;
                        GessoBlameShow = ColorData;
                        GessoTitleBlame = CurColor;
                        GessoSolarPierce = ReadyNumber;
                        GessoTactEsoteric = InitPosition;
                        GessoReckon = FinishDaoshui;
                        GessoOfReckon = Unfinish;
                        GessoDNAHealer = CurVolume;
                        GessoDiscoBuyer = ImageArray;
                        GessoWeekdayBuyer = FanguangArray;
                        GessoWormInca = QuesMark;
                        GessoWeb = Top;
                        GessoDetailEdgeSiltFir = RollBackAdd;
                        GessoConnectWebBlame = DaoshuiTopColor;
                        GessoVagueBlameHealer = ClearColorVolume;
                    }
                    else
                    {
                        //当前倒水颜色 和被倒水颜色不一致 并且被倒水颜色不为空
                        if (GessoTitleBlame != CurColor && CurColor != null)
                        {
                            //第一个瓶子落下
                            GessoOfReckon();
                            StepperJudge(MusicType.UIMusic.click_2);
                            //第二个瓶子抬起
                            AnimationGroup.EntityByPut(SelectObj, InitPosition, () =>
                            {
                                ReClick();
                            }); ;

                            GessoCut = SelectObj;
                            ItGesso = false;
                            GessoArmyGourd = VaseIndex;
                            GessoBlameShow = ColorData;
                            GessoTitleBlame = CurColor;
                            GessoTactEsoteric = InitPosition;
                            GessoSolarPierce = ReadyNumber;
                            GessoReckon = FinishDaoshui;
                            GessoOfReckon = Unfinish;
                            GessoDNAHealer = CurVolume;
                            GessoDiscoBuyer = ImageArray;
                            GessoWeekdayBuyer = FanguangArray;
                            GessoWormInca = QuesMark;
                            GessoWeb = Top;
                            GessoDetailEdgeSiltFir = RollBackAdd;
                            GessoConnectWebBlame = DaoshuiTopColor;
                            GessoVagueBlameHealer = ClearColorVolume;
                        }
                        else
                        {
                            ConferWebInvest = WaterLineEffect;
                            GessoCut.transform.SetAsLastSibling();
                            //倒水过程中道具禁用
                            DisableProp(true);
                            ItCompress = true;
                            //如果预倒水量 + 第二个瓶子已有容量 > 瓶子的总量
                            //则预倒水量改为 第二个瓶子还能倒进去的量
                            if (GessoSolarPierce + CurVolume > MaxVolume)
                            {
                                //第一个瓶子未倒出去的水量
                                GessoSkyMightyPierce = GessoSolarPierce - (MaxVolume - CurVolume);
                                //实际倒水值
                                GessoSolarPierce = MaxVolume - CurVolume;
                            }
                            //倾斜值 根据瓶子剩余容量 - 实际倒水值
                            int SlantNum = GessoDNAHealer - GessoSolarPierce;
                            switch (SlantNum)
                            {
                                case 3:
                                    Ridge = 70;
                                    break;
                                case 2:
                                    Ridge = 80;
                                    break;
                                case 1:
                                    Ridge = 90;
                                    break;
                                case 0:
                                    Ridge = 100;
                                    break;
                                default:
                                    break;
                            }
                            FirBloom.Push(GessoDetailEdgeSiltFir);
                            SoftballBloom.Push(RollBackSubtract);
                            BloomWhigPierce.Push(GessoSolarPierce);
                            BloomBlamePierce.Push(GessoTitleBlame);

                            PingziCell item = GessoCut.GetComponent<PingziCell>();
                            item.CurvatureMonoid();
                            //Vector3 StartFirstPos = item.InitPosition;

                            for (int i = 0; i < GessoWormInca.Length; i++)
                            {
                                GessoWormInca[i].SetActive(false);
                            }
                            //开始倒水清空倒水瓶子的预倒水值
                            GessoVagueBlameHealer();
                            //判断瓶子的相对位置，区分被倒水瓶子和倒水瓶子的位置，区分方向
                            if (GessoCut.transform.position.x < SelectObj.transform.position.x)
                            {
                                item.Physics.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
                                for (int i = 0; i < item.WhigBlame1.Length; i++)
                                {
                                    RectTransform Coloritem = item.WhigBlame1[i].GetComponent<RectTransform>();
                                    Coloritem.pivot = new Vector2(1, 1);
                                }
                                CoalTitlePut(-Ridge, GessoSkyMightyPierce, GessoBlameShow, GessoDiscoBuyer, ImageArray, GessoWeekdayBuyer, GessoWeb, Top, GessoTactEsoteric, SelectObj, GessoDNAHealer, CurVolume, GessoSolarPierce, () =>
                                {
                                    // 倒水动画执行后 , 调用第一个瓶子的倒水完成和第二个瓶子被倒水完成
                                    GessoReckon(GessoSkyMightyPierce);
                                    FinishBeidaoshui(GessoSolarPierce, GessoTitleBlame);

                                    BeakThunder();
                                    ItCompress = false;
                                    if (CompressCut != null)
                                    {
                                        GessoBlameShow = CompressBlameShow;
                                        GessoArmyGourd = CompressArmyGourd;
                                        GessoCut = CompressCut;
                                        ItGesso = false;
                                        GessoTitleBlame = CompressTitleBlame;
                                        GessoTactEsoteric = CompressTactEsoteric;
                                        GessoSolarPierce = CompressSolarPierce;
                                        GessoReckon = CompressReckon;
                                        GessoOfReckon = CompressOfReckon;
                                        GessoDNAHealer = CompressDNAHealer;
                                        GessoDiscoBuyer = CompressDiscoBuyer;
                                        GessoWeekdayBuyer = CompressExteriorBuyer;
                                        GessoWormInca = CompressWormInca;
                                        GessoWeb = CompressWeb;
                                        GessoDetailEdgeSiltFir = CompressDetailEdgeSiltFir;
                                        GessoConnectWebBlame = CompressConnectWebBlame;
                                        GessoVagueBlameHealer = CompressVagueBlameHealer;
                                        CompressCut = null;
                                    }

                                });
                            }
                            else
                            {
                                item.Physics.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
                                for (int i = 0; i < item.WhigBlame1.Length; i++)
                                {
                                    RectTransform Coloritem = item.WhigBlame1[i].GetComponent<RectTransform>();
                                    Coloritem.pivot = new Vector2(0, 1);
                                }

                                CoalTitlePut(Ridge, GessoSkyMightyPierce, GessoBlameShow, GessoDiscoBuyer, ImageArray, GessoWeekdayBuyer, GessoWeb, Top, GessoTactEsoteric, SelectObj, GessoDNAHealer, CurVolume, GessoSolarPierce, () =>
                                {
                                    // 倒水动画执行后 , 调用第一个瓶子的倒水完成和第二个瓶子被倒水完成
                                    GessoReckon(GessoSkyMightyPierce);
                                    FinishBeidaoshui(GessoSolarPierce, GessoTitleBlame);

                                    BeakThunder();
                                    ItCompress = false;
                                    if (CompressCut != null)
                                    {
                                        GessoBlameShow = CompressBlameShow;
                                        GessoArmyGourd = CompressArmyGourd;
                                        GessoCut = CompressCut;
                                        ItGesso = false;
                                        GessoTitleBlame = CompressTitleBlame;
                                        GessoTactEsoteric = CompressTactEsoteric;
                                        GessoSolarPierce = CompressSolarPierce;
                                        GessoReckon = CompressReckon;
                                        GessoOfReckon = CompressOfReckon;
                                        GessoDNAHealer = CompressDNAHealer;
                                        GessoDiscoBuyer = CompressDiscoBuyer;
                                        GessoWeekdayBuyer = CompressExteriorBuyer;
                                        GessoWormInca = CompressWormInca;
                                        GessoWeb = CompressWeb;
                                        GessoDetailEdgeSiltFir = CompressDetailEdgeSiltFir;
                                        GessoConnectWebBlame = CompressConnectWebBlame;
                                        GessoVagueBlameHealer = CompressVagueBlameHealer;
                                        CompressCut = null;
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
    }

    //点击撤回后取出需要撤回的数据
    public void EdgeSiltCheep()
    {
        if (BloomWhigPierce.Count > 0)
        {
            if (GessoCut != null)
            {
                GessoOfReckon();
                BeakThunder();
            }
            if (ConferWebInvest.activeSelf && ConferWebInvest!= null)
            {
                ConferWebInvest.SetActive(false);
            }
            int ReadyNumber = BloomWhigPierce.Pop();
            string WaterColor = BloomBlamePierce.Pop();
            Action<int, string> AcAdd = FirBloom.Pop();
            Action<int> AcSubtract = SoftballBloom.Pop();
            AcAdd(ReadyNumber, WaterColor);
            AcSubtract(ReadyNumber);
            MessageManager.PutCambrian().Afternoon(MessageCode.PostwarFoment);
        }
    }
    //根据当前数据数量判断是否可以继续撤回
    public int EdgeSiltEar()
    {
        return BloomWhigPierce.Count;
    }

    //当瓶子完成后，数据不能撤回
    public void PassionEdgeSilt()
    {
        BloomWhigPierce.Clear();
        BloomBlamePierce.Clear();
        FirBloom.Clear();
        SoftballBloom.Clear();
    }

    //倒水后重置状态  
    //第二次点击相同的对象，重置状态
    public void BeakThunder()
    {
        ItGesso = true;
    }

    public void SkiBardTact()
    {
        if (!ItGesso)
        {
            GessoOfReckon();
            BeakThunder();
        }
    }

    //用来判断当前有没有点击起来的瓶子
    public bool DetailGessoCut()
    {
        return ItGesso;
    }

    //回调当前抬起的瓶子的索引
    public int DetailGessoGourd()
    {
        return GessoArmyGourd;
    }

    /// <summary>
    /// UI的世界坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 LiterInput2EyelidInput(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为世界坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 EyelidInput2LiterInput(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public void PartDistanceExcite(string JsonName)
    {
        string json = Resources.Load<TextAsset>("LocationJson/" + JsonName).text;
        DistancePuff = JsonConvert.DeserializeObject<List<LanguageconfigDB>>(json);
    }

    public List<LanguageconfigDB> PutDistanceShow()
    {
        return DistancePuff;
    }

    //获取皮肤
    public void  PartUserExcite(string JsonName)
    {
        string json = Resources.Load<TextAsset>("LocationJson/" + JsonName).text;

        UserPuff = JsonConvert.DeserializeObject<List<colorconfigDB>>(json);
    }

    //刷新当前皮肤下水的色值
    public void PartDNAUser()
    {
        UserWax.Clear();
        int CurSkin = PlayerPrefs.GetInt(DataManager.AcidDNAUser);
        int BlameGroup= 0;
        foreach (var item in NetInfoMgr.instance.ZealShow.shop)
        {
            if (CurSkin == item.id && item.type == 2)
            {
                BlameGroup = item.colorgroup;
                break;
            }
        }
        foreach (var item in UserPuff)
        {
            if (item.group == BlameGroup)
            {
                UserWax.Add(item.id, item);
            }
        }
    }
    public Dictionary<int , colorconfigDB> PutUserShow()
    {
        return UserWax;
    }
    /// <summary>
    /// 倒水动画打包
    /// </summary>
    /// <param name="A">角度</param>
    /// <param name="WaterColor">水颜色</param>
    /// <param name="DaoshuiImageArray">倒水数组</param>
    /// <param name="BeidaoshuiImageArray">被倒水数组</param>
    /// <param name="ImageFanguangArray">反光数组</param>
    /// <param name="DaohuiTop">倒水水面</param>
    /// <param name="BeidaoshuiTop">被倒水水面</param>
    /// <param name="StartFirstPos">位置起始值</param>
    /// <param name="SelectObj">选中</param>
    /// <param name="FristCurVolme">首次剩余</param>
    /// <param name="CurVolme">剩余</param>
    /// <param name="FirstReadyNumber">首次预倒水</param>
    /// <param name="finish">回调</param>
    public void CoalTitlePut(float A,int NotVolume, colorconfigDB WaterColor,Image[] DaoshuiImageArray, Image[] BeidaoshuiImageArray, Image[] ImageFanguangArray, GameObject DaohuiTop, GameObject BeidaoshuiTop, Vector3 StartFirstPos, GameObject SelectObj, int FristCurVolme, int CurVolme, int FirstReadyNumber, Action finish)
    {
        //倒水准备
        AnimationGroup.StretcherCoalTitlePut(GessoCut, A, SelectObj.transform.position, DaoshuiImageArray, DaohuiTop, () =>
        {
            StepperJudge(MusicType.UIMusic.PourWater);
            //被倒水
            AnimationGroup.TheApplySymbolizeCoalTitle(NotVolume,BeidaoshuiImageArray, SelectObj, WaterColor, BeidaoshuiTop, CurVolme, A, FristCurVolme, FirstReadyNumber, GessoConnectWebBlame);
            //正在倒水
            AnimationGroup.CoalTitlePutInProfound(GessoCut, A, DaoshuiImageArray, DaohuiTop, FristCurVolme, () =>
            {
                StepperTheyJudge(MusicType.UIMusic.PourWater);
                //倒水完成
                AnimationGroup.CoalTitlePutLowa(GessoCut, StartFirstPos, FristCurVolme, FirstReadyNumber, A, DaoshuiImageArray, ImageFanguangArray, DaohuiTop, () =>
                {
                    finish?.Invoke();
                });
            });
        });
    }

    

    public void StepperTrail(HapticPatterns.PresetType type)
    {
        if (ItTrail)
        {
            HapticPatterns.PlayPreset(type);
        }
    }
    public void StepperJudge(MusicType.UIMusic sfx)
    { 
        if (ItJudge)
        {
            //AudioManager.Instance.PlaySFX(sfx);
            MusicMgr.PutCambrian().CorpInvest(sfx);
        }
    }
    //暂定指定的音效
    public void StepperTheyJudge(MusicType.UIMusic sfx)
    {
        if (ItJudge)
        {

            //AudioManager.Instance.StopSFX(sfx);
            //MusicMgr.GetInstance().StopEffect(sfx);
        }
    }

    private LevelGuideInfo.LevelGuideData DNAStyShow;
    public LevelGuideInfo.LevelGuideData BelowClick(int CurStep)
    {
        if (LevelGuideInfo.ClickWax.ContainsKey(CurStep))
        {
            DNAStyShow = LevelGuideInfo.ClickWax[CurStep];
        }
        else
        {
            DNAStyShow = null;
        }
        return DNAStyShow;
    }

    public void EyelidConcentrate(RectTransform ObjRect)
    {
        //ObjRect.localScale = new Vector2((float)Screen.width / 1080, (float)Screen.width / 1080);
    }

    public List<string> VerifyEar(int wantNum, int dataCount)
    {
        System.Random random = new System.Random();
        HashSet<int> values = new HashSet<int>();
        List<string> list = new List<string>();
        int n;
        while (values.Count < wantNum)
        {
            n = random.Next(0, dataCount);

            if (values.Add(n))
            {
                list.Add(n.ToString());
            }
        }
        return list;
    }
}

public class RewardPanelData
{
    /// <summary>
    /// 小游戏类型
    /// </summary>
    public string JustWhen;
    public Dictionary<RewardType, double> Wax_Clothe;

    public RewardPanelData()
    {
        Wax_Clothe = new();
    }
}






