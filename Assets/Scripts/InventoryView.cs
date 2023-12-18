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
	}

	private void Fill()
	{
		_cells.Clear();
		var applesCount = _inventoryController.ApplesCount;

		for (var i = 0; i < _inventoryController.MaxItemCount; i++)
		{
			var cell = Instantiate(_inventoryCell, _parentGrid.transform);
			cell.SetState(applesCount > i);
			cell.gameObject.SetActive(true);
			_cells.Add(cell);
		}
	}

	public void OnItemClick()
	{
		_inventoryController.EatApple();
	}
}