using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class AppleTweener : MonoBehaviour
{
     
    [SerializeField] private Transform _target;
    // [SerializeField] private 

    

    	private void AppleFlight()
	{
        Vector3 hudPos = Camera.main.ScreenToWorldPoint(_target.position);
		var seq = DOTween.Sequence();
		seq.Append(transform.DOMove(hudPos, 2.0f));
        seq.AppendCallback(selfDestroy);
	}

    private void selfDestroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AppleFlight();
        InventoryController invCon = FindObjectOfType<InventoryController>();
        invCon.AddApples(1);
        HudController hudController = FindObjectOfType<HudController>();
        hudController.RefreshRate(invCon.ApplesCount);

    }
}
