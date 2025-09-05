/**
 * 
 * 音乐类型管理的枚举列表
 * 
 * **/

//所有音乐名称的枚举列表

public class MusicType
{
    //ui使用的音乐音效
    public enum UIMusic
    {
        None,
        win_2,
        fail,
        click,
        waterfull,
        win_1,
        win_3,
        PourWater,
        pop_up,
        click_2,
    }

    //场景中的音效，包括场景中所有音效，包括背景音效
    public enum SceneMusic
    {
        None,
        bgm,
    }

}

