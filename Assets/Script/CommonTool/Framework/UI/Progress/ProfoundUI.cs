using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class ProfoundUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ProgressImage")]    public Image ProfoundDisco;
[UnityEngine.Serialization.FormerlySerializedAs("ProgressText")]    public Text ProfoundHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PostwarProfound(int progress, int total, bool animation = true, System.Action cb = null)
    {
        ProfoundHand.text = progress + "/" + total;

        float newProgress = (float)progress / total;
        if (animation)
        {
            ProfoundDisco.DOFillAmount(newProgress, 0.8f).OnComplete(() => {
                cb?.Invoke();
            });
        } else
        {
            ProfoundDisco.fillAmount = newProgress;
            cb?.Invoke();
        }
    }
}
