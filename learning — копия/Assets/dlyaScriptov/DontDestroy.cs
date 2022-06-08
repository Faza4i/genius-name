using UnityEngine;

public class DontDestroy : MonoBehaviour {
    [Header("Text")]
    [SerializeField]private string createdTag;

    private void Awake(){
        GameObject obj = GameObject.FindWithTag (this.createdTag);
        if (obj != null) {
            Destroy (this.gameObject);
        } else {
            this.gameObject.tag = createdTag;
            DontDestroyOnLoad (this.gameObject);
        }
    }
}