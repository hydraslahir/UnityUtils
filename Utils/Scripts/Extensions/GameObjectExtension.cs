using UnityEngine;

namespace HYDRA
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// Premise:
        /// Using SerializedField do have some problem, 
        /// - losing reference when renaming
        /// - conserving references when duplicating
        /// - can be overriden by code
        /// 
        /// Assigning on Start do have some problem, sometimes
        /// - Start() is called after the current frame where the object is instantiated.
        /// doing something like 'AddComponent T ' and then T.Variable, if Variable is assigned at start, it will not be set soon enough
        /// 
        /// Drawback, always compare to null
        /// 
        /// This method can be modified to throw when component is not found.
        /// </summary>
        public static T GetAndAssign<T>(this GameObject go, ref T component)
            where T : Component
        {
            if (component == null)
                component = go.GetComponent<T>();
            return component;
        }
    }
}