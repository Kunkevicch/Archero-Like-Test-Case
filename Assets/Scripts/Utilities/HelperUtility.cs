using UnityEngine;

namespace ArcheroLike.Utilities
{
    /// <summary>
    /// Класс для валидации путем расширения классов,
    /// а также для хранения различных полезных методов,
    /// функционал которых нельзя отнести к какой-то определенной
    /// сущности
    /// </summary>
    public static class HelperUtility
    {
        public static bool CheckEmptyString(this Object thisObject, string fieldName, string stringToCheck)
        {
            if (stringToCheck == "")
            {
                Debug.LogError($"{fieldName} is empty and must contain a value in object {thisObject.name}");
            }

            return false;
        }

        public static bool CheckPositiveValue(this Object thisObject, string fieldName, int valueToCheck, bool zeroAllowed = false)
        {
            if ( zeroAllowed == false && valueToCheck <= 0 )
            {
                Debug.LogError($"{fieldName} is negative or equal zero and must contain positive value in object {thisObject.name}");
            }

            return false;
        }

        public static bool CheckPositiveValue(this Object thisObject, string fieldName, float valueToCheck, bool zeroAllowed = false)
        {
            if ( zeroAllowed == false && valueToCheck <= 0 )
            {
                Debug.LogError($"{fieldName} is negative or equal zero and must contain positive value in object {thisObject.name}");
            }

            return false;
        }
    }
}
