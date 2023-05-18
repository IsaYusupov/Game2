
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 directione;
    [SerializeField] private int _speed;
    private int lineToMove = 1;
    public int lineDistance = 4;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject losePanel;
    
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Time.timeScale = 1; 
    }

    

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;
        transform.position = targetPosition;
        if (SwipeController.swipeUp)
        {
            if (_controller.isGrounded)
            {
                Jump();
            }

            



        }
        if (transform.position == targetPosition) 
        {
            return;
        }
            

        Vector3 diff = targetPosition - transform.position;
        
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        
            
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            _controller.Move(moveDir);
        }
        else
        {
            _controller.Move(diff);
        }
    }

    private void Jump()
    {
        directione.y = jumpForce;
    }
        


    void FixedUpdate()
    {
        directione.z = _speed;
      _controller.Move(directione * Time.fixedDeltaTime);
      directione.y += gravity * Time.fixedDeltaTime;


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            
        }
    }
    
   
}

    
