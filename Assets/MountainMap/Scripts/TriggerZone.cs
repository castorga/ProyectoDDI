using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public PathFollow[] carts;
    private bool hasEntered;
    // Start is called before the first frame update
/*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "playercart") {
            foreach(PathFollow cart in carts) {
            cart.setFollow(true);
            }
            Destroy(this.gameObject);
        }
    }
}
