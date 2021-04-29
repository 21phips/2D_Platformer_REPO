using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    private int count;
    bool isAlive = true;
    int currentLevel;
    public GameObject winTextObject;
    
     
  
    
    // Start is called before the first frame update
    void Start()
    {
        //isAlive = true;
        count = 0;
        SetCountText();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        winTextObject.SetActive(false);
    }


    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject. tag == "Bad")
        {
            //die
            isAlive = false;
            Destroy(gameObject);
            //reset
            SceneManager.LoadScene(currentLevel);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
              
        }
    }
 


    void Update()
    {
        if (isAlive)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

        }

    }


    void FixedUpdate()
    {
        //move our character
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
          
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); 
        if(count >= 40)
        {
            winTextObject.SetActive(true);
            SceneManager.LoadScene(currentLevel + 1);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
      
    }

}