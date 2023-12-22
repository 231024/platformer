using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
	[SerializeField] private InventoryController _inventoryController;
	[SerializeField] private CellItemView _inventoryCell;
	[SerializeField] private GameObject _parentGrid;

	private List<CellItemView> _cells = new();

	private void OnEnable()
	{
		Fill();
		_inventoryController.ApplesCountChanged += Refresh;
	}

	private void OnDisable()
	{
		_inventoryController.ApplesCountChanged -= Refresh;
	}

	private void Clear()
	{
		foreach (Transform child in _parentGrid.transform)
			Destroy(child.gameObject);

		_cells.Clear();
	}

	private void Fill()
	{
		Clear();
		var applesCount = _inventoryController.ApplesCount;

		for (var i = 0; i < _inventoryController.MaxItemCount; i++)
		{
			var cell = Instantiate(_inventoryCell, _parentGrid.transform);
			cell.SetState(applesCount > i);
			cell.gameObject.SetActive(true);
			_cells.Add(cell);
		}
	}

	private void Refresh()
	{
		var applesCount = _inventoryController.ApplesCount;
		for (var i = 0; i < _inventoryController.MaxItemCount; i++)
			_cells[i].SetState(applesCount > i);
	}

	public void OnItemClick()
	{
		_inventoryController.EatApple();
	}

	public void OnCloseClick()
	{
		gameObject.SetActive(false);
	}
}