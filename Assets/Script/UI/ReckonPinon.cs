using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Spine.Unity;
using DG.Tweening;
using sf_database;

/// <summary>
/// FinishPanelView - 自动生成的UI视图脚本
/// </summary>
public class ReckonPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("Fx_Fireworks")]    
#region UI组件
    //烟花特效
    public ParticleSystem By_Magnetism; 
[UnityEngine.Serialization.FormerlySerializedAs("Fx_Ribbon")]    //彩带特效
    public ParticleSystem By_Quiver;
[UnityEngine.Serialization.FormerlySerializedAs("CatSpineAni")]    // 猫的spine动画
    public SkeletonGraphic BowVenuePut;
[UnityEngine.Serialization.FormerlySerializedAs("WelldoneSpineAni")]    // welldone的spine动画
    public SkeletonGraphic UncarvedVenuePut;
[UnityEngine.Serialization.FormerlySerializedAs("ShowList")]    // 显示列表
    public List<GameObject> ShunPuff;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    //金币显示
    public Text CoreBias;
[UnityEngine.Serialization.FormerlySerializedAs("CoinAward")]    //金币奖励数量
    public Text CoreTinge;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondAward")]    public Text CreeperTinge;
[UnityEngine.Serialization.FormerlySerializedAs("FreeBtn")]    public Button JuryShy;
[UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]    public Button MoundShy;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondLight")]
    public GameObject CreeperPilot;
[UnityEngine.Serialization.FormerlySerializedAs("CoinLight")]    public GameObject CorePilot;
[UnityEngine.Serialization.FormerlySerializedAs("MaskIcon")]
    public GameObject GlueSoup;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
    public GameObject CoreSoup;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    public Transform AlaMat;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondReward")]
    public GameObject CreeperClothe;
