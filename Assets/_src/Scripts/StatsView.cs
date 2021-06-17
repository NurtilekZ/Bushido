using System;
using UnityEngine;
using UnityEngine.UI;

namespace _src.Scripts
{
    [Serializable]
    public class StatsView : MonoBehaviour
    {
        [Header("Fields")]
        [SerializeField] private float _health;
        [SerializeField] private float _concentration;
        [SerializeField] private bool _attachToActor = true;
        [SerializeField] private Vector3 _statsViewDistance;
        
        [Header("References")]
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Slider _concentrationBar;
        [SerializeField]private Stats _stats;
        private Vector3 _actorPosition;

        public float Health
        {
            get => _health;
            set
            {
                _health = value > 0 ? value : 0;
                _healthBar.value = _health / _stats.MAXHealth;
            }
        }
        
        public float Concentration
        {
            get => _concentration;
            set
            {
                _concentration = value > 0 ? value : 0;
                _concentrationBar.value = _concentration / _stats.MAXConcentration;
            }
        }

        public void Set(Stats stats, bool attach, Vector3 actorPosition)
        {
            _stats = stats;
            Health = stats.MAXHealth;
            Concentration = stats.MAXConcentration;
            _actorPosition = actorPosition;
            _attachToActor = attach;
        }

        private void SetPosition(Vector3 worldToScreenPoint)
        {
            transform.position = worldToScreenPoint;
        }
        
        private void Update()
        {
            if (_attachToActor)
            {
                SetPosition(UIManager.mainCamera.WorldToScreenPoint(_actorPosition + _statsViewDistance));
            }
        }

        private void OnValidate()
        {
            if (!ReferenceEquals(_stats, null))
            {
                Health = _stats.MAXHealth;
                Concentration = _stats.MAXConcentration;
            }
        }
    }
}