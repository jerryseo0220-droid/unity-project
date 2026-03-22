using UnityEngine;
using UnityEngine.InputSystem;
public class player : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    
    public void OnMove(InputValue value)
    {
      moveInput = value.Get<Vector2>();  
    }

  
    void Update()
    {
       if(moveInput.x > 0) 
       {
           transform.localScale = new Vector3(1,1,1);
       }
       else if(moveInput.x < 0 )
       { 
        transform.localScale = new Vector3(-1,1,1);
       }
       transform.Translate(new Vector3(moveInput.x,0,0) * moveSpeed * Time.deltaTime);
    }
   }
  