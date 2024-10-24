using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private GameObject _dice;

	[SerializeField]
	private GameObject _board;
	
	private Vector3[] _coordinates;
	private GameObject _instantiatedDice1;
	private GameObject _instantiatedDice2;
	private int _roll1;
	private int _roll2;
	private int _currentCell = 0;
	private int _nextCell = 0;
	private int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
		_coordinates = _board.GetComponent<BoardManager>()._coordinatesInOrder;
    }

    // Update is called once per frame
    void Update()
    {
		if (_nextCell > _currentCell)
		{
			movePlayer();
		}
    }

	public void onRollDice(InputAction.CallbackContext context) 
	{
		if (context.started)
		{
			_instantiatedDice1 = Instantiate(_dice);
			_instantiatedDice2 = Instantiate(_dice);
			_roll1 = _instantiatedDice1.GetComponent<DiceRoll>()._value;
			_roll2 = _instantiatedDice2.GetComponent<DiceRoll>()._value;
			_nextCell += _roll1 + _roll2;

			if (_nextCell >= _coordinates.Length)
			{
				_nextCell = _coordinates.Length - 1;
			}
			
			Debug.Log(_roll1);
			Debug.Log(_roll2);
		}
		else if (context.performed)
		{
			Destroy(_instantiatedDice1);
			Destroy(_instantiatedDice2);
		}
	}

	void movePlayer()
	{
		Vector3 direction = Vector3.Normalize(_coordinates[_currentCell + 1] - _coordinates[_currentCell]);
		transform.Translate(direction * speed * Time.deltaTime);

		if ((direction.z < 0 
				&& transform.position.z 
					<= _coordinates[_currentCell + 1].z)
			|| (direction.x < 0 
				&& transform.position.x
					<= _coordinates[_currentCell + 1].x)
			|| (direction.z > 0 
				&& transform.position.z 
					>= _coordinates[_currentCell + 1].z)
			|| (direction.x > 0 
				&& transform.position.x 
					>= _coordinates[_currentCell + 1].x))
		{
			_currentCell++;
			transform.position = _coordinates[_currentCell];
		}
	}
}
