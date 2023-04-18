using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//EventSystem.current.IsPointerOverGameObject() [for that]
using UnityEngine.EventSystems;
// using UnityEngine.
public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrenght;
    public AudioSource buttonSound;
    public AudioSource jumpSound;
    public AudioSource scoreSound;
    public AudioSource endSound;
    public AudioSource buttonOverSound;
    public AudioSource yeahBoi;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb.velocity = Vector2.up*flapStrenght;
    }

    // Update is called once per frame
    void Update()
    {
        // High Score 
       highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString(); 
    //    if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !GameManager.instance.GameEnded &&!isPaused)
    //     {
    //         MousePress();
    //     }
    }
    // public void NextScene() {
    //     SceneManager.LoadScene("Game");
    // }


    public void MousePress()
    {
        if(!GameManager.instance.GameEnded &&!isPaused)
        {

        Time.timeScale = 1f;
        jumpSound.Play();
        rb.velocity = Vector2.up*flapStrenght;
       // GameManager.instance.GameStart();  
        }
    }

    public void StartButton()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        rb.velocity = Vector2.up*flapStrenght;
       // GameManager.instance.GameStart();  
    } 

    public void TogglePause()
    {
        
        buttonSound.Play();
        GameManager.instance.GameEnded = true;
        Time.timeScale = 0f;
        isPaused = true;
    
        
        // if(isPaused==false)
        // {
        //     buttonSound.Play();
        //     isPaused = true;
        //     Time.timeScale = 0f;
        // }
        // else
        // {
        //     buttonSound.Play();
        //     isPaused =false;
        //     Time.timeScale = 0f;
        // }
        
       // GameManager.instance.GameStart();  
    } 
    public void QuitGame()
    {
        Application.Quit();
        buttonOverSound.Play();
        Debug.Log("Quitting");
    }

    public void TogglePlay()
    {
         if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            GameManager.instance.GameEnded = false;
            buttonSound.Play();
            isPaused = false;
        }
        // Time.timeScale = 1f;
       
    }
   private void OnTriggerExit2D(Collider2D collision) 
   {
         //Debug.Log("Collision Exited");
        if(collision.gameObject.tag== "ScoreCheck")
        {
           // Debug.Log("Collded with scoreCheck");
            scoreSound.Play();
            score++;
            scoreText.text= score.ToString();
        }
         // Upgrading Health
        if(collision.gameObject.tag=="HealthUpgrade")
        {
            Debug.Log("HealthUpgrade");
            HeartSystem.instance.IncreaseHealth(1);
            yeahBoi.Play();
           Destroy (GameObject.FindWithTag("HealthUpgrade"));

        }
    }
    // High Score 1
    private void ValidateScore()
    {
        
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
    public void  ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision Enter");
        endSound.Play();
        ValidateScore();
        //TakeDamage(int d);
        if(other.gameObject.tag=="ground" || other.gameObject.tag =="pipe")
        {
            HeartSystem.instance.DecreaseHealth(1);
        }
    }
    // private void OnTriggerEnter2D(Collider2D other) {
       
    // }
    

}
