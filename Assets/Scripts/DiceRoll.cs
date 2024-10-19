using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.String;

public class DiceRoll : MonoBehaviour
{
    public int _value { get; private set; }
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
	_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
	// If player presses spacebar
	if (Input.GetKeyDown(KeyCode.Space))
	{
	    // public static int Range(int minInclusive, int maxExclusive);
	    _value = Random.Range(1,7);
	    _text.text = Format("{0}", _value);
	}
    }
}
