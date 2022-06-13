using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
	[Header("Хп Игрока")]
	public int playerHp;
	[Header("Бар здоровья игрока")]
	public Text healthBar;
	public GameObject panelRestart;
	public Weapon offShooting;
	public CharacterControl offControll;
	public CameraController offcam;



	void Update () {
		healthBar.text = playerHp + "HP";
		if (playerHp <= 0) {
			healthBar.text = "0";
			panelRestart.SetActive(true);
			offShooting.enabled = false;
			offControll.enabled = false;
			offcam.enabled = false;
			Cursor.lockState = CursorLockMode.Confined;
		}
	}
}