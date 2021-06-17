using System;
using UnityEngine;

namespace _src.Scripts
{
    [Serializable]
    [CreateAssetMenu(menuName = "Stats", fileName = "Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _maxConcentration;

        public float MAXHealth
        {
            get => _maxHealth;
            set => _maxHealth = value > 0 ? value : 0;
        }

        public float MAXConcentration
        {
            get => _maxConcentration;
            set => _maxConcentration = value > 0 ? value : 0;
        }
    }
}