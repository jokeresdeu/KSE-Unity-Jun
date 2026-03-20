namespace ChickenHunt
{
    public class DamageSystem
    {
        public void TakeDamage(IDamageable damageable, int damage)
        {
            damage /=2;
            damageable.TakeDamage(damage);
        }
    }
}