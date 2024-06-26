using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class RelaxerActivity : Activity
    {
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected virtual void Start()
        {
            SetActive(true);
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected override void OnCompleteActivity()
        {
            base.OnCompleteActivity();
            
            TaskManager.instance.ActivateNextStressor();
        }
    }
}