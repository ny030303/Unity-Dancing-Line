using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // �÷��̾� �̵� �ӵ�

    public Vector3 moveDirection = Vector3.right; // �÷��̾� �̵� ���� (�ʱⰪ x��)
    public bool isRunning = false; // �÷��̾ ���� ������ ����

    Collider[] colliders;

    public void Awake()
    {

        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders)
        {
            if (c.name == "Player") continue;
            c.gameObject.GetComponent<Renderer>().enabled = false;
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
            rb.constraints = (RigidbodyConstraints)126; // 126���� �ϸ� ���� ���
        }
    }

    private void Update()
    {
        if (isRunning == true)
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        
    }

    public void Die()
    {
        isRunning = false;
        GetComponent<Renderer>().enabled = false;
        foreach (Collider c in colliders)
        {
            if (c.name == "Player") continue;
            c.gameObject.GetComponent<Renderer>().enabled = true;
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
            rb.constraints = (RigidbodyConstraints)0; // ���� ����
        }
    }

    public bool getIsRunning() { return isRunning; }
    public void setIsRunning()  {  isRunning = !isRunning; }
    public Vector3 getMoveDirection() {return moveDirection;}
    public Transform getTransform() {  return transform; }

    // �̵� ������ 90�� ȸ����ŵ�ϴ�.
    public void setRotate()
    {
        if (moveDirection == Vector3.right) moveDirection = Vector3.forward;
        else moveDirection = Vector3.right;
    }

   
}