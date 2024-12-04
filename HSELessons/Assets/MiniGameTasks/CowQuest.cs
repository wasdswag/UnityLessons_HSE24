using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CowQuest : Quest
{
    
    private void Update()
    {
        if (!IsActive) return;
        if (Input.GetMouseButtonDown(0) && !IsComplete)
        {
            SetComplete();
        }
    }
}
