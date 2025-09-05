using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FecundGritPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button XenonInnate;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustAdidText")]    public Text FecundLampHand;
[UnityEngine.Serialization.FormerlySerializedAs("ServerIdText")]    public Text LizardToHand;
[UnityEngine.Serialization.FormerlySerializedAs("ActCounterText")]    public Text AskEclipseHand;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustTypeText")]    public Text FecundWhenHand;
[UnityEngine.Serialization.FormerlySerializedAs("ResetActCountButton")]    public Button AmpleAskEjectInnate;
[UnityEngine.Serialization.FormerlySerializedAs("AddActCountButton")]    public Button FirAskEjectInnate;

    // Start is called before the first frame update
    void Start()
    {
        XenonInnate.onClick.AddListener(() => {
            XenonUILift(GetType().Name);
        });

        AmpleAskEjectInnate.onClick.AddListener(() => {
            FecundTactImagery.Instance.AmpleAskEject();
        });

        FirAskEjectInnate.onClick.AddListener(() => {
            FecundTactImagery.Instance.FirAskEject("test");
        });
    }

    private void ShunEclipseHand()
    {
        FecundLampHand.text = FecundTactImagery.Instance.PutFecundLamp();
        LizardToHand.text = AcidShowImagery.PutMeadow(CExcite.Ax_LiterLizardTo);
        AskEclipseHand.text = FecundTactImagery.Instance._FestiveEject.ToString();
        FecundWhenHand.text = AcidShowImagery.PutMeadow("sv_ADJustInitType");
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        InvokeRepeating(nameof(ShunEclipseHand), 0, 0.5f);
    }

    public override void Hidding()
    {
        base.Hidding();
        CancelInvoke(nameof(ShunEclipseHand));
    }
}
