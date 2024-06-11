using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    [CreateAssetMenu(fileName = "Task", menuName = "Task")]
    public class SOTask : ScriptableObject
    {
        [Tooltip("The name of the task.")]
        [SerializeField] private string name;
        [Tooltip("A description containing the details of the task.")]
        [SerializeField] private string details;
    }
}
