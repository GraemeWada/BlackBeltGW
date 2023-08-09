using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note: MonoBehaviour {
  public GameObject noteText;
  public bool inCollision;
  public bool reading;
  public GameObject PM;
  public AudioSource paperRustle;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player") {
      inCollision = true;
    }
  }
  private void OnTriggerExit2D() {
    inCollision = false;
  }
  void Update() {
    if (Input.GetKeyDown(KeyCode.Return) && inCollision) {
      paperRustle.Play();
      Time.timeScale = 0;
      noteText.SetActive(true);
      reading = true;
      PM.SetActive(false);
    }
    if (reading && Input.GetKeyDown(KeyCode.Tab)) {
      Time.timeScale = 1;
      reading = false;
      noteText.SetActive(false);
      PM.SetActive(true);
      paperRustle.Play();
    }
  }
  public void OkPressed()
  {
    reading = false;
    noteText.SetActive(false);
    PM.SetActive(true);
    Time.timeScale = 1;
  }
}