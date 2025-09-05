using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZealShowImagery : BeerZoologist<ZealShowImagery>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TactZealShow()
    {
#if SOHOShop
        // 提现商店初始化
        // 提现商店中的金币、现金和amazon卡均为double类型，参数请根据具体项目自行处理
        SOHOShopManager.instance.InitSOHOShopAction(
            getToken,
            getGold, 
            getAmazon,    // amazon
            (subToken) => { addToken(-subToken); }, 
            (subGold) => { addGold(-subGold); }, 
            (subAmazon) => { addAmazon(-subAmazon); });
#endif
    }

    // 金币
    public double RobSlam()
    {

        return AcidShowImagery.PutInvade(CExcite.Ax_SlamCore);
    }

    public void UteSlam(double gold)
    {
        UteSlam(gold, SlitImagery.instance.transform);
    }

    public void UteSlam(double gold, Transform startTransform)
    {
        int oldGold = AcidShowImagery.PutRat(CExcite.Ax_SlamCore);
        AcidShowImagery.AntRat(CExcite.Ax_SlamCore, (int)(oldGold + gold));
        if (gold > 0)
        {
            AcidShowImagery.AntInvade(CExcite.Ax_UniformitySlamCore, AcidShowImagery.PutInvade(CExcite.Ax_UniformitySlamCore) + gold);
        }
        PotteryShow md = new PotteryShow(oldGold);
        md.HouseLifeblood = startTransform;
        PotteryFrenzySwirl.PutCambrian().Roof(CExcite.So_Ox_Alcohol, md);
    }
    
    // 现金
    public double RobChimp()
    {
        return AcidShowImagery.PutInvade(CExcite.Ax_Chimp);
    }

    public void UteChimp(double token)
    {
        UteChimp(token, SlitImagery.instance.transform);
    }

    public double PutDisc()
    {
        return CashOutManager.PutCambrian().Money;
    }
    public void FirDisc(double cash)
    {
        CashOutManager.PutCambrian().AddMoney((float)cash);
        double oldToken = PlayerPrefs.HasKey(CExcite.Ax_Chimp) ? double.Parse(AcidShowImagery.PutMeadow(CExcite.Ax_Chimp)) : 0;
        double newToken = oldToken + cash;
        AcidShowImagery.AntInvade(CExcite.Ax_Chimp, newToken);
        if (cash > 0)
        {
            double allToken = AcidShowImagery.PutInvade(CExcite.Ax_UniformityChimp);
            AcidShowImagery.AntInvade(CExcite.Ax_UniformityChimp, allToken + cash);
        }
    }
    public void UteChimp(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CExcite.Ax_Chimp) ? double.Parse(AcidShowImagery.PutMeadow(CExcite.Ax_Chimp)) : 0;
        double newToken = oldToken + token;
        AcidShowImagery.AntInvade(CExcite.Ax_Chimp, newToken);
        if (token > 0)
        {
            double allToken = AcidShowImagery.PutInvade(CExcite.Ax_UniformityChimp);
            AcidShowImagery.AntInvade(CExcite.Ax_UniformityChimp, allToken + token);
        }
#if SOHOShop
        SOHOShopManager.instance.UpdateCash();
#endif
        PotteryShow md = new PotteryShow(oldToken);
        md.HouseLifeblood = startTransform;
        PotteryFrenzySwirl.PutCambrian().Roof(CExcite.So_Ox_Pathogen, md);
    }

    //Amazon卡
    public double RobNative()
    {
        return AcidShowImagery.PutInvade(CExcite.Ax_Native);
    }

    public void UteNative(double amazon)
    {
        UteNative(amazon, SlitImagery.instance.transform);
    }
    public void UteNative(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CExcite.Ax_Native) ? double.Parse(AcidShowImagery.PutMeadow(CExcite.Ax_Native)) : 0;
        double newAmazon = oldAmazon + amazon;
        AcidShowImagery.AntInvade(CExcite.Ax_Native, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = AcidShowImagery.PutInvade(CExcite.Ax_UniformityNative);
            AcidShowImagery.AntInvade(CExcite.Ax_UniformityNative, allAmazon + amazon);
        }
        PotteryShow md = new PotteryShow(oldAmazon);
        md.HouseLifeblood = startTransform;
        PotteryFrenzySwirl.PutCambrian().Roof(CExcite.So_Ox_Perfectly, md);
    }
}
