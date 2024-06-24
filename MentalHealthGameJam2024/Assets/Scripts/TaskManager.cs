using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class TaskManager : MonoBehaviour
    {
        // Singleton
        public static TaskManager instance;
        
        [FormerlySerializedAs("_stressorActivities")] [SerializeField] private StressorActivity[] _stressors;

        [Space] [SerializeField] private GameObject _taskUI;
        [SerializeField] private GameObject _thoughtBubblePrefab;

        private Queue<StressorActivity> _inactiveStressorsQueue;
        private HashSet<StressorActivity> _activeStressors;

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

            _inactiveStressorsQueue = new Queue<StressorActivity>();
            _activeStressors = new HashSet<StressorActivity>();
            
            // Put all tasks into a queue
            foreach (StressorActivity stressor in _stressors)
            {
                _inactiveStressorsQueue.Enqueue(stressor);
            }
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
            ActivateNextStressor();
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void ActivateNextStressor()
        {
            if (_inactiveStressorsQueue.Count == 0)
            {
                return;
            }

            // Activate the next stressor activity
            StressorActivity nextStressor = _inactiveStressorsQueue.Dequeue();
            nextStressor.SetActive(true);
            
            _activeStressors.Add(nextStressor);
            
            nextStressor.gameObject.SetActive(true);
            
            // Create the thought bubble for the next stressor activity
            ThoughtBubbleUI thoughtBubble = Instantiate(_thoughtBubblePrefab).GetComponent<ThoughtBubbleUI>();
            thoughtBubble.Initialize(nextStressor.task);
            thoughtBubble.transform.SetParent(_taskUI.transform);

            nextStressor.thoughtBubble = thoughtBubble;
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void DeactivateStressor(StressorActivity stressor)
        {
            _activeStressors.Remove(stressor);
            stressor.SetActive(false);
            
            // Destroy thought bubble
            Destroy(stressor.thoughtBubble.gameObject);
            stressor.thoughtBubble = null;
        }
    }
}