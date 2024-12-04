using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenQuest : Quest
{
    private List<Chick> chicks = new List<Chick>(); 
    
    private void Update()
    {
        if (!IsActive) return;
        
        if (Input.GetKeyDown(KeyCode.A) && !IsComplete)
        {
            AddChick(new Chick());
        }
        
    }

    public void AddChick(Chick chick)
    {
        chicks.Add(chick);
        if(chicks.Count >= 5)
            SetComplete();
    }
    
}

public class Chick
{
    
} 
