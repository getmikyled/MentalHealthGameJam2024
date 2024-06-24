using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class StressorActivity : Activity
    {
        [SerializeField] private SOTask _task;
        public SOTask task => _task;

        public ThoughtBubbleUI thoughtBubble;

        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected override void OnCompleteActivity()
        {
            base.OnCompleteActivity();
            
            // Deactivate task in TaskManager
            TaskManager.instance.DeactivateStressor(this);
        }
    }
}