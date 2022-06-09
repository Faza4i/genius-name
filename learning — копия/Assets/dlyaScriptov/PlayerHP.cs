using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
	[Header("Хп Игрока")]
	public int playerHp;
	[Header("Бар здоровья игрока")]
	public Text healthBar;

	void Update () {
		healthBar.text = playerHp + "HP";
		if (playerHp <= 0) {
			healthBar.text = "0";
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
