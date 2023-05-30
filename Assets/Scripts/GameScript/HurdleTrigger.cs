using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurdleTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            Debug.Log("Die");
            GameManager.instance.GameOverEvent();
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            //PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트 가져오는 데 성공했다면
            //if (playercontroller != null)
            //{
            //    playercontroller.die();
            //}

        }
    }
}
