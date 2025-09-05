using DG.Tweening;
using sf_database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingziCell : MonoBehaviour
{
    //防止重复点击
    private bool OxCheep;

    private bool ItReckonConnect;
[UnityEngine.Serialization.FormerlySerializedAs("SceenEffect")]
    public ParticleSystem MagicInvest;
[UnityEngine.Serialization.FormerlySerializedAs("RibbonEffect")]    public ParticleSystem QuiverInvest;
[UnityEngine.Serialization.FormerlySerializedAs("WaterEffect")]    public ParticleSystem TitleInvest;
[UnityEngine.Serialization.FormerlySerializedAs("PingziCellBtn")]
    public Button VanishLackShy;
[UnityEngine.Serialization.FormerlySerializedAs("ShuiColor1")]    public Image[] WhigBlame1;
[UnityEngine.Serialization.FormerlySerializedAs("ShuifanguangColor")]    public Image[] SymbolicallyBlame;
[UnityEngine.Serialization.FormerlySerializedAs("ObstacleColor")]    //障碍颜色 0：最上层障碍图片 1：中间障碍层图片 2：最下层障碍图片
    public GameObject[] TentacleBlame;
[UnityEngine.Serialization.FormerlySerializedAs("ObstacleQuesMaek")]    public GameObject[] TentacleWormSeep;
[UnityEngine.Serialization.FormerlySerializedAs("ObstacleEffect")]    public ParticleSystem[] TentacleInvest;
[UnityEngine.Serialization.FormerlySerializedAs("Plug")]    public GameObject Gild;
[UnityEngine.Serialization.FormerlySerializedAs("WaterLine")]    public GameObject TitleWhen;
[UnityEngine.Serialization.FormerlySerializedAs("Shuitop")]
    public Image Physics;
[UnityEngine.Serialization.FormerlySerializedAs("ShuitopFanguang")]    public Image PhysicsExterior;
[UnityEngine.Serialization.FormerlySerializedAs("ShuitopMaterial")]    public Material PhysicsSchedule;
    private Material ExteriorSchedule;
    //最大容量
    private int GinHealer;
    //当前容量
    private int DNAHealer= 0;
    //取到当前颜色
    private string DNABlame;
    //取到颜色个数
    private int BlamePierce;
[UnityEngine.Serialization.FormerlySerializedAs("InitPosition")]    public Vector3 TactEsoteric;
    private bool ItDye;
    private Dictionary<int, colorconfigDB> BlameWax= new Dictionary<int, colorconfigDB>();
    private Color DiscoStepper= new Color();
    private colorconfigDB TowelShow;

    private string[] BlameBuyer;
    //将颜色存到栈里
    private Stack<string> BlameBloom= new Stack<string>();
    private bool ItReckon;
    private Action<int> ReckonDetail;
    private Action<bool> ItTextileBard;
    private int ArmyNotion;
    private LevelGuideInfo.LevelGuideData ClickShow;
    private Action<Vector3> ClickDetail;

    private Action<int, Stack<string>, ShuiState , Transform> DetailFomentArmy;

    private Action DetailGoat;

    //从上往下第一层障碍
    private bool Tentacle1= false;
    //从上往下第二层障碍
    private bool Tentacle2= false;
    //从上往下第三层障碍
    private bool Tentacle3= false;

    private int TentaclePierce;
[UnityEngine.Serialization.FormerlySerializedAs("RewardPos")]
    public GameObject ClotheMat;
[UnityEngine.Serialization.FormerlySerializedAs("RewardObj")]    public GameObject ClotheCut;
    private GameObject ClotheBranch;
    private double ExhalePierce;
    private bool ItClothe;

   

    //瓶子水的颜色  ， 瓶子容量
    public void Tact(int VaseIndex,bool isReward, string curColor, int Volume, string LevelObstacle, LevelGuideInfo.LevelGuideData guideData,  Action<int> Finish , Action<bool> DisableProp , Action<int,Stack<string>, ShuiState,Transform> ActionRemind , Action<Vector3> GuidePos , Action step )
    {
        GameManager.PutCambrian().EyelidConcentrate(gameObject.GetComponent<RectTransform>());
        ItClothe = isReward;
        

        ClickShow = guideData;
        ClickDetail = GuidePos;
        //回调步数
        DetailGoat = step;
        //道具基础信息回调
        DetailFomentArmy = ActionRemind;
        //瓶子索引
        ArmyNotion = VaseIndex;
        ReckonDetail = Finish;
        //禁用道具回调
        ItTextileBard = DisableProp;
        ItReckon = false;
        BlameWax = GameManager.PutCambrian().PutUserShow();
        ExteriorSchedule = Instantiate<Material>(PhysicsSchedule);
        PhysicsExterior.material = ExteriorSchedule;
        GinHealer = Volume;
        DiscoStepper.a = 0;
        VanishLackShy.onClick.AddListener(CheepShow);
        TentaclePierce = int.Parse(LevelObstacle);
        //当前颜色值长度为0时 透明度调为0
        if (curColor.Length == 0)
        {
            StepperDiscoNovel(DiscoStepper);
        }
        else
        {
            if (TentaclePierce == PlayerPrefs.GetInt(DataManager.AcidTentacleBelow))
            {
                Tentacle1 = true;
                Tentacle2 = true;
                Tentacle3 = true;
                for (int i = 0; i < TentacleBlame.Length; i++)
                {
                    TentacleBlame[i].SetActive(true);
                }
            }
            
            BlameBuyer = curColor.Split("_");
            Color ShuiColor = new Color();
            Color TopColor = new Color();
            for (int i = 0; i < GinHealer; i++)
            {
                if (BlameBuyer[i] == " " || BlameBuyer[i] == string.Empty)
                {
                    ShuiColor.a = 0;
                    WhigBlame1[i].color = ShuiColor;
                    SymbolicallyBlame[i].color = ShuiColor;
                }
                else
                {
                    DNAHealer++;
                    BlameBloom.Push(BlameBuyer[i]);
                    colorconfigDB data = BlameWax[int.Parse(BlameBuyer[i])];
                    if (ColorUtility.TryParseHtmlString(data.color, out ShuiColor))
                    {
                        ShuiColor.a = 1;
                        WhigBlame1[i].color = ShuiColor;
                        SymbolicallyBlame[i].color = ShuiColor;
                    }

                    if (ColorUtility.TryParseHtmlString(data.topcolor, out TopColor))
                    {
                        TopColor.a = 1;
                        //Shuitop.color = TopColor;
                        StepperWebDisco(WhigBlame1[i].transform.position, TopColor);
                    }
                }
            }
        }
        
        //回调瓶子的索引和颜色集合
        ActionRemind(VaseIndex, BlameBloom,ShuiState.None, transform);
        ItDye = false;
        OxCheep = false;
        ItReckonConnect = false;
        Invoke(nameof(CornetClickDetail),0.05f);
    }

    public void CheepShow()
    {
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) == 1)
        {
            //判断当前点击的瓶子是否是引导的瓶子
            //如果是回调，并且执行点击。
            //如果不是没反应
            if (ArmyNotion == ClickShow.ClickArmyID)
            {
                ClickDetail(gameObject.transform.position);
            }
            else
            {
                return;
            }
        }
        //保证瓶子在动画运动过程中不能点击
        if (!OxCheep)
        {
            OxCheep = true;

            //Isput true为抬起  false未抬起
            if (!ItDye)
            {
                BlamePierce = 0;
                //Debug.Log("当前颜色：" + CurColor + "当前倒水值：" + ColorNumber + "当前已有容量：" + CurVolume + "瓶子最大容量：" + MaxVolume);
                if (BlameBloom.Count == 0)
                {
                    OxCheepTact();
                    
                    TowelShow = new colorconfigDB();
                    GameManager.PutCambrian().ConnectRadial(ArmyNotion,gameObject, TowelShow, null, BlamePierce, DNAHealer, GinHealer, TactEsoteric, WhigBlame1, SymbolicallyBlame, TentacleWormSeep, Physics.gameObject, TitleInvest.gameObject, VagueConnectHealer, ReckonConnectMonoid, ReckonCumbersomeMonoid, OfReckonMonoid, OxCheepTact , EdgeSiltFir , EdgeSiltSoftball,ItTextileBard, ConnectWebBlame);
                }
                else
                {
                    TactEsoteric = gameObject.transform.position;
                    ItDye = true;

                    DNABlame = BlameBloom.Peek();
                    TowelShow = BlameWax[int.Parse(DNABlame)];

                    //判断当前关卡是否是障碍关卡
                    if (TentaclePierce == PlayerPrefs.GetInt(DataManager.AcidTentacleBelow))
                    {
                        int Number = BlameBloom.Count;
                        for (int i = 0; i < Number; i++)
                        {
                            if (DNABlame == BlameBloom.Peek())
                            {
                                if (Tentacle1)
                                {
                                    BlameBloom.Pop();
                                    BlamePierce++;
                                    break;
                                }
                                else
                                {
                                    if (Tentacle2)
                                    {
                                        if (BlameBloom.Count > 2)
                                        {
                                            BlameBloom.Pop();
                                            BlamePierce++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (Tentacle3)
                                        {
                                            if (BlameBloom.Count > 1)
                                            {
                                                BlameBloom.Pop();
                                                BlamePierce++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            BlameBloom.Pop();
                                            BlamePierce++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in BlameBloom)
                        {
                            if (item == DNABlame)
                            {
                                BlamePierce++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int i = 0; i < BlamePierce; i++)
                        {
                            BlameBloom.Pop();
                        }
                    }
                    Debug.Log("当前颜色：" + DNABlame + "当前倒水值：" + BlamePierce + "当前已有容量：" + DNAHealer + "瓶子最大容量：" + GinHealer);
                    GameManager.PutCambrian().ConnectRadial(ArmyNotion, gameObject, TowelShow, DNABlame, BlamePierce, DNAHealer, GinHealer, TactEsoteric, WhigBlame1, SymbolicallyBlame, TentacleWormSeep, Physics.gameObject, TitleInvest.gameObject, VagueConnectHealer, ReckonConnectMonoid, ReckonCumbersomeMonoid, OfReckonMonoid, OxCheepTact, EdgeSiltFir, EdgeSiltSoftball , ItTextileBard , ConnectWebBlame);
                }
            }
            else
            {
                if (!ItReckonConnect)
                {
                    ItDye = false;
                    for (int i = 0; i < BlamePierce; i++)
                    {
                        BlameBloom.Push(DNABlame);
                    }
                    GameManager.PutCambrian().BeakThunder();
                    AnimationGroup.EntityBeakPut(OxCheep, gameObject, TactEsoteric, OxCheepTact);
                }
            }
        }
    }
    public void OxCheepTact()
    {
        //恢复点击
        OxCheep = false;
    }

    public void CurvatureMonoid()
    {
        ItReckonConnect = true;
    }

    public void PostwarFoment()
    {
        if (ItSkiFoment)
        {
            ItSkiFoment = false;
        }
    }

    //倒水动画执行时，清空倒水瓶子的预倒水值
    //防止快速点击又将数值加回到倒水瓶子中
    public void VagueConnectHealer()
    {
        BlamePierce = 0;
    }

    //倒水完成回调
    public void ReckonConnectMonoid(int UnDaoshuiNumbber)
    {
        gameObject.transform.SetSiblingIndex(transform.parent.childCount - 1 - ArmyNotion);
        ItReckonConnect = false;
        //未成功倒水的数量
        if (UnDaoshuiNumbber != 0)
        {
            for (int i = 0; i < UnDaoshuiNumbber; i++)
            {
                BlameBloom.Push(DNABlame);
            }
        }

        DetailFomentArmy(ArmyNotion, BlameBloom,ShuiState.Daoshui, transform);
        //刷新当前瓶子颜色
        PostwarBlame();
        GameManager.PutCambrian().BeakThunder();
        DNAHealer = BlameBloom.Count;
        ItDye = false;
        OxCheepTact();

        //没有使用道具正常倒水完成清除障碍色。一次清除一个
        if (!ItSkiFoment)
        {
            DetailGoat();

            if (BlameBloom.Count == 3)
            {
                if (Tentacle1)
                {
                    Tentacle1 = false;
                    TentacleWormSeep[1].SetActive(true);
                    TentacleWormSeep[2].SetActive(true);
                    AnimationGroup.VagueTentacleBlame(TentacleBlame[0], TentacleInvest[0], VagueTentacle);
                }
                else if (Tentacle2)
                {
                    TentacleWormSeep[1].SetActive(true);
                    TentacleWormSeep[2].SetActive(true);
                }
                else if (Tentacle3)
                {
                    TentacleWormSeep[2].SetActive(true);
                }
            }
            else if (BlameBloom.Count == 2)
            {
                if (Tentacle2)
                {
                    Tentacle2 = false;
                    TentacleWormSeep[2].SetActive(true);
                    AnimationGroup.VagueTentacleBlame(TentacleBlame[1], TentacleInvest[1], VagueTentacle);
                }
                else if (Tentacle3)
                {
                    TentacleWormSeep[2].SetActive(true);
                }
            }
            else if (BlameBloom.Count == 1)
            {
                if (Tentacle3)
                {
                    Tentacle3 = false;
                    AnimationGroup.VagueTentacleBlame(TentacleBlame[2], TentacleInvest[2], VagueTentacle);
                }
            }
        }
        else
        {
            if (Tentacle1)
            {
                TentacleWormSeep[0].SetActive(true);
                TentacleWormSeep[1].SetActive(true);
                TentacleWormSeep[2].SetActive(true);
            }
            else if (Tentacle2)
            {
                TentacleWormSeep[1].SetActive(true);
                TentacleWormSeep[2].SetActive(true);
            }
            else if (Tentacle3)
            {
                TentacleWormSeep[2].SetActive(true);
            }
        }
    }

    //被倒水完成回调
    public void ReckonCumbersomeMonoid(int ReadyNumber, string WaterColor)
    {
        ItDye = false;
        for (int i = 0; i < ReadyNumber + BlamePierce; i++)
        {
            BlameBloom.Push(WaterColor);
        }
        DNAHealer = BlameBloom.Count;
       
        PostwarBlame();
        if (ItSkiFoment)
        {
            OxCheepTact();
            ItSkiFoment = false;
            Invoke(nameof(CornetEdgeSilt), 0.1f);
        }
        else
        {
            DetailFomentArmy(ArmyNotion, BlameBloom, ShuiState.Beidaoshui, transform);
            if (BlameBloom.Count == GinHealer)
            {
                string colorStr = BlameBloom.Peek();
                foreach (var item in BlameBloom)
                {
                    if (colorStr != item)
                    {
                        ItReckon = false;
                        break;
                    }
                    else
                    {
                        ItTextileBard(true);
                        ItReckon = true;
                    }
                }

                if (ItReckon && !Tentacle1 && !Tentacle2 && !Tentacle3)
                {
                    GameManager.PutCambrian().PassionEdgeSilt();
                    OxCheep = true;
                    Gild.SetActive(true);
                    GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.waterfull);
                    
                    AnimationGroup.PlasterReckonPut(gameObject.transform.GetChild(0).gameObject, Gild, MagicInvest, QuiverInvest, () => {
                        //GameManager.GetInstance().SettingVibra();
                        ReckonDetail(ArmyNotion);
                        if (ItClothe && !CommonUtil.ItOxide())
                        {
                            GamePanel.instance.AndCore(ClotheBranch.transform, ExhalePierce);
                            Destroy(ClotheBranch);
                            //RewardObject.SetActive(false);
                        }
                    });
                }
                else
                {
                    ItTextileBard(false);
                    OxCheepTact();
                }
            }
            else
            {
                ItTextileBard(false);
                OxCheepTact();
            }
        }
    }

    //未完成回调 瓶子落下并将数据存回到栈中
    public void OfReckonMonoid()
    {
        ItDye = false;
        ItReckonConnect = false;
        //倒水完成，如果使用了提示道具，则更新状态
        if (ItSkiFoment)
        {
            ItSkiFoment = false;
        }
        for (int i = 0; i < BlamePierce; i++)
        {
            BlameBloom.Push(DNABlame);
        }
        AnimationGroup.EntityBeakPut(OxCheep, gameObject, TactEsoteric, OxCheepTact);
    }

    //调整图片透明度
    public void StepperDiscoNovel(Color imageColor)
    {
        for (int i = 0; i < WhigBlame1.Length; i++)
        {
            WhigBlame1[i].color = imageColor;
        }
        for (int i = 0; i < SymbolicallyBlame.Length; i++)
        {
            SymbolicallyBlame[i].color = imageColor;
        }
        Physics.color = imageColor;
        PhysicsExterior.color = imageColor;
    }

    //设置水面的位置和颜色
    public void StepperWebDisco(Vector3 CurPos, Color Topcolor)
    {
        Physics.transform.position = CurPos;
        Physics.GetComponent<RectTransform>().anchoredPosition = new Vector2(Physics.GetComponent<RectTransform>().anchoredPosition.x, Physics.GetComponent<RectTransform>().anchoredPosition.y + Physics.GetComponent<RectTransform>().rect.height * 0.5f);

        Physics.color = Topcolor;
        ExteriorSchedule.color = Topcolor;
    }

    //刷新水面位置以及水的颜色
    public void PostwarBlame()
    {
        StepperDiscoNovel(DiscoStepper);
        Color ShuiColor = new Color();
        Color TopColor = new Color();
        if (BlameBloom.Count == 0)
        {
            TopColor.a = 0;
            StepperWebDisco(WhigBlame1[0].transform.position, TopColor);
        }
        else
        {
            if (Physics.gameObject.activeSelf == false)
            {
                Physics.gameObject.SetActive(true);
            }
            ShuiColor.a = 1;
            TopColor.a = 1;
            int Residue = BlameBloom.Count;
            colorconfigDB data = BlameWax[int.Parse(BlameBloom.Peek())];
            if (ColorUtility.TryParseHtmlString(data.topcolor, out TopColor))
            {
                StepperWebDisco(WhigBlame1[Residue - 1].transform.position, TopColor);
            }

            int Reset = 0;
            foreach (var item in BlameBloom)
            {
                data = BlameWax[int.Parse(item)];
                if (ColorUtility.TryParseHtmlString(data.color, out ShuiColor))
                {
                    if (Reset <= Residue)
                    {
                        Residue--;
                        WhigBlame1[Residue].color = ShuiColor;
                        //ShuifanguangColor[Residue].color = ShuiColor;
                    }
                }
            }
        }
    }
    public void EdgeSiltFir(int ReadyNumber , string WaterColor)
    {
        for (int i = 0; i < ReadyNumber; i++)
        {
            BlameBloom.Push(WaterColor);
        }
        DNAHealer = BlameBloom.Count;
        PostwarBlame();
    }

    public void EdgeSiltSoftball(int ReadyNumber)
    {
        for (int i = 0; i < ReadyNumber; i++)
        {
            BlameBloom.Pop();
        }
        DNAHealer = BlameBloom.Count;
        PostwarBlame();
    }

    //单独处理倒水瓶子水面颜色
    //如果NotVolume为0 ，则用数组中的颜色
    //如果Norvolume不为0，则用
    private void ConnectWebBlame(int NotVolume)
    {
        Color TopColor = new Color();
        TopColor.a = 1;
        if (BlameBloom.Count != 0)
        {
            if (NotVolume == 0)
            {
                colorconfigDB data = BlameWax[int.Parse(BlameBloom.Peek())];
                if (ColorUtility.TryParseHtmlString(data.topcolor, out TopColor))
                {
                    Physics.color = TopColor;
                }
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(TowelShow.topcolor, out TopColor))
                {
                    Physics.color = TopColor;
                }
            }
        }
    }

    private void Start()
    {
         //SceenEffect = (UIManager.GetInstance().GetCurrentUI() as GamePanel).Fx_Sceen;
        MagicInvest = UIManager.PutCambrian().PutPinonOrHiss(nameof(GamePanel)).GetComponent<GamePanel>().By_Magic;
        Vector2 SceenScale = MagicInvest.GetComponent<RectTransform>().localScale;
        //当屏幕尺寸
        if (Screen.width < 1080)
        {
            MagicInvest.GetComponent<RectTransform>().localScale = new Vector2(SceenScale.x * 1080 / (float)Screen.width, SceenScale.y * 1080 / (float)Screen.width);
        }
        else
        {
            MagicInvest.GetComponent<RectTransform>().localScale = new Vector2(SceenScale.x * (float)Screen.width / 1080, SceenScale.y * (float)Screen.width / 1080);
        }
    }
    private void Awake()
    {
        MessageManager.PutCambrian().FirChapbook(MessageCode.PostwarVanishBlame, PostwarBlame);
        MessageManager.PutCambrian().FirChapbook<int>(MessageCode.SkiFomentBard, SkiFoment);
        MessageManager.PutCambrian().FirChapbook(MessageCode.PostwarFoment, PostwarFoment);
        MessageManager.PutCambrian().FirChapbook<LevelGuideInfo.LevelGuideData>(MessageCode.BelowClick, PotteryClickShow);
        MessageManager.PutCambrian().FirChapbook<Transform>(MessageCode.TariffClothe, TariffArmyClothe);
        MessageManager.PutCambrian().FirChapbook(MessageCode.PostwarClotheMat, PostwarClotheMat);
    }

    private void OnDestroy()
    {
        MessageManager.PutCambrian().SlowlyChapbook(MessageCode.PostwarVanishBlame, PostwarBlame);
        MessageManager.PutCambrian().SlowlyChapbook<int>(MessageCode.SkiFomentBard, SkiFoment);
        MessageManager.PutCambrian().SlowlyChapbook(MessageCode.PostwarFoment, PostwarFoment);
        MessageManager.PutCambrian().SlowlyChapbook<LevelGuideInfo.LevelGuideData>(MessageCode.BelowClick, PotteryClickShow);
        MessageManager.PutCambrian().SlowlyChapbook<Transform>(MessageCode.TariffClothe, TariffArmyClothe);
        MessageManager.PutCambrian().SlowlyChapbook(MessageCode.PostwarClotheMat, PostwarClotheMat);
    }

    private void TariffArmyClothe(Transform obj)
    {
        if (ItClothe && !CommonUtil.ItOxide())
        {
            ClotheBranch = Instantiate(ClotheCut, obj);
            ClotheBranch.transform.position = ClotheMat.transform.position;
            ExhalePierce = NetInfoMgr.instance.ZealShow.rewardvaseData.reward_num + GameUtil.GetCashMulti();
            ClotheBranch.GetComponent<RewardCell>().Tact(ExhalePierce);
        }
    }
    private void PostwarClotheMat()
    {
        if (ItClothe && !CommonUtil.ItOxide())
        {
            ClotheBranch.transform.position = ClotheMat.transform.position;
        }
    }

    private bool ItSkiFoment= false;
    //使用提示 如果瓶子序号相等，执行点击操作
    public void SkiFoment(int VaseIndex)
    {
        ItSkiFoment = true;
        if (VaseIndex == ArmyNotion)
        {
            CheepShow();
        }
    }

    public void CornetEdgeSilt()
    {
        ItTextileBard(false);
        GameManager.PutCambrian().EdgeSiltCheep();
    }

    public void PotteryClickShow(LevelGuideInfo.LevelGuideData guide)
    {
        ClickShow = guide;
        if (ClickShow.ClickArmyID == ArmyNotion)
        {
            ClickDetail(gameObject.transform.position);
        }
    }

    private void CornetClickDetail()
    {
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) == 1)
        {
            if (ArmyNotion == ClickShow.ClickArmyID)
            {
                ClickDetail(gameObject.transform.position);
            }
        }
    }

    public void VagueTentacle()
    {
    }
}

