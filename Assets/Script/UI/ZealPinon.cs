using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using sf_database;
using System.Linq;
using DG.Tweening;
using static RomanWhen;

/// <summary>
/// GamePanelView - 自动生成的UI视图脚本
/// </summary>
public class ZealPinon : TurnUIShiny
{
    public static ZealPinon instance;
[UnityEngine.Serialization.FormerlySerializedAs("CaseEnter")]   
#region UI组件
    public GameObject SlipApril;
[UnityEngine.Serialization.FormerlySerializedAs("TopArray")]    public GameObject WebBuyer;
[UnityEngine.Serialization.FormerlySerializedAs("BtnArray")]    public GameObject ShyBuyer;
[UnityEngine.Serialization.FormerlySerializedAs("ShopBtn")]    public Button ClubShy;
[UnityEngine.Serialization.FormerlySerializedAs("AddAfresh")]    public Button FirMaster;
[UnityEngine.Serialization.FormerlySerializedAs("AddVase")]    public Button FirArmy;
[UnityEngine.Serialization.FormerlySerializedAs("AddRemind")]    public Button FirFoment;
[UnityEngine.Serialization.FormerlySerializedAs("AddRollBack")]    public Button FirEdgeSilt;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button StepperShy;
[UnityEngine.Serialization.FormerlySerializedAs("FinishBtn")]    public Button ReckonShy;
[UnityEngine.Serialization.FormerlySerializedAs("FailBtn")]    public Button RiskShy;
[UnityEngine.Serialization.FormerlySerializedAs("TurnBtn")]    public Button RimeShy;
[UnityEngine.Serialization.FormerlySerializedAs("InputField")]    public InputField DwellJoint;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public GameObject Erie;
[UnityEngine.Serialization.FormerlySerializedAs("GuideTip")]    public Text ClickMob;
[UnityEngine.Serialization.FormerlySerializedAs("UseRollBackBtn")]
    public Button SkiEdgeSiltShy;
[UnityEngine.Serialization.FormerlySerializedAs("UseRemindBtn")]    public Button SkiFomentShy;
[UnityEngine.Serialization.FormerlySerializedAs("UseVaseBtn")]    public Button SkiArmyShy;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]
    public Text BelowBias;
[UnityEngine.Serialization.FormerlySerializedAs("VaseTip")]
    public GameObject ArmyMob;
[UnityEngine.Serialization.FormerlySerializedAs("VaseTipDesc")]    public Text ArmyMobBias;
[UnityEngine.Serialization.FormerlySerializedAs("RemindTip")]    public GameObject FomentMob;
[UnityEngine.Serialization.FormerlySerializedAs("RemindDesc")]    public Text FomentBias;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackTip")]    public GameObject EdgeSiltMob;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackDesc")]    public Text EdgeSiltBias;
[UnityEngine.Serialization.FormerlySerializedAs("PropMask")]    public GameObject BardGlue;
[UnityEngine.Serialization.FormerlySerializedAs("Layout")]
    public ViewResumeBelowAt Resume;
[UnityEngine.Serialization.FormerlySerializedAs("ScrollViewObj")]    public GameObject DetachHoldCut;
[UnityEngine.Serialization.FormerlySerializedAs("Content")]    public Transform Kinetic;
[UnityEngine.Serialization.FormerlySerializedAs("ItemCell")]    public GameObject RaftLack;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_Sceen")]    public ParticleSystem By_Magic;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
    public GameObject CoreSoup;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    public Transform AlaMat;
[UnityEngine.Serialization.FormerlySerializedAs("TurnIcon")]
    public Image RimeSoup;
