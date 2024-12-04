using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolleQuest : Quest
{
    private int hitCount = 0;
    private void Update()
    {
        if (!IsActive) return;
        
        if (Input.GetKeyDown(KeyCode.Space) && !IsComplete)
        {
            hitCount++;
            if(hitCount >= 3)
                SetComplete();
        }
    }
}
