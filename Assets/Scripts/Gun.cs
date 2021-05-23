using UnityEngine;
using IBM.Watsson.Examples;
using TMPro;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public int maxBullets = 6;
    public int bullets;
    public TextMeshPro currentBullets;
    public Camera fpsCam;
    public float fireRate = 2f;

    private float nextTimeToFire = 0f;

    public string VoiceCommand = "reload";

    private void Awake() {
        bullets = maxBullets;
        currentBullets.SetText(bullets.ToString());

        VoiceCommandProcessor commandProcessor = GameObject.FindObjectOfType<VoiceCommandProcessor>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
    }

    // Update is called once per frame
    void Update()
    {
        if(Google.XR.Cardboard.Api.IsTriggerPressed && (bullets > 0) && (Time.time >= nextTimeToFire)){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            bullets -= 1;
        }
        currentBullets.SetText(bullets.ToString());
    }

    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.WasShoot();
            }
        }
    }

    void Reload(){
        bullets = maxBullets;
    }

    public void OnVoiceCommandRecognized(string command){
        Debug.Log(command);
        if(command.ToLower().Contains(VoiceCommand.ToLower()) && bullets < maxBullets){
            Reload();
        }
    }
}
