using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : PuzzleElement
{
    [field:SerializeField] public bool IsFree { get; private set; }

    public Vector3 Position () => transform.position; 

    public void SetFree(bool value)
    {
        IsFree = value;
        if (IsFree) 
            PuzzleField.FreeSocket = this;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Tag tag))
        {
            tag.SetColor(tag.Index == Index, this);
        }
    }
}
