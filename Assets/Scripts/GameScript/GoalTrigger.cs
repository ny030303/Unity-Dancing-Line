using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            Debug.Log("Goal!");
            GameManager.instance.GoalEvent();
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
