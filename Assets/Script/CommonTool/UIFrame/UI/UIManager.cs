/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIManager : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas SlitSquash;
    private static UIManager _Cambrian= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _WaxShinyAloof;
    //缓存所有的ui窗体
    private Dictionary<string, BaseUIForms> _WaxALLUIShiny;
    //栈结构标识当前ui窗体的集合
    private Stack<BaseUIForms> _BedBizarreUIShiny;
    //当前显示的ui窗体
    private Dictionary<string, BaseUIForms> _WaxBizarreShunUIShiny;
    //临时关闭窗口
    private List<UIFormParams> _WaitUIShiny;
    //ui根节点
    private Transform _DimSquashSupersede= null;
    //全屏幕显示的节点
    private Transform _DimSchist= null;
    //固定显示的节点
    private Transform _DimGoose= null;
    //弹出节点
    private Transform _DimBagBy= null;
    //ui特效节点
    private Transform _Web= null;
    //ui管理脚本的节点
    private Transform _DimUIWealthy= null;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("_TraUICamera")]    public Transform _DimUITenant= null;
    public Camera UITenant{ get; private set; }
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string PinonHiss;
    List<string> PinonHissPuff;
    public List<UIFormParams> WaitUIShiny    {
        get
        {
            return _WaitUIShiny;
        }
    }
    //得到实例
    public static UIManager PutCambrian()
    {
        if (_Cambrian == null)
        {
            _Cambrian = new GameObject("_UIManager").AddComponent<UIManager>();
            
        }
        return _Cambrian;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        PinonHissPuff = new List<string>();
        //字段初始化
        _WaxALLUIShiny = new Dictionary<string, BaseUIForms>();
        _WaxBizarreShunUIShiny = new Dictionary<string, BaseUIForms>();
        _WaitUIShiny = new List<UIFormParams>();
        _WaxShinyAloof = new Dictionary<string, string>();
        _BedBizarreUIShiny = new Stack<BaseUIForms>();
        //初始化加载（根ui窗体）canvas预设
        TactHangSquashConsume();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _DimSquashSupersede = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS).transform;
        _DimSchist = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject,SysDefine.SYS_NORMAL_NODE);
        _DimGoose = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject, SysDefine.SYS_FIXED_NODE);
        _DimBagBy = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject,SysDefine.SYS_POPUP_NODE);
        _Web = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject, SysDefine.SYS_TOP_NODE);
        _DimUIWealthy = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject,SysDefine.SYS_SCRIPTMANAGER_NODE);
        _DimUITenant = UnityHelper.TeamBedAuralPeal(_DimSquashSupersede.gameObject, SysDefine.SYS_UICAMERA_NODE);
        //把本脚本作为“根ui窗体”的子节点
        UnityHelper.FirAuralPealUpStickyPeal(_DimUIWealthy, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_DimSquashSupersede);
        //初始化ui窗体预设路径数据
        TactUIShinyAloofShow();
        //初始化UI相机参数，主要是解决URP管线下UI相机的问题
        TactTenant();
    }
    private void FirPinon(string name)
    {
        if (!PinonHissPuff.Contains(name))
        {
            PinonHissPuff.Add(name);
            PinonHiss = name;
        }
    }
    private void BatPinon(string name)
    {
        if (PinonHissPuff.Contains(name))
        {
            PinonHissPuff.Remove(name);
        }
        if (PinonHissPuff.Count == 0)
        {
            PinonHiss = "";
        }
        else
        {
            PinonHiss = PinonHissPuff[0];
        }
    }
    //初始化加载（根ui窗体）canvas预设
    private void TactHangSquashConsume()
    {
        SlitSquash = ResourcesMgr.PutCambrian().PartFever(SysDefine.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="uiFormName">ui窗体预设的名称</param>
    public GameObject ShunUIShiny(string uiFormName, object uiFormParams = null)
    {
        //参数的检查
        if (string.IsNullOrEmpty(uiFormName)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        BaseUIForms baseUIForms = PartShinyUpALLUIShinyForce(uiFormName);
        if (baseUIForms == null) return null;

        FirPinon(uiFormName);
        
        //判断是否清空“栈”结构体集合
        if (baseUIForms.BizarreUIWhen.ItVagueReverseUnseen)
        {
            VagueBloomBuyer();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.BizarreUIWhen.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                AprilUIShinyStand(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.ReverseChange:
                PushUIShiny(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.HideOther:
                AprilUIMentalUpStandPileApply(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.Wait:
                AprilUIShinyStandAcidXenon(uiFormName, uiFormParams);
                break;
            default:
                break;
        }
        return baseUIForms.gameObject;
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void XenonDyCowboyUIShiny(string strUIFormsName)
    {
        BatPinon(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        BaseUIForms baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _WaxALLUIShiny.TryGetValue(strUIFormsName,out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.BizarreUIWhen.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                FeatUIShinyStand(strUIFormsName);
                break;
            
            case UIFormShowMode.ReverseChange:
                BagUIShiny();
                break;
            case UIFormShowMode.HideOther:
                FeatUIShinyHeedStandWedShunApply(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                FeatUIShinyStand(strUIFormsName);
                break;
            default:
                break;
        }
        
    }

    public void VagueWetUI()
    {
        foreach (var panel in PutDisplayBeacon(true))
        {
            XenonDyCowboyUIShiny(panel.name);
        }
    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void ShunNileBagBy()
    {
        if (_WaitUIShiny.Count > 0)
        {
            ShunUIShiny(_WaitUIShiny[0].OxLiftHiss, _WaitUIShiny[0].OxLiftMandan);
            _WaitUIShiny.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void VagueAcidUIShiny()
    {
        if (_WaitUIShiny.Count > 0)
        {
            _WaitUIShiny = new List<UIFormParams>();
        }
    }
     /// <summary>
     /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
      /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
      /// </summary>
      /// <param name="uiFormsName">UI窗体（预设）的名称</param>
      /// <returns></returns>
    private BaseUIForms PartShinyUpALLUIShinyForce(string uiFormName)
    {
        //加载的返回ui窗体基类
        BaseUIForms baseUIResult = null;
        _WaxALLUIShiny.TryGetValue(uiFormName, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = PartUILift(uiFormName);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="uiFormName">UI窗体名称</param>
    private BaseUIForms PartUILift(string uiFormName)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        BaseUIForms baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _WaxShinyAloof.TryGetValue(uiFormName, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
           goCloneUIPrefabs= ResourcesMgr.PutCambrian().PartFever(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if(_DimSquashSupersede!=null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<BaseUIForms>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName="+uiFormName);
                return null;
            }
            switch (baseUIForm.BizarreUIWhen.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_DimSchist, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_DimGoose, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_DimBagBy, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Web, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _WaxALLUIShiny.Add(uiFormName, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数uiFormName=" + uiFormName);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 uiFormName=" + uiFormName);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void AprilUIShinyStand(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        BaseUIForms baseUIForm;
        //从所有窗体集合中得到的窗体
        BaseUIForms baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _WaxBizarreShunUIShiny.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _WaxALLUIShiny.TryGetValue(uiFormName, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _WaxBizarreShunUIShiny.Add(uiFormName, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display(uiFormParams);
            
        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void FeatUIShinyStand(string strUIFormsName)
    {
        //ui窗体基类
        BaseUIForms baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _WaxBizarreShunUIShiny.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _WaxBizarreShunUIShiny.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void AprilUIMentalUpStandPileApply(string strUIFormsName, object uiFormParams)
    {
        //窗体基类
        BaseUIForms baseUIForms;
        //所有窗体集合中的窗体基类
        BaseUIForms baseUIFormsFromAllCache;
        _WaxBizarreShunUIShiny.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<BaseUIForms> ShowUIFormsList = new List<BaseUIForms>(_WaxBizarreShunUIShiny.Values);
        foreach (BaseUIForms baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                FeatUIShinyHeedStandWedShunApply(baseUIFormsItem.GetType().Name);
            }
        }
        List<BaseUIForms> CurrentUIFormsList = new List<BaseUIForms>(_BedBizarreUIShiny);
        foreach (BaseUIForms baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            FeatUIShinyHeedStandWedShunApply(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _WaxALLUIShiny.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _WaxBizarreShunUIShiny.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display(uiFormParams);
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void AprilUIShinyStandAcidXenon(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        BaseUIForms baseUIForm;
        //从所有窗体集合中得到的窗体
        BaseUIForms baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _WaxBizarreShunUIShiny.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (BaseUIForms uiforms in _WaxBizarreShunUIShiny.Values)
        {
            if (uiforms.BizarreUIWhen.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _WaxALLUIShiny.TryGetValue(uiFormName, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _WaxBizarreShunUIShiny.Add(uiFormName, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display(uiFormParams);

            }
        }
        else
        {
            _WaitUIShiny.Add(new UIFormParams() { OxLiftHiss = uiFormName, OxLiftMandan = uiFormParams });
        }
        
    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void FeatUIShinyHeedStandWedShunApply(string strUIFormsName)
    {
        //ui窗体基类
        BaseUIForms baseUIForms;
        _WaxBizarreShunUIShiny.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _WaxBizarreShunUIShiny.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (BaseUIForms baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (BaseUIForms baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void PushUIShiny(string strUIFormsName, object uiFormParams)
    {
        //ui预设窗体
        BaseUIForms baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_BedBizarreUIShiny.Count > 0)
        {
            BaseUIForms topUIForms = _BedBizarreUIShiny.Peek();
            topUIForms.Occupy();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _WaxALLUIShiny.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display(uiFormParams);
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _BedBizarreUIShiny.Push(baseUI);
       
    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void BagUIShiny()
    {

        if (_BedBizarreUIShiny.Count >= 2)
        {
            //出栈逻辑
            BaseUIForms topUIForms = _BedBizarreUIShiny.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() => {
                //出栈窗体的下一个窗体逻辑
                BaseUIForms nextUIForms = _BedBizarreUIShiny.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_BedBizarreUIShiny.Count == 1)
        {
            BaseUIForms topUIForms = _BedBizarreUIShiny.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void TactUIShinyAloofShow()
    {
        IConfigManager configMgr = new ConfigManagerByJson(SysDefine.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_WaxShinyAloof != null)
        {
            _WaxShinyAloof = configMgr.IceStepper;
        }
    }

    /// <summary>
    /// 初始化UI相机参数
    /// </summary>
    private void TactTenant()
    {
        //当渲染管线为URP时，将UI相机的渲染方式改为Overlay，并加入主相机堆栈
        RenderPipelineAsset currentPipeline = GraphicsSettings.renderPipelineAsset;
        if (currentPipeline != null && currentPipeline.name == "UniversalRenderPipelineAsset")
        {
            UITenant = _DimUITenant.GetComponent<Camera>();
            UITenant.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_DimUITenant.GetComponent<Camera>());
        }
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool VagueBloomBuyer()
    {
        if(_BedBizarreUIShiny!=null && _BedBizarreUIShiny.Count >= 1)
        {
            _BedBizarreUIShiny.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<BaseUIForms> PutBizarreLiftBloom()
    {
        return _BedBizarreUIShiny;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="uiFormName"></param>
    /// <returns></returns>
    public GameObject PutPinonOrHiss(string uiFormName)
    {
        //ui窗体基类
        BaseUIForms baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _WaxALLUIShiny.TryGetValue(uiFormName, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> PutDisplayBeacon(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<BaseUIForms> allUIFormsList = new List<BaseUIForms>(_WaxALLUIShiny.Values);
        foreach(BaseUIForms panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._BizarreUIWhen.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
}

public class UIFormParams
{
    public string OxLiftHiss;   // 窗体名称
    public object OxLiftMandan; // 窗体参数
}
