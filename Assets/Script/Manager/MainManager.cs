using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

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
            CommonUtil.DraperyPanelPella();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GustTact()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CConfig.Ax_ItTowRecall + "Bool") || SaveDataManager.PutTest(CConfig.Ax_ItTowRecall);
        AdjustInitManager.Instance.TactFecundShow(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            SaveDataManager.AntTest(CConfig.Ax_ItTowRecall, false);
            GameDataManager.PutCambrian().UteSlam(NetInfoMgr.instance.ZealShow.initgamedata.initial_coin);
            PlayerPrefs.SetInt(DataManager.AcidArmyBard, NetInfoMgr.instance.ZealShow.initgamedata.add_bottles_nums);
            PlayerPrefs.SetInt(DataManager.AcidFomentBard, NetInfoMgr.instance.ZealShow.initgamedata.Hint_nums);
            PlayerPrefs.SetInt(DataManager.AcidMaverickBard, NetInfoMgr.instance.ZealShow.initgamedata.withdrawn_nums);
            PlayerPrefs.SetInt(DataManager.AcidBelow, 1);
            PlayerPrefs.SetInt(DataManager.AcidTentacleBelow, 3);
            PlayerPrefs.SetInt(DataManager.AcidBelowBuck, 1);
            PlayerPrefs.SetInt(DataManager.AcidDepositor, 1);
            PlayerPrefs.SetString(DataManager.ReckonEntombBelow, "");
            //获取瓶子和颜色的初始皮肤  数字为表里的colorGroup字段
            PlayerPrefs.SetInt(DataManager.AcidDNAUser, 1);
            //存储的数据为colorGroup字段
            DataManager.AntPuff(DataManager.AcidWetBlameUser, 0, 1);
            PlayerPrefs.SetInt(DataManager.AcidArmyUser, 1);
            DataManager.AntPuff(DataManager.AcidWetArmyUser, 0, 1);
            //商店引导是否执行 0未执行 1执行过
            PlayerPrefs.SetInt(DataManager.AcidOfTextClub, 0);
            PlayerPrefs.SetInt(DataManager.AcidDepositor, 1);
            PlayerPrefs.SetInt(DataManager.AcidRoman, 0);
            PlayerPrefs.SetInt(DataManager.AcidJudge, 1);
            //MusicMgr.GetInstance().setBgmCloseOneTime();
           
            GameManager.PutCambrian().ItTrail = true;
            GameManager.PutCambrian().ItRoman = true;
            GameManager.PutCambrian().ItJudge = true;
        }
        else
        {
            //读取是否开启震动设置
            if (PlayerPrefs.GetInt(DataManager.AcidDepositor) == 1)
            {
                GameManager.PutCambrian().ItTrail = true;
            }
            else
            {
                GameManager.PutCambrian().ItTrail = false;
            }

            //if (PlayerPrefs.GetInt(DataManager.SaveMusic) == 1)
            //{
            //    GameManager.GetInstance().IsMusic = true;
            //    MusicMgr.GetInstance().setBgmReplaceOneTime();
            //}
            //else
            //{
            //    GameManager.GetInstance().IsMusic = false;
            //    MusicMgr.GetInstance().setBgmCloseOneTime();
            //}

            if (PlayerPrefs.GetInt(DataManager.AcidJudge) == 1)
            {
                GameManager.PutCambrian().ItJudge = true;
            }
            else
            {
                GameManager.PutCambrian().ItJudge = false;
            }
        }

        //MusicMgr.GetInstance().PlayBg(MusicType.SceneMusic.bgm);
        GameManager.PutCambrian().PartDNAUser();
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) == 1)
        {
            UIManager.PutCambrian().ShunUIShiny(nameof(GamePanel));
        }
        else
        {
            UIManager.PutCambrian().ShunUIShiny(nameof(HomePanel));
        }

        GameDataManager.PutCambrian().TactZealShow();

        Disco = true;

    }

}
