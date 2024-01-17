using System;

public class PatrolState : IState<Bandit>
{
	public void UpdateState(Bandit enemy)
	{
		// if (Vector2.Distance(enemy.transform.position, enemy.StartPosition) > _maxDistance)
		// {
		// 	enemy.transform.Translate((enemy.StartPosition) * (_speed * Time.deltaTime));
		// }
		// else
		// {
		// 	enemy.transform.Translate((enemy.StartPosition + _offset) * (_speed * Time.deltaTime));
		// }
	}
}
