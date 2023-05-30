using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject LinePrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void rotatedEvent(Transform t, Vector3 moveDirection)
    {
        GameObject line = Instantiate(LinePrefab, t.position, t.rotation);
        
    }
}
