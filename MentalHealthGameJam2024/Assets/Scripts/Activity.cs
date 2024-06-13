using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class Activity : MonoBehaviour
    {
        private bool isPeformingActivity = false;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void Update()
        {
            OnUpdateActivity();
        }

        public virtual void StartActivity()
        {
            isPeformingActivity = true;
            OnStartActivity();
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void OnStartActivity()
        {
            
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
            
        }
    }
}