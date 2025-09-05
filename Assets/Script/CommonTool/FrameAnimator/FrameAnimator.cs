using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class FrameAnimator : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Squirt{ get { return Accept; } set { Accept = value; } }

	[SerializeField] private Sprite[] Accept= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Polyphony{ get { return Depiction; } set { Depiction = value; } }

	[SerializeField] private float Depiction= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool AdjustWakeIncur{ get { return SquareWakeIncur; } set { SquareWakeIncur = value; } }

	[SerializeField] private bool SquareWakeIncur= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Poll{ get { return Suck; } set { Suck = value; } }

	[SerializeField] private bool Suck= true;

	//动画曲线
	[SerializeField] private AnimationCurve Curve= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action FinishEvent;

	//目标Image组件
	private Image Clerk;
	//目标SpriteRenderer组件
	private SpriteRenderer MannerFacelift;
	//当前帧索引
	private int FestiveWharfGourd= 0;
	//下一次更新时间
	private float Solar= 0.0f;
	//当前帧率，通过曲线计算而来
	private float FestivePolyphony= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Ample()
	{
		FestiveWharfGourd = Depiction < 0 ? Accept.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void Corp()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Cajun()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void They()
	{
		Cajun();
		Ample();
	}

	//自动开启动画
	void Start()
	{
		Clerk = this.GetComponent<Image>();
		MannerFacelift = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (Clerk == null && MannerFacelift == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Accept == null || Accept.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Curve.Evaluate((float)FestiveWharfGourd / Accept.Length);
			float curvedFramerate = curveValue * Depiction;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float Only= SquareWakeIncur ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (Only - Solar > interval)
				{
					//执行更新操作
					DoStable();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void DoStable()
	{
		//计算新的索引
		int nextIndex = FestiveWharfGourd + (int)Mathf.Sign(FestivePolyphony);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Accept.Length)
		{
			//广播事件
			if (FinishEvent != null)
			{
				FinishEvent();
			}
			//非循环模式，禁用脚本
			if (Suck == false)
			{
				FestiveWharfGourd = Mathf.Clamp(FestiveWharfGourd, 0, Accept.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		FestiveWharfGourd = nextIndex % Accept.Length;
		//更新图片
		if (Clerk != null)
		{
			Clerk.sprite = Accept[FestiveWharfGourd];
		}
		else if (MannerFacelift != null)
		{
			MannerFacelift.sprite = Accept[FestiveWharfGourd];
		}
		//设置计时器为当前时间
		Solar = SquareWakeIncur ? Time.unscaledTime : Time.time;
	}
}

