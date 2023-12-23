using DG.Tweening;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	[SerializeField] private Apple _apple;

	public void Interact()
	{
		transform.DOShakePosition(0.1f).SetEase(Ease.OutQuad);
		Instantiate(_apple, transform.position, transform.rotation);
	}
}
