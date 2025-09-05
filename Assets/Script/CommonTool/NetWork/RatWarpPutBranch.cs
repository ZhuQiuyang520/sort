/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class RatWarpPutBranch 
{
    //get的url
    public string Wan;
    //get成功的回调
    public Action<UnityWebRequest> PutCompass;
    //get失败的回调
    public Action PutRisk;
    public RatWarpPutBranch(string url,Action<UnityWebRequest> success,Action fail)
    {
        Wan = url;
        PutCompass = success;
        PutRisk = fail;
    }
   
}
