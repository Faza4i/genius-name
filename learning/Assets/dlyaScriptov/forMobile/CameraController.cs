using UnityEngine;

public class CameraController : MonoBehaviour {
    public float mouseX;
    public float mouseY;

    [Header("Чувствительность мыши")]
    public float sensitivityMouse;

    public Transform player;
    public bool CanSensor;

    void Update () {
        if (CanSensor == true) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Moved) {
                    mouseX = touch.deltaPosition.x * sensitivityMouse*Time.deltaTime;
                    mouseY = touch.deltaPosition.y * sensitivityMouse*Time.deltaTime;
                    player.Rotate (mouseX * new Vector3 (0, 1, 0));
                    transform.Rotate (-mouseY * new Vector3 (1, 0, 0));
                }
                if (touch.phase == TouchPhase.Stationary) {
                    mouseX = 0;
                    mouseY = 0;
                }
            }
     
        }
    }
}
