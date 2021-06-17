using UnityEngine;

namespace _src.Scripts
{
    public class WeaponView : MonoBehaviour
    {
        [Header("Fields")]
        [SerializeField] private float damage;
        [SerializeField] private float durability;

        [Header("References")]
        [SerializeField] private Collider _collider;
        [SerializeField] private Weapon _weapon;

        private void Awake()
        {
            damage = _weapon.Damage;
            durability = _weapon.Durability;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (other.TryGetComponent(out WeaponView weaponView))
            {
                weaponView.durability -= damage / 2;
            }
            else if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }

        public void SetActive(int value)
        {
            _collider.enabled = value == 1;
        }

        private void OnValidate()
        {
            if (!ReferenceEquals(_weapon, null))
            {
                damage = _weapon.Damage;
                durability = _weapon.Durability;
            }
        }
    }
}