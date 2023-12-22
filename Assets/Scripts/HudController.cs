using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private InventoryController _inventory;

    public Transform ApplesMagnet => tmpText.transform;

private void Start()
{
    _inventory.ApplesCountChanged += OnApplesCountChanged;
}

private void OnDestroy()
{
    _inventory.ApplesCountChanged -= OnApplesCountChanged;
}


    private void OnApplesCountChanged()
    {
        tmpText.text = _inventory.ApplesCount.ToString();
    }
}
