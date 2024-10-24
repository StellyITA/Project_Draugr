using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.String;

public class DiceRoll : MonoBehaviour
{
	public int _value { get; private set; }

	void Awake()
	{
		// UnityEngine.Random
		// public static int Range(int minInclusive, int maxExclusive)
		_value = Random.Range(1,7);
	}
}
