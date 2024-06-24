using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class ThoughtBubbleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private bool isClickedOn = false;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Update()
        {
            if (isClickedOn)
            {
                transform.position = Input.mousePosition;
            }
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            Debug.Log("ENTERED");
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
    
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            isClickedOn = true;
        }
    
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            isClickedOn = false;
        }
    }

}