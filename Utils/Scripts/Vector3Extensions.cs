using UnityEngine;

namespace HYDRA
{
    public static class Vector3Extensions
    {
        public static bool ValuesAreEqual(this Vector3 v, Vector3 u)
        {
            if (!v.x.ValuesAreEqual(u.x))
                return false;
            if (!v.y.ValuesAreEqual(u.y))
                return false;
            if (!v.z.ValuesAreEqual(u.z))
                return false;
            return true;
        }
    }
}