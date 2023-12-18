using UnityEngine;

public class CellItemView : MonoBehaviour
{
	[SerializeField] private GameObject _apple;

	public void SetState(bool isFull)
	{
		_apple.gameObject.SetActive(isFull);
	}
}