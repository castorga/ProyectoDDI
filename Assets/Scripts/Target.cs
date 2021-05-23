using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //targetYype
    // 1=head
    // 2=body
    // 3=inocent
    public int targetType = 1;
    public void WasShoot(){
        switch(targetType){
            case 1: PlayerScore.score += 5;
                break;
            case 2: PlayerScore.score += 1;
                break;
            case 3: PlayerScore.score -= 5;
                break;
        }
        Destroy(transform.parent.gameObject);
    }
}
