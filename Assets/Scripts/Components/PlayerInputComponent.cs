using ArcheroLike.Characters;
using ArcheroLike.SO;
using System;
using UnityEngine;

namespace ArcheroLike.Components
{
    /// <summary>
    /// Publisher
    /// Хэндлер для реализации управления персонажем
    /// </summary>
    #region Attributes
    [DisallowMultipleComponent]
    #endregion
    public class PlayerInputComponent : MonoBehaviour
    {
        [SerializeField] private MoveDetailsSO _moveDetailsSO;

        private float _velocity;
        private Vector3 _direction;

        private Player _player;
        private bool _isPlayerDead;

        private void Awake()
        {
            _player = GetComponent<Player>();

            
        }

        private void Start()
        {
            InitializeMoveDetails();
        }

        private void InitializeMoveDetails()
        {
            _velocity = _moveDetailsSO.velocity;
        }

        private void Update()
        {
            if ( _isPlayerDead )
                return;

            MovementInput();

        }

        private void MovementInput()
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            float verticalMove = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalMove,0,verticalMove);

            if(horizontalMove != 0 && verticalMove != 0 )
            {
                direction *= 0.7f;
            }

            if ( direction != Vector3.zero )
            {
                _player.moveByVelocityEvent.CallMoveByVelocityEvent(direction,_velocity);
                _player.rotateEvent.CallRotateEvent(direction.x,direction.z);
            }
            else
            {
                _player.idleEvent.CallIdleEvent();
            }

        }
    }

}
