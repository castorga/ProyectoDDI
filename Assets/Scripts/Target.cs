using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //targetYype
    // 1=head
    // 2=body
    // 3=inocent
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int targetType = 1;
    public List<GameObject> disableAfterShot = new List<GameObject>();
    public void WasShoot(){
        switch(targetType){
            case 1: PlayerScore.score += 5;
                break;
            case 2: PlayerScore.score += 1;
                break;
            case 3: PlayerScore.score -= 5;
                break;
        }
        audioSource.PlayOneShot(audioClip, 0.5f);
        //Destroy(transform.parent.gameObject);
        foreach(GameObject obj in disableAfterShot) {
            obj.SetActive(false);
        }
    }
}
