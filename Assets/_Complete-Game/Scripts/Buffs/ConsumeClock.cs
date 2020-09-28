using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class ConsumeClock : MonoBehaviour
    {
        GameObject player;
        EnemyManager[] enemyManagers;

        bool playerInRange = false;

        // Start is called before the first frame update
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            GameObject enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
            enemyManagers = enemyManager.GetComponents<EnemyManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInRange)
            {
                foreach (EnemyManager enemyManager in enemyManagers)
                {
                    enemyManager.SlowRateSpawn();
                }

                Destroy(gameObject);
            }
        }


    }
}
