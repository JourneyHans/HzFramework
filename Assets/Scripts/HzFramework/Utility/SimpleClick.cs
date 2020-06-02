using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleClick : MonoBehaviour, IPointerClickHandler
{
    public Action ClickCallback = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log($"[SimpleClick:OnPointerClick] object name: {name}");
        ClickCallback?.Invoke();
    }
}
