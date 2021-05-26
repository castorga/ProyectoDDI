using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public pathNode startingNode = null;

    public pathNode getStartingNode() {
        return startingNode;
    }
    // Start is called before the first frame update
    /*
    void Start()
    {
        Transform[] allchildren = this.transform.GetComponentsInChildren<Transform>();
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            //printTransform(g.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void printTransform(Transform transform) 
    {
        Debug.Log("x: " + transform.position.x + ", y: " + transform.position.y + ", z: " + transform.position.z);
    }*/
}
