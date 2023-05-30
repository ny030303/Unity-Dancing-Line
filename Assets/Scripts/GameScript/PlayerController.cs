using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // 플레이어 이동 속도

    public Vector3 moveDirection = Vector3.right; // 플레이어 이동 방향 (초기값 x축)
    public bool isRunning = false; // 플레이어가 가는 중인지 여부

    Collider[] colliders;

    public void Awake()
    {

        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders)
        {
            if (c.name == "Player") continue;
            c.gameObject.GetComponent<Renderer>().enabled = false;
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
            rb.constraints = (RigidbodyConstraints)126; // 126으로 하면 모든게 잠김
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
            rb.constraints = (RigidbodyConstraints)0; // 모든게 해제
        }
    }

    public bool getIsRunning() { return isRunning; }
    public void setIsRunning()  {  isRunning = !isRunning; }
    public Vector3 getMoveDirection() {return moveDirection;}
    public Transform getTransform() {  return transform; }

    // 이동 방향을 90도 회전시킵니다.
    public void setRotate()
    {
        if (moveDirection == Vector3.right) moveDirection = Vector3.forward;
        else moveDirection = Vector3.right;
    }

   
}