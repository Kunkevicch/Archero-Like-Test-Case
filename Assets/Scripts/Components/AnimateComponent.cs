using ArcheroLike.Characters;
using ArcheroLike.Events.Move;
using ArcheroLike.Misc;
using System;
using UnityEngine;

namespace ArcheroLike.Components
{
    /// <summary>
    /// Subscriber
    /// Компонент анимирования
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(Player))]

    [DisallowMultipleComponent]
    #endregion
    public class AnimateComponent : MonoBehaviour
    {
        private Player _player;
        
        private void Awake()
        {
            _player = GetComponent <Player>();    
        }

        private void OnEnable()
        {
            _player.moveByVelocityEvent.OnMoveByVelocityEvent += MoveByVelocityEvent_OnMoveByVelocityEvent;
            _player.idleEvent.OnIdleEvent += IdleEvent_OnIdleEvent;
        }

        private void OnDisable()
        {
            _player.moveByVelocityEvent.OnMoveByVelocityEvent -= MoveByVelocityEvent_OnMoveByVelocityEvent;
            _player.idleEvent.OnIdleEvent -= IdleEvent_OnIdleEvent;
        }

        private void MoveByVelocityEvent_OnMoveByVelocityEvent(MoveByVelocityEvent @event, MoveByVelocityEventArgs eventArgs)
        {
            SetMoveAnimationParameters();
        }

        private void IdleEvent_OnIdleEvent(IdleEvent @event)
        {
            SetIdleAnimationParameters();
        }

        private void SetMoveAnimationParameters()
        {
            _player.animator.SetBool(SystemSettings.isIdle,false);
            _player.animator.SetBool(SystemSettings.isMoving,true);
        }

        private void SetIdleAnimationParameters()
        {
            _player.animator.SetBool(SystemSettings.isIdle,true);
            _player.animator.SetBool(SystemSettings.isMoving,false);

        }
    }
}
