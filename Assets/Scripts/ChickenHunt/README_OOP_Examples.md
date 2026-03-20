# OOP Principles — Unity Examples (ChickenHunt)

Examples for teaching the four OOP principles. All follow the project coding guidelines.

| Principle      | File(s)           | What to look at |
|----------------|-------------------|------------------|
| **Encapsulation** | `PlayerHealth.cs` | Private `_currentHealth`; public `TakeDamage()`, `Heal()`, and read-only properties. |
| **Inheritance**   | `Enemy.cs`       | Base `Enemy`; `FlyingEnemy` and `FastEnemy` override `UpdateMovement()`. |
| **Polymorphism**  | `EnemyManager.cs`| Works with type `Enemy`; real instances can be `FlyingEnemy` or `FastEnemy`. |
| **Abstraction**   | `Weapon.cs`      | Abstract `Weapon` with `Fire()`; `LaserWeapon` and `ProjectileWeapon` implement it. |

## Folder structure

```
Assets/Scripts/ChickenHunt/
├── PlayerHealth.cs   (Encapsulation)
├── Enemy.cs          (Inheritance: Enemy, FlyingEnemy, FastEnemy)
├── EnemyManager.cs   (Polymorphism)
├── Weapon.cs         (Abstraction: Weapon, LaserWeapon, ProjectileWeapon)
└── README_OOP_Examples.md
```

## Usage in a scene

- **PlayerHealth**: Attach to player GameObject; other scripts call `TakeDamage()` / `Heal()` and subscribe to `OnDeath`.
- **Enemy / FlyingEnemy / FastEnemy**: Use as prefabs; assign in EnemyManager.
- **EnemyManager**: One per scene; assign prefabs and a spawn Transform.
- **Weapon (LaserWeapon or ProjectileWeapon)**: Attach to player or weapon holder; configure in Inspector.
