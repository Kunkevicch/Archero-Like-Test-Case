using ArcheroLike.Characters;
using ArcheroLike.Misc;
using ArcheroLike.SO;
using System;
using UnityEngine;

namespace ArcheroLike.Components
{
    /// <summary>
    /// Publisher
    /// ������� ��� ���������� ���������� ����������
    /// </summary>
    #region Attributes
    [DisallowMultipleComponent]
    #endregion
    public class PlayerInputHandler : MonoBehaviour
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

        }
    }

    /// <summary>
    /// Subscriber
    /// ��������� ��� ���������� ������������
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

    /// <summary>
    /// Event
    /// �������, ������� ��������� ���� �����������
    /// ����� ����� �������������
    /// </summary>
    #region Attributes
    [DisallowMultipleComponent]
    #endregion
    public class MoveByVelocityEvent
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

    /// <summary>
    /// Event
    /// �������, ������� ��������� ���� ����������� � ���, ��� ����� �����������
    /// </summary>
    public class IdleEvent
    {
        public event Action<IdleEvent> OnIdleEvent;

        public void CallIdleEvent()
        {
            OnIdleEvent?.Invoke(this);
        }
    }

    /// <summary>
    /// Subscriber
    /// ��������� ������������
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
        }

        private void OnDisable()
        {
            _player.moveByVelocityEvent.OnMoveByVelocityEvent -= MoveByVelocityEvent_OnMoveByVelocityEvent;
        }

        private void MoveByVelocityEvent_OnMoveByVelocityEvent(MoveByVelocityEvent @event, MoveByVelocityEventArgs eventArgs)
        {
            SetMoveAnimationParameters();
        }

        private void SetMoveAnimationParameters()
        {
            _player.animator.SetBool(SystemSettings.isIdle,false);
            _player.animator.SetBool(SystemSettings.isMoving,true);
        }
    }
}
