using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tutorialDialog : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private bool text = true;

    private bool DidDialogueStart;
    private int LineIndex;
    [SerializeField] private float TimeTyping = 0.075f;

    public GameObject panel;
    private float tiempoEspera = 0f; // Tiempo en segundos antes de activar el panel

    //public MoveToPoint moveToPointScript;

    public Image ImagePanel;
    [SerializeField] private bool startTyping = false;

    //public GameObject Pause;
    public GameObject studentEx;

    private void Start()
    {
        // Llama a la funci�n ActivarPanelDespuesDeEspera despues del tiempo especificado
        Invoke("ActivarPanelDespuesDeEspera", tiempoEspera);
    }

    private void Update()
    {
        if (text)
        {
            
            if (startTyping)
            {
                if (!DidDialogueStart)
                {
                    StartDialogue();
                }
                else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (dialogue.text == dialogueLines[LineIndex])
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
            studentEx.SetActive(true);
            //moveToPointScript.flag = false;
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
    public void Empezar()
    {
        Color colorActual = ImagePanel.color;
        colorActual.a = 0.5f;

        ImagePanel.color = colorActual;

        startTyping = true;
    }
}
