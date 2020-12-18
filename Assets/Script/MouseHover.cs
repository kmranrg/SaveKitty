using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter (PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }
}
