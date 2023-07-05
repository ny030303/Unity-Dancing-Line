using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    // Start is called before the first frame update
    LoadingSceneManager loadingSceneManager;
    void Start()
    {
        loadingSceneManager = FindObjectOfType<LoadingSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit = new RaycastHit();

                if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인

                {

                    //있으면 오브젝트를 저장한다.
                    print(hit.collider.name);
                    if (hit.collider.name == "Stage01 Floor") loadingSceneManager.LoadScene("Scene01");
                    if (hit.collider.name == "Stage02 Floor") loadingSceneManager.LoadScene("Scene02");
                    //if (hit.collider.name == "Stage01 Floor") SceneManager.LoadScene("Scene01");
                    //if (hit.collider.name == "Stage02 Floor") SceneManager.LoadScene("Scene02");

                }
            }
            
        }
    }
}
