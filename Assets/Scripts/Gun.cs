using UnityEngine;
using IBM.Watsson.Examples;
using TMPro;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public int maxBullets = 6;
    public int bullets;
    public TextMeshPro currentBullets;
    public GameObject muzzlePoint;
    public float fireRate = 2f;
    private float muzzleLifetime = 0.05f;
    private float muzzleTime = 0f;
    public Animator animator;
    private float nextTimeToFire = 0f;
    public string VoiceCommand = "reload";
    public float reloadTime = 2f;
    private float nextReload;
    private bool isReloading = false;
    public GameObject laser;
    public Material defaultMaterial;
    private bool hasFired = false;
    public GameObject muzzleFlash;
    public AudioSource audioSource = null;
    public AudioClip fireAudioClip;
    public AudioClip noAmmoAudioClip;
    public AudioClip reloadAudioClip;
    

    private void Awake() {
        bullets = maxBullets;
        currentBullets.SetText(bullets.ToString());
        VoiceCommandProcessor commandProcessor = GameObject.FindObjectOfType<VoiceCommandProcessor>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
    }

    // Update is called once per frame
    void Update()
    {
        if((Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0)) && (bullets > 0) && (Time.time >= nextTimeToFire)){
            nextTimeToFire = Time.time + 1f / fireRate;
            muzzleTime = Time.time + muzzleLifetime;
            if(animator.GetBool("isIdle")) {
                animator.Play("Armature|Fire");
            }
            hasFired = true;
            muzzleFlash.SetActive(true);
            playSound(fireAudioClip);
            Shoot();
            bullets -= 1;
        } else if ((Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0)) && (bullets == 0)) {
            playSound(noAmmoAudioClip);
        }
        if(isReloading) {
            if(Time.time >= nextReload) {
                Reload();
                isReloading = false;
                laser.SetActive(true);
            }
        }
        if(hasFired && (Time.time >= muzzleTime)) {
            hasFired = false;
            muzzleFlash.SetActive(false);
        }
        currentBullets.SetText(bullets.ToString());
    }


    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(muzzlePoint.transform.position, muzzlePoint.transform.forward, out hit, range)){
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.WasShoot();
                laser.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            }
        }
    }

    public void Reload(){
        bullets = maxBullets;
    }

    private void playSound(AudioClip sound) {
        if(audioSource != null)
            audioSource.PlayOneShot(sound, 0.2f);
    }

    public void OnVoiceCommandRecognized(string command){
        Debug.Log(command);
        if(command.ToLower().Contains(VoiceCommand.ToLower()) && bullets < maxBullets){
            animator.Play("Armature|Reload");
            if(!isReloading) {
                playSound(reloadAudioClip);
            }
            isReloading = true;
            nextReload = Time.time + reloadTime;
            laser.SetActive(false);
            //Reload();
        }
    }
}
