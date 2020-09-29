using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class BuffManager : MonoBehaviour
    {
        public GameObject buff;
        public float spawnTime;
        public Transform[] spawnPoints;

        GameObject player;
        PlayerHealth playerHealth;

        GameObject currentBuff;

        // Start is called before the first frame update
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        void Start()
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }

        //// Update is called once per frame
        //void Update()
        //{
        
        //}

        void Spawn()
        {
            // If the player has no health left...
            if (playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // If currentBuff exists exit the function
            if (currentBuff)
            {
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            currentBuff = Instantiate(buff, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
