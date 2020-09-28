using UnityEngine;

namespace CompleteProject
{
    public class ConsumeBiberon : MonoBehaviour
    {
        public int bonusHealth = 25;

        GameObject player;
        PlayerHealth playerHealth;

        bool playerInRange = false;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerHealth = player.GetComponent<PlayerHealth>();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is NOT in range.
                playerInRange = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInRange && playerHealth.currentHealth < playerHealth.startingHealth)
            {
                playerHealth.IncreaseHealth(bonusHealth);
                Destroy(gameObject);
            }
        }
    }
}
