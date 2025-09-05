using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateUsPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Allay;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Silk1Herald;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Silk2Herald;
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public Button Xenon;

    // Start is called before the first frame update
    void Start()
    {
        Xenon.onClick.AddListener(UnseenXenon);
        foreach (Button star in Allay)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                lightRefer(index);
            });
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        for (int i = 0; i < 5; i++)
        {
            Allay[i].gameObject.GetComponent<Image>().sprite = Silk2Herald;
        }
    }


    private void lightRefer(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Allay[i].gameObject.GetComponent<Image>().sprite = i <= index ? Silk1Herald : Silk2Herald;
        }
        PostEventScript.PutCambrian().RoofFloor("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(MoodyPinon());
        } else
        {
            // 跳转到应用商店
            RateUsManager.instance.TaskAPAxeModule();
            StartCoroutine(MoodyPinon());
        }
        
        // 打点
        //PostEventScript.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator MoodyPinon(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        XenonUILift(GetType().Name);
    }

    public void UnseenXenon()
    {
        XenonUILift(GetType().Name);
    }
}
