using UnityEngine;

namespace CompleteProject
{
    public class ConsumeCookie : MonoBehaviour
    {
        GameObject player;
        PlayerShooting playerShooting;

        bool playerInRange = false;

        // Start is called before the first frame update
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerShooting = player.transform.GetChild(2).gameObject.GetComponent<PlayerShooting>();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }

        void OnTriggerExit(Collider other)
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
                playerShooting.CookieBuff();

                Destroy(gameObject);
            }
        }
    }
}