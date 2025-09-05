using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArabianPinon : TurnUIShiny
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
        MeetFloorGently.PutCambrian().RoofFloor("1012");
        ADImagery.Cambrian.AnSelectFirEject();
        XenonUILift(GetType().Name);
        ZealPinon.instance.UnseenMasterRefer();
    }

    private void UnseenAn()
    {
        XenonUILift(GetType().Name);
    }
}
