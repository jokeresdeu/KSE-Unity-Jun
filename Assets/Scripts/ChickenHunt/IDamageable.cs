namespace ChickenHunt
{
    public interface IDamageable
    {
        //public
        int Hp { get; set; }
        void TakeDamage(int damage);
        void Die();
    }
}