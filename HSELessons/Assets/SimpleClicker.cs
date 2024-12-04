using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleClicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;

    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            _score = PlayerPrefs.GetInt("Score");
            score.SetText(_score.ToString());
        }

    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _score++;
            score.SetText(_score.ToString());
            PlayerPrefs.SetInt("Score", _score);
        }
    }
}
