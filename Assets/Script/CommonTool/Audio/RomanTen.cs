/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanTen : BeerZoologist<RomanTen>
{
    //音频组件管理队列的对象
    private BleakEarnerFlesh BleakFlesh;
    // 用于播放背景音乐的音乐源
    private AudioSource m_AxRoman=null;
    //播放音效的音频组件管理列表
    private List<AudioSource> CorpBleakEarnerPuff;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float PellaColumbia= 2f; 
    //背景音乐开关
    private bool _SoRomanDesire;
    //音效开关
    private bool _InvestRomanDesire;
    //音乐音量
    private float _SoHealer=1f;
    //音效音量
    private float _InvestHealer=1f;
    string BGM_Hiss= "";

    public Dictionary<string, AudioModel> BleakStepperFoot;

    // 控制背景音乐音量大小
    public float SoHealer    {
        get { 
            return SoRomanDesire ? RobHealer(BGM_Hiss) : 0f; 
        }
        set {
            _SoHealer = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float InvestFringe    {
        get { return _InvestHealer; }
        set { 
            _InvestHealer = value;
            AntWetInvestHealer();
        }
    }
    //控制背景音乐开关
    public bool SoRomanDesire    {
        get {

            _SoRomanDesire = AcidShowImagery.PutTest("_BgMusicSwitch");
            return _SoRomanDesire; 
        }
        set {
            if(m_AxRoman)
            {
                _SoRomanDesire = value;
                AcidShowImagery.AntTest("_BgMusicSwitch", _SoRomanDesire);
                m_AxRoman.volume = SoHealer; 
            }
        }
    }
    public void AllBudXenonOneWake()
    {
        m_AxRoman.volume = 0;
    }
    public void AllBudMexicanBagWake()
    {
        m_AxRoman.volume = SoHealer;
    }
    //控制音效开关
    public bool InvestRomanDesire    {
        get {
            _InvestRomanDesire = AcidShowImagery.PutTest("_EffectMusicSwitch");
            return _InvestRomanDesire; 
        }
        set {
            _InvestRomanDesire = value;
            AcidShowImagery.AntTest("_EffectMusicSwitch", _InvestRomanDesire);
            
        }
    }
    public RomanTen()
    {
        CorpBleakEarnerPuff = new List<AudioSource>();      
    }
    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !AcidShowImagery.PutTest("first_music_set"))
        {
            AcidShowImagery.AntTest("first_music_set", true);
            AcidShowImagery.AntTest("_BgMusicSwitch", true);
            AcidShowImagery.AntTest("_EffectMusicSwitch", true);
        }
        BleakFlesh = new BleakEarnerFlesh(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        BleakStepperFoot = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
    }
    private void Start()
    {
        StartCoroutine(nameof(PellaOfSkiBleakHumiliate));
    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator PellaOfSkiBleakHumiliate()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(PellaColumbia);
            for (int i = 0; i < CorpBleakEarnerPuff.Count; i++)
            {
                //防止数据越界
                if (i < CorpBleakEarnerPuff.Count)
                {
                    //确保物体存在
                    if (CorpBleakEarnerPuff[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((CorpBleakEarnerPuff[i].clip == null || !CorpBleakEarnerPuff[i].isPlaying))
                        {
                            //返回队列
                            BleakFlesh.OfSkiBleakHumiliate(CorpBleakEarnerPuff[i]);
                            //从播放列表中删除
                            CorpBleakEarnerPuff.Remove(CorpBleakEarnerPuff[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        CorpBleakEarnerPuff.Remove(CorpBleakEarnerPuff[i]);
                    }                 
                }            
               
            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void AntWetInvestHealer()
    {
        for (int i = 0; i < CorpBleakEarnerPuff.Count; i++)
        {
            if (CorpBleakEarnerPuff[i] && CorpBleakEarnerPuff[i].isPlaying)
            {
                CorpBleakEarnerPuff[i].volume = _InvestRomanDesire ? _InvestHealer : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void CorpSoTurn(object bgName, bool restart = false)
    {

        BGM_Hiss = bgName.ToString();
        if (m_AxRoman == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_AxRoman = BleakFlesh.PutBleakHumiliate();
            //开启循环
            m_AxRoman.loop = true;
            //开始播放
            m_AxRoman.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!SoRomanDesire)
        {
            m_AxRoman.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_AxRoman.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_AxRoman.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        AudioClip clip = Resources.Load<AudioClip>(BleakStepperFoot[BGM_Hiss].filePath);
        //如果找到了，不为空
        if (clip != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (clip.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_AxRoman.clip = clip;
            m_AxRoman.volume = SoHealer;
            m_AxRoman.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_AxRoman.isPlaying)
            {
                m_AxRoman.Stop();
            }
            m_AxRoman.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void CorpInvestTurn(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!InvestRomanDesire)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = BleakFlesh.PutBleakHumiliate();
        if (m_effectMusic.isPlaying) {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = RobHealer(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        AudioClip clip = Resources.Load<AudioClip>(BleakStepperFoot[effectName.ToString()].filePath);
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            //UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            BleakFlesh.OfSkiBleakHumiliate(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        //加入播放列表
        CorpBleakEarnerPuff.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void CorpSo(RomanWhen.UIMusic bgName, bool restart = false)
    {
        CorpSoTurn(bgName, restart);
    }

    public void CorpSo(RomanWhen.SceneMusic bgName, bool restart = false)
    {
        CorpSoTurn(bgName, restart);
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void CorpInvest(RomanWhen.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        CorpInvestTurn(effectName, defAudio, volume);
    }

    public void CorpInvest(RomanWhen.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        CorpInvestTurn(effectName, defAudio, volume);
    }
    float RobHealer(string name)
    {
        if (BleakStepperFoot == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            BleakStepperFoot = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
        }

        if (BleakStepperFoot.ContainsKey(name))
        {
             return (float)BleakStepperFoot[name].volume;

        }
        else
        {
            return 1;
        }
    }

}