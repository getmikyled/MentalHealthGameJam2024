using System.Collections;
using System.Collections.Generic;
using MentalHealthGJ_2024;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 cameraOffset = new Vector3(0, 3, -10);
            
        private PlayerCharacterController player;
        
        private void Start()
        {
            player = PlayerCharacterController.instance;
        }

        private void LateUpdate()
        {
            transform.position = player.transform.position + cameraOffset;
        }
    }
}
