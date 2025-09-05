/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMaskMgr : MonoBehaviour
{
    private static UIMaskMgr _Cambrian= null;
    //ui根节点对象
    private GameObject _UpSquashHang= null;
    //ui脚本节点对象
    private Transform _DimUIWealthyPeal= null;
    //顶层面板
    private GameObject _UpToPinon;
    //遮罩面板
    private GameObject _UpGluePinon;
    //ui摄像机
    private Camera _UITenant;
    //ui摄像机原始的层深
    private float _AlthoughUITenantStamp;
    //获取实例
    public static UIMaskMgr PutCambrian()
    {
        if (_Cambrian == null)
        {
            _Cambrian = new GameObject("_UIMaskMgr").AddComponent<UIMaskMgr>();
        }
        return _Cambrian;
    }
    private void Awake()
    {
        _UpSquashHang = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);
        _DimUIWealthyPeal = UnityHelper.TeamBedAuralPeal(_UpSquashHang, SysDefine.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        UnityHelper.FirAuralPealUpStickyPeal(_DimUIWealthyPeal, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _UpToPinon = _UpSquashHang;
        _UpGluePinon = UnityHelper.TeamBedAuralPeal(_UpSquashHang, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UITenant = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UITenant != null)
        {
            //得到ui相机原始的层深
            _AlthoughUITenantStamp = _UITenant.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void AntGlueJoiner(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _UpToPinon.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _UpGluePinon.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _UpGluePinon.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _UpGluePinon.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _UpGluePinon.GetComponent<Image>().color = newColor2;
                MessageCenterLogic.PutCambrian().Roof(CConfig.mg_JoinerTask);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _UpGluePinon.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _UpGluePinon.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_UpGluePinon.activeInHierarchy)
                {
                    _UpGluePinon.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _UpGluePinon.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UITenant != null)
        {
            _UITenant.depth = _UITenant.depth + 100;
        }
    }
    public void PileGlueJoiner()
    {
        if (UIManager.PutCambrian().WaitUIShiny.Count > 0 || UIManager.PutCambrian().PutBizarreLiftBloom().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_UpGluePinon.GetComponent<Image>().color.r, _UpGluePinon.GetComponent<Image>().color.g, _UpGluePinon.GetComponent<Image>().color.b,0);
        _UpGluePinon.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void TycoonGlueJoiner()
    {
        if (UIManager.PutCambrian().WaitUIShiny.Count > 0 || UIManager.PutCambrian().PutBizarreLiftBloom().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIManager.PutCambrian().PutDisplayBeacon(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<BaseUIForms>();
            if (baseUIForm != null && baseUIForm.BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _UpGluePinon.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _UpToPinon.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_UpGluePinon.activeInHierarchy)
            {
                _UpGluePinon.SetActive(false);
                MessageCenterLogic.PutCambrian().Roof(CConfig.So_JoinerXenon);
            }
            //恢复当前ui摄像机的层深
            if (_UITenant != null)
            {
                _UITenant.depth = _AlthoughUITenantStamp;
            }
        }
    }
}
