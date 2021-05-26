using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathNode : MonoBehaviour
{
    private pathNode previousNode = null;
    private pathNode nextNode = null;
    public float speed = 4.0f;
    public float rotationSpeed = 50;

    void Start() {
        int index = transform.GetSiblingIndex();
        if(index == 0) {
            previousNode = null;
        } else {
            previousNode = transform.parent.GetChild(index - 1).GetComponent<pathNode>();
        }
        if(index >= (transform.parent.childCount - 1)) {
            nextNode = null;
        } else {
            nextNode = transform.parent.GetChild(index + 1).GetComponent<pathNode>();
        }
    }

    public float getSpeed() {
        return speed;
    }

    public float getRotationSpeed() {
        return rotationSpeed;
    }

    public pathNode getPreviousNode() {
        return previousNode;
    }

    public pathNode getNextNode() {
        return nextNode;
    }

    public Vector3 getPosition() {
        return transform.position;
    }

    public Quaternion getRotation() {
        return transform.rotation;
    }
}
