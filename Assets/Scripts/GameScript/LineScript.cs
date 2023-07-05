using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineScript : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.right; // 플레이어 이동 방향 (초기값 x축)
    bool isRunning = true;
    PlayerController pController;
    // Start is called before the first frame update
    void Start()
    {

        pController = GameManager.instance.playerController;
        moveDirection = pController.moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == true)
        {
            if(pController.moveDirection != moveDirection) disabled();
            else if(pController.isRunning)
            {
                transform.Translate(moveDirection * 5f * Time.deltaTime);
                setScale();
            }
        }
    }

    private void setScale()
    {
        float addX = 10f * Time.deltaTime;
        if (moveDirection == Vector3.right) transform.localScale += new Vector3(addX, 0f, 0f);
        else transform.localScale += new Vector3(0f, 0f, addX);
    }

    public void disabled()
    {
        isRunning = !isRunning;
        Invoke("deleteObj", 3f);
    }

    void deleteObj()
    {
        if (GameManager.instance.isGameover == false)
        {
            Destroy(gameObject);
        }
    }

}
