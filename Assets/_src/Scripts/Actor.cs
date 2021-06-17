using UnityEngine;

namespace _src.Scripts
{
    public class Actor : MonoBehaviour, IDamageable
    {
        [Header("General References")]
        [SerializeField] private Stats _stats;
        [SerializeField] private bool instantiateStats;
        [SerializeField] private StatsView _statsView;
        
        private void Start()
        {
            if (instantiateStats)
            {
                _statsView = UIManager.Instance.InstantiateStatsUI(_stats, true, transform.position);
            }
        }

        public void TakeDamage(float damage)
        {
            _statsView.Health -= damage;
            _statsView.Concentration -= damage;
        }
    }
}