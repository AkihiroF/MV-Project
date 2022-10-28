using System;

namespace Source.Scripts
{
    public class PlayerModel
    {
        private double _hpPlayer;
        private PlayerController _controller;
        
        public static Action<double> OnHealthChange;
        public static Action OnPlayerDeath;

        public PlayerModel(int hpPlayer)
        {
            _hpPlayer = hpPlayer;
        }
        
        public void Damage(double damage)
        {
            _hpPlayer -= damage;
            if (_hpPlayer <= 0)
            {
                OnPlayerDeath.Invoke();
                return;
            }
            OnHealthChange.Invoke(_hpPlayer);
            
        }
    }
}
