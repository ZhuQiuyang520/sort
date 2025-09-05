using DG.Tweening;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunDiverPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("bigWheelItem")]    //public List<GameObject> LightList;
    public GameObject PaySlopeRaft;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheelItem")]    public GameObject BeachSlopeRaft;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheel")]    public GameObject BeachSlope;
[UnityEngine.Serialization.FormerlySerializedAs("bigWheel")]    public GameObject PaySlope;
[UnityEngine.Serialization.FormerlySerializedAs("pointer")]    public GameObject Spatial;
[UnityEngine.Serialization.FormerlySerializedAs("spinButton")]    public Button DeepInnate;

    List<GameObject> PayRaftPuff;
    bool DyTact= false;

    private RewardPanelData _ExhaleShow;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        MeetFloorGently.PutCambrian().RoofFloor("1004");
        ZealImagery.PutCambrian().StepperTrail(HapticPatterns.PresetType.Success);
        DeepInnate.gameObject.SetActive(true);
        GushSlope();
        _ExhaleShow = new RewardPanelData();
    }

    private void Start()
    {
        DeepInnate.onClick.AddListener(Deep);
    }

    void GushSlope()
    {
        if (!DyTact)
        {
            DyTact = true;
            PayRaftPuff = new List<GameObject>();
            for (int i = 0; i < 8; i++)
            {
                TurnRewardData rewardItem = RatLadyTen.instance.ZealShow.wheel_reward_weight_group[i];
                GameObject bigItem = Instantiate(PaySlopeRaft, PaySlope.transform);
                string type = rewardItem.type;
                //if (InnateWine.IsApple() && (type == "cash"))
                //{
                //    type = "gold";
                //}
                bigItem.GetComponent<BigWheelItem>().initIcon(type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
                bigItem.transform.eulerAngles = new Vector3(0, 0, -i * (360 / 8f));
                PayRaftPuff.Add(bigItem);
            }
            for (int i = 0; i < 6; i++)
            {
                WheelMultiItem multiItem = RatLadyTen.instance.ZealShow.wheel_reward_multi.diamand[i];
                GameObject smallItem = Instantiate(BeachSlopeRaft, BeachSlope.transform);
                smallItem.GetComponent<SmallWheelItem>().text.text = "×" + multiItem.multi.ToString();
                smallItem.transform.eulerAngles = new Vector3(0, 0, i * (360 / 6f));
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                TurnRewardData rewardItem = RatLadyTen.instance.ZealShow.wheel_reward_weight_group[i];
                GameObject bigItem = PayRaftPuff[i];
                bigItem.GetComponent<BigWheelItem>().initIcon(rewardItem.type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
            }
        }
        DeepInnate.transform.localScale = Vector3.zero;
        DeepInnate.transform.DOScale(new Vector3(0.7f, 0.7f, 1), 0.2f).SetDelay(0.2f);
        PaySlope.transform.eulerAngles = new Vector3(0, 0, 180);
        BeachSlope.transform.eulerAngles = new Vector3(0, 0, 0);

    }
    public void Deep()
    {
        CashOutManager.PutCambrian().AddTaskValue("Wheel", 1);
        ZealImagery.PutCambrian().StepperTrail(HapticPatterns.PresetType.LightImpact);
        //StartCoroutine(pointerAnimation());
        int bigIndex = GameUtil.GetRewardIndexWithWeight(RatLadyTen.instance.ZealShow.wheel_reward_weight_group);
        TurnRewardData rewardData = RatLadyTen.instance.ZealShow.wheel_reward_weight_group[bigIndex];
        int smallIndex = GameUtil.GetWheelMultiIndex(rewardData.type);
        float multi = (float)RatLadyTen.instance.ZealShow.wheel_reward_multi.diamand[smallIndex].multi;

        PaySlope.transform.DORotate(new Vector3(0, 0, 360 * 10 + (360 / 8f) * bigIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine);
        BeachSlope.transform.DORotate(new Vector3(0, 0, -360 * 10 - (360 / 6f) * smallIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine).OnComplete(() => {
            StartCoroutine(WithFadCurvature(() =>
            {
                Debug.Log(rewardData.type + ", " + rewardData.num + ", ×" + multi);
                DryPutClothePinon(rewardData.type, multi * (float)rewardData.num);
            }));
        });
        DeepInnate.gameObject.SetActive(false);
    }
    IEnumerator SpatialCurvature()
    {
        yield return new WaitForSeconds(0.2f);
        Sequence seq = DOTween.Sequence();
        seq.Append(Spatial.transform.DOLocalRotate(new Vector3(0, 0, -20 + UnityEngine.Random.Range(-2f, 2f)), 2f / 36 * 0.3f)
            .SetEase(Ease.Linear));
        seq.Append(Spatial.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f / 36 * 0.7f).SetEase(Ease.Linear));
        seq.AppendCallback(() => {
            //HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        });
        seq.SetLoops(36);
        seq.SetEase(Ease.InOutSine);
        seq.Play();
    }
    /// <summary>
    /// 中奖动画
    /// </summary>
    /// <param name="finish"></param>
    public IEnumerator WithFadCurvature(System.Action finish)
    {
        //var light = DOTween.Sequence();
        //fx_wheel.SetActive(true);
        //light.Append(LightList[0].GetComponent<Image>().DOFade(1, 0.15f));
        //light.Append(LightList[0].GetComponent<Image>().DOFade(0, 0.15f));
        //light.SetLoops(5, LoopType.Restart);
        //var light_1 = DOTween.Sequence();
        //light_1.Append(LightList[1].GetComponent<Image>().DOFade(1, 0.15f));
        //light_1.Append(LightList[1].GetComponent<Image>().DOFade(0, 0.15f));
        //light_1.SetLoops(5, LoopType.Restart);
        yield return new WaitForSeconds(1.5f);
        //LightList[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //LightList[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        finish();
    }
    /// <summary>
    /// 弹出奖励弹窗
    /// </summary>
    /// <param name="type">奖励类型</param>
    /// <param name="num">奖励金额</param>
    public void DryPutClothePinon(string type, float num)
    {
        RewardType rewardType = RewardType.Gold;
        if (type == "diamand")
        {
            rewardType = RewardType.diamand;
            //if (InnateWine.IsApple())
            //{
            //    rewardType = RewardType.Gold;
            //}
        }
        if (type == "gold")
        {
            rewardType = RewardType.Gold;
        }
        if (type == "add")
        {
            rewardType = RewardType.add;
        }
        if (type == "roll")
        {
            rewardType = RewardType.roll;
        }
        if (type == "remind")
        {
            rewardType = RewardType.remind;
        }
        _ExhaleShow.JustWhen = "LuckyWheel";
        
        _ExhaleShow.Wax_Clothe.Add(rewardType, num);
        XenonUILift(GetType().Name);
        UIImagery.PutCambrian().ShunUIShiny(nameof(StillChicPinon), _ExhaleShow);
        ADImagery.Cambrian.InvadeWakeEntrepreneur();
    }
}
