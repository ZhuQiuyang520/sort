using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static RomanWhen;
using DG.Tweening;

/// <summary>
/// LoadPanelView - 自动生成的UI视图脚本
/// </summary>
public class PartPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    #region UI组件
    public GameObject[] PuffBuyer;
    public static PartPinon Instance;
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image SalmonDisco;
[UnityEngine.Serialization.FormerlySerializedAs("ProgressText")]    public Text ProfoundHand;
[UnityEngine.Serialization.FormerlySerializedAs("LoadingItems")]
    public List<GameObject> ConsumeClock;
    #endregion

    #region 生命周期函数

    private void Start()
    {
        MeetFloorGently.PutCambrian().RoofFloor("1001");
        MeetFloorGently.PutCambrian().MuchZealProfound();
        CurvatureBelow.ConsumePut(ConsumeClock);
        for (int i = 0; i < PuffBuyer.Length; i++)
        {
            ZealImagery.PutCambrian().EyelidConcentrate(PuffBuyer[i].GetComponent<RectTransform>());
        }
        SalmonDisco.fillAmount = 0;
        ProfoundHand.text = "0%";
        CashOutManager.PutCambrian().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    #endregion

    #region 事件绑定
    private void Update()
    {
        // 如果没有登录成功，进度卡在60%，显示“登录中”
        // 如果登录后没有成功获取配置，进度卡在80%，显示“获取配置中”
        // 如果登录成功，获取配置成功，但有其他问题，进度卡在90%，显示“初始化中”
        if (SalmonDisco.fillAmount <= 0.8f || (RatLadyTen.instance.Disco && CashOutManager.PutCambrian().Ready))
        {
            SalmonDisco.fillAmount += Time.deltaTime * 0.2f;
            ProfoundHand.text = (int)(SalmonDisco.fillAmount * 100) + "%";

            if (SalmonDisco.fillAmount >= 1)
            {
                // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (InnateWine.DraperyPanelPella())
                {
                    this.enabled = false;
                    return;
                }
                    
                InnateWine.ItOxide();
                Destroy(transform.parent.gameObject);
                SlitImagery.instance.GustTact();
                CashOutManager.PutCambrian().ReportEvent_LoadingTime();
            }
        }

    }
    #endregion

}
