using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class StressManager : MonoBehaviour
    {
        public static StressManager instance;

        [SerializeField] private float stressThresholdMin = 0f;
        [SerializeField] private float stressThresholdMax = 10f;
        [SerializeField] private float startingStress = 5f;

        private float stressRange => stressThresholdMax - stressThresholdMin;
        private float currentStressLevel = 5f;

        public UnityEvent<float> onUpdateStress = new UnityEvent<float>();
        
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

            currentStressLevel = startingStress;
            onUpdateStress.Invoke(currentStressLevel / stressRange);
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void UpdateStressLevels(float stress)
        {
            currentStressLevel += stress;
            
            // Update stress levels to fit in threshold.
            currentStressLevel = Mathf.Max(stressThresholdMin, currentStressLevel);
            currentStressLevel = Mathf.Min(stressThresholdMax, currentStressLevel);
            print(currentStressLevel);
            onUpdateStress.Invoke(currentStressLevel / stressRange);
        }
    }
}