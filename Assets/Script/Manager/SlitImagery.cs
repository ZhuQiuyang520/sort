using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlitImagery : MonoBehaviour
{
    public static SlitImagery instance;

    private bool Disco= false;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    //切前后台也需要检测屏蔽 防止游戏中途更改手机状态
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            InnateWine.DraperyPanelPella();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GustTact()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CExcite.Ax_ItTowRecall + "Bool") || AcidShowImagery.PutTest(CExcite.Ax_ItTowRecall);
        FecundTactImagery.Instance.TactFecundShow(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            AcidShowImagery.AntTest(CExcite.Ax_ItTowRecall, false);
            ZealShowImagery.PutCambrian().UteSlam(RatLadyTen.instance.ZealShow.initgamedata.initial_coin);
            PlayerPrefs.SetInt(ShowImagery.AcidArmyBard, RatLadyTen.instance.ZealShow.initgamedata.add_bottles_nums);
            PlayerPrefs.SetInt(ShowImagery.AcidFomentBard, RatLadyTen.instance.ZealShow.initgamedata.Hint_nums);
            PlayerPrefs.SetInt(ShowImagery.AcidMaverickBard, RatLadyTen.instance.ZealShow.initgamedata.withdrawn_nums);
            PlayerPrefs.SetInt(ShowImagery.AcidBelow, 1);
            PlayerPrefs.SetInt(ShowImagery.AcidTentacleBelow, 3);
            PlayerPrefs.SetInt(ShowImagery.AcidBelowBuck, 1);
            PlayerPrefs.SetInt(ShowImagery.AcidDepositor, 1);
            PlayerPrefs.SetString(ShowImagery.ReckonEntombBelow, "");
            //获取瓶子和颜色的初始皮肤  数字为表里的colorGroup字段
            PlayerPrefs.SetInt(ShowImagery.AcidDNAUser, 1);
            //存储的数据为colorGroup字段
            ShowImagery.AntPuff(ShowImagery.AcidWetBlameUser, 0, 1);
            PlayerPrefs.SetInt(ShowImagery.AcidArmyUser, 1);
            ShowImagery.AntPuff(ShowImagery.AcidWetArmyUser, 0, 1);
            //商店引导是否执行 0未执行 1执行过
            PlayerPrefs.SetInt(ShowImagery.AcidOfTextClub, 0);
            PlayerPrefs.SetInt(ShowImagery.AcidDepositor, 1);
            PlayerPrefs.SetInt(ShowImagery.AcidRoman, 0);
            PlayerPrefs.SetInt(ShowImagery.AcidJudge, 1);
            //RomanTen.GetInstance().setBgmCloseOneTime();
           
            ZealImagery.PutCambrian().ItTrail = true;
            ZealImagery.PutCambrian().ItRoman = true;
            ZealImagery.PutCambrian().ItJudge = true;
        }
        else
        {
            //读取是否开启震动设置
            if (PlayerPrefs.GetInt(ShowImagery.AcidDepositor) == 1)
            {
                ZealImagery.PutCambrian().ItTrail = true;
            }
            else
            {
                ZealImagery.PutCambrian().ItTrail = false;
            }

            //if (PlayerPrefs.GetInt(ShowImagery.SaveMusic) == 1)
            //{
            //    ZealImagery.GetInstance().IsMusic = true;
            //    RomanTen.GetInstance().setBgmReplaceOneTime();
            //}
            //else
            //{
            //    ZealImagery.GetInstance().IsMusic = false;
            //    RomanTen.GetInstance().setBgmCloseOneTime();
            //}

            if (PlayerPrefs.GetInt(ShowImagery.AcidJudge) == 1)
            {
                ZealImagery.PutCambrian().ItJudge = true;
            }
            else
            {
                ZealImagery.PutCambrian().ItJudge = false;
            }
        }

        //RomanTen.GetInstance().PlayBg(RomanWhen.SceneMusic.bgm);
        ZealImagery.PutCambrian().PartDNAUser();
        if (PlayerPrefs.GetInt(ShowImagery.AcidBelow) == 1)
        {
            UIImagery.PutCambrian().ShunUIShiny(nameof(ZealPinon));
        }
        else
        {
            UIImagery.PutCambrian().ShunUIShiny(nameof(TirePinon));
        }

        ZealShowImagery.PutCambrian().TactZealShow();

        Disco = true;

    }

}
