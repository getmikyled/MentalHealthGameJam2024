using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class ActiveOnTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToActivate;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void OnTriggerEnter(Collider other)
        {
            PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
            if (player != null)
            {
                _objectToActivate.SetActive(true);
            }
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void OnTriggerExit(Collider other)
        {
            PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
            if (player != null)
            {
                _objectToActivate.SetActive(false);
            } 
        }
    }
}