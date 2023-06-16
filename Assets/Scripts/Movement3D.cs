using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //이동속도
    private Vector3 moveDirection; //이동방향

    [SerializeField]
    private float gravity = -9.81f; //중력계수

    [SerializeField]
    private float jumpForce = 3.0f; // 뛰어오르는 힘 계수

    

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //플레이어가 땅을 밟고 있지않다면 
        //y축 이동방향에 gravity *Time.deltaTime 을 더해준다.
        if(characterController.isGrounded ==false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        //카메라가 바라보고 있는 방향을 기준으로 방향키에 따라 이동할 수 있도록 함
        Vector3 moveDis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(moveDis.x, moveDirection.y, moveDis.z);
    }

    public void JumpTo()
    {
        if(characterController.isGrounded ==true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
