using UnityEngine;

namespace ChickenHunt
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        public abstract  int Health { get;  }

        //private
        int hp;
        
        public abstract void Heal(int amount);
    }
}