[UnityEngine.Serialization.FormerlySerializedAs("CoinReward")]    public GameObject CoreClothe;

    [Header("转盘组")]
    //public SiteBelow SlotBG;
    private bool YetStiffenMeShy;

    private bool ItSpeech= true;

    //当前金币数
    private int DNACorePierce;
    //奖励数量
    private double ClothePierce;
    private double CoreClothePierce;
    private int DNAReckonBelow;

    private List<LevelConfig> BelowPuff= new List<LevelConfig>();

    private int Buck;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    public GameObject[] PuffBuyer;
    #endregion

    #region 生命周期函数
    private void Start()
    {
        JuryShy.onClick.AddListener(CorpWorkmanship);
        MoundShy.onClick.AddListener(AnWorkmanship);
        for (int i = 0; i < PuffBuyer.Length; i++)
        {
            ZealImagery.PutCambrian().EyelidConcentrate(PuffBuyer[i].GetComponent<RectTransform>());
        }
    }
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        //SlotBG.initMulti();
        ZealImagery.PutCambrian().EyelidConcentrate(JuryShy.GetComponent<RectTransform>());
        Buck = PlayerPrefs.GetInt(ShowImagery.AcidBelowBuck);
        GlueSoup.SetActive(false);
        ItSpeech = true;
        ClothePierce = RatLadyTen.instance.ZealShow.initgamedata.level_complete_cash_num;
        CoreClothePierce = RatLadyTen.instance.ZealShow.initgamedata.win_coins;
        CoreTinge.text = CoreClothePierce.ToString();
        CreeperTinge.text = ClothePierce.ToString("f2");
        DNACorePierce = PlayerPrefs.GetInt(CExcite.Ax_SlamCore);
        CoreBias.text = DNACorePierce.ToString();

        int CurLevelNumber = PlayerPrefs.GetInt(ShowImagery.AcidBelow);
        AcidShowImagery.AntRat(CExcite.Ax_MortiseMindBiotic, CurLevelNumber);
        if (CurLevelNumber == 2)
        {
            MeetFloorGently.PutCambrian().RoofFloor("1002");
        }
        MeetFloorGently.PutCambrian().RoofFloor("1003", CurLevelNumber.ToString());
        //AdCtrl.Instance.AddPassLevel(CurLevelNumber);
        DNAReckonBelow = CurLevelNumber;
        CurLevelNumber++;
        if (Buck > 1)
        {
            if (CurLevelNumber > BelowPuff.Count + ((BelowPuff.Count - 30) * Buck))
            {
                Buck++;
                PlayerPrefs.SetInt(ShowImagery.AcidBelowBuck, Buck);
                if (Buck % 2 == 1)
                {
                    PlayerPrefs.SetInt(ShowImagery.AcidTentacleBelow, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(ShowImagery.AcidTentacleBelow, 0);
                }
            }
        }
        else
        {
            if (CurLevelNumber > BelowPuff.Count * Buck)
            {
                Buck++;
                PlayerPrefs.SetInt(ShowImagery.AcidBelowBuck, Buck);
                PlayerPrefs.SetInt(ShowImagery.AcidTentacleBelow, 0);
            }
        }
        
        PlayerPrefs.SetInt(ShowImagery.AcidBelow, CurLevelNumber);
        ShunReckonPinon();
    }

    protected override void Awake()
    {
        base.Awake();

        //RewardMuilte = ZealImagery.GetInstance().GetGameConfig().win_ad_coins;
        BelowPuff = RatLadyTen.instance.BelowExciteShow;
        if (InnateWine.ItOxide())
        {
            CoreClothe.transform.localPosition = Vector3.zero;
        }
        else
        {
            CreeperClothe.gameObject.SetActive(true);
        }
    }

    #endregion

    /// <summary>
    /// 初始化动画
    /// </summary>
    /// <param name="finish"></param>
    public void TactShunPuff(System.Action finish)
    {
        for (int i = 0; i < ShunPuff.Count; i++)
        {
            ShunPuff[i].transform.localScale = new Vector3(0, 0, 0);
        }
        StableVenue(BowVenuePut);
        StableVenue(UncarvedVenuePut);
        BowVenuePut.gameObject.SetActive(false);
        UncarvedVenuePut.gameObject.SetActive(false);
        finish?.Invoke();
    }

    /// <summary>
    /// 过关成功动画
    /// </summary>
    public void ShunReckonPinon()
    {
        TactShunPuff(() =>
        {
            StartCoroutine(CurvatureBelow.BelowReckonPut(BowVenuePut, UncarvedVenuePut, By_Magnetism, By_Quiver, ShunPuff, () =>
            {
                Debug.Log("动画结束");
            }));
        });
    }
    /// <summary>
    /// 重置Spine动画
    /// </summary>
    /// <param name="skeletonGraphic"></param>
    public void StableVenue(SkeletonGraphic skeletonGraphic)
    {
        skeletonGraphic.Skeleton.SetToSetupPose();
        skeletonGraphic.AnimationState.ClearTracks();
        // 强制立即更新骨骼状态（关键步骤！）
        skeletonGraphic.Update(0);
    }

    public void CorpWorkmanship()
    {
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        GlueSoup.SetActive(true);
        MeetFloorGently.PutCambrian().RoofFloor("1007");
        MeetFloorGently.PutCambrian().RoofFloor("9001", "3");
        ADImagery.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                MeetFloorGently.PutCambrian().RoofFloor("9003", "3");
                CurvatureFahrenheit.UnseenPierce(ClothePierce, ClothePierce * RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums, 0.1f, CreeperTinge, () => {
                    
                });
                CurvatureFahrenheit.UnseenPierce(CoreClothePierce, CoreClothePierce * RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums, 0.1f, CoreTinge, () => {
                    AndCore(CoreTinge.transform, CoreClothePierce);
                });
                ClothePierce = ClothePierce * RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums;
                CoreClothePierce = CoreClothePierce * RatLadyTen.instance.ZealShow.initgamedata.withdrawn_ad_nums;
            }
            else
            {
                GlueSoup.SetActive(false);
                WasteImagery.PutCambrian().ShunWaste("No ads right now, please try it later.");
            }
        }, "3");

        //if (isNewUser())
        //{
        //    playSlot();
        //}
        //else
        //{
        //    ADImagery.Instance.playRewardVideo((success) =>
        //    {
        //        if (success)
        //        {
        //            playSlot();
        //        }
        //        else
        //        {
        //            MaskIcon.SetActive(false);
        //            WasteImagery.GetInstance().ShowToast("No ads right now, please try it later.");
        //        }
        //    }, "");
        //}

    }
    
    public void AnWorkmanship()
    {
        ADImagery.Cambrian. AnSelectFirEject();
        ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.click);
        GlueSoup.SetActive(true);
        if (ItSpeech)
        {
            ZealImagery.PutCambrian().StepperJudge(RomanWhen.UIMusic.win_3);
            ItSpeech = false;
            AndCore(CoreTinge.transform, CoreClothePierce);
        }
    }


    //private void playSlot()
    //{
    //    int index = getSlotMultiIndex();
    //    SlotBG.slot(index, (multi) => {
    //        // slot结束后的回调
    //        MeetFloorGently.GetInstance().SendEvent("9007", "4");
    //        CurvatureFahrenheit.ChangeNumber(RewardNumber, RewardNumber * multi, 0, CoinAward, "+", () =>
    //        {
    //            RewardNumber = RewardNumber * multi;
    //            CoinAward.text = "+" + PierceWine.DoubleToStr(RewardNumber);
    //            hasClickedAdBtn = true;

    //            GetCoin.count = (int)RewardNumber;
    //            GetCoin.way = "rv_win";
    //            PlayerPrefs.SetInt(ShowImagery.SaveCoinNumber, (int)(CurCoinNumber + RewardNumber));
    //            ZealPinon.instance.FlyCoin(CoinAward.transform, RewardNumber);
    //            UIImagery.GetInstance().ClearAllUI();
    //            //弹出好评页面
    //            if (CurFinishLevel == RatLadyTen.instance.GameData.initgamedata.rateconfig)
    //            {
    //                UIImagery.GetInstance().ShowUIForms(nameof(TirePinon), CurFinishLevel);
    //                UIImagery.GetInstance().ShowUIForms(nameof(LuckIDPinon));
    //            }
    //            else
    //            {
    //                UIImagery.GetInstance().ShowUIForms(nameof(ZealPinon));
    //            }
    //        });
    //    });

    //    AcidShowImagery.SetBool(CExcite.sv_FirstSlot, false);
    //}

    //private int getSlotMultiIndex()
    //{
    //    // 新用户，第一次固定翻5倍
    //    if (isNewUser())
    //    {
    //        int index = 0;
    //        foreach (SlotItem wg in RatLadyTen.instance.InitData.slot_group)
    //        {
    //            if (wg.multi == 7)
    //            {
    //                return index;
    //            }
    //            index++;
    //        }
    //    }
    //    else
    //    {
    //        int sumWeight = 0;
    //        foreach (SlotItem wg in RatLadyTen.instance.InitData.slot_group)
    //        {
    //            sumWeight += wg.weight;
    //        }
    //        int r = UnityEngine.Random.Range(0, sumWeight);
    //        int nowWeight = 0;
    //        int index = 0;
    //        foreach (SlotItem wg in RatLadyTen.instance.InitData.slot_group)
    //        {
    //            nowWeight += wg.weight;
    //            if (nowWeight > r)
    //            {
    //                return index;
    //            }
    //            index++;
    //        }

    //    }
    //    return 0;
    //}
    //private bool isNewUser()
    //{
    //    return !PlayerPrefs.HasKey(CExcite.sv_FirstSlot + "Bool") || AcidShowImagery.GetBool(CExcite.sv_FirstSlot);
    //}

    public void AndCore(Transform StartPostion, double AwardNum)
    {
        int CorePierce= (int)AwardNum / RatLadyTen.instance.ZealShow.coin_fly_count;
        
        if (AwardNum % RatLadyTen.instance.ZealShow.coin_fly_count > 0)
        {
            CorePierce += 1;
        }
        CurvatureFahrenheit.SlamPileFrom(CoreSoup, CorePierce, StartPostion, AlaMat, () =>
        {
            ZealPinon.instance.ReckonAndCore(CreeperTinge.transform, ClothePierce);
            int oldGold = AcidShowImagery.PutRat(CExcite.Ax_SlamCore);
            ZealShowImagery.PutCambrian().UteSlam(AwardNum);
            CurvatureFahrenheit.UnseenPierce(oldGold, oldGold + AwardNum, 0.1f, CoreBias, () => {
                UIImagery.PutCambrian().VagueWetUI();
                //弹出好评页面
                if (DNAReckonBelow == RatLadyTen.instance.ZealShow.initgamedata.rateconfig)
                {
                    UIImagery.PutCambrian().ShunUIShiny(nameof(TirePinon), DNAReckonBelow);
                    UIImagery.PutCambrian().ShunUIShiny(nameof(LuckIDPinon));
                }
                else
                {
                    UIImagery.PutCambrian().ShunUIShiny(nameof(ZealPinon));
                }
            });
            
        });
    }

    private void Update()
    {
        CreeperPilot.transform.Rotate(0, 0, -1);
        CorePilot.transform.Rotate(0, 0, -1);
    }
}
