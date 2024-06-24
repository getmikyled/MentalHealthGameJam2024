using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class ThoughtBubbleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Thought Bubble")]
        [SerializeField] private float _minXPos = -520f;
        [SerializeField] private float _maxXPos = 520f;
        [SerializeField] private float _minYPos = -250f;
        [SerializeField] private float _maxYPos = 250f;

        [Space]
        [SerializeField] private TextMeshProUGUI _textArea;
        
        private SOTask _task;
        
        private bool isClickedOn = false;

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void Initialize(SOTask task)
        {
            _task = task;
            _textArea.text = task.taskName;

            // Set ThoughtBubble to random position
            float xPos = Random.Range(_minXPos, _maxXPos);
            float yPos = Random.Range(_minYPos, _maxYPos);
            transform.localPosition = new Vector3(xPos, yPos, 0);
        }
        
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