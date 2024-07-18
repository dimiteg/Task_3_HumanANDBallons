using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    public float leftBound = -15f;
    private PlayerController playerController;
    

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
