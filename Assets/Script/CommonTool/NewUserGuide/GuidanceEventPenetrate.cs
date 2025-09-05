using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class GuidanceEventPenetrate : MonoBehaviour, ICanvasRaycastFilter
{
    private Image FlywayDisco;
    public void AntHairdoDisco(Image target)
    {
        FlywayDisco = target;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (FlywayDisco == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(FlywayDisco.rectTransform, sp, eventCamera);
    }
}