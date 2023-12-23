using UnityEngine;

public class HealthBandit : MonoBehaviour
{
	private static readonly int Death = Animator.StringToHash("Death");
	private static readonly int Hurt = Animator.StringToHash("Hurt");

	[SerializeField] private float _amountHealth;
	[SerializeField] private Animator _animator;

	private void Update()
	{
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
