 using UnityEngine;
 using System.Collections;
 
 public class Rotate : MonoBehaviour {
     public float horizontalSpeed = 1.0F;
     public float verticalSpeed = 1.0F;
    //public Camera camera;
    public void Start() {

    }

     void Update() {
         Cursor.lockState = CursorLockMode.Locked;
         float h = horizontalSpeed * Input.GetAxis("Mouse X");
         float v = verticalSpeed * -Input.GetAxis("Mouse Y");
        // Event currentEvent = Event.current;
        // Debug.Log(currentEvent);
         //Vector3 point = new Vector3();

        // Vector2 mousePos = new Vector2();
        //mousePos.x = currentEvent.mousePosition.x;
        //mousePos.y = camera.pixelHeight - currentEvent.mousePosition.y;
         transform.Rotate(v, h, 0);

        //point = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));

         //transform.LookAt(point);
         if(Input.GetMouseButtonDown(1)) {
             transform.localRotation = Quaternion.identity;
         }
     }

    private void LateUpdate() {
         Input.ResetInputAxes();
     }
 }