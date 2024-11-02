using static System.Array;
using UnityEngine;

public class MinPriorityQueue<T>
{
	private T[] _elements;
	private int[] _priorities;
	private int _capacity = 7;
	private int _count = 0;

	// Constructor
	
	public MinPriorityQueue()
	{
		_elements = new T[_capacity + 1];
		_priorities = new int[_capacity + 1];
	}

	// Methods

	public void Enqueue(T e, int p)
	{	
		_count++;

		if (_count >= _capacity)
		{
			_capacity += _capacity + 1;
			
			Resize(ref _priorities, _capacity + 1);
			Resize(ref _elements, _capacity + 1);
		}

		_priorities[_count] = p;
		_elements[_count] = e;

		int i = _count;

		while (i / 2 > 0 && _priorities[i / 2] > p)
		{
			_priorities[i] = _priorities[i / 2];
			_elements[i] = _elements[i / 2];
			i /= 2;
			_elements[i] = e;
			_priorities[i] = p;
		}
	}

	public T Dequeue()
	{
		T first = _elements[1];

		_elements[1] = _elements[_count];
		_priorities[1] = _priorities[_count];
		_count--;

		if (_count <= _capacity / 2)
		{
			_capacity /= 2;
			Resize(ref _elements, _capacity + 1);
			Resize(ref _priorities, _capacity + 1);
		}
		
		int i = 1;
		while ((i * 2 <= _count 
					&& _priorities[i] >= _priorities[i * 2]) 
				|| (i * 2 + 1 <= _count 
					&& _priorities[i] >= _priorities[i * 2 + 1]))
		{
			if (_priorities[i * 2 + 1] >= _priorities[i * 2])
			{
				T tempElement = _elements[i];
				int tempPriority = _priorities[i];

				_elements[i] = _elements[i * 2];
				_priorities[i] = _priorities[i * 2];

				_elements[i * 2] = tempElement;
				_priorities[i * 2] = tempPriority;

				i *= 2;
			}
			else
			{
				T tempElement = _elements[i];
				int tempPriority = _priorities[i];

				_elements[i] = _elements[i * 2 + 1];
				_priorities[i] = _priorities[i * 2 + 1];

				_elements[i * 2 + 1] = tempElement;
				_priorities[i * 2 + 1] = tempPriority;

				i *= 2;
				i++;
			}
		}

		return first;
	}

	public int GetCount()
	{
		return _count;
	}
}

public class CircularSingleLinkedList<T>
{
	private ListNode<T> _last;
	
	public CircularSingleLinkedList(T val)
	{
		_last = new ListNode<T>(val);
		_last.SetNext(_last);
	}

	public void AddFirst(T val)
	{
		ListNode<T> temp = new ListNode<T>(val);

		temp.SetNext(_last.GetNext());
		_last.SetNext(temp);
	}

	public ListNode<T> GetFirst()
	{
		return _last.GetNext();
	}
}

public class ListNode<T>
{
	private T _value;
	private ListNode<T> _next;

	// Constructor
	public ListNode(T val)
	{
		_value = val;
		_next = null;
	}

	//Methods
	public void SetNext(ListNode<T> next)
	{
		_next = next;
	}

	public ListNode<T> GetNext()
	{
		return _next;
	}

	public T GetValue()
	{
		return _value;
	}
}
