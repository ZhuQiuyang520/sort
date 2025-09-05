using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyManager : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyItem")]    public GameObject AndRaft;
    public static FlyManager Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isOpenFly")]
    public bool DyTaskAnd;
[UnityEngine.Serialization.FormerlySerializedAs("leftOrRight")]    public int LiraOrTrail;

    private int _ZebraTaskWake;
    private int _AddFirWake;

    private GameObject Bat;

    private void Awake()
    {
        Instance = this;
        _AddFirWake = 0;
        DyTaskAnd = true;
        _ZebraTaskWake = NetInfoMgr.instance.ZealShow.bubble_cd;
        LiraOrTrail = 0;
    }

    private void OnEnable()
    {
        if (!DyTaskAnd)
        {
            if (Bat != null)
            {
                Bat.GetComponent<FlyItem>().DestroyFlyItem();
            }
            DyTaskAnd = !DyTaskAnd;
        }
        TaskIEAnd();
    }

    public void TaskIEAnd()
    {
        StopCoroutine(nameof(TaskAndOutwit));
        StartCoroutine(nameof(TaskAndOutwit));
    }
    IEnumerator TaskAndOutwit()
    {
        while (DyTaskAnd)
        {
            if (_AddFirWake >= _ZebraTaskWake)
            {
                TariffAndRaft();
            }
            _AddFirWake++;
            yield return new WaitForSeconds(1);
        }
    }

    public void EmblemAndRaft()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<FlyItem>().DestroyFlyItem();
            DyTaskAnd = true;
        }
    }

    public void TariffAndRaft()
    {
        if (!DyTaskAnd) { return; }
        // 新增：引导阶段禁止飞行气泡
        if (PlayerPrefs.GetInt(DataManager.AcidBelow) <= 2 || CommonUtil.ItOxide())
        {
            return;
        }
        //if (BubbleManager.GetInstance().IsWinGame()) { return; }
        //  if ( LevelManager.GetInstance().CurLevel > 1 && !CommonUtil.IsApple
        DyTaskAnd = false;
        _AddFirWake = 0;
        Bat = Instantiate(AndRaft.gameObject);
        Bat.transform.SetParent(transform);
        Bat.transform.localScale = Vector3.one;
        Bat.transform.localPosition = LiraOrTrail == 0 ? new Vector3(-650, 0, 0) : new Vector3(650, 0, 0);
    }

    //public void SendFlyCollider(BubbleItem bubble)
    //{
    //    KeyValuesUpdate key = new KeyValuesUpdate(StringConst.SendFlyCollider, bubble);
    //    MessageCenter.SendMessage(StringConst.SendFlyCollider, key);
    //}
}
