using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public Path path;
    public float threshold = 0.05f;
    private pathNode currentNode;

    private Vector3 getPosition() { return transform.position; }
    private Quaternion getRotation() { return transform.rotation; }

    private void setPosition(Vector3 pos) { transform.position = pos; }
    private void setRotation(Quaternion rot) { transform.rotation = rot; }

    public void setFollow(bool value) { this.followTrigger = value; }

    public bool followTrigger;

    private float stepSpeed(float multiplier) {
        return Time.deltaTime * multiplier;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentNode = path.getStartingNode();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentNode != null && followTrigger == true) 
        {
            setRotation(Quaternion.RotateTowards(
                            this.getRotation(),                              
                            currentNode.getRotation(), 
                            stepSpeed(currentNode.getRotationSpeed())
            ));
            setPosition(Vector3.MoveTowards(
                            this.getPosition(),
                            currentNode.getPosition(),
                            stepSpeed(currentNode.getSpeed())
            ));
            if(Vector3.Distance(this.getPosition(), currentNode.getPosition()) < threshold)
            {
                currentNode = currentNode.getNextNode();
            }
        }
    }
}
