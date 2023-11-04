using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

  public string sceneToGoTo;
  private bool colliding;
  private FadeInOut fade;
  [SerializeField]
  private AudioSource audioSource;


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

  public IEnumerator _ChangeScene()
  {
    float startVolume = audioSource.volume;
    while (audioSource.volume > 0)
    {
      audioSource.volume -= startVolume * Time.deltaTime / 1.5f;
      yield return null;
    }

    fade.FadeIn();
    yield return new WaitForSeconds(1);
    SceneManager.LoadScene(sceneToGoTo);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    MainManager.Instance.BrumePosition = GameObject.FindWithTag("brume").transform.position;
    MainManager.Instance.ChienPosition = GameObject.FindWithTag("chien").transform.position;
    MainManager.Instance.CurrentScene = sceneToGoTo;
    MainManager.Instance.DisabledEnterSceneList.Add(gameObject.name);

    StartCoroutine(_ChangeScene());

  }
}
