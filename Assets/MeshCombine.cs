using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshFilter))]

[RequireComponent(typeof(MeshRenderer))]



public class MeshCombine : MonoBehaviour
{



    public Material[] materials;



    void Start()

    {

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        int leng = renderer.materials.Length;
        renderer.materials = materials;

        int i = 0;
        while (i < meshFilters.Length)
        {

            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //meshFilters[i].gameObject.active = false;
            i++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.active = true;

        this.gameObject.transform.localPosition = new Vector3 (2f, -7.4f, 3f);
        //this.gameObject.transform.localEulerAngles = new Vector3(0, 90);

    }

}