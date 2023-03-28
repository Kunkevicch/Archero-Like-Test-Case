using ArcheroLike.Characters;
using ArcheroLike.Events.Move;
using UnityEngine;

namespace ArcheroLike.Components
{
    /// <summary>
    /// Subscriber
    /// Компонент для реализации передвижения
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(MoveByVelocityEvent))]
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody))]
    [DisallowMultipleComponent]
    #endregion
    public class MoveByVelocityComponent:MonoBehaviour
    {
        private MoveByVelocityEvent _moveByVelocityEvent;
        private Rigidbody _rb;

        private void Awake()
        {
            _moveByVelocityEvent = GetComponent<MoveByVelocityEvent>();
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _moveByVelocityEvent.OnMoveByVelocityEvent += MoveByVelocityEvent_OnMoveByVelocityEvent;
        }

        private void OnDisable()
        {
            _moveByVelocityEvent.OnMoveByVelocityEvent -= MoveByVelocityEvent_OnMoveByVelocityEvent;
        }

        private void MoveByVelocityEvent_OnMoveByVelocityEvent(MoveByVelocityEvent @event, MoveByVelocityEventArgs eventArgs)
        {
            MoveRigidBody(eventArgs.direction, eventArgs.velocity);
        }

        private void MoveRigidBody(Vector3 moveDirection, float velocity)
        {
            _rb.velocity = moveDirection*velocity;
        }
    }
}
