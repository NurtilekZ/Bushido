using UnityEngine;

namespace _src.Scripts
{
    [CreateAssetMenu(menuName = "Weapon", fileName = "Weapon")]
    internal class Weapon : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _durability;

        public float Damage
        {
            get => _damage;
            set => _damage = value > 0 ? value : 0;
        }

        public float Durability
        {
            get => _durability;
            set => _durability = value > 0 ? value : 0;
        }
    }
}