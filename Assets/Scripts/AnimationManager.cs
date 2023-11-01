using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject brumeObject;
    [SerializeField]
    private Dialogue introDialogue;
    [SerializeField]
    private TextMeshProUGUI introText;

    private int sentencesIndex = 0;
    void Start()
    {
        var animator = brumeObject.GetComponent<Animator>();
        animator.SetBool("isStarted", true);

        introText.text = introDialogue.localizedSentences[0].GetLocalizedString();
    }

    public void NextSentence()
    {
        sentencesIndex += 1;

        if (sentencesIndex >= introDialogue.localizedSentences.Length)
        {
            SceneManager.LoadScene("nouvelle_map");
        }
        else
        {
            introText.text = introDialogue.localizedSentences[sentencesIndex].GetLocalizedString();
        }
    }
}
