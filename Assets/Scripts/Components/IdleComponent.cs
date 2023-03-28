using ArcheroLike.Events.Move;
using UnityEngine;

namespace ArcheroLike.Components
{
    /// <summary>
    /// Subscriber
    /// Компонент, который подписан на IdleEvent
    /// в случае, если игрок бездействует
    /// скорость rb приравнивается к 0
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(IdleEvent))]
    [RequireComponent(typeof(Rigidbody))]

    [DisallowMultipleComponent]
    #endregion
    public class IdleComponent:MonoBehaviour
    {
        private Rigidbody _rb;
        private IdleEvent _idleEvent;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _idleEvent = GetComponent<IdleEvent>();
        }

        private void OnEnable()
        {
            _idleEvent.OnIdleEvent += IdleEvent_OnIdleEvent;
        }

        private void OnDisable()
        {
            _idleEvent.OnIdleEvent -= IdleEvent_OnIdleEvent;
        }

        private void IdleEvent_OnIdleEvent(IdleEvent @event)
        {
            MoveRigidBody();
        }

        private void MoveRigidBody()
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
