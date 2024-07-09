using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class StressBarUI : MonoBehaviour
    {
        [SerializeField] private GameObject _stressBarRed;

        private RectTransform rectTransform;
        private Vector2 originalPosition;
        private float width;
    
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
            StressManager.instance.onUpdateStress.AddListener(UpdateStressUI);

            rectTransform = _stressBarRed.GetComponent<RectTransform>();
            originalPosition = rectTransform.anchoredPosition;
            width = rectTransform.sizeDelta.x;
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void UpdateStressUI(float stressPercentage)
        {
            rectTransform.anchoredPosition = originalPosition + new Vector2(width * stressPercentage, 0);
        }
    }
}
