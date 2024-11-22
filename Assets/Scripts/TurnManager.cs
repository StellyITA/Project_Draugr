using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	[SerializeField]
	private PlayerMovement[] _players;

	[SerializeField]
	private DiceRoll _roll1;

	[SerializeField]
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
		MinPriorityQueue<PlayerMovement> playersMinHeap = new MinPriorityQueue<PlayerMovement>();

		foreach (PlayerMovement player in _players)
		{
			int rollValue1 = _roll1.GetRoll();
			int rollValue2 = _roll2.GetRoll();

			playersMinHeap.Enqueue(player, rollValue1 + rollValue2);

			Debug.Log(player.gameObject.name + ": " + rollValue1 + ", " + rollValue2);
		}
	
		_turns = new CircularSingleLinkedList<PlayerMovement>(playersMinHeap.Dequeue());

		while (playersMinHeap.GetCount() > 0)
		{
			_turns.AddFirst(playersMinHeap.Dequeue());
		}
	}
}
