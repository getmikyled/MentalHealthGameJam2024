using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class PlayerStressController : MonoBehaviour
    {
        public static PlayerStressController instance;

        [SerializeField] private float stressThresholdMin = 0f;
        [SerializeField] private float stressThresholdMax = 10f;

        private float currentStressLevel = 5f;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Awake()
        {
            // Create singleton
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void UpdateStressLevels(float stress)
        {
            currentStressLevel += stress;
            
            // Update stress levels to fit in threshold.
            currentStressLevel = Mathf.Max(stressThresholdMin, currentStressLevel);
            currentStressLevel = Mathf.Min(stressThresholdMax, currentStressLevel);
        }
    }
}