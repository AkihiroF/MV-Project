
using Unity.VisualScripting;
using UnityEngine.InputSystem;

namespace Source.Scripts
{
    public class PlayerController
    {
        private InputController _input;
        private PlayerModel _playerModel;
        private PlayerView _playerView;

        public PlayerController( PlayerView view, PlayerModel model)
        {
            _playerModel = model;
            _playerView = view;
            
            _input = new InputController();
            _input.Player.Damage.Enable();
            _input.Player.Damage.performed += TakeDamage;
            PlayerModel.OnPlayerDeath += Dead;

        }

        private void TakeDamage(InputAction.CallbackContext obj)
        {
            _playerModel.Damage(10);
        }
        private void Dead()
        {
            _input.Player.Damage.performed -= TakeDamage;
            PlayerModel.OnPlayerDeath -= Dead;
        }
    }
}