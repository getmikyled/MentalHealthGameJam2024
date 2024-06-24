using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    [CreateAssetMenu(fileName = "Task", menuName = "Task")]
    public class SOTask : ScriptableObject
    {
        [FormerlySerializedAs("name")]
        [Tooltip("The name of the task.")]
        [SerializeField] private string _taskName;
        public string taskName => _taskName;
        [FormerlySerializedAs("details")]
        [Tooltip("A description containing the details of the task.")]
        [SerializeField] private string _details;
        public string details => _details;
    }
}
