using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
	[SerializeField] private GameObject _inventory;

	public void OnInventoryButtonClick() => _inventory.SetActive(true);
}