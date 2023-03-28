using System;
using UnityEngine;

namespace ArcheroLike.Events.Move
{
    /// <summary>
    /// Event
    /// Событие, которое оповещает всех подписчиков о том, что игрок остановился
    /// </summary>
    public class IdleEvent : MonoBehaviour
    {
        public event Action<IdleEvent> OnIdleEvent;

        public void CallIdleEvent()
        {
            OnIdleEvent?.Invoke(this);
        }
    }
}
