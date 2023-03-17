using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float jumpForce = 10f;
    public string currentColor;
    public float currentPos;
    
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    
    string x;

    public static bool IsDead = false;
    public static bool Won = false;
    public static bool IsPaused = false;

    public GameObject DeathMenuUI;
    public GameObject WinMenuUI;
    public GameObject PauseMenuUI;

    private void Start()
    {
        WinMenuUI.SetActive(false);
        IsDead = false;
        rb.gravityScale = 0f;
        SetRandomColor();
        x = currentColor;
    }
    void Update() 
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(1)) 
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * jumpForce;
            rb.gravityScale = 3f;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanger")
        {
            
            while(x == currentColor)
            {
                SetRandomColor();
            }
            x = currentColor;
            
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag != currentColor && collision.tag != "Win" && collision.tag != "Floor" && collision.tag != "Star")
        {
            IsDead = true;
            Died();
        }
        if (collision.tag == "Win")
        {
            Won = true;
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if(collision.tag == "Floor")
        {
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = new Vector2(transform.position.x, -3.449f);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);


        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }


    void Died()
    {
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
