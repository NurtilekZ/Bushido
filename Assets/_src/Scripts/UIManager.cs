using UnityEngine;

namespace _src.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        public static Camera mainCamera;

        [Header("References")]
        [SerializeField] private RectTransform _statsRectTransform;
        [SerializeField] private StatsView _statsViewPrefab;

        private void Awake()
        {
            SetSingleton();
            mainCamera = Camera.main;
        }

        private void SetSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public StatsView InstantiateStatsUI(Stats stats, bool attach, Vector3 actorPosition)
        {
            StatsView newStatsView = Instantiate(_statsViewPrefab, _statsRectTransform);
            newStatsView.Set(stats, attach, actorPosition);
            return newStatsView;
        }
    }
}