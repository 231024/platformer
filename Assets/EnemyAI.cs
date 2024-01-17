using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] private Seeker _seeker;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] public Transform _target;
	[SerializeField] public float _speed = 200f;
	[SerializeField] public float _nextWaypointDistance = 3f;
	private int _currentWaypoint;
	private Path _path;
	private bool _reachedEndOfPath;

	public Transform Target
	{
		get => _target;
		set => _target = value;
	}

	public void Start()
	{
		InvokeRepeating(nameof(UpdatePath), 0.0f, 0.5f);
	}

	private void FixedUpdate()
	{
		if (_path == null)
		{
			return;
		}

		if (_currentWaypoint >= _path.vectorPath.Count)
		{
			_reachedEndOfPath = true;
			return;
		}

		_reachedEndOfPath = false;

		var direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
		var force = direction * (_speed * Time.deltaTime);
		_rb.AddForce(force);
		
		var distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

		if (distance < _nextWaypointDistance)
		{
			_currentWaypoint++;
		}
	}

	private void UpdatePath()
	{
		_seeker.StartPath(_rb.position, _target.position, OnPathComplete);
	}

	private void OnPathComplete(Path p)
	{
		if (!p.error)
		{
			_path = p;
			_currentWaypoint = 0;
		}
	}
}
