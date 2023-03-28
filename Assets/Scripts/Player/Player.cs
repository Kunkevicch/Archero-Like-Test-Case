using ArcheroLike.Components;
using ArcheroLike.Events.Move;
using UnityEngine;

namespace ArcheroLike.Characters
{
    /// <summary>
    /// Главный класс игрока, который является проводником для всех остальных компонентов
    /// и связывает компоненты между собой, если это необходимо,
    /// а также хранит в себе события, которые publishat комоненты 
    /// и подписываются другие компоненты
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]

    [RequireComponent(typeof(PlayerInputComponent))]
    [RequireComponent(typeof(AnimateComponent))]

    [RequireComponent(typeof(MoveByVelocityComponent))]
    [RequireComponent(typeof(MoveByVelocityEvent))]

    [RequireComponent(typeof(IdleComponent))]
    [RequireComponent(typeof(IdleEvent))]

    [RequireComponent(typeof(RotateComponent))]
    [RequireComponent(typeof(RotateEvent))]


    [RequireComponent(typeof(Rigidbody))]

    [DisallowMultipleComponent]
    #endregion
    public class Player : MonoBehaviour
    {
        [HideInInspector] public Animator animator;

        [HideInInspector] public PlayerInputComponent inputHandler;

        [HideInInspector] public MoveByVelocityEvent moveByVelocityEvent;

        [HideInInspector] public IdleEvent idleEvent;

        [HideInInspector] public RotateEvent rotateEvent;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            inputHandler = GetComponent<PlayerInputComponent>();

            moveByVelocityEvent = GetComponent<MoveByVelocityEvent>();
            idleEvent = GetComponent<IdleEvent>();
            rotateEvent = GetComponent<RotateEvent>();
        }
    }
}