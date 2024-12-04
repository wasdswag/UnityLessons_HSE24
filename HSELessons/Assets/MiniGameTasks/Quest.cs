using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour, IQuest
{
    [SerializeField] private QuestList list;
   
    public bool IsActive { get; set; }
    public bool IsComplete { get; set; }

 
    public void SetComplete()
    {
        IsComplete = true;
        list.SetNextQuest();
        Debug.Log($"{gameObject.name} quest is complete");
        Destroy(this);
        
    }
}
