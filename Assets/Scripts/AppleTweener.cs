using DG.Tweening;
using UnityEngine;

public class AppleTweener : MonoBehaviour
{
    [SerializeField] private float _animationTime;
    [SerializeField] private int _healthAmount;
    private Transform _target;

    public int HealthAmount => _healthAmount;
    
    private void Start()
    {
        _target = FindObjectOfType<HudController>().ApplesMagnet;
    }

    private void AppleFlight()
	{
        Vector3 hudPos = Camera.main.ScreenToWorldPoint(_target.position);
		var seq = DOTween.Sequence();
		seq.Append(transform.DOMove(hudPos, _animationTime));
        seq.AppendCallback(SelfDestroy);
	}

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<HeroPhysicsController>() != null)
        {
            AppleFlight();
            InventoryController invCon = FindObjectOfType<InventoryController>();
            invCon.AddApples(this);
        }
    }
}
