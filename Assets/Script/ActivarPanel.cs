using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivarPanel : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private bool text = true;

    private bool DidDialogueStart;
    private int LineIndex;
    [SerializeField] private float TimeTyping = 0.075f;


    public GameObject panel;
    private float tiempoEspera = 0f; // Tiempo en segundos antes de activar el panel

    private void Start()
    {
        // Llama a la función ActivarPanelDespuesDeEspera después del tiempo especificado
        Invoke("ActivarPanelDespuesDeEspera", tiempoEspera);
    }

    private void Update()
    {
        if (text)
        {
            if (!DidDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogue.text == dialogueLines[LineIndex])
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogue.text = dialogueLines[LineIndex];
                }
            }

        }
        else
        {
            panel.SetActive(false);
        }
    }
    private void StartDialogue()
    {
        DidDialogueStart = true;
        LineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        LineIndex++;
        if (LineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            DidDialogueStart = false;
            panel.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogue.text = string.Empty;

        foreach (char ch in dialogueLines[LineIndex])
        {
            dialogue.text += ch;
            yield return new WaitForSeconds(TimeTyping);
        }
    }

    private void ActivarPanelDespuesDeEspera()
    {
        // Activa el panel
        panel.SetActive(true);
    }
}
