using UnityEngine;

public class Damage : MonoBehaviour
{
	[SerializeField] private float _amountDamage;
	[SerializeField] private AnimationClip _hitAnimation;

	public float AmountDamage => _amountDamage;

	private void Start()
	{
		Destroy(gameObject, _hitAnimation.length);
	}
}
