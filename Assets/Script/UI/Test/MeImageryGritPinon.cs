using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeImageryGritPinon : TurnUIShiny
{
[UnityEngine.Serialization.FormerlySerializedAs("LastPlayTimeCounterText")]    public Text SoftCorpWakeEclipseHand;
[UnityEngine.Serialization.FormerlySerializedAs("Counter101Text")]    public Text Eclipse101Hand;
[UnityEngine.Serialization.FormerlySerializedAs("Counter102Text")]    public Text Eclipse102Hand;
[UnityEngine.Serialization.FormerlySerializedAs("Counter103Text")]    public Text Eclipse103Hand;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumText")]    public Text NurseEarHand;
[UnityEngine.Serialization.FormerlySerializedAs("PlayRewardedAdButton")]    public Button CorpNineteenMeInnate;
[UnityEngine.Serialization.FormerlySerializedAs("PlayInterstitialAdButton")]    public Button CorpEntrepreneurMeInnate;
[UnityEngine.Serialization.FormerlySerializedAs("NoThanksButton")]    public Button AnSelectInnate;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumButton")]    public Button NurseEarInnate;
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button XenonInnate;
[UnityEngine.Serialization.FormerlySerializedAs("TimeInterstitialText")]    public Text WakeEntrepreneurHand;
[UnityEngine.Serialization.FormerlySerializedAs("PauseTimeInterstitialButton")]    public Button CajunWakeEntrepreneurInnate;
[UnityEngine.Serialization.FormerlySerializedAs("ResumeTimeInterstitialButton")]    public Button ResumeWakeEntrepreneurInnate;

    private void Start()
    {
        InvokeRepeating(nameof(ShunEclipseHand), 0, 0.5f);

        XenonInnate.onClick.AddListener(() => {
            XenonUILift(GetType().Name);
        });

        CorpNineteenMeInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.WithClotheFolly((success) => { }, "10");
        });

        CorpEntrepreneurMeInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.WithEntrepreneurMe(1);
        });

        AnSelectInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.AnSelectFirEject();
        });

        NurseEarInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.StableNurseEar(AcidShowImagery.PutRat(CExcite.Ax_By_Clean_Let) + 1);
            NurseEarHand.text = AcidShowImagery.PutRat(CExcite.Ax_By_Clean_Let).ToString();
        });

        CajunWakeEntrepreneurInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.CajunWakeEntrepreneur();
            ShunCajunWakeEntrepreneur();
        });

        ResumeWakeEntrepreneurInnate.onClick.AddListener(() => {
            ADImagery.Cambrian.InvadeWakeEntrepreneur();
            ShunCajunWakeEntrepreneur();
        });

    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        NurseEarHand.text = AcidShowImagery.PutRat(CExcite.Ax_By_Clean_Let).ToString();
        ShunCajunWakeEntrepreneur();
    }

    private void ShunEclipseHand()
    {
        SoftCorpWakeEclipseHand.text = ADImagery.Cambrian.OhioCorpWakeEclipse.ToString();
        Eclipse101Hand.text = ADImagery.Cambrian.Chemist101.ToString();
        Eclipse102Hand.text = ADImagery.Cambrian.Chemist102.ToString();
        Eclipse103Hand.text = ADImagery.Cambrian.Chemist103.ToString();
    }

    private void ShunCajunWakeEntrepreneur()
    {
        WakeEntrepreneurHand.text = ADImagery.Cambrian.RainyWakeEntrepreneur ? "已暂停" : "未暂停";
    }
}
