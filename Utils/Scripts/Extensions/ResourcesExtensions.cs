using System.Runtime.CompilerServices;
using UnityEngine;

namespace HYDRA
{
    public static class ResourcesExtensions
    {
        public static T LoadOrThrow<T>(string path, [CallerMemberName] string caller = null) where T : Object
        {
            T resource = Resources.Load<T>(path);
            if (resource == null)
                throw new System.ArgumentException($"Resource not found for {path} -> {caller}");

            return resource;
        }
    }
}