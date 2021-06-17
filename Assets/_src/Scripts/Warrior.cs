using UnityEngine;

namespace _src.Scripts
{
    public class Warrior : Actor
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private WeaponView weaponView;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        private static readonly int Block1 = Animator.StringToHash("Block");

        [ContextMenu("Attack")]
        public void Attack()
        {
            _animator.SetTrigger(Attack1);
        }
        
        [ContextMenu("Block")]
        public void Block()
        {
            _animator.SetTrigger(Block1);
        }

        public void SetCollisionActive(int value)
        {
            weaponView.SetActive(value);
        }
    }
}