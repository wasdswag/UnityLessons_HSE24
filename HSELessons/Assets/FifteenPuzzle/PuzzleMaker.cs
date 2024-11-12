using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleMaker : MonoBehaviour
{
    [SerializeField] private Socket socketPrefab;
    [SerializeField] private Tag tagPrefab;
    [SerializeField] private int gridSize = 3;
    [SerializeField] private float gap = 1.2f;

    private int [] numbers; // 1,2,3,4,5...
    private List<int> numbersBuffer = new List<int>(); // 
    [SerializeField] private List<int> randomNumbers = new List<int>();


    private int GetShuffleNumber()
    {
        if (numbersBuffer.Count == 0)
            numbersBuffer = new List<int>(numbers);
        
        int rnd = Random.Range(0, numbersBuffer.Count);
        int result = numbersBuffer[rnd];
        numbersBuffer.Remove(result);
        return result;
    }

    private void SetShuffleList()
    {
        randomNumbers.Clear();
        for (int i = 0; i < (gridSize * gridSize) - 1; i++)
            randomNumbers.Add(GetShuffleNumber());
    }
    
    
    private void Start()
    {
        PuzzleField.GridSize = gridSize;
        numbers = Enumerable.Range(1, (gridSize * gridSize) - 1).ToArray();
        SetShuffleList();
        
        while (!IsSolvable())
            SetShuffleList();
        
        
        int index = 1;
        float offset = gap * (gridSize - 1) / 2;

        for (int y = gridSize; y > 0; y--)
        {
            for (int x = 0; x < gridSize; x++)
            {
                Vector3 spawnPosition = new Vector3(x - offset, y - offset, 0) * gap;
                Socket socket = Instantiate(socketPrefab, spawnPosition, Quaternion.identity);
                socket.SetIndex(index);
                socket.SetFree(index == gridSize*gridSize);

                if (index < gridSize * gridSize)
                {
                    Tag tag = Instantiate(tagPrefab, spawnPosition, Quaternion.identity);
                    int rnd = randomNumbers[index-1];
                    tag.SetIndex(rnd);
                }
                index++;
            }
        }
    }

    
    private bool IsSolvable()
    {
        int summ = 0;
        List<int> temp = new List<int>(randomNumbers);
        for (int i = 0; i < randomNumbers.Count; i++)
        {
            foreach (var n in temp)
                if (randomNumbers[i] > n) 
                    summ++;

            temp.Remove(numbers[i]);
        }

        bool result = summ % 2 == 0;
        
        Debug.Log($"{result} SOLVABLE {summ}");
        return result;
    }
    
    

}
