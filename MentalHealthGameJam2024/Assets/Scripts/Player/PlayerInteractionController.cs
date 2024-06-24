using System.Collections;
using System.Collections.Generic;
using GetMikyled;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public partial class PlayerCharacterController
    {
        [Header("Interaction")]
        [SerializeField] private KeyCode interactKey;
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        protected void OnUpdateInteract()
        {
            if (Input.GetKeyDown(interactKey))
            {
                Collider2D[] overlapColliders = GetOverlapColliders();
                if (overlapColliders != null && overlapColliders.Length > 0)
                {
                    foreach (Collider2D collider in overlapColliders)
                    {
                        Activity activity = collider.transform.GetComponent<Activity>();
                        if (activity != null)
                        {
                            activity.StartActivity();
                            break;
                        }
                    }
                }
            }
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private Collider2D[] GetOverlapColliders()
        {
            Vector2 capsulePosition = transform.position.AsVector2() + _capsuleCollider.offset;
            Collider2D[] results = new Collider2D[5];
            Physics2D.OverlapCapsuleNonAlloc(capsulePosition, _capsuleCollider.size, _capsuleCollider.direction, 0, results);
            return results;
        }
    }
}