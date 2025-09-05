﻿/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class RatWarpMeetBranch 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Lift;
    //post成功回调
    public Action<UnityWebRequest> MeetCompass;
    //post失败回调
    public Action MeetRisk;
    public RatWarpMeetBranch(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Lift = form;
        MeetCompass = success;
        MeetRisk = fail;
    }
}
