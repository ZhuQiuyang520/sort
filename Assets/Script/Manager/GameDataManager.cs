using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoSingleton<GameDataManager>
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

        return SaveDataManager.PutInvade(CConfig.Ax_SlamCore);
    }

    public void UteSlam(double gold)
    {
        UteSlam(gold, MainManager.instance.transform);
    }

    public void UteSlam(double gold, Transform startTransform)
    {
        int oldGold = SaveDataManager.PutRat(CConfig.Ax_SlamCore);
        SaveDataManager.AntRat(CConfig.Ax_SlamCore, (int)(oldGold + gold));
        if (gold > 0)
        {
            SaveDataManager.AntInvade(CConfig.Ax_UniformitySlamCore, SaveDataManager.PutInvade(CConfig.Ax_UniformitySlamCore) + gold);
        }
        MessageData md = new MessageData(oldGold);
        md.HouseLifeblood = startTransform;
        MessageCenterLogic.PutCambrian().Roof(CConfig.So_Ox_Alcohol, md);
    }
    
    // 现金
    public double RobChimp()
    {
        return SaveDataManager.PutInvade(CConfig.Ax_Chimp);
    }

    public void UteChimp(double token)
    {
        UteChimp(token, MainManager.instance.transform);
    }

    public double PutDisc()
    {
        return CashOutManager.PutCambrian().Money;
    }
    public void FirDisc(double cash)
    {
        CashOutManager.PutCambrian().AddMoney((float)cash);
        double oldToken = PlayerPrefs.HasKey(CConfig.Ax_Chimp) ? double.Parse(SaveDataManager.PutMeadow(CConfig.Ax_Chimp)) : 0;
        double newToken = oldToken + cash;
        SaveDataManager.AntInvade(CConfig.Ax_Chimp, newToken);
        if (cash > 0)
        {
            double allToken = SaveDataManager.PutInvade(CConfig.Ax_UniformityChimp);
            SaveDataManager.AntInvade(CConfig.Ax_UniformityChimp, allToken + cash);
        }
    }
    public void UteChimp(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CConfig.Ax_Chimp) ? double.Parse(SaveDataManager.PutMeadow(CConfig.Ax_Chimp)) : 0;
        double newToken = oldToken + token;
        SaveDataManager.AntInvade(CConfig.Ax_Chimp, newToken);
        if (token > 0)
        {
            double allToken = SaveDataManager.PutInvade(CConfig.Ax_UniformityChimp);
            SaveDataManager.AntInvade(CConfig.Ax_UniformityChimp, allToken + token);
        }
#if SOHOShop
        SOHOShopManager.instance.UpdateCash();
#endif
        MessageData md = new MessageData(oldToken);
        md.HouseLifeblood = startTransform;
        MessageCenterLogic.PutCambrian().Roof(CConfig.So_Ox_Pathogen, md);
    }

    //Amazon卡
    public double RobNative()
    {
        return SaveDataManager.PutInvade(CConfig.Ax_Native);
    }

    public void UteNative(double amazon)
    {
        UteNative(amazon, MainManager.instance.transform);
    }
    public void UteNative(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CConfig.Ax_Native) ? double.Parse(SaveDataManager.PutMeadow(CConfig.Ax_Native)) : 0;
        double newAmazon = oldAmazon + amazon;
        SaveDataManager.AntInvade(CConfig.Ax_Native, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = SaveDataManager.PutInvade(CConfig.Ax_UniformityNative);
            SaveDataManager.AntInvade(CConfig.Ax_UniformityNative, allAmazon + amazon);
        }
        MessageData md = new MessageData(oldAmazon);
        md.HouseLifeblood = startTransform;
        MessageCenterLogic.PutCambrian().Roof(CConfig.So_Ox_Perfectly, md);
    }
}
