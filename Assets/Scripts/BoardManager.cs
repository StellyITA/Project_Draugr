using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public Vector3[] _coordinatesInOrder { get; private set; } = new Vector3[40];
	private Vector3[][] _coordinatesMatrix = new Vector3[7][];
	private int _columns = 6;
	private int _distanceBetweenCells = 2;

    // Start is called before the first frame update
    void Start()
    {
		initializeCoords();
		getCellProgression();
    }

    // Update is called once per frame
    void Update()
    {
        
    }	

	void initializeCoords()
	{
		for (int i = 0; i < _coordinatesMatrix.Length; i++)
		{
			_coordinatesMatrix[i] = new Vector3[_columns];

			for (int j = 0; j < _columns; j++)
			{
				_coordinatesMatrix[i][j] = new Vector3(
					i * _distanceBetweenCells,
					0,
					j * _distanceBetweenCells
				);
			}
		}
	}

	void getCellProgression()
	{
		int top = 0;
		int bottom = _coordinatesMatrix.Length - 1;
		int left = 0;
		int right = _coordinatesMatrix[0].Length - 1;
		int i = 0;

		while (i < _coordinatesInOrder.Length)
		{
			for (int j = left; j <= right && i < _coordinatesInOrder.Length; j++)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[top][j];
				i++;	
			}
			top++;

			for (int j = top; j <= bottom && i < _coordinatesInOrder.Length; j++)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[j][right];
				i++;	
			}
			right--;

			for (int j = right; j >= left && i < _coordinatesInOrder.Length; j--)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[bottom][j];
				i++;	
			}
			bottom--;

			for (int j = bottom; j >= top && i < _coordinatesInOrder.Length; j--)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[j][left];
				i++;	
			}	
			left++;
		}
	}
}
