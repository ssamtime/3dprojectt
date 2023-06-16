using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //�̵��ӵ�
    private Vector3 moveDirection; //�̵�����

    [SerializeField]
    private float gravity = -9.81f; //�߷°��

    [SerializeField]
    private float jumpForce = 3.0f; // �پ������ �� ���

    

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //�÷��̾ ���� ��� �����ʴٸ� 
        //y�� �̵����⿡ gravity *Time.deltaTime �� �����ش�.
        if(characterController.isGrounded ==false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        //ī�޶� �ٶ󺸰� �ִ� ������ �������� ����Ű�� ���� �̵��� �� �ֵ��� ��
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
