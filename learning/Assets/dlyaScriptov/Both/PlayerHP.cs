using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
	[Header("Хп Игрока")]
	public int playerHp;
	[Header("Бар здоровья игрока")]
	public Text healthBar;
	[Header("Панель если умер нахуй")]
	public GameObject panelRestart;
	[Header("Мобилки или Компы(1 или 2)")]
	public int ChoosePlatform;
	[Header("Обьекты")]
	public GameObject Cam;
	public GameObject Controll;
	public GameObject Gun;
	//Скрипты на мобилки(1)
	private CCforMObible offControllMobile;
	private CameraController offcamMobile;
	private Weapon offShootingMobile;
	//Скрипты на ПК(2)
	private CharacterControl offControllPC;
	private CameraControllerPC offcamPC;
	private WeaponPC offShootingPC;

	void Start(){
		//вместо ковычек и того что в них назвние нужных скриптов
		if (ChoosePlatform == 1) {
			offControllMobile = Controll.GetComponent<CCforMObible>();
			offcamMobile = Cam.GetComponent<CameraController>();
			offShootingMobile = Gun.GetComponent<Weapon>();
		}else if (ChoosePlatform == 2) {
			offControllPC = Controll.GetComponent<CharacterControl>();
			offcamPC = Cam.GetComponent<CameraControllerPC>();
			offShootingPC = Gun.GetComponent<WeaponPC>();
		}
	}

	void Update () {
		healthBar.text = playerHp + "HP";
		if (playerHp <= 0) {
			healthBar.text = "0";
			panelRestart.SetActive(true);
			if (ChoosePlatform == 1) {
				offShootingMobile.enabled = false;
				offControllMobile.enabled = false;
				offcamMobile.enabled = false;
			} else if (ChoosePlatform == 2) {
				offShootingPC.enabled = false;
				offControllPC.enabled = false;
				offcamPC.enabled = false;
			}
			Cursor.lockState = CursorLockMode.Confined;
		}
	}
}