using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }
    public void OnMove(InputValue value)
    {
      moveInput = value.Get<Vector2>();  
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
  
    void Update()
   {

   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name =="Death")
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("PlayScene_" + collision.name);
        }
    
       if(moveInput.x > 0) 
       {
           transform.localScale = new Vector3(1,1,1);
       }
       else if(moveInput.x < 0 )
       { 
        transform.localScale = new Vector3(-1,1,1);
       }
       transform.Translate(new Vector3(moveInput.x,0,0) * moveSpeed * Time.deltaTime);
    
   if(moveInput.magnitude > 0)  {
       myAnimator.SetBool("move",true);
   }
   else {
       myAnimator.SetBool("move",false);
   }
   transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);
    }
  }
  
  