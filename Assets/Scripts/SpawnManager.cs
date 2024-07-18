using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerController;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void SpawnObstacle()
    {
        if (playerController.isGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
