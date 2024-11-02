using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
	[SerializeField]
	private int _maxExclusive;
	
	[SerializeField]
	private int _minInclusive;

	private int _roll;

    void OnEnable()
    {
		_roll = Random.Range(_minInclusive, _maxExclusive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public int GetRoll()
	{
		return _roll;
	}
}
