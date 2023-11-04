using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IntroAnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject brumeObject;
    [SerializeField]
    private Dialogue introDialogue;
    [SerializeField]
    private TextMeshProUGUI introText;
    private int sentencesIndex = 0;
    private FadeInOut fade;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Image textBoxImage;
    [SerializeField]
    private GameObject nextButton;
    private EventSystem eventSystem;

    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();

        var animator = brumeObject.GetComponent<Animator>();
        animator.SetBool("isStarted", true);

        eventSystem.SetSelectedGameObject(nextButton, null);
        introText.text = introDialogue.localizedSentences[0].GetLocalizedString();
    }

    public void NextSentence()
    {
        if (textBoxImage.color.a == 1)
        {
            sentencesIndex += 1;

            if (sentencesIndex >= introDialogue.localizedSentences.Length)
            {
                StartCoroutine(_ChangeScene());
            }
            else
            {
                introText.text = introDialogue.localizedSentences[sentencesIndex].GetLocalizedString();
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
        SceneManager.LoadScene("nouvelle_map");
    }
}
