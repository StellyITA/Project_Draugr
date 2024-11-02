using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _players;

	[SerializeField]
	private GameObject _dice1;

	[SerializeField]
	private GameObject _dice2;

	private DiceRoll _roll1;
	private DiceRoll _roll2;
	private CircularSingleLinkedList<PlayerMovement> _turns;
	private ListNode<PlayerMovement> _currentTurn;

    // Start is called before the first frame update
    void Start()
    {
		SetTurnsOrder();
		_currentTurn = _turns.GetFirst();
		_currentTurn.GetValue().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetNextTurn()
	{
		_currentTurn.GetValue().enabled = false;
		_currentTurn = _currentTurn.GetNext();
		_currentTurn.GetValue().enabled = true;
	}

	void SetTurnsOrder()
	{
		_roll1 = _dice1.GetComponent<DiceRoll>();
		_roll2 = _dice2.GetComponent<DiceRoll>();

        MinPriorityQueue<PlayerMovement> playersMinHeap = new MinPriorityQueue<PlayerMovement>();

		foreach (GameObject player in _players)
		{
			_dice1.SetActive(true);
			_dice2.SetActive(true);
			
			PlayerMovement playerScript = player.GetComponent<PlayerMovement>();

			playersMinHeap.Enqueue(playerScript, _roll1.GetRoll() + _roll2.GetRoll());

			Debug.Log(player.name + ": " + _roll1.GetRoll() + ", " + _roll2.GetRoll());

			_dice1.SetActive(false);
			_dice2.SetActive(false);
		}
	
		_turns = new CircularSingleLinkedList<PlayerMovement>(playersMinHeap.Dequeue());

		while (playersMinHeap.GetCount() > 0)
		{
			_turns.AddFirst(playersMinHeap.Dequeue());
		}
	}
}