[UnityEngine.Serialization.FormerlySerializedAs("RewardContent")]
    public Transform ClotheKinetic;

    public Image Mask;

    private float DNARimeDiverFlash;

    private string BelowTentacle;

    private Dictionary<string, int> TheseWax= new Dictionary<string, int>();
    
    private Dictionary<int, Stack<string>> ArmyWax= new Dictionary<int, Stack<string>>();
    private List<LevelConfig> BelowPuff= new List<LevelConfig>();
    private LevelConfig DNABelowLady;
    private int DNABelowID;
    private int ReckonPierce;

    private int GinReckonPierce;
    private bool BelowReckon;

    private int ArmyBardPierce;
    private int FomentBardPierce;
    private int MaverickBardPierce;
    private string LaceVanishBlame= "";
    private int ArmyGinHealer= 0;
    private LevelGuideInfo.LevelGuideData DNAClickShow= new LevelGuideInfo.LevelGuideData();
    private int DNAClickGoat= 0;
    private bool ItClick= true;
    private bool ItClubClick= false;
    private bool ItTaskGlue= false;
    private int ClubDecode;

    private List<string> ClotheArmy;

    //埋点数据
    private int TurnAlaSkiPolitics;
    private int TurnAlaSkiSpit;
    private int TurnAlaSkiFir;
    private float TurnAlaWake;
    private int TurnAlaGoat;
    private bool CajunAlaWake;

    private BaseStartGame ReferZeal;
    private BaseEndGame AlaZeal;
    private BaseUseProp SkiBard;

    private string[] AugerLady;
    private string[] BelowStepper;
    private string[] BelowBlame;

    private Sequence WangzhuanSequence;

    //道具 和失败 产生的瓶子数量。
    private int BardPierce= 0;
    #endregion

    #region 生命周期函数

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        PotteryImagery.PutCambrian().FirChapbook<PopupType>(MessageCode.FirBring, UnseenBringPierce);
        PotteryImagery.PutCambrian().FirChapbook(MessageCode.PostwarDistance, PostwarDistance);
        PotteryImagery.PutCambrian().FirChapbook(MessageCode.RiskFollyTinge, RiskPostwarArmy);
        ClubDecode = RatLadyTen.instance.ZealShow.initgamedata.unclock_shop_lv;
        BelowPuff = RatLadyTen.instance.BelowExciteShow;
    }

    private void Start()
    {
        ClubShy.onClick.AddListener(TaskClub);
        FirMaster.onClick.AddListener(UnseenArabian);
        FirArmy.onClick.AddListener(UnseenFirArmy);
        FirFoment.onClick.AddListener(UnseenFirFoment);
        FirEdgeSilt.onClick.AddListener(UnseenFirEdgeSilt);
        StepperShy.onClick.AddListener(TaskStepper);

        SkiEdgeSiltShy.onClick.AddListener(UnseenSkiEdgeSilt);
        SkiFomentShy.onClick.AddListener(UnseenSkiFoment);
        SkiArmyShy.onClick.AddListener(UnseenSkiArmy);

        ReckonShy.onClick.AddListener(GritReckon);
        RiskShy.onClick.AddListener(GritRisk);
        RimeShy.onClick.AddListener(LintRime);

        DNARimeDiverFlash = 0;

        ZealImagery.PutCambrian().EyelidConcentrate(ShyBuyer.GetComponent<RectTransform>());
        ZealImagery.PutCambrian().EyelidConcentrate(WebBuyer.GetComponent<RectTransform>());
        ZealImagery.PutCambrian().EyelidConcentrate(Erie.GetComponent<RectTransform>());
        ZealImagery.PutCambrian().EyelidConcentrate(Kinetic.GetComponent<RectTransform>());

        if (!InnateWine.ItOxide())
        {
            SlipApril.SetActive(true);
            RimeSoup.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        PotteryImagery.PutCambrian().SlowlyChapbook<PopupType>(MessageCode.FirBring, UnseenBringPierce);
        PotteryImagery.PutCambrian().SlowlyChapbook(MessageCode.PostwarDistance, PostwarDistance);
        PotteryImagery.PutCambrian().SlowlyChapbook(MessageCode.RiskFollyTinge, RiskPostwarArmy);
        //PotteryImagery.GetInstance().RemoveListener(MessageCode.CreatePingziFinish, SettingLayout);
    }
    //购买道具后刷新道具数量
    public void UnseenBringPierce(PopupType type)
    {
        switch (type)
        {
            case PopupType.Vase:
                ArmyBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidArmyBard);
                ArmyMob.SetActive(true);
                ArmyMobBias.text = ArmyBardPierce.ToString();
                break;
            case PopupType.Remind:
                FomentBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidFomentBard);
                FomentMob.SetActive(true);
                FomentBias.text = FomentBardPierce.ToString();
                break;
            case PopupType.RollBack:
                MaverickBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidMaverickBard);
                EdgeSiltMob.SetActive(true);
                EdgeSiltBias.text = MaverickBardPierce.ToString();
                break;
            default:
                break;
        }
    }

    private void TextileBard(bool IsDisable)
    {
        BardGlue.SetActive(IsDisable);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        BelowReckon = false;
        CajunAlaWake = true;
        TurnAlaWake = 0;
        TurnAlaGoat = 0;
        ReferZeal = new BaseStartGame();
        AlaZeal = new BaseEndGame();
        SkiBard = new BaseUseProp();

        ItTaskGlue = false;
        Resume.enabled = true;
        ArmyBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidArmyBard);
        FomentBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidFomentBard);
        MaverickBardPierce = PlayerPrefs.GetInt(ShowImagery.AcidMaverickBard);


        if (ArmyBardPierce > 0)
        {
            ArmyMob.SetActive(true);
            ArmyMobBias.text = ArmyBardPierce.ToString();
        }
        else
        {
            ArmyMob.SetActive(false);
        }

        if (FomentBardPierce > 0)
        {
            FomentMob.SetActive(true);
            FomentBias.text = FomentBardPierce.ToString();
        }
        else
        {
            FomentMob.SetActive(false);
        }

        if (MaverickBardPierce > 0)
        {
            EdgeSiltMob.SetActive(true);
            EdgeSiltBias.text = MaverickBardPierce.ToString();
        }
        else
        {
            EdgeSiltMob.SetActive(false);
        }
        

        //处理新手玩家
        if (PlayerPrefs.GetInt(ShowImagery.AcidBelow) == 0)
        {
            PlayerPrefs.SetInt(ShowImagery.AcidBelow, 1);
            DNABelowID = 1;
        }
        else
        {
            DNABelowID = PlayerPrefs.GetInt(ShowImagery.AcidBelow);
        }
        //关卡进入埋点数据
        ReferZeal.Auger_On = DNABelowID;
        ReferZeal.Collagen_Thin = MaverickBardPierce;
        ReferZeal.Sign_Thin = FomentBardPierce;
        ReferZeal.Ute_Thin = ArmyBardPierce;

        AlaZeal.Auger_On = DNABelowID;

        StepperShy.gameObject.SetActive(true);
        FirMaster.gameObject.SetActive(true);
        SkiEdgeSiltShy.gameObject.SetActive(true);
        SkiFomentShy.gameObject.SetActive(true);
        SkiArmyShy.gameObject.SetActive(true);
        ClickMob.gameObject.SetActive(false);
        Erie.SetActive(false);
        //第一关的新手引导
        if (DNABelowID == 1)
        {
            StepperShy.gameObject.SetActive(false);
            FirMaster.gameObject.SetActive(false);
            SkiEdgeSiltShy.gameObject.SetActive(false);
            SkiFomentShy.gameObject.SetActive(false);
            SkiArmyShy.gameObject.SetActive(false);
            ClickMob.gameObject.SetActive(true);
            Erie.SetActive(true);
            ClickMob.text = "Click to pour water";

            DNAClickShow = ZealImagery.PutCambrian().BelowClick(DNAClickGoat);
            
        }
        else if (DNABelowID == 2)
        {
            StepperShy.gameObject.SetActive(false);
            FirMaster.gameObject.SetActive(false);
            SkiEdgeSiltShy.gameObject.SetActive(false);
            SkiFomentShy.gameObject.SetActive(false);
            SkiArmyShy.gameObject.SetActive(false);
            ClickMob.gameObject.SetActive(true);
            ClickMob.text = "Only water of the same color can be poured on top of each other";
        }
        else if (DNABelowID == 3 && PlayerPrefs.GetString(ShowImagery.LevelGuide) == "0")
        {
            if (!InnateWine.ItOxide())
            {
                Mask.gameObject.SetActive(true);
                Color MaskColir = new Color();
                MaskColir.a = 0.85f;
                Mask.color = MaskColir;
                WangzhuanSequence = DOTween.Sequence();
                WangzhuanSequence.Append(SlipApril.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f).SetLoops(10, LoopType.Yoyo))
                    .SetDelay(2)
                    .SetLoops(-1);
            }
        }
        else if (DNABelowID == ClubDecode)
        {
            ClubShy.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt(ShowImagery.AcidOfTextClub) == 0)
            {
                ItClubClick = true;
                Erie.SetActive(true);
                Erie.transform.position = ClubShy.transform.position;
                CurvatureBelow.EriePut(Erie, ClubShy.transform.position, true);
            }
        }
        else if (DNABelowID > ClubDecode)
        {
            ClubShy.gameObject.SetActive(true);
        }
        


        //根据轮数选择关卡
        //当轮数>=3的时候 加载权重字典 加载剩余关卡
        //if (PlayerPrefs.GetInt(ShowImagery.SaveLevelBout) >= 3)
        //{
        //    int RandomWeight = UnityEngine.Random.Range(1, ZealImagery.GetInstance().AllWeight);
        //    foreach (var item in ZealImagery.GetInstance().GetLevelWeight())
        //    {
        //        RandomWeight -= item.Value;
        //        if (RandomWeight <= 0)
        //        {
        //            CurLevelID = item.Key;
        //        }
        //    }
        //}
        if (PlayerPrefs.GetInt(ShowImagery.AcidBelowBuck) >= 2)
        {
            if (BelowPuff.Count < DNABelowID)
            {
                DNABelowID = DNABelowID - BelowPuff.Count - ((BelowPuff.Count - 30) * ((PlayerPrefs.GetInt(ShowImagery.AcidBelowBuck) - 2))) + 29;
            }
        }
        DNABelowLady = new LevelConfig();
        DNABelowLady = BelowPuff.Find(x => x.ID == DNABelowID);

        //0关卡设置  1颜色设置  2关卡轮回
        AugerLady = DNABelowLady.Layout.Split("|");
        BelowStepper = AugerLady[0].Split("_");
        BelowBlame = AugerLady[1].Split(",");
        ClotheArmy = new List<string>();
        if (DNABelowID > 2)
        {
            ClotheArmy = ZealImagery.PutCambrian().VerifyEar(2, int.Parse(BelowStepper[1]));
        }
        
        //CurLevelID = RatLadyTen.instance.LevelList.Find(x => x.LevelID == CurLevelID).LevelData;
        MasterRefer();
        if (ClotheKinetic.childCount > 0)
        {
            for (int i = 0; i < ClotheKinetic.childCount; i++)
            {
                Destroy(ClotheKinetic.GetChild(i).gameObject);
            }
        }
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            PotteryImagery.PutCambrian().Afternoon(MessageCode.TariffClothe, ClotheKinetic);
        })
        .SetDelay(0.15f)
        .SetLoops(0);
    }

    public void CloseWangzhuanMask()
    {
        if (Mask.gameObject.activeSelf)
        {
            Mask.gameObject.SetActive(false);
            WangzhuanSequence.Kill();
            SlipApril.transform.localScale = Vector3.one;
        }
    }

    private void PostwarDistance()
    {
        BelowBias.text = "Level " + PlayerPrefs.GetInt(ShowImagery.AcidBelow);
    }

    public void MasterRefer()
    {
        TheseWax = new Dictionary<string, int>();
        PostwarDistance();
        if (ArmyWax.Count > 0)
        {
            ArmyWax.Clear();
        }
        BardPierce = 0;
        //游戏开始或者关卡更新时，重置数据
        ZealImagery.PutCambrian().PassionEdgeSilt();
        ZealImagery.PutCambrian().BeakThunder();
        BardGlue.SetActive(true);
        ReckonPierce = 0;
        if (Kinetic.childCount > 0)
        {
            for (int i = 0; i < Kinetic.childCount; i++)
            {
                Destroy(Kinetic.GetChild(i).gameObject);
            }
        }
        
       
        BelowTentacle = DNABelowLady.Mask.ToString();
       
        ArmyGinHealer = int.Parse(BelowStepper[0]);
        GinReckonPierce = int.Parse(BelowStepper[2]);

        //创建瓶子
        for (int i = int.Parse(BelowStepper[1]) - 1; i >= 0; i--)
        {
            if (ClotheArmy.Contains(i.ToString()))
            {
                Lack().Tact(i, true, BelowBlame[i], int.Parse(BelowStepper[0]), BelowTentacle, DNAClickShow, ReckonDetail, TextileBard, VanishBlameBloom, DetailClick, DetailGoat);
            }
            else
            {
                Lack().Tact(i, false, BelowBlame[i], int.Parse(BelowStepper[0]), BelowTentacle, DNAClickShow, ReckonDetail, TextileBard, VanishBlameBloom, DetailClick, DetailGoat);
            }

            string[] colorArray = BelowBlame[i].Split('_');
            string curColor = colorArray[0];
            int DNAHealer= 1;
            if (curColor == string.Empty)
            {
                continue;
            }
            if (!TheseWax.ContainsKey(curColor))
            {
                TheseWax.Add(curColor, DNAHealer);
            }
            for (int j = 1; j < colorArray.Length; j++)
            {
                if (curColor == colorArray[j])
                {
                    DNAHealer++;
                    TheseWax[curColor] = DNAHealer;
                }
                else
                {
                    curColor = colorArray[j];
                    DNAHealer = 1;
                    if (!TheseWax.ContainsKey(curColor))
                    {
                        TheseWax.Add(curColor, DNAHealer);
                    }
                }
            }
        }
        //根据关卡瓶子总数设置排列规则
        VanishPierce(int.Parse(BelowStepper[1]));
    }

    /// <summary>
    /// 根据瓶子总数动态设置排列方式
    /// </summary>
    /// <param name="LevelPingziNumber">关卡默认瓶子数量</param>
    public void VanishPierce(int LevelPingziNumber)
    {
        Resume.enabled = true;
        int number = LevelPingziNumber;
        //设置瓶子大小和位置 第一排个数不到三个按照三个处理
        int FirstNumber = number / 2 + number % 2;
        if (FirstNumber < 4)
        {
            Resume.spacing = new Vector2((1080 - 3 * Resume.cellSize.x) / 3, Resume.spacing.y);
        }
        else
        {
            Resume.spacing = new Vector2((1080 - FirstNumber * Resume.cellSize.x) / FirstNumber, Resume.spacing.y);
        }
        //动态排列瓶子
        if (number > 3 && number <= 14)
        {
            Resume.constraintCount = number / 2 + number % 2;
        }
        else if (number <= 3)
        {
            Resume.constraintCount = 3;
        }
        else if (number > 14)
        {
            //弹提示
        }
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            ItTaskGlue = true;
            Resume.enabled = false;
            PotteryImagery.PutCambrian().Afternoon(MessageCode.PostwarClotheMat);
        })
        .SetDelay(0.1f)
        .SetLoops(0);
        
    }

    private bool ItRisk= false;
    private bool ItLaceArmy= false;
    public void VanishBlameBloom(int VaseIndex , Stack<string> color,ShuiState state , Transform pos)
    {
        if (state == ShuiState.Beidaoshui && !InnateWine.ItOxide())
        {
            int colorNumber = 0;
            string curColor = color.Peek();
            foreach (var item in color)
            {
                if (item == curColor)
                {
                    colorNumber++;
                }
                else
                {
                    break;
                }
            }
            if (TheseWax[curColor] < colorNumber )
            {
                double ExhalePierce= RatLadyTen.instance.ZealShow.vaildData.reward_num + GameUtil.GetCashMulti();
                AndCore(pos, ExhalePierce);
                TheseWax[curColor] = colorNumber;
                DNARimeDiverFlash++;
                if (DNARimeDiverFlash >= RatLadyTen.instance.ZealShow.initgamedata.TurntableValue)
                {
                    DNARimeDiverFlash = 0;
                    UIImagery.PutCambrian().ShunUIShiny(nameof(TrunDiverPinon));
                }
                RimeSoup.fillAmount = DNARimeDiverFlash / RatLadyTen.instance.ZealShow.initgamedata.TurntableValue;
            }
        }
        
        if (ArmyWax.ContainsKey(VaseIndex))
        {
            ArmyWax[VaseIndex] = color;
        }
        else
        {
            ArmyWax.Add(VaseIndex, color);
        }
        //排除当前还有空瓶
        foreach (var item in ArmyWax)
        {
            if (item.Value.Count == 0)
            {
                ItLaceArmy = true;
                break;
            }
            else
            {
                ItLaceArmy = false;
            }
        }
        //如果没有空瓶，则开始判断是否能倒水
        if (!ItLaceArmy)
        {
            for (int i = 0; i < ArmyWax.Count; i++)
            {
                string FirstColor = ArmyWax.ElementAt(i).Value.Peek();
                for (int j = i+1; j < ArmyWax.Count; j++)
                {
                    
                    if (FirstColor == ArmyWax.ElementAt(j).Value.Peek() && (ArmyWax.ElementAt(i).Value.Count != 4 || ArmyWax.ElementAt(j).Value.Count != 4))
                    {
                        //可以动
                        ItRisk = false;
                        return;
                    }
                    else
                    {
                       
                        if (BardPierce<2)
                        {
                            //不可以动，添加失败界面
                            ItRisk = true;
                        }
                        else
                        {
                            ItRisk = false;
                        }
                    }
                }
            }
            if (ItRisk)
            {
                AlaZeal.Auger_Brutal = "fail";
                AlaZeal.Wee_Collagen_Thin = TurnAlaSkiPolitics;
                AlaZeal.Wee_Sign_Thin = TurnAlaSkiSpit;
                AlaZeal.Wee_Ute_Thin = TurnAlaSkiFir;
                AlaZeal.Only = (int)TurnAlaWake;
                AlaZeal.Plan = TurnAlaGoat;
                CajunAlaWake = false;

                UIImagery.PutCambrian().ShunUIShiny(nameof(RiskPinon));
            }
        }
    }

    public void ReckonDetail(int FinishVaseIndex)
    {
        //清除掉已完成的瓶子
        ArmyWax.Remove(FinishVaseIndex);

        ReckonPierce++;
        if (ReckonPierce == GinReckonPierce)
        {
            BelowReckon = true;
            BardGlue.SetActive(true);

            AlaZeal.Auger_Brutal = "success";
            AlaZeal.Wee_Collagen_Thin = TurnAlaSkiPolitics;
            AlaZeal.Wee_Sign_Thin = TurnAlaSkiSpit;
            AlaZeal.Wee_Ute_Thin = TurnAlaSkiFir;
            AlaZeal.Only = (int)TurnAlaWake;
            AlaZeal.Plan = TurnAlaGoat;

            UIImagery.PutCambrian().ShunUIShiny(nameof(ReckonPinon));
        }
        else
        {
            BardGlue.SetActive(false);
        }
    }

    private void UnseenFirArmy()
    {
        //打开页面之前传参数
        //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.Vase);
       UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.Vase);
    }
    private void UnseenFirFoment()
    {
        //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.Remind);
       UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.Remind);
    }
    private void UnseenFirEdgeSilt()
    {
        //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.RollBack);
        UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.RollBack);
    }

    private void UnseenSkiArmy()
    {
        BardGlue.SetActive(true);
        if (ArmyBardPierce > 0)
        {
            if (BardPierce < 2)
            {
                MeetFloorGently.PutCambrian().RoofFloor("1010");
                TurnAlaSkiFir++;
                SkiBard.type = "add";
                SkiBard.Bemoan = 1;
                SkiBard.Daunt = DNABelowID;

                BardPierce++;
                ArmyMob.SetActive(true);
                ArmyBardPierce--;
                ArmyMobBias.text = ArmyBardPierce.ToString();
                PlayerPrefs.SetInt(ShowImagery.AcidArmyBard, ArmyBardPierce);
                if (ArmyBardPierce == 0)
                {
                    ArmyMob.SetActive(false);
                }
                BardLack().Tact(Kinetic.childCount - 1, false, LaceVanishBlame, ArmyGinHealer, BelowTentacle, DNAClickShow, ReckonDetail, TextileBard, VanishBlameBloom, DetailClick, DetailGoat);
                VanishPierce(Kinetic.childCount + 1);
            }
            else
            {
                if (!BelowReckon)
                {
                    WasteImagery.PutCambrian().ShunWaste("The maximum limit has been reached");
                    //MgrTips.Instance.ShowTip("The maximum limit has been reached");
                    BardGlue.SetActive(false);
                }
            }
        }
        else
        {
            if (!BelowReckon)
            {
                BardGlue.SetActive(false);
            }
            
            //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.Vase);
           UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.Vase);
        }
    }

    //失败看广告获得道具瓶子
    private void RiskPostwarArmy()
    {
        CajunAlaWake = true;
        BaseGetProp GetProp = new BaseGetProp();
        GetProp.Bemoan = 1;
        GetProp.Bee = "retry";
        GetProp.type = "add";
        BardLack().Tact(Kinetic.childCount - 1, false, LaceVanishBlame, ArmyGinHealer, BelowTentacle, DNAClickShow, ReckonDetail, TextileBard, VanishBlameBloom, DetailClick, DetailGoat);
        VanishPierce(Kinetic.childCount + 1);

    }

    private string FomentBlame;

    private void UnseenSkiFoment()
    {
        BardGlue.SetActive(true);
        if (FomentBardPierce > 0)
        {
            MeetFloorGently.PutCambrian().RoofFloor("1009");
            TurnAlaSkiSpit++;

            SkiBard.type = "hint";
            SkiBard.Bemoan = 1;
            SkiBard.Daunt = DNABelowID;

            FomentMob.SetActive(true);
            
            FomentBardPierce--;
            PlayerPrefs.SetInt(ShowImagery.AcidFomentBard, FomentBardPierce);
            
            FomentBias.text = FomentBardPierce.ToString();

            if (FomentBardPierce == 0)
            {
                FomentMob.SetActive(false);
            }
            //使用提示按钮
            ZealImagery.PutCambrian().SkiBardTact();
            for (int i = 0; i < ArmyWax.Count - 1; i++)
            {
                for (int j = i + 1; j < ArmyWax.Count; j++)
                {
                    //如果第一层为空瓶 第二层的瓶不为空  则第二层往第一层的空瓶中倒水
                    if (ArmyWax.ElementAt(i).Value.Count == 0 && ArmyWax.ElementAt(j).Value.Count != 0)
                    {
                        StartCoroutine(PotteryFoment(ArmyWax.ElementAt(j).Key, ArmyWax.ElementAt(i).Key));
                        return;
                    }
                    //如果第一层不为空瓶 ， 第二层为空瓶  第一层往第二层中倒水
                    else if (ArmyWax.ElementAt(i).Value.Count != 0 && ArmyWax.ElementAt(j).Value.Count == 0)
                    {
                        StartCoroutine(PotteryFoment(ArmyWax.ElementAt(i).Key, ArmyWax.ElementAt(j).Key));
                        return;
                    }
                    //如果都不为空瓶
                    else if (ArmyWax.ElementAt(i).Value.Count != 0 && ArmyWax.ElementAt(j).Value.Count != 0)
                    {
                        
                        FomentBlame = ArmyWax.ElementAt(i).Value.Peek();
                        //第二层瓶中的颜色最上层颜色等于第一层的预倒水颜色
                        if (FomentBlame == ArmyWax.ElementAt(j).Value.Peek())
                        {
                            //如果第一层瓶子为满水状态  第二层瓶子为不满水状态  则第一层往第二层倒水
                            if (ArmyWax.ElementAt(i).Value.Count == 4 && ArmyWax.ElementAt(j).Value.Count != 4)
                            {
                                StartCoroutine(PotteryFoment(ArmyWax.ElementAt(i).Key, ArmyWax.ElementAt(j).Key));
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(i).Key);
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(j).Key);
                                return;
                            }
                            //如果第一层为不满水状态 第二层瓶子为满水装填  则第二层往第一层倒水
                            else if (ArmyWax.ElementAt(i).Value.Count != 4 && ArmyWax.ElementAt(j).Value.Count == 4)
                            {
                                StartCoroutine(PotteryFoment(ArmyWax.ElementAt(j).Key, ArmyWax.ElementAt(i).Key));
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(j).Key);
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(i).Key);
                                return;
                            }
                            //如果两层都不为满水 则第一层往第二层倒水
                            else if (ArmyWax.ElementAt(i).Value.Count != 4 && ArmyWax.ElementAt(j).Value.Count != 4)
                            {
                                StartCoroutine(PotteryFoment(ArmyWax.ElementAt(i).Key, ArmyWax.ElementAt(j).Key));
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(i).Key);
                                //PotteryImagery.GetInstance().Broadcast(MessageCode.UseRemindProp, VaseDic.ElementAt(j).Key);
                                return;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (!BelowReckon)
            {
                BardGlue.SetActive(false);
            }
           
            //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.Remind);
           UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.Remind);
        }
    }

    private void UnseenSkiEdgeSilt()
    {
        if (ZealImagery.PutCambrian().EdgeSiltEar() > 0)
        {
            if (MaverickBardPierce > 0)
            {
                MeetFloorGently.PutCambrian().RoofFloor("1008");
                TurnAlaSkiPolitics++;

                SkiBard.type = "withdraw";
                SkiBard.Bemoan = 1;
                SkiBard.Daunt = DNABelowID;

                EdgeSiltMob.SetActive(true);
                MaverickBardPierce--;
                PlayerPrefs.SetInt(ShowImagery.AcidMaverickBard, MaverickBardPierce);
                
                EdgeSiltBias.text = MaverickBardPierce.ToString();

                if (MaverickBardPierce == 0)
                {
                    EdgeSiltMob.SetActive(false);
                }
                //使用回退按钮
                ZealImagery.PutCambrian().EdgeSiltCheep();
            }
            else
            {
                //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.RollBack);
               UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.RollBack);
            }
        }
        else
        {
            if (MaverickBardPierce == 0)
            {
                //UIImagery.GetInstance().CacheUIMessage(UINames.FirBardBring, PopupType.RollBack);
               UIImagery.PutCambrian().ShunUIShiny(nameof( FirBardBring), PopupType.RollBack);
            }
            else
            {
                WasteImagery.PutCambrian().ShunWaste("Irrevocable");
                //MgrTips.Instance.ShowTip("Irrevocable");
            }
        }
    }

    VanishLack Lack()
    {
        GameObject Go = Instantiate<GameObject>(RaftLack);
        Go.transform.SetParent(Kinetic, false);
        VanishLack cell = Go.GetComponent<VanishLack>();
        return cell;
    }


    //由于动态排列组件是从右下角开始 所以新建的道具瓶子要将索引排在第一位
    VanishLack BardLack()
    {
        GameObject Go = Instantiate<GameObject>(RaftLack);
        Go.transform.SetParent(Kinetic, false);
        Go.transform.SetSiblingIndex(0);
        VanishLack cell = Go.GetComponent<VanishLack>();
        return cell;
    }

    #endregion

    #region 事件绑定

    public void GritReckon()
    {
        UIImagery.PutCambrian().ShunUIShiny(nameof(ReckonPinon));
    }
    public void GritRisk()
    {
        UIImagery.PutCambrian().ShunUIShiny(nameof(RiskPinon));
    }

    public void LintRime()
    {
        UIImagery.PutCambrian().ShunUIShiny(nameof(TrunDiverPinon));
    }
    public void GritUnseenBelow()
    {
        PlayerPrefs.SetInt(ShowImagery.AcidBelow, int.Parse(DwellJoint.text));
        UIImagery.PutCambrian().VagueWetUI();
        UIImagery.PutCambrian().ShunUIShiny(nameof(ZealPinon));
    }

    public void UnseenArabian()
    {
        
        UIImagery.PutCambrian().ShunUIShiny(nameof(ArabianPinon));
    }

    public void UnseenMasterRefer()
    {
        MasterRefer();

        if (ClotheKinetic.childCount > 0)
        {
            for (int i = 0; i < ClotheKinetic.childCount; i++)
            {
                Destroy(ClotheKinetic.GetChild(i).gameObject);
            }
        }
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            PotteryImagery.PutCambrian().Afternoon(MessageCode.TariffClothe, ClotheKinetic);
        })
        .SetDelay(0.15f)
        .SetLoops(0);
    }

    //打开商店
    public void TaskClub()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.pop_up);
        if (Erie.activeSelf)
        {
            DOTween.Kill("handanimation");
            Erie.SetActive(false);
        }
        UIImagery.PutCambrian().ShunUIShiny(nameof(ClubPinon));
    }

    public void TaskStepper()
    {
        ZealImagery.PutCambrian().StepperJudge(UIMusic.pop_up);
        //UIImagery.GetInstance().CacheUIMessage(UINames.StepperPinon, PopupType.Game);
        UIImagery.PutCambrian().ShunUIShiny(nameof(StepperPinon), PopupType.Game);
    }

    IEnumerator PotteryFoment(int A , int B)
    {
        if (A != ZealImagery.PutCambrian().DetailGessoGourd())
        {
            ZealImagery.PutCambrian().SkiBardTact();
            yield return new WaitForSeconds(0.2f);
            PotteryImagery.PutCambrian().Afternoon(MessageCode.SkiFomentBard, A);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            PotteryImagery.PutCambrian().Afternoon(MessageCode.SkiFomentBard, A);
        }
        yield return new WaitForSeconds(0.1f);

        PotteryImagery.PutCambrian().Afternoon(MessageCode.SkiFomentBard, B);
        
        StopCoroutine(nameof(PotteryFoment));
    }

    public void DetailGoat()
    {
        TurnAlaGoat++;
    }

    public void DetailClick(Vector3 HandPos)
    {
        if (DNABelowID == 1)
        {
            if (ItClick)
            {
                DNAClickGoat++;
                ItClick = false;
                Vector3 Pos = new Vector3(HandPos.x, HandPos.y - 1f, HandPos.z);
                Erie.transform.position = Pos;
                //Hand.SetActive(true);
                CurvatureBelow.EriePut(Erie, Pos, true);
                DNAClickShow = ZealImagery.PutCambrian().BelowClick(DNAClickGoat);
            }
            else
            {
                ItClick = true;
                Erie.transform.position = new Vector3(HandPos.x, HandPos.y - 5f, HandPos.z);
                CurvatureBelow.EriePut(Erie, HandPos, true);
                DNAClickShow = ZealImagery.PutCambrian().BelowClick(DNAClickGoat);
                if (DNAClickShow != null)
                {
                    PotteryImagery.PutCambrian().Afternoon(MessageCode.BelowClick, DNAClickShow);
                }
                else
                {
                    DOTween.Kill("handanimation");
                    Erie.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {
        if (CajunAlaWake)
        {
            TurnAlaWake += Time.deltaTime;
        }
        
        if (Input.GetMouseButtonDown(0) && ItClubClick)
        {
            if (PlayerPrefs.GetInt(ShowImagery.AcidOfTextClub) == 0 && DNABelowID == ClubDecode && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject != null)
            {
                if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name != "Shangdian")
                {
                    ItClubClick = false;
                    DOTween.Kill("handanimation");
                    Erie.SetActive(false);
                    PlayerPrefs.SetInt(ShowImagery.AcidOfTextClub, 1);
                }
            }
        }
        //只在初始化时瓶子创建完之后执行
        //避免重新开始时或游戏刚开始时瓶子未排列完成就使用道具造成，打断排列造成的瓶子位置错误
        if (ItTaskGlue && BardGlue.activeSelf)
        {
            ItTaskGlue = false;
            BardGlue.SetActive(false);
        }
    }

    public void AndCore(Transform StartPostion, double AwardNum)
    {
        if (!InnateWine.ItOxide())
        {
            int CorePierce= (int)AwardNum / RatLadyTen.instance.ZealShow.diamond_fly_count;
            if (AwardNum % RatLadyTen.instance.ZealShow.diamond_fly_count > 0)
            {
                CorePierce += 1;
            }
            CurvatureFahrenheit.SlamPileFrom(CoreSoup, CorePierce, StartPostion, AlaMat, () =>
            {
                ZealShowImagery.PutCambrian().FirDisc(AwardNum);
            });
        }  
    }
    public void ReckonAndCore(Transform StartPostion, double AwardNum)
    {
        if (!InnateWine.ItOxide())
        {
            PlayerPrefs.SetString(ShowImagery.LevelGuide, "1");
            if (PlayerPrefs.GetInt(ShowImagery.AcidBelow) == 3)
            {
                Mask.gameObject.SetActive(true);
            }
            int CorePierce= (int)AwardNum / RatLadyTen.instance.ZealShow.diamond_fly_count;
            if (AwardNum % RatLadyTen.instance.ZealShow.diamond_fly_count > 0)
            {
                CorePierce += 1;
            }
            CurvatureFahrenheit.ReckonSlamPileFrom(CoreSoup, CorePierce, StartPostion, AlaMat, () =>
            {
                PlayerPrefs.SetString(ShowImagery.LevelGuide, "0");
                if (DNABelowID == 3)
                {
                    Color MaskColir = new Color();
                    MaskColir.a = 0.85f;
                    Mask.color = MaskColir;
                    WangzhuanSequence = DOTween.Sequence();
                    WangzhuanSequence.Append(SlipApril.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f).SetLoops(10, LoopType.Yoyo))
                        .SetDelay(2)
                        .SetLoops(-1);
                }
                ZealShowImagery.PutCambrian().FirDisc(AwardNum);
            });
        }
    }

    #endregion

}
