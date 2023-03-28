using ArcheroLike.Characters;
using ArcheroLike.Events.Move;
using System;
using UnityEngine;

namespace ArcheroLike.Components
{
    #region Attributes
    [RequireComponent(typeof(RotateEvent))]
    [RequireComponent(typeof(Player))]
    
    [DisallowMultipleComponent]
    #endregion
    public class RotateComponent : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _player.rotateEvent.OnRotateEvent += RotateEvent_OnRotateEvent;
        }

        private void OnDisable()
        {
            _player.rotateEvent.OnRotateEvent -= RotateEvent_OnRotateEvent;
        }

        private void RotateEvent_OnRotateEvent(RotateEvent @event, RotateEventArgs eventArgs)
        {
            RotatePlayer(eventArgs.horizontalMove, eventArgs.verticalMove);
        }

        private void RotatePlayer(float horizontalMove, float verticalMove)
        {
            Vector3 direction = new (horizontalMove, 0f, verticalMove);

            float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f,targetAngle,0f),10f*Time.deltaTime);

        }
    }
}
