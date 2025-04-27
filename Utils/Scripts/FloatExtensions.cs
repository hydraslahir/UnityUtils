using UnityEngine;

namespace HYDRA
{
    public static class FloatExtensions
    {
        public static bool ValuesAreEqual(this float a, float b)//, float epsilon = 0.001f)
        {
            return Mathf.Approximately(a, b);
            // var absDelta = Mathf.Abs(b - a);
            // return absDelta < Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), epsilon);
        }
    }
}