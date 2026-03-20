using System.Collections.Generic;
using UnityEngine;

namespace ChickenHunt
{
    /// <summary>
    /// OOP Example: Polymorphism — treats all enemies as Enemy; actual type (Enemy, FlyingEnemy, FastEnemy) doesn't matter.
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {
        [Header("Spawning")]
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private FlyingEnemy _flyingEnemyPrefab;
        [SerializeField] private FastEnemy _fastEnemyPrefab;

        [SerializeField] private Transform _spawnPoint;

        private readonly List<Enemy> _activeEnemies = new();

        private void Start()
        {
            SpawnWave();
        }

        private void OnDestroy()
        {
            foreach (var enemy in _activeEnemies)
            {
                if (enemy == null) continue;
                enemy.OnDeath -= HandleEnemyDeath;
            }
        }

        public void SpawnWave()
        {
            SpawnEnemy(_enemyPrefab);
            SpawnEnemy(_flyingEnemyPrefab);
            SpawnEnemy(_fastEnemyPrefab);
        }

        private void SpawnEnemy(Enemy prefab)
        {
            if (prefab == null || _spawnPoint == null) return;

            var enemyInstance = Instantiate(prefab, _spawnPoint.position, Quaternion.identity);
            enemyInstance.OnDeath += HandleEnemyDeath;
            _activeEnemies.Add(enemyInstance);
        }

        private void HandleEnemyDeath(Enemy enemy)
        {
            enemy.OnDeath -= HandleEnemyDeath;
            _activeEnemies.Remove(enemy);
        }
    }
}
