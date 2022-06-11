using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    //public Text Score;
    //public ScoreManager sm;

    //private void Start()
    //{
    //    score.text = ("пока что оно нахуй не надо") + sm.score.ToSring();
    //}

        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
