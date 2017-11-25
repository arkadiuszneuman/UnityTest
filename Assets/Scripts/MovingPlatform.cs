using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform _platform;
    private Transform _startPoint;
    private Transform _endPoint;
    private float _moveSpeed;
    private Vector3 _destination;

	void Start ()
	{
	    _endPoint = transform.Find("End");
	    _startPoint = transform.Find("Start");
	    _platform = transform.Find("Platform");
	    _moveSpeed = 3.0f;
	    _destination = _endPoint.position;
	}
	
	void Update ()
	{
	    Move();
	    SetDestination();
	}

    private void SetDestination()
    {
        _platform.position = Vector3.MoveTowards(_platform.position, _destination, 
            _moveSpeed * Time.deltaTime);
    }

    private void Move()
    {
        if (_platform.position == _endPoint.position)
            _destination = _startPoint.position;

        if (_platform.position == _startPoint.position)
            _destination = _endPoint.position;
    }
}
