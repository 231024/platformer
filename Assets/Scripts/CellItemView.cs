using UnityEngine;

public class CellItemView : MonoBehaviour
{
	[SerializeField] private GameObject _apple;

	public void SetState(bool isEmpty)
	{
		_apple.gameObject.SetActive(!isEmpty);
	}
}