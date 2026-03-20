namespace ChickenHunt
{
    public class Props : IDamageable
    {
        public int Hp { get; set; }
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }
    }
}