using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Box : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnClick;
    

    public void Start()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + gameObject.name);
    }
}