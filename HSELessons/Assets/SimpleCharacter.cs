using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleCharacter : MonoBehaviour
{

    [System.Serializable] public class CharacterSavedData
    {
        public Color Color;
        public Vector3 Position;

        public CharacterSavedData(Color c, Vector3 p)
        {
            Color = c;
            Position = p;
        }
    }
    


    [SerializeField] private CharacterSavedData data; 

    [SerializeField] private float speed = 10f;
    
    private SpriteRenderer _look;

    private const string SAVE = "SavedData";
    
    
    private void Start()
    {
        _look = GetComponent<SpriteRenderer>();
        LoadSavedData();
    }

    private void LoadSavedData()
    {
        if (PlayerPrefs.HasKey(SAVE))
        {
            data = JsonUtility.FromJson<CharacterSavedData>(PlayerPrefs.GetString(SAVE));
           
            transform.position = data.Position;
            _look.color = data.Color;
        }
    }

    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _look.color = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveStats();
        }
    }

    private void SaveStats()
    {
        data = new CharacterSavedData(_look.color, transform.position);
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE, jsonData);

    }

    private void OnDestroy()
    {
        SaveStats();
    }
}


