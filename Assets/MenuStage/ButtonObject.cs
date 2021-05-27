using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : ObjectController
{
    public GameObject nextScene;
    public override void OnPointerClick() {
        nextScene.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
