using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Source.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Color colorDamage;
        [SerializeField] private float timeDamage;
        [SerializeField] private TextMeshProUGUI hpText;
        private SpriteRenderer _spritePlayer;
        private void OnEnable()
        {
            PlayerModel.OnHealthChange += TakeDamage;
            PlayerModel.OnPlayerDeath += Dead;
            _spritePlayer = GetComponent<SpriteRenderer>();
        }

        private void Dead()
        {
            hpText.text = "Dead";
            PlayerModel.OnHealthChange -= TakeDamage;
            PlayerModel.OnPlayerDeath -= Dead;
            Destroy(this.gameObject);
        }

        private void TakeDamage(double currentHp)
        {
            hpText.text = $"HP {currentHp}";
            StartCoroutine(RenderDamage());
        }

        private IEnumerator RenderDamage()
        {
            _spritePlayer.DOColor(colorDamage, timeDamage/2);
            yield return new WaitForSeconds(timeDamage/2);
            _spritePlayer.DOColor(Color.white, timeDamage/2);
        }
    }
}
