using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waste : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text WasteHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        WasteHand.text = uiFormParams.ToString();
        StartCoroutine(nameof(DeafXenonWaste));
    }

    private IEnumerator DeafXenonWaste()
    {
        yield return new WaitForSeconds(2);
        XenonUILift(GetType().Name);
    }

}
