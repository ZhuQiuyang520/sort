using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdManagerTestPanel : BaseUIForms
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
            ADManager.Cambrian.WithClotheFolly((success) => { }, "10");
        });

        CorpEntrepreneurMeInnate.onClick.AddListener(() => {
            ADManager.Cambrian.WithEntrepreneurMe(1);
        });

        AnSelectInnate.onClick.AddListener(() => {
            ADManager.Cambrian.AnSelectFirEject();
        });

        NurseEarInnate.onClick.AddListener(() => {
            ADManager.Cambrian.StableNurseEar(SaveDataManager.PutRat(CConfig.Ax_By_Clean_Let) + 1);
            NurseEarHand.text = SaveDataManager.PutRat(CConfig.Ax_By_Clean_Let).ToString();
        });

        CajunWakeEntrepreneurInnate.onClick.AddListener(() => {
            ADManager.Cambrian.CajunWakeEntrepreneur();
            ShunCajunWakeEntrepreneur();
        });

        ResumeWakeEntrepreneurInnate.onClick.AddListener(() => {
            ADManager.Cambrian.InvadeWakeEntrepreneur();
            ShunCajunWakeEntrepreneur();
        });

    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        NurseEarHand.text = SaveDataManager.PutRat(CConfig.Ax_By_Clean_Let).ToString();
        ShunCajunWakeEntrepreneur();
    }

    private void ShunEclipseHand()
    {
        SoftCorpWakeEclipseHand.text = ADManager.Cambrian.OhioCorpWakeEclipse.ToString();
        Eclipse101Hand.text = ADManager.Cambrian.Chemist101.ToString();
        Eclipse102Hand.text = ADManager.Cambrian.Chemist102.ToString();
        Eclipse103Hand.text = ADManager.Cambrian.Chemist103.ToString();
    }

    private void ShunCajunWakeEntrepreneur()
    {
        WakeEntrepreneurHand.text = ADManager.Cambrian.RainyWakeEntrepreneur ? "已暂停" : "未暂停";
    }
}
