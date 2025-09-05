using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClockText")]    public Text WidenHand;
[UnityEngine.Serialization.FormerlySerializedAs("Pointer")]    public RectTransform Optical;

    private long Lightning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TactAlaWake(long endTime)
    {
        Lightning = endTime - DateUtil.Bizarre();

        StopCoroutine(nameof(PostwarWiden));
        StartCoroutine(nameof(PostwarWiden));
    }

    private IEnumerator PostwarWiden()
    {
        float angle = 0;
        while(Lightning > 0)
        {
            WidenHand.text = DateUtil.CrumpleBestow(Lightning);
            Optical.DORotate(new Vector3(0, 0, angle), 0.5f);
            angle = angle - 90 == -360 ? 0 : angle - 90;
            Lightning--;
            yield return new WaitForSeconds(1);
        }
        if (Lightning <= 0)
        {
            WidenHand.text = "Finished";
            Optical.rotation = Quaternion.identity;
        }
    }
}
