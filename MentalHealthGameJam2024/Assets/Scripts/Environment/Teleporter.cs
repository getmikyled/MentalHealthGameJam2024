using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    [RequireComponent(typeof(Collider2D))]
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Transform _destination;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void Teleport()
        {
            PlayerCharacterController.instance.transform.position = _destination.position;
        }
    }

}