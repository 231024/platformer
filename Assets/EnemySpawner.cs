using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Game _game;
	[SerializeField] private Bandit[] _bandits;
	[SerializeField] private Transform _spawnPoint;

	private void Start()
	{
		var bandit = Instantiate(_bandits[0], _spawnPoint.position, _spawnPoint.rotation);
		bandit.GetComponent<EnemyAI>().Target = _game.Hero.transform;
	}
}
