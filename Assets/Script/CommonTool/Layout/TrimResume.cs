using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class TrimResume : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Hairdo_When;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Resume_When;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Age_Wake;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Resume_Pierce;
    private void Awake()
    {
        if (Age_Wake == RunTime.Awake)
        {
            CenterDetail();
        }
    }
    private void Start()
    {
        if (Age_Wake == RunTime.Start)
        {
            CenterDetail();
        }
    }

    public void CenterDetail()
    {
        if (Resume_When == LayoutType.Sprite_First_Weight)
        {
            if (Hairdo_When == TargetType.UGUI)
            {

                float scale = Screen.width / Resume_Pierce;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        if (Resume_When == LayoutType.Screen_First_Weight)
        {
            if (Hairdo_When == TargetType.Scene)
            {
                float scale = PutSampleShow.PutCambrian().RobTenantAnvil() / Resume_Pierce;
                transform.localScale = transform.localScale * scale;
            }
        }
        
        if (Resume_When == LayoutType.Bottom)
        {
            if (Hairdo_When == TargetType.Scene)
            {
                float screen_bottom_y = PutSampleShow.PutCambrian().RobTenantMotive() / -2;
                screen_bottom_y += (Resume_Pierce + (PutSampleShow.PutCambrian().RobHeraldGibe(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
