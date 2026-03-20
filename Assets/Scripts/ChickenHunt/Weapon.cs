using UnityEngine;

namespace ChickenHunt
{
    /// <summary>
    /// OOP Example: Abstraction — Weapon defines Fire(); concrete weapons implement how.
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _cooldown = 0.5f;

        private float _nextFireTime;

        public bool CanFire => Time.time >= _nextFireTime;

        private void Update()
        {
            if (!CanFire) return;

            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                _nextFireTime = Time.time + _cooldown;
            }
        }

        public abstract void Fire();
    }

    public class LaserWeapon : Weapon
    {
        [Header("Laser")]
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _range = 10f;

        public override void Fire()
        {
            if (_lineRenderer == null) return;

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, transform.position + transform.right * _range);
            _lineRenderer.enabled = true;
        }
    }

    public class ProjectileWeapon : Weapon
    {
        [Header("Projectile")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _projectileSpeed = 10f;

        public override void Fire()
        {
            if (_projectilePrefab == null) return;

            var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
            var rigidbody = projectile.GetComponent<Rigidbody2D>();

            if (rigidbody == null) return;

            rigidbody.linearVelocity = transform.right * _projectileSpeed;
        }
    }
}
