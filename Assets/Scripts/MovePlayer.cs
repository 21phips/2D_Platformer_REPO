using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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