using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

        bool slowed = false;
        public float slowMultiplier = 2f;

        float timer = 0.0f;

        public float slowDuration;
        float slowTimer = 0.0f;

        void Start ()
        {
            slowDuration = spawnTime * slowMultiplier * 3;
        }

        void Update()
        {
            timer += Time.deltaTime;
            
            if (slowed)
            {
                slowTimer += Time.deltaTime;
                if (slowTimer > slowDuration)
                {
                    NormalRateSpawn();
                }

                if (timer >= spawnTime * slowMultiplier)
                {
                    Spawn();
                    timer = 0.0f;
                }
            }
            else
            {
                if (timer >= spawnTime)
                {
                    Spawn();
                    timer = 0.0f;
                }
            }
        }

        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            if (slowed)
            {
                SetEnemiesSpeed(0.6f);
            }
            else
            {
                SetEnemiesSpeed(2.0f);
            }
        }

        public void SlowRateSpawn()
        {
            slowed = true;
            slowTimer = 0.0f;

            SetEnemiesSpeed(0.6f);
        }

        public void NormalRateSpawn()
        {
            slowed = false;
            slowTimer = 0.0f;

            SetEnemiesSpeed(2f);
        }

        private void SetEnemiesSpeed(float speed)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed;
            }
        }
    }
}