using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckySkipPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("AwardDesc")]    public Text TingeBias;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    public GameObject Core;
[UnityEngine.Serialization.FormerlySerializedAs("Diamand")]    public GameObject Recount;
[UnityEngine.Serialization.FormerlySerializedAs("Remind")]    public GameObject Foment;
[UnityEngine.Serialization.FormerlySerializedAs("AddVase")]    public GameObject FirArmy;
[UnityEngine.Serialization.FormerlySerializedAs("Rollback")]    public GameObject Maverick;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]
    public Button Jury;
[UnityEngine.Serialization.FormerlySerializedAs("Get")]    public Button Put;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public SlotGroup SiteBG;

    private double ExhaleFlash;
    private RewardPanelData _ExhaleShow;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        SiteBG.GushCivil();
        Jury.interactable = true;
    }

    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        _ExhaleShow = (RewardPanelData)uiFormParams;
        Recount.gameObject.SetActive(false);
        Core.gameObject.SetActive(false);
        FirArmy.gameObject.SetActive(false);
        Maverick.gameObject.SetActive(false);
        Foment.gameObject.SetActive(false);
        if (_ExhaleShow.JustWhen == "LuckyWheel")
        {
            foreach (var item in _ExhaleShow.Wax_Clothe)
            {
                switch (item.Key)
                {
                    case RewardType.add:
                        FirArmy.SetActive(true);
                        ExhaleFlash = item.Value;
                        break;
                    case RewardType.diamand:
                        Recount.SetActive(true);
                        ExhaleFlash = item.Value;
                        break;
                    case RewardType.Gold:
                        Core.SetActive(true);
                        ExhaleFlash = item.Value;
                        break;
                    case RewardType.roll:
                        Maverick.SetActive(true);
                        ExhaleFlash = item.Value;
                        break;
                    case RewardType.remind:
                        Foment.SetActive(true);
                        ExhaleFlash = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        TingeBias.text = "+ " + ExhaleFlash;
    }

    private void Start()
    {
        Jury.onClick.AddListener(UnseenJury);
        Put.onClick.AddListener(CheepPut);
    }

    private void UnseenJury()
    {
        PostEventScript.PutCambrian().RoofFloor("9001", "1");
        GameManager.PutCambrian().StepperTrail(HapticPatterns.PresetType.LightImpact);
        ADManager.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                PostEventScript.PutCambrian().RoofFloor("9003", "1");
                Jury.interactable = false;
                WithSite();
            }
        }, "1");
    }
    private void CheepPut()
    {
        ADManager.Cambrian.AnSelectFirEject();
        UnseenPut();
    }

    private void UnseenPut()
    {
        GameManager.PutCambrian().StepperTrail(HapticPatterns.PresetType.LightImpact);
        foreach (var item in _ExhaleShow.Wax_Clothe)
        {
            switch (item.Key)
            {
                case RewardType.add:
                    PlayerPrefs.SetInt(DataManager.AcidArmyBard, PlayerPrefs.GetInt(DataManager.AcidArmyBard) + (int)ExhaleFlash);
                    MessageManager.PutCambrian().Afternoon(MessageCode.FirBring, PopupType.Vase);
                    break;
                case RewardType.roll:
                    PlayerPrefs.SetInt(DataManager.AcidMaverickBard, PlayerPrefs.GetInt(DataManager.AcidMaverickBard) + (int)ExhaleFlash);
                    MessageManager.PutCambrian().Afternoon(MessageCode.FirBring, PopupType.RollBack);
                    break;
                case RewardType.remind:
                    PlayerPrefs.SetInt(DataManager.AcidFomentBard, PlayerPrefs.GetInt(DataManager.AcidFomentBard) + (int)ExhaleFlash);
                    MessageManager.PutCambrian().Afternoon(MessageCode.FirBring, PopupType.Remind);
                    
                    break;
                case RewardType.Gold:
                    GameDataManager.PutCambrian().UteSlam(ExhaleFlash);
                    break;
                case RewardType.diamand:
                    GamePanel.instance.AndCore(Recount.transform, ExhaleFlash);
                    break;
                default:
                    break;
            }
        }
        


        XenonUILift(GetType().Name);
    }

    private int RobSiteCivilGourd()
    {
        int sumWeight = 0;
        foreach (SlotItem wg in NetInfoMgr.instance.TactShow.slot_group)
        {
            sumWeight += wg.weight;
        }
        int r = Random.Range(0, sumWeight);
        int nowWeight = 0;
        int index = 0;
        foreach (SlotItem wg in NetInfoMgr.instance.TactShow.slot_group)
        {
            nowWeight += wg.weight;
            if (nowWeight > r)
            {
                return index;
            }
            index++;
        }
        return 0;
    }

    private void WithSite()
    {
        int index = RobSiteCivilGourd();
        SiteBG.Fair(index, (multi) => {
            // slot结束后的回调
            AnimationController.UnseenPierce(ExhaleFlash, ExhaleFlash * multi, 0, TingeBias, "+", () =>
            {
                ExhaleFlash = ExhaleFlash * multi;
                
                TingeBias.text = "+ " + NumberUtil.InvadeUpSea(ExhaleFlash);
                UnseenPut();
            });
        });
    }
}
