using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private SOTask taskQueue;
        private HashSet<SOTask> activeTasks;

    }

}