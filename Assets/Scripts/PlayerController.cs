using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    private Rigidbody playerRB ;
    public bool isOnGround;
    public bool isGameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionSmoke;
    public ParticleSystem dirtSmoke;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1.0f);
            dirtSmoke.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround =true;
            if (!isGameOver)
            {
                dirtSmoke.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            dirtSmoke.Stop();
            explosionSmoke.Play();
            Debug.Log("GameOver!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
    }


}
