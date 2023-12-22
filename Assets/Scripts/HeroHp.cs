
using UnityEngine;

public class HeroHp : MonoBehaviour
{
    [SerializeField] private int heroMaxHp;
    [SerializeField] private InventoryController inventoryController;
    private const string heroHpKey = "HeroHpKey";
    private int currentHp;

    private void Awake()
    {
         currentHp = GetPlayerPrefs(heroHpKey);
       
    }
    private void OnEnable()
    {
        inventoryController.OnAppleEat += IncreaseHp;
    }

    private void IncreaseHp()
    {
        IncreaseHp(10);
    }

    private void OnDestroy()
    {
        inventoryController.OnAppleEat -= IncreaseHp;
    }

    private void IncreaseHp(int value)
    {
        currentHp += value;

        if (currentHp >= heroMaxHp)
        {
            currentHp = heroMaxHp;
        }

        SavePlayerPrefs(heroHpKey, currentHp);
    }

    private void DecreaseHp(int value)
    {
        currentHp -= value;

        if (currentHp <= 0)
        {
            currentHp = 0;
        }

        SavePlayerPrefs(heroHpKey, currentHp);
    }

    private void SavePlayerPrefs(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    private int GetPlayerPrefs(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }

        else
        {
            return heroMaxHp;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>())
        {
            DecreaseHp(5);
        }
    }
}
