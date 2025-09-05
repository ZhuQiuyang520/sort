using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class TurnUIShiny : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("_CurrentUIType")]    //当前（基类）窗口的类型
    public UIWhen _BizarreUIWhen= new UIWhen();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Moody_Scurry;
    //属性，当前ui窗体类型
    internal UIWhen BizarreUIWhen    {
        set
        {
            _BizarreUIWhen = value;
        }
        get
        {
            return _BizarreUIWhen;
        }
    }
    protected virtual void Awake()
    {
        TeamAuralFirHumiliate(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Moody_Scurry = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Moody_Scurry.onClick.AddListener(() => {
                UIImagery.PutCambrian().XenonDyCowboyUIShiny(this.GetType().Name);
            });
        }
        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }

    public static void TeamAuralFirHumiliate(GameObject goParent)
    {
        Transform parent = goParent.transform;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = parent.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() => {

                });
            }

            if (chile.childCount > 0)
            {
                TeamAuralFirHumiliate(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display(object uiFormParams)
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp && _BizarreUIWhen.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIGlueTen.PutCambrian().AntGlueJoiner(this.gameObject, _BizarreUIWhen.UIForm_LucencyType);
        }
        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_BizarreUIWhen.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    CurvatureFahrenheit.BagShun(gameObject, () =>
                    {

                    });
                    break;

            }
            
        }
        if (uiFormParams != null)
        {
            OnMessageReceived(uiFormParams);
        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        //{
        //    UIGlueTen.GetInstance().HideMaskWindow();
        //}

        //取消模态窗体调用

        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
        {
            switch (_BizarreUIWhen.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    CurvatureFahrenheit.BagHide(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp && _BizarreUIWhen.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UIGlueTen.PutCambrian().TycoonGlueJoiner();
                        }
                        UIImagery.PutCambrian().ShunNileBagBy();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp && _BizarreUIWhen.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UIGlueTen.PutCambrian().TycoonGlueJoiner();
                    }
                    UIImagery.PutCambrian().ShunNileBagBy();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
            //{
            //    UIGlueTen.GetInstance().CancelMaskWindow();
            //}
            finish?.Invoke();
        }
    }

    protected virtual void OnMessageReceived(object uiFormParams)
    {

    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
        {
            UIGlueTen.PutCambrian().AntGlueJoiner(this.gameObject, _BizarreUIWhen.UIForm_LucencyType); 
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Occupy()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void ListenerInnateBranchFloor(string buttonName,FloorBiologyChapbook.VoidDelegate delHandle)
    {
        GameObject goButton = BelleQuasar.TeamBedAuralPeal(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            FloorBiologyChapbook.Put(goButton).onCheep = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="uiFormName"></param>
    protected void TaskUILift(string uiFormName)
    {
        UIImagery.PutCambrian().ShunUIShiny(uiFormName);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void XenonUILift(string uiFormName)
    {
        //处理后的uiform名称
        UIImagery.PutCambrian().XenonDyCowboyUIShiny(uiFormName);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void RoofPottery(string msgType,string msgName,object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        PotteryFrenzy.RoofPottery(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void FatefulPottery(string messageType,PotteryFrenzy.DelMessageDelivery handler)
    {
        PotteryFrenzy.FirNssChapbook(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Shun(string id)
    {
        string strResult = string.Empty;
        strResult = MedicineTen.PutCambrian().ShunHand(id);
        return strResult;
    }
}
