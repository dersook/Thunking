using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour {
    public SavePoint savePoint;
    public GameObject player;

    private Status playerStatus;

    private void Awake() {
        playerStatus = player.GetComponent<Status>();
    }

    private void Start() {
        if (!Application.isEditor) {
            player.transform.position = savePoint.savePoint;
        }
    }

    private void Update() {
        if (!Application.isEditor && playerStatus.isDead) {
            Invoke("BackToSavePoint", 2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!Application.isEditor && other.gameObject.CompareTag("Player")) {
            print("save");
            savePoint.savePoint = other.gameObject.transform.position;
            print(savePoint.savePoint);
        }
    }

    private void BackToSavePoint() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
