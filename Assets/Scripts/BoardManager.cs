using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	private Vector3[][] _coordinatesMatrix;
	private Vector3[] _coordinatesInOrder;
	private int _rows = 7;
	private int _columns = 6;
	private int _cellNumber = 40;
	private int _distanceBetweenCells = 2;

    // Start is called before the first frame update
    void Awake()
    {
		GenerateBoardMatrix();

		GetCellsOrder();
    }

	public Vector3[] GetCoordinates()
	{
		return _coordinatesInOrder;
	}

	void GetCellsOrder()
	{
		_coordinatesInOrder = new Vector3[_cellNumber];

		int top = 0;
		int left = 0;
		int bottom = _rows - 1;
		int right = _columns - 1;
		
		int i = 0;
		while (i < _cellNumber)
		{
			for (int j = left; j <= right && i < _cellNumber; j++)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[top][j];
			   i++;	
			}
			top++;

			for (int j = top; j <= bottom && i < _cellNumber; j++)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[j][right];
			   i++;	
			}
			right--;

			for (int j = right; j >= left && i < _cellNumber; j--)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[bottom][j];
			   i++;	
			}
			bottom--;

			for (int j = bottom; j >= top && i < _cellNumber; j--)
			{
				_coordinatesInOrder[i] = _coordinatesMatrix[j][left];
			   i++;	
			}
			left++;
		}
	}

	void GenerateBoardMatrix()
	{
		_coordinatesMatrix = new Vector3[_rows][];

		for (int x = 0; x < _rows; x++)
		{
			_coordinatesMatrix[x] = new Vector3[_columns];

			for (int z = 0; z < _columns; z++)
			{
				_coordinatesMatrix[x][z] = new Vector3(
					x * _distanceBetweenCells, 
					0, 
					z * _distanceBetweenCells
				);
			}
		}
	}
}
