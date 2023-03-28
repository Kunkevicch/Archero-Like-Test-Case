using ArcheroLike.Components;
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

    [RequireComponent(typeof(PlayerInputHandler))]

    [RequireComponent(typeof(MoveByVelocityComponent))]
    [RequireComponent(typeof(MoveByVelocityEvent))]
    //[RequireComponent(typeof(AnimatePlayer))]

    [DisallowMultipleComponent]
    #endregion
    public class Player : MonoBehaviour
    {
        [HideInInspector] public CapsuleCollider capsuleCollider;
        [HideInInspector] public Animator animator;

        [HideInInspector] public PlayerInputHandler inputHandler;

        [HideInInspector] public MoveByVelocityEvent moveByVelocityEvent;

        private void Awake()
        {
            capsuleCollider = GetComponent<CapsuleCollider>();
            animator = GetComponent<Animator>();

            inputHandler = GetComponent<PlayerInputHandler>();

            moveByVelocityEvent = GetComponent<MoveByVelocityEvent>();
        }
    }
}