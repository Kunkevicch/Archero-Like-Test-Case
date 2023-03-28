using ArcheroLike.Utilities;
using UnityEngine;

namespace ArcheroLike.SO
{
    /// <summary>
    /// Scriptable Object для настройки передвижения
    /// </summary>
    [CreateAssetMenu(fileName ="MoveDetails_",menuName ="Scriptable Objects/Move/Move Details")]
    public class MoveDetailsSO : MonoBehaviour
    {
        #region Header Move Details
        [Header("Move details")]
        #endregion
        public string characterName = "John Doe";
        public float velocity = 10f;

        #region Validation
#if UNITY_EDITOR

        private void OnValidate()
        {
            HelperUtility.CheckEmptyString(this,nameof(characterName),characterName);
            HelperUtility.CheckPositiveValue(this,nameof(velocity),velocity);
        }

#endif
        #endregion

    }
}
