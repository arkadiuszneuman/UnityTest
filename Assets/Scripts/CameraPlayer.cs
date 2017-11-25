using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private GameObject _player;

	void Start ()
    {
		_player = GameObject.FindWithTag("Player");
	}
	
	void LateUpdate ()
	{
	    transform.position = new Vector3(_player.transform.position.x,
	        _player.transform.position.y + 2.0f, transform.position.z);
	}
}
