using System;
using UnityEngine;

namespace ChickenHunt
{
    /// <summary>
    /// OOP Example: Encapsulation — health is private; external code uses TakeDamage, Heal, and read-only properties.
    /// </summary>
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] private int _maxHealth = 100;

        private int _currentHealth;

        public event Action OnDeath;

        public bool IsAlive => _currentHealth > 0;
        public int CurrentHealth => _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive) return;

            _currentHealth = Mathf.Max(_currentHealth - amount, 0);

            if (!IsAlive)
                OnDeath?.Invoke();
        }

        public void Heal(int amount)
        {
            if (!IsAlive) return;

            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        }
    }
}
