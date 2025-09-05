using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartPanel : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Yes")]    public Button Mix;
[UnityEngine.Serialization.FormerlySerializedAs("No")]    public Button An;

    private void Start()
    {
        Mix.onClick.AddListener(UnseenYse);
        An.onClick.AddListener(UnseenAn);
    }

    private void UnseenYse()
    {
        PostEventScript.PutCambrian().RoofFloor("1012");
        ADManager.Cambrian.AnSelectFirEject();
        XenonUILift(GetType().Name);
        GamePanel.instance.UnseenMasterRefer();
    }

    private void UnseenAn()
    {
        XenonUILift(GetType().Name);
    }
}
