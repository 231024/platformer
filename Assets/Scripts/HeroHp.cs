using UnityEngine;

public class HeroHp : MonoBehaviour
{
	private const string HeroHpKey = "HeroHpKey";

	[SerializeField] private int _heroMaxHp;
	[SerializeField] private InventoryController _inventoryController;

	private int _currentHp;

	private void Awake()
	{
		_currentHp = GetPlayerPrefs(HeroHpKey);
	}

	private void OnEnable()
	{
		_inventoryController.OnAppleEat += IncreaseHp;
	}

	private void OnDestroy()
	{
		_inventoryController.OnAppleEat -= IncreaseHp;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Damage>())
		{
			DecreaseHp(5);
		}
	}

	private void IncreaseHp(int value)
	{
		_currentHp += value;

		if (_currentHp >= _heroMaxHp)
		{
			_currentHp = _heroMaxHp;
		}

		SavePlayerPrefs(HeroHpKey, _currentHp);
	}

	private void DecreaseHp(int value)
	{
		_currentHp -= value;

		if (_currentHp <= 0)
		{
			_currentHp = 0;
		}

		SavePlayerPrefs(HeroHpKey, _currentHp);
	}

	private void SavePlayerPrefs(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}

	private int GetPlayerPrefs(string key)
	{
		return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : _heroMaxHp;
	}
}
