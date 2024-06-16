using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class TaskManager : MonoBehaviour
    {
        // Singleton
        public static TaskManager instance;
        
        [SerializeField] private SOTask[] _tasks;

        private Queue<SOTask> _inactiveTasks;
        private HashSet<SOTask> _activeTasks;

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Awake()
        {
            // Initiate singleton.
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
            
            // Put all tasks into a queue
            foreach (SOTask task in _tasks)
            {
                _inactiveTasks.Enqueue(task);
            }
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void ActivateNextTask()
        {
            if (_inactiveTasks.Count == 0)
            {
                return;
            }

            SOTask task = _inactiveTasks.Dequeue();
            _activeTasks.Add(task);
        }
    }

}