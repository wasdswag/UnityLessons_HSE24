using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using TMPro;

public class PuzzleElement : MonoBehaviour
{

    public int Index { get; private set; }
    [SerializeField] private TextMeshProUGUI indexDisplay;
    

    public void SetIndex(int index)
    {
        indexDisplay.SetText(index.ToString());
        Index = index;

    }
    
   
}
