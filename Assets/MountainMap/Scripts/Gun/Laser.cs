using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Material normal;
    public Material detected;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Body" || other.gameObject.name == "Head") {
            this.GetComponent<MeshRenderer>().material = detected; 
        }
    }

    void OnTriggerExit(Collider other) {
        this.GetComponent<MeshRenderer>().material = normal; 
    }
}
