using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PaanelSensor : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public CameraController Camera;
    public void OnPointerDown(PointerEventData eventData){
        if (eventData.pointerCurrentRaycast.gameObject == gameObject){
            Camera.CanSensor = true;
            Debug.Log("фыпфвкппфвкпфкп");
        }
    }
    public void OnPointerUp(PointerEventData eventData){
        Camera.CanSensor = false;
        Camera.mouseX = 0;
        Camera.mouseY = 0;
        Debug.Log("sfsfdafsdafsdasfdaaffae4fjqaeiugheqauihgiueeqhg");
    }
}
