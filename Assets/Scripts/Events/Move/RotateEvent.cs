using System;
using UnityEngine;

namespace ArcheroLike.Events.Move
{
    public class RotateEvent : MonoBehaviour
    {
        public event Action<RotateEvent, RotateEventArgs> OnRotateEvent;

        public void CallRotateEvent(float newHorizontalMove, float newVerticalMove)
        {
            OnRotateEvent?.Invoke(this, new() { horizontalMove = newHorizontalMove, verticalMove = newVerticalMove });
        }
    }

    public class RotateEventArgs : EventArgs
    {

        public float horizontalMove;
        public float verticalMove;
    }
}
