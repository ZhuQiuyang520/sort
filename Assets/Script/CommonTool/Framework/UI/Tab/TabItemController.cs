using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tab按钮样式脚本
/// </summary>

public class TabItemController : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Icon")]    public Image Soup;
[UnityEngine.Serialization.FormerlySerializedAs("Title")]    public Text Round;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AntDevoidUI(bool active, TabController controller, TabItem tabItem)
    {
        if (Round != null && controller.DevoidBlame != null)
        {
            Round.color = active ? controller.DevoidBlame : controller.IslanderBlame;
        }
        if (gameObject.GetComponent<Image>() != null && controller.DevoidBG != null)
        {
            gameObject.GetComponent<Image>().sprite = active ? controller.DevoidBG : controller.IslanderBG;
        }
        if (Soup != null && tabItem.DevoidSoup != null)
        {
            Soup.sprite = active ? tabItem.DevoidSoup : tabItem.IslanderSoup;
        }
    }
}
