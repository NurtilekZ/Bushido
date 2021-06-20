using UnityEngine;

namespace _src.Scripts
{
    public class SingletonPersistent<T> : MonoBehaviour
        where T : Component
    {
        public static T Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            } else {    
                Destroy(gameObject);
            }
        }
    }
}