using UnityEngine;

public class Bandit : MonoBehaviour
{
	private static readonly int Death = Animator.StringToHash("Death");
	private static readonly int Hurt = Animator.StringToHash("Hurt");

	[SerializeField] private float _amountHealth;
	[SerializeField] private Animator _animator;

	private IState<Bandit> _currentState;

	private void Start()
	{
		_currentState = new PatrolState();
	}

	private void Update()
	{
		_currentState.UpdateState(this);

		if (_amountHealth <= 0.0f)
		{
			PlayDeathAnimation();
			Destroy(gameObject, 3);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponentInChildren<Damage>() != null)
		{
			DecreaseHealth(other.gameObject.GetComponentInChildren<Damage>().AmountDamage);
			PlayHurthAnimation();
			Destroy(other.gameObject.GetComponentInChildren<Damage>().gameObject);
		}
	}
	
	private void DecreaseHealth(float damage)
	{
		_amountHealth -= damage;
	}

	private void PlayHurthAnimation()
	{
		_animator.SetTrigger(Hurt);
	}

	private void PlayDeathAnimation()
	{
		_animator.SetTrigger(Death);
	}
}
