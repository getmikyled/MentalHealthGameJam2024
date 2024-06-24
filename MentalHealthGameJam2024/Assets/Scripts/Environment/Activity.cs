using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class Activity : MonoBehaviour
    {
        [SerializeField] private float addedStressOnCompletion = 0f;


        protected bool _isActive = false;
        protected bool isPeformingActivity = false;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void Update()
        {
            OnUpdateActivity();
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public virtual void SetActive(bool active)
        {
            _isActive = active;
        }

        public virtual void StartActivity()
        {
            if (_isActive == false)
            {
                return;
            }
            
            isPeformingActivity = true;
            OnStartActivity();
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void OnStartActivity()
        {
            Debug.Log("Started activity.");
            OnCompleteActivity();
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void OnUpdateActivity()
        {
            if (isPeformingActivity == false)
            {
                return;
            }
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void OnCompleteActivity()
        {
            StressManager.instance.UpdateStressLevels(addedStressOnCompletion);
        }
    }
}