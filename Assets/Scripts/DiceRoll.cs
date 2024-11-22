using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
	[SerializeField]
	private Animation _fallAnimation;

	[SerializeField]
	private Animation _rollAnimation;

	private int _roll;

	private Vector3[] _initialRotations = new Vector3[6];

	void Awake()
	{
		_initialRotations[0] = new Vector3(0,0,0);
		_initialRotations[1] = new Vector3(270,0,0);
		_initialRotations[2] = new Vector3(0,0,90);
		_initialRotations[3] = new Vector3(0,0,270);
		_initialRotations[4] = new Vector3(90,0,0);
		_initialRotations[5] = new Vector3(180,0,0);
	}

	public int GetRoll()
	{
		_roll = Random.Range(1, 7);

		if (gameObject.activeSelf)
		{
			transform.localEulerAngles = new Vector3(_initialRotations[_roll - 1].x, Random.Range(0,360), _initialRotations[_roll - 1].z);

			_rollAnimation.Play();
			_fallAnimation.Play();
		}

		return _roll;
	}
}
