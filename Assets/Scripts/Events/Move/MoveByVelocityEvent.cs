using System;
using UnityEngine;

namespace ArcheroLike.Events.Move
{
    /// <summary>
    /// Event
    /// Событие, которое оповещает всех подписчиков
    /// когда игрок передивагется
    /// </summary>
    #region Attributes
    [DisallowMultipleComponent]
    #endregion
    public class MoveByVelocityEvent : MonoBehaviour
    {
        public event Action<MoveByVelocityEvent,MoveByVelocityEventArgs> OnMoveByVelocityEvent;

        public void CallMoveByVelocityEvent(Vector3 newDirection, float newVelocity)
        {
            OnMoveByVelocityEvent?.Invoke(this, new() {direction=newDirection,velocity=newVelocity });
        }
    }
    public class MoveByVelocityEventArgs : EventArgs
    {
        public Vector3 direction;
        public float velocity;
    }
}
