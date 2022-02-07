using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIbutton1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // дает залипанте UI клавши исключительно для удобства управления на сенсоре
    public bool isDown { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(TimeToStart());
    }


    IEnumerator TimeToStart()
    {

        yield return new WaitForSeconds(0.2f);
        isDown = false;
    }
}
