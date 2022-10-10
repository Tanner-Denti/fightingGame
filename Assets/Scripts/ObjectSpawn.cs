using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectSpawn : MonoBehaviour
{
    public GameObject testPrefab;
    int i = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            // GameObject instantiatedObject = Instantiate(testPrefab, new Vector3(i*1.0f, 2.0f, 0f), Quaternion.Euler(0f, i*30f, 0f));
            GameObject instantiatedObject = Instantiate(testPrefab, new Vector3(i*1.0f, 2.0f, 0f));
            instantiatedObject.name = "Sphere " + i.ToString();
            i++;
        }
    }
}