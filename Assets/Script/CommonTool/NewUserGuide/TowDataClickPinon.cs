using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowDataClickPinon : TurnUIShiny
{
    public static TowDataClickPinon instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]
    public GameObject Erie;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Flyway;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Hand;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Melodic= new Vector3[4];
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float FlywayStrictX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float FlywayStrictY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Plutonic;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float FestiveStrictX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float FestiveStrictY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float SatireWake= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private SpaciousFloorGenerally PeskyGenerally;

    protected override void Awake()
    {
        base.Awake();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void ShunClick(GameObject _target, string text)
    {
        if (_target == null)
        {
            Erie.SetActive(false);
            if (Plutonic == null)
            {
                Plutonic = GetComponent<Image>().material;
            }
            Plutonic.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Plutonic.SetFloat("_SliderX", 0);
            Plutonic.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                XenonUILift(GetType().Name);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            Tact(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Hand.text = text;
            Hand.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Hand.transform.parent.gameObject.SetActive(false);
        }
    }

    private float FlywayAnvil= 1;
    private float FlywayMotive= 1;
    public void Tact(GameObject _target)
    {
        this.Flyway = _target;

        PeskyGenerally = GetComponent<SpaciousFloorGenerally>();
        if (PeskyGenerally != null)
        {
            PeskyGenerally.AntHairdoDisco(_target.GetComponent<Image>());
        }

        Canvas canvas = UIImagery.PutCambrian().SlitSquash.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Flyway.GetComponent<RectTransform>() != null)
        {
            Flyway.GetComponent<RectTransform>().GetWorldCorners(Melodic);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIImagery.PutCambrian()._DimUITenant.GetComponent<Camera>().ScreenToWorldPoint(pos);
            Melodic[0] = new Vector3(pos.x - FlywayAnvil, pos.y - FlywayMotive);
            Melodic[1] = new Vector3(pos.x - FlywayAnvil, pos.y + FlywayMotive);
            Melodic[2] = new Vector3(pos.x + FlywayAnvil, pos.y + FlywayMotive);
            Melodic[3] = new Vector3(pos.x + FlywayAnvil, pos.y - FlywayMotive);
        }
        //计算高亮显示区域在画布中的范围
        FlywayStrictX = Vector2.Distance(StudyUpSquashMat(canvas, Melodic[0]), StudyUpSquashMat(canvas, Melodic[3])) / 2f;
        FlywayStrictY = Vector2.Distance(StudyUpSquashMat(canvas, Melodic[0]), StudyUpSquashMat(canvas, Melodic[1])) / 2f;
        //计算高亮显示区域的中心
        float x = Melodic[0].x + ((Melodic[3].x - Melodic[0].x) / 2);
        float y = Melodic[0].y + ((Melodic[1].y - Melodic[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Influx= StudyUpSquashMat(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Influx.x, Influx.y, 0, 0);
        Plutonic = GetComponent<Image>().material;
        Plutonic.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Melodic);
            //计算偏移初始值
            for (int i = 0; i < Melodic.Length; i++)
            {
                if (i % 2 == 0)
                {
                    FestiveStrictX = Mathf.Max(Vector3.Distance(StudyUpSquashMat(canvas, Melodic[i]), Influx), FestiveStrictX);
                }
                else
                {
                    FestiveStrictY = Mathf.Max(Vector3.Distance(StudyUpSquashMat(canvas, Melodic[i]), Influx), FestiveStrictY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Plutonic.SetFloat("_SliderX", FestiveStrictX);
        Plutonic.SetFloat("_SliderY", FestiveStrictY);
        Erie.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(ShunErie(Influx));
    }

    private IEnumerator ShunErie(Vector2 center)
    {
        Erie.SetActive(false);
        yield return new WaitForSeconds(SatireWake);

        Erie.transform.localPosition = center;
        ErieCurvature();

        Erie.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float SatireEconomicX= 0f;
    private float SatireEconomicY= 0f;
    private void Update()
    {
        if (Plutonic == null) return;

        FestiveStrictX = FlywayStrictX;
        Plutonic.SetFloat("_SliderX", FestiveStrictX);
        FestiveStrictY = FlywayStrictY;
        Plutonic.SetFloat("_SliderY", FestiveStrictY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 StudyUpSquashMat(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }

    public void ErieCurvature()
    {

        var s = DOTween.Sequence();
        s.Append(Erie.transform.DOLocalMoveY(Erie.transform.localPosition.y + 10f, 0.5f));
        s.Append(Erie.transform.DOLocalMoveY(Erie.transform.localPosition.y, 0.5f));
        s.Join(Erie.transform.DOScaleY(1.1f, 0.125f));
        s.Join(Erie.transform.DOScaleX(0.9f, 0.125f).OnComplete(() =>
        {
            Erie.transform.DOScaleY(0.9f, 0.125f);
            Erie.transform.DOScaleX(1.1f, 0.125f).OnComplete(() =>
            {
                Erie.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
