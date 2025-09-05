using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class PostEventScript : MonoSingleton<PostEventScript>
{
    public string version = "1.2";
    public string ZealSolo= NetInfoMgr.instance.ZealSolo;
    //channel
#if UNITY_IOS
    private string Artisan= "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        PostEventScript.PutCambrian().MuchZealProfound();
    }
    
    public Text Open;

    protected override void Awake()
    {
        base.Awake();
        
        version = Application.version;
        StartCoroutine(nameof(DeafPottery));
    }
    IEnumerator DeafPottery()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            PostEventScript.PutCambrian().MuchZealProfound();
        }
    }
    private void Start()
    {
        if (SaveDataManager.PutRat("event_day") != DateTime.Now.Day && SaveDataManager.PutMeadow("user_servers_id").Length != 0)
        {
            SaveDataManager.AntRat("event_day", DateTime.Now.Day);
        }
    }
    public void RoofAnParaFloor(string event_id)
    {
        RoofFloor(event_id);
    }
    public void MuchZealProfound(List<string> valueList = null)
    {
        if (SaveDataManager.PutInvade(CConfig.Ax_UniformitySlamCore) == 0)
        {
            SaveDataManager.AntInvade(CConfig.Ax_UniformitySlamCore, SaveDataManager.PutRat(CConfig.Ax_SlamCore));
        }
        if (SaveDataManager.PutInvade(CConfig.Ax_UniformityChimp) == 0)
        {
            SaveDataManager.AntInvade(CConfig.Ax_UniformityChimp, SaveDataManager.PutInvade(CConfig.Ax_Chimp));
        }
        if (valueList == null)
        {
            valueList = new List<string>() {

                SaveDataManager.PutRat(CConfig.Ax_SlamCore).ToString(),
                SaveDataManager.PutInvade(CConfig.Ax_Chimp).ToString(),
                SaveDataManager.PutRat(CConfig.Ax_UniformitySlamCore).ToString(),
                SaveDataManager.PutMeadow(CConfig.Ax_UniformityChimp),
                SaveDataManager.PutRat(CConfig.Ax_MortiseMindBiotic).ToString(),
                //SaveDataManager.GetInt(SlotConfig.sv_SlotSpinCount).ToString()
            };
        }
        
        if (SaveDataManager.PutMeadow(CConfig.Ax_LiterLizardTo) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", ZealSolo);
        wwwForm.AddField("userId", SaveDataManager.PutMeadow(CConfig.Ax_LiterLizardTo));

        wwwForm.AddField("gameVersion", version);

        wwwForm.AddField("channel", Artisan);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }
        StartCoroutine(RoofMeet(NetInfoMgr.instance.TurnWan + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    public void RoofFloor(string event_id, string p1 = null, string p2 = null, string p3 = null)
    {
        if (Open != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                Open.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (SaveDataManager.PutMeadow(CConfig.Ax_LiterLizardTo) == null)
        {
            NetInfoMgr.instance.Ghost();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", ZealSolo);
        wwwForm.AddField("userId", SaveDataManager.PutMeadow(CConfig.Ax_LiterLizardTo));
        //Debug.Log("userId:" + SaveDataManager.GetString(CConfig.sv_LocalServerId));
        wwwForm.AddField("version", version);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Artisan);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        Debug.Log("operateId:" + event_id);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        StartCoroutine(RoofMeet(NetInfoMgr.instance.TurnWan + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    IEnumerator RoofMeet(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        using UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            endSeminar();
        }
        else
        {
            success(request.downloadHandler.text);
            endSeminar();
        }
    }
    private void endSeminar()
    {
        StopCoroutine(nameof(RoofMeet));
    }


}