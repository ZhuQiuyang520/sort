/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioSourceQueue 
{
    //音乐的管理者
    private GameObject BleakTen;
    //音乐组件管理队列
    private List<AudioSource> BleakHumiliateFlesh;
    //音乐组件默认容器最大值  
    private int GinEject= 25;
    public AudioSourceQueue(MusicMgr audioMgr)
    {
        BleakTen = audioMgr.gameObject;
        TactBleakEarnerFlesh();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void TactBleakEarnerFlesh()
    {
        BleakHumiliateFlesh = new List<AudioSource>();
        for(int i = 0; i < GinEject; i++)
        {
            FirBleakEarnerGunDealTen();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource FirBleakEarnerGunDealTen()
    {
        AudioSource audio = BleakTen.AddComponent<AudioSource>();
        BleakHumiliateFlesh.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource PutBleakHumiliate()
    {
        if (BleakHumiliateFlesh.Count > 0)
        {
            AudioSource audio = BleakHumiliateFlesh.Find(t => !t.isPlaying);
            if (audio)
            {
                BleakHumiliateFlesh.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return FirBleakEarnerGunDealTen();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  FirBleakEarnerGunDealTen();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void OfSkiBleakHumiliate(AudioSource audio)
    {
        if (BleakHumiliateFlesh.Contains(audio)) return;
        if (BleakHumiliateFlesh.Count >= GinEject)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            BleakHumiliateFlesh.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
