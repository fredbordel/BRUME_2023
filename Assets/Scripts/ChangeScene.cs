using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

  public string sceneToGoTo;
  private bool colliding;
  FadeInOut fade;


  void Start()
  {
    fade = FindObjectOfType<FadeInOut>();

    foreach (string gameObjectName in MainManager.Instance.DisabledEnterSceneList)
    {
      if (gameObjectName == gameObject.name)
      {
        gameObject.SetActive(false);
      }
    }
  }

  public void Test()
  {
    SceneManager.LoadScene("nouvelle_map");
    MainManager.Instance.PathNumber += 1;
  }

  public IEnumerator _ChangeScene()
  {
    fade.FadeIn();
    yield return new WaitForSeconds(1);
    SceneManager.LoadScene(sceneToGoTo);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("HELLO?");
    MainManager.Instance.BrumePosition = GameObject.FindWithTag("brume").transform.position;
    MainManager.Instance.ChienPosition = GameObject.FindWithTag("chien").transform.position;
    MainManager.Instance.DisabledEnterSceneList.Add(gameObject.name);
    StartCoroutine(_ChangeScene());

    MainManager.Instance.PathNumber += 1;
  }
}
