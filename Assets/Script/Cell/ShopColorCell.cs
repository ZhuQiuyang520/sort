using Lofelt.NiceVibrations;
using sf_database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static MusicType;

public class ShopColorCell : MonoBehaviour
{
    public Toggle ShopTog;

    public Button BuyButton;

    public Image BGImage;

    public Image NullImage;

    public Text SkinPrice;

    public Text LevelText;

    public GameObject SelectStatus;
    public GameObject BuyStatus;
    public GameObject NullStatus;
    public GameObject LevelStatus;

    public GameObject Fx_Shoplock;

    //�Ѿ�ӵ�е�ȫ��Ƥ��
    private List<int> ALLSkin = new List<int>();
    private Action<ShopConfig> BuyAction;
    private int CurUseSkin;

    private ShopConfig ShopData;

    private string ColorImagePath = "Art/Tex/Sprite/UI/ShopPanel/Color/";
    private string TubeImagePath = "Art/Tex/Sprite/UI/ShopPanel/Tube/";
    private string ImagePath;
    private Action<ShopConfig, Vector3> ShopGuideAction;

    private bool IsClick = false;

    private void OnEnable()
    {
        if (ShopData != null)
        {
            LevelText.text = "Level " + ShopData.unclock_lv;
        }
    }

    public void Init(ToggleGroup group , ShopConfig data , Action<ShopConfig> AC , Action<ShopConfig, Vector3> AcGuide)
    {
        ShopGuideAction = AcGuide;
        ShopTog.group = group;
        ShopTog.onValueChanged.AddListener(ChangeTog);
        if (data.type == 2)
        {
            Invoke(nameof(InvokeShopGuide), 0.1f);
            ImagePath = ColorImagePath;
        }
        else if (data.type == 1)
        {
            ImagePath = TubeImagePath;
        }
#if UNITY_EDITOR
        BGImage.sprite = Resources.Load(ImagePath + data.pic, typeof(Sprite)) as Sprite;
#else
        BGImage.sprite = Resources.Load(ImagePath + data.pic, typeof(Sprite)) as Sprite;
#endif
        ShopData = data;
        BuyAction = AC;

        if (data.id == 0)
        {
            NullImage.sprite = Resources.Load(ImagePath + data.pic, typeof(Sprite)) as Sprite;
            BGImage.gameObject.SetActive(false);

            NullStatus.SetActive(true);
        }
        else
        {
            BGImage.gameObject.SetActive(true);
            if (data.type == 2)
            {
                CurUseSkin = PlayerPrefs.GetInt(DataManager.AcidDNAUser);
                ALLSkin = DataManager.PutPuff(DataManager.AcidWetBlameUser);
            }
            else if (data.type == 1)
            {
                CurUseSkin = PlayerPrefs.GetInt(DataManager.AcidArmyUser);
                ALLSkin = DataManager.PutPuff(DataManager.AcidWetArmyUser);
            }
            //��ǰӵ�е�����Ƥ��
            //�жϵ�ǰƤ���ǲ�������ʹ�õ�
            if (ALLSkin.Contains(data.id))
            {
                SelectStatus.SetActive(true);
                if (data.id == CurUseSkin)
                {
                    ChangeTog(true);
                }
            }
            else
            {
                if (data.unclock_lv > PlayerPrefs.GetInt(DataManager.AcidBelow))
                {
                    LevelStatus.SetActive(true);
                    //string str = string.Format(I18NManager.Instance.GetText("Level_Limit{0}"),data.unclock_lv);
                    //LevelText.text = str;
                    LevelText.text = "Level " + data.unclock_lv;
                }
                else
                {
                    BuyStatus.SetActive(true);
                    IsClick = true;
                    SkinPrice.text = data.price.ToString();
                }
            }
        }
        BuyButton.onClick.AddListener(BuyColorGroup);
    }

    public void BuyColorGroup()
    {
        if (IsClick)
        {
            GameManager.PutCambrian().StepperJudge(UIMusic.click);
            int CurPlayerCoin = PlayerPrefs.GetInt(CConfig.Ax_SlamCore);
            if (CurPlayerCoin >= ShopData.price)
            {
                IsClick = false;
                PostEventScript.PutCambrian().RoofFloor("1006");
                BaseUseCoin useCoin = new BaseUseCoin();
                useCoin.Auger_On = PlayerPrefs.GetInt(DataManager.AcidBelow);
                useCoin.Reset = ShopData.price;
                GameManager.PutCambrian().StepperTrail(HapticPatterns.PresetType.Selection);
                AnimationGroup.OfTextClubPut(Fx_Shoplock, gameObject, () =>
                {
                    if (ShopData.type == 1)
                    {
                        useCoin.Daunt = "tube";
                        PlayerPrefs.SetInt(DataManager.AcidArmyUser, ShopData.id);
                    }
                    else if (ShopData.type == 2)
                    {
                        useCoin.Daunt = "color";
                        PlayerPrefs.SetInt(DataManager.AcidDNAUser, ShopData.id);
                    }
                    BuyAction(ShopData);
                    BuyStatus.SetActive(false);
                    SelectStatus.SetActive(true);
                    ChangeTog(true);
                });

            }
            else
            {
                //UIManager.GetInstance().ShowUIForms(nameof(DontShopPopup));
            }
        }
    }

    public void ChangeTog(bool open)
    {
        GameManager.PutCambrian().StepperJudge(MusicType.UIMusic.click);
        if (open)
        {
            ShopTog.isOn = true;
            if (ShopData.type == 2)
            {
                PlayerPrefs.SetInt(DataManager.AcidDNAUser,ShopData.id);
                GameManager.PutCambrian().PartDNAUser();
            }
            else if (ShopData.type == 1)
            {
                PlayerPrefs.SetInt(DataManager.AcidArmyUser, ShopData.id);
            }
        }
    }

    private void InvokeShopGuide()
    {
        ShopGuideAction(ShopData, BuyButton.transform.position);
    }
}
