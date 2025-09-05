using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FlyItem : MonoBehaviour
{
    public Button FlyButton;
    public Text CashValue;

    private Sequence _Via1;
    private Sequence _Via2;

    private double _cashNum;

    private void Awake()
    {
        FlyButton.onClick.AddListener(() => {
            //if (NewbieManager.GetInstance().IsOpenNewbie) { return; }
            //if (BubbleManager.GetInstance().IsWinGame()) { return; }
            AndImagery.Instance.DyTaskAnd = true;
            AndImagery.Instance.TaskIEAnd();
            MeetFloorGently.PutCambrian().RoofFloor("1011");
            GetReward();

        });
        GunTuneReason();
    }


    public void FlyPlay()
    {
        transform.DOPlay();
        _Via1.Play();
        _Via2.Play();
    }

    public void FlyPause()
    {
        transform.DOPause();
        _Via1.Pause();
        _Via2.Pause();
    }

    public void FlyKill()
    {
        _Via1.Kill();
        _Via2.Kill();
        transform.DOKill();
    }

    private void GetReward()
    {
        //RewardPanelData data = new RewardPanelData();
        //data.MiniType = "Fly";
        //data.Dic_Reward.Add(RewardType.cash, _cashNum);
        //RewardManager.GetInstance().OpenLevelCompletePanel(data);
        MeetFloorGently.PutCambrian().RoofFloor("9001", "2");
        ADImagery.Cambrian.WithClotheFolly((success) =>
        {
            if (success)
            {
                MeetFloorGently.PutCambrian().RoofFloor("9003", "2");
                ZealPinon.instance.AndCore(this.transform, _cashNum);
                DestroyFlyItem();
            }
        }, "2");
    }

    private void GunTuneReason()
    {
        _cashNum = RatLadyTen.instance.ZealShow.bubbledata.reward_num * GameUtil.GetCashMulti();
        _cashNum = Mathf.Ceil((float)_cashNum);
        CashValue.text =  _cashNum.ToString();
        _Via1 = DOTween.Sequence();
        _Via2 = DOTween.Sequence();
        /*int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {*/
            LeftFly();
        /*}
        else
        {
            RigthFly();
        }*/
    }

    private void LeftFly()
    {
        transform.localPosition = new Vector3(-650f, 0, 0);
        _Via1 = DOTween.Sequence();
        _Via2 = DOTween.Sequence();
        _Via1.Append(transform.DOLocalMoveY(-250f - Random.Range(-100f, 100f), 2.5f).SetEase(Ease.InSine));
        _Via1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Via1.SetLoops(-1);
        _Via1.Play();

        _Via2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _Via2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _Via2.SetLoops(-1);
        _Via2.Play();
        transform.DOLocalMoveX(650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (AndImagery.Instance.DyTaskAnd)
            {
                DestroyFlyItem();
            }
            else
            {
                FlyKill();
                StartCoroutine(LoopFly(() => { RigthFly(); }));
            }
        });
    }

    private void RigthFly()
    {
        transform.localPosition = new Vector3(650, 100, 0);
        _Via1 = DOTween.Sequence();
        _Via2 = DOTween.Sequence();
        _Via1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Via1.Append(transform.DOLocalMoveY(100, 2.5f).SetEase(Ease.InSine));
        _Via1.SetLoops(-1);
        _Via1.Play();

        _Via2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _Via2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _Via2.SetLoops(-1);
        _Via2.Play();
        transform.DOLocalMoveX(-650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (AndImagery.Instance.DyTaskAnd)
            {
                DestroyFlyItem();
            }
            else
            {
                FlyKill();
                StartCoroutine(LoopFly(() => { LeftFly(); }));
            }

        });
    }

    IEnumerator LoopFly(Action action)
    {
        yield return new WaitForSeconds(5f);
        action?.Invoke();
    }

    public void DestroyFlyItem()
    {
        FlyKill();
        GetComponent<RectTransform>().DOKill();
        Destroy(gameObject);
    }

}
