using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    public partial class PlayerCharacterController
    {
        [Header("Interaction")]
        [SerializeField] private KeyCode interactKey;
        protected void OnUpdateInteract()
        {
            // TO DO: Check for input to see if the player attempted to interact.
            // Use OverlapColliders to detect if any collisions have an activity. 
        }
    }
}