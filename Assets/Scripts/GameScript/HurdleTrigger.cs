using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurdleTrigger : MonoBehaviour
{


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
