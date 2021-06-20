using UnityEngine;

namespace _src.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour 
        where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    LookForInstance();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        private static void LookForInstance()
        {
            var objs = FindObjectsOfType(typeof(T)) as T[];
            if (objs.Length > 0)
                _instance = objs[0];
            if (objs.Length > 1)
            {
                Debug.Log($"There is more than one {typeof(T).Name} in the Scene");
            }
        }
    }
}