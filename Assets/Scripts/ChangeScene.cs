using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour { 

	// public int index;
    private bool colliding;
    FadeInOut fade;


void Start()
{
  fade = FindObjectOfType<FadeInOut>();
}

public IEnumerator _ChangeScene()
{
  fade.FadeIn();
  yield return new WaitForSeconds(1);
  SceneManager.LoadScene("personnes_agees");
}

private void OnTriggerEnter2D(Collider2D collision)
{
  StartCoroutine(_ChangeScene());
}
}
