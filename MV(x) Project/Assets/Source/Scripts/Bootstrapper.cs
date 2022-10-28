using UnityEngine;

namespace Source.Scripts
{
    public class Bootstrapper : MonoBehaviour
    {

        [SerializeField] private GameObject playerPrefab;

        [SerializeField] private int maxHpPlayer;

        private void Awake()
        {

            var playerController = new PlayerController(Instantiate(playerPrefab).GetComponent<PlayerView>(),
                new PlayerModel(maxHpPlayer));
        }
    }
}
