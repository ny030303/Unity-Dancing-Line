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
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            Debug.Log("Die");
            GameManager.instance.GameOverEvent();
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            //PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ �������� �� �����ߴٸ�
            //if (playercontroller != null)
            //{
            //    playercontroller.die();
            //}

        }
    }
}
