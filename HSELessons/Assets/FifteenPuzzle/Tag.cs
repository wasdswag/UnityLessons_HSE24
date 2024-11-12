using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : PuzzleElement
{
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color correctColor;

    private SpriteRenderer _look;
    private Socket currentSocket;

    private void Awake()
    {
        _look = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (IsAllowedToMove())
        {
            Vector3 freePos = PuzzleField.FreeSocket.Position();
            PuzzleField.FreeSocket = currentSocket;
            transform.position = freePos;
        }
    }

    private bool IsAllowedToMove()
    {
        int freeIndex = PuzzleField.FreeSocket.Index;
        bool isNeigbourByRow = Mathf.Abs(freeIndex - currentSocket.Index) == 1;
        bool isInSameRow = (currentSocket.Index - 1) / PuzzleField.GridSize == (freeIndex - 1) / PuzzleField.GridSize;
        bool isNeigbourByCol = Mathf.Abs(freeIndex - currentSocket.Index) == PuzzleField.GridSize;

        var result = (isNeigbourByRow && isInSameRow) || isNeigbourByCol;
        Debug.Log($"{result}: IS ALLOWED ");
        return result;
    }
    


    public void SetColor(bool isPlacedCorrect, Socket socket)
    {
        currentSocket = socket;
        _look.color = isPlacedCorrect ? correctColor : wrongColor;
    }


}
