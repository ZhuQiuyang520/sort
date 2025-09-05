using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不同屏幕安全区适配
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class LungBoneSustain : MonoBehaviour
{
    RectTransform Pinon;
    Rect SoftLungBone= new Rect(0, 0, 0, 0);

    void Awake()
    {
        Pinon = GetComponent<RectTransform>();
        if (Pinon == null)
            return;

        Pinon.anchorMin = Vector2.zero;
        Pinon.anchorMax = Vector2.one;
        Pinon.offsetMin = Vector2.zero;
        Pinon.offsetMax = Vector2.zero;

        Postwar();
    }

    void Postwar()
    {
        Rect safeArea = Screen.safeArea;

        if (safeArea != SoftLungBone)
            ApplyLungBone(safeArea);
    }

    void ApplyLungBone(Rect r)
    {
        SoftLungBone = r;


        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Pinon.anchorMin = anchorMin;
        Pinon.anchorMax = anchorMax;

        Debug.LogFormat("新的安全区适配 safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6} ---- rw={7}, rh={8} ",
            name, r.x, r.y, r.width, r.height, Screen.width, Screen.height, Screen.currentResolution.width, Screen.currentResolution.height);
    }
}
