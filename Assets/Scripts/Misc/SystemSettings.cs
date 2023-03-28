using UnityEngine;

namespace ArcheroLike.Misc
{
    /// <summary>
    /// Класс для хранения различных настроек, значений и так далее
    /// </summary>
    public static class SystemSettings
    {
        #region Animator Parameters
        public static readonly int isIdle = Animator.StringToHash("isIdle");
        public static readonly int isMoving = Animator.StringToHash("isMoving");
        public static readonly int isAttack = Animator.StringToHash("isAttack");
        public static readonly int isDead = Animator.StringToHash("isDead");
        #endregion
    }
}