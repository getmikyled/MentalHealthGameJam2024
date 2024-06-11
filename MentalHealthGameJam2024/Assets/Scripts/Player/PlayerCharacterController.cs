using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentalHealthGJ_2024
{
    public enum PlayerMovementState
    {
        None = 0,
        
        Walking = 2
    }
    
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public class PlayerCharacterController : MonoBehaviour
    {
        // SINGLETON
        public static PlayerCharacterController instance;
        
        [Tooltip("The speed of the player when walking")]
        [SerializeField] private float _walkingSpeed = 5f;
        
        private PlayerMovementState _playerMovementState = PlayerMovementState.Walking;
        
        private Rigidbody2D _rigidbody;

        private Vector2 _movementDirection = Vector2.zero;

        private bool movementPaused = false;

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
            CacheComponents();
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void CacheComponents()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void FixedUpdate()
        {
            UpdatePlayerMovementState();
        }

#region PLAYER MOVEMENT STATE MACHINE
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void SetPlayerMovementState(PlayerMovementState newState)
        {
            PlayerMovementState prevState = _playerMovementState;
            _playerMovementState = newState;
            
            // Call exit state methods
            switch (prevState)
            {
                case PlayerMovementState.None:
                case PlayerMovementState.Walking:
                    break;
            }
            
            // Call enter state methods
            switch (_playerMovementState)
            {
                case PlayerMovementState.None:
                case PlayerMovementState.Walking:
                    break;
            }
        }

        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void UpdatePlayerMovementState()
        {
            switch (_playerMovementState)
            {
                case PlayerMovementState.None:
                    break;
                case PlayerMovementState.Walking:
                    OnUpdateWalkingState();
                    break;
            }
        }
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        private void OnUpdateWalkingState()
        {
            // Get Movement Direction
            float horizontalDirection = Input.GetAxis("Horizontal");
            float verticalDirection = Input.GetAxis("Vertical");
            SetMovementDirection(new Vector2(horizontalDirection, verticalDirection).normalized);
            
            _rigidbody.velocity = _movementDirection * (_walkingSpeed * Time.fixedDeltaTime);
        }
        
#endregion // PLAYER MOVEMENT STATE MACHINE
        
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public void SetMovementDirection(Vector2 argMovementDirection)
        {
            _movementDirection = argMovementDirection;
        }
    }

}