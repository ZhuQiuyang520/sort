using UnityEngine;
using UnityEngine.UI;

/// <summary> 屏蔽界面 阻止玩家操作 退出游戏 </summary>
public class BlockPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("InfoText")]    public Text LadyHand;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button SlabShy;

    private void Start()
    {
        SlabShy.onClick.AddListener(Application.Quit);
    }

    public void ShunLady(string info)
    {
        LadyHand.text = info;
    }
}
