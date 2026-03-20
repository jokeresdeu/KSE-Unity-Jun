using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenHunt
{
    /// <summary>
    /// OOP Example: Inheritance — base Enemy; FlyingEnemy and FastEnemy override UpdateMovement.
    /// </summary>
    public class Enemy : BaseEnemy, IDamageable, IDisposable
    {
        [Header("Stats")]
        [SerializeField] protected int _maxHealth = 3;
        [SerializeField] private float _moveSpeed = 2f;

        public int MaxHealth => _maxHealth;


        private int _currentHealth;

        public event Action<Enemy> OnDeath;

        public bool IsAlive => _currentHealth > 0;

        protected virtual void Awake()
        {
            _currentHealth = _maxHealth;
            List<MonoBehaviour> monoBehs = new List<MonoBehaviour>();
            monoBehs.Add(this);
            List<IDamageable> damageables = new List<IDamageable>();
            damageables.Add(this);
            damageables.Add(new Player());
            Warrior elfWarrior = new ElfWarrior();
            ElfWarrior elfWarrior2 = new ElfWarrior();
            elfWarrior.Heal();
            elfWarrior.TakeDamage();
            elfWarrior2.Heal();
            elfWarrior2.TakeDamage();
        }

        private void Update()
        {
            UpdateMovement();
        }

        public void IncreaseMaxHp(int amount, IDamageable damageable)
        {
            _maxHealth += amount;
        }

        public int Hp { get; set; }

        public void TakeDamage(int amount)
        {
            if (!IsAlive) return;

            _currentHealth = Mathf.Max(_currentHealth - amount, 0);

            if (!IsAlive)
            {
                OnDeath?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        protected virtual void UpdateMovement()
        {
            transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override int Health { get; }

        public override void Heal(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class FlyingEnemy : Enemy
    {
        [Header("Flying")]
        [SerializeField] private float _hoverAmplitude = 0.5f;
        [SerializeField] private float _hoverSpeed = 3f;

        private float _baseY;

        protected override void Awake()
        {
            _maxHealth = 10;
            base.Awake();
            Debug.Log("Hello");
        }

        private void Start()
        {
            _baseY = transform.position.y;
        }

        public void TakeDamage(int amount)
        {
            
        }

        protected override void UpdateMovement()
        {
            base.UpdateMovement();

            var position = transform.position;
            position.y = _baseY + Mathf.Sin(Time.time * _hoverSpeed) * _hoverAmplitude;
            transform.position = position;
        }
    }

    public class FastEnemy : Enemy
    {
        [Header("Fast")]
        [SerializeField] private float _speedMultiplier = 2f;

        protected override void UpdateMovement()
        {
            transform.Translate(Vector3.left * (_speedMultiplier * Time.deltaTime));
        }
    }

    public abstract class Warrior
    {
        public void TakeDamage()
        {
            Debug.Log(nameof(Warrior) + " has taken damage");
        }

        public virtual void Heal()
        {
            Debug.Log(nameof(Warrior) + " has been heald"); 
        }
    }

    public class ElfWarrior : Warrior
    {
        public void TakeDamage()
        {
            base.TakeDamage();
            Debug.Log(nameof(ElfWarrior) + " has taken damage");
        }
        public override void Heal()
        {
            base.Heal();
            Debug.Log(nameof(ElfWarrior) + " has been heald twise");
        }
    }
    
}
