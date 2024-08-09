using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MentalHealthGJ_2024
{
    public enum StressState
    {
        Low, High
    }
    
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class StressManager : MonoBehaviour
    {
        public static StressManager instance;

        [SerializeField] private float stressThresholdMin = 0f;
        [SerializeField] private float stressThresholdMax = 10f;
        [SerializeField] private float startingStress = 5f;
        [FormerlySerializedAs("stressIncrementPerSecod")] [SerializeField] private float stressIncrementPerSecond = 0.5f;

        [Header("Music")] 
        [SerializeField] private string lowStressMusicName = "";
        [SerializeField] private float lowStressMusicVolume = 0.75f;
        [SerializeField] private string highStressMusicName = "";
        [SerializeField] private float highStressMusicVolume = 0.75f;
        
        private StressState stressState = StressState.Low;
        
        private float stressRange => stressThresholdMax - stressThresholdMin;
        private float currentStressLevel = 5f;

        public UnityEvent<float> onUpdateStress = new UnityEvent<float>();

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void SetStressState(StressState newStressState)
        {
            if (newStressState == stressState)
            {
                return;
            }

            StressState prevStressState = stressState;
            stressState = newStressState;

            switch (prevStressState)
            {
                case StressState.Low:
                case StressState.High:
                    AudioManager.instance.StopAllAudio();
                    break;
            }

            switch (stressState)
            {
                case StressState.Low:
                    AudioManager.instance.PlayGlobalAudio(lowStressMusicName, lowStressMusicVolume, true);
                    break;
                case StressState.High:
                    AudioManager.instance.PlayGlobalAudio(lowStressMusicName, lowStressMusicVolume, false);
                    break;
            }
        }
        
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
        private void Update()
        {
            UpdateStressLevels(stressIncrementPerSecond * Time.deltaTime);
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
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
            
            onUpdateStress.Invoke(currentStressLevel / stressRange);
            
            // Play Audio
            if (currentStressLevel >= stressThresholdMax * 0.6f)
            {
                SetStressState(StressState.High);
            }
            else
            {
                SetStressState(StressState.Low);
            }
        }
    }
}