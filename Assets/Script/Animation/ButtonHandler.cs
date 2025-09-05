
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //public Text Value;
    public void Start()
    { 
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable == true)
        {
            transform.DOScale((float)Screen.width / 1080, 0.1f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale((float)Screen.width / 1080, 0.1f).SetEase(Ease.OutBack);   
    }
}