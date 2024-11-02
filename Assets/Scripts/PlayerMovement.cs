using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private bool _aI;

	[SerializeField]
	private GameObject _dice1;

	[SerializeField]
	private GameObject _dice2;

	[SerializeField]
	private GameObject _board;

	[SerializeField]
	private GameObject _turnObject;

	private BoardManager _boardManager;
	private TurnManager _turnManager;
	private DiceRoll _roll1;
	private DiceRoll _roll2;
	private Vector3[] _coordinates;
	private int _currentCell = -1;
	private int _nextCell = -1;
	private bool _isMoving;

	void Awake()
	{
		_roll1 = _dice1.GetComponent<DiceRoll>();
		_roll2 = _dice2.GetComponent<DiceRoll>();
		_boardManager = _board.GetComponent<BoardManager>();
		_turnManager = _turnObject.GetComponent<TurnManager>();
	}

	void Start()
	{
		_coordinates = _boardManager.GetCoordinates();
	}

    void OnEnable()
    {
        if (_aI)
		{
			GetNextCell();
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (_nextCell > _currentCell)
		{
			Vector3 direction = Vector3.Normalize(_coordinates[_currentCell + 1] - transform.position);

			transform.Translate(direction * Time.deltaTime);

			if ((direction.x > 0 
					&& transform.position.x >= _coordinates[_currentCell + 1].x)
				|| (direction.x < 0 
					&& transform.position.x <= _coordinates[_currentCell + 1].x)
				|| (direction.z > 0 
					&& transform.position.z >= _coordinates[_currentCell + 1].z)
				|| (direction.z < 0 
					&& transform.position.z <= _coordinates[_currentCell + 1].z))
			{
				_currentCell++;
				transform.position = _coordinates[_currentCell];
			}
		}
		else if (_isMoving)
		{
			_isMoving = false;
			_turnManager.SetNextTurn();
		}
    }

	public void OnDiceRoll(InputAction.CallbackContext context)
	{
		if (context.started && !_aI && !_isMoving)
		{
			GetNextCell();
		}
	}

	void GetNextCell()
	{
		_isMoving = true;

		_dice1.SetActive(true);
		_dice2.SetActive(true);
		
		Debug.Log(_roll1.GetRoll());
		Debug.Log(_roll2.GetRoll());

		_nextCell += _roll1.GetRoll() + _roll2.GetRoll();

		_dice1.SetActive(false);
		_dice2.SetActive(false);
	}
}
