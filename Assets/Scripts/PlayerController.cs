using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float speed = 1.0f; // add SerializeField - Encapsulation
    private float zBound = 7;
    private float zBoundMin = -2;
    private Rigidbody playerRb;
    private int score;
   [SerializeField] private TextMeshProUGUI scoreText; // add SerializeField - Encapsulation
    [SerializeField] private TextMeshProUGUI gameOverText; // add SerializeField - Encapsulation
     [SerializeField] private Button restartButton; // add SerializeField - Encapsulation
    public static PlayerController Instance { get; private set; } //add getter and private setter - Encapsulation
    public AudioClip pickUpSound;
   public AudioClip badUpSound; 
  public AudioClip deathSound;  
    // Start is called before the first frame update
    void Start()
    {
         
       UpdateScore(0); //add method - Abstraction;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //add method - Abstraction;
        ConstrainPlayerPosition(); //add method - Abstraction;
        
    }
   // Moves the player based on arrow key input
    void MovePlayer()
    {
        float horrizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horrizontalInput);
    }
    // Prevent the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition ()
    {
        if (transform.position.z < zBoundMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundMin);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
    //Collision with Enemy
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(gameObject);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);// add soundEffect when game over
       
        }
    }
    //Collision with PowerUp
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
        
            UpdateScore(1);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);// add sound effect for pick 
        } else
        {
            if(other.gameObject.CompareTag("BadUp"))
            {
             UpdateScore2(1);
             Destroy(other.gameObject);
             AudioSource.PlayClipAtPoint(badUpSound, transform.position); // add sound effect for pick up
            }
        }
    }
    // Method for calculate Score and add component - Abstraction
    public  void UpdateScore(int scoreToAdd)
    {
        playerRb = GetComponent <Rigidbody>();
        score += scoreToAdd;

        scoreText.text = "Score: " + score;
    }
    public void UpdateScore2(int scoreToAdd)
  {
     playerRb = GetComponent <Rigidbody>();
        score -= scoreToAdd;

        scoreText.text = "Score: " + score;
  }
  
  
}
