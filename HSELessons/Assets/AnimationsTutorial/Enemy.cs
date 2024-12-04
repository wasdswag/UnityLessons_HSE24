
using UnityEngine;
using Lesson1;

    public class Enemy : MonoBehaviour
    {
        public Player player;
        void Start()
        {
            Debug.Log(player.PlayerName);
        }

    }
