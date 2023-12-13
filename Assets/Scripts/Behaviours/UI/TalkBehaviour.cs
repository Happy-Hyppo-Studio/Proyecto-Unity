using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkBehaviour : MonoBehaviour
{
    public string[] dialog;
    public GameObject[] image;
    public GameObject img;
    public TMP_Text text;
    public GameObject[] colonel;
    Coroutine dialogue;
    public float textSpeed = 0.3f;
    private int dialogueI;
    private int dialogueLength;
    private bool polloPollo;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        dialogue = StartCoroutine(StartDialogue());
        dialogueLength = dialog.Length - 1;

        if (MusicControler.Instance.polloPollo)
        {
            colonel[0].SetActive(false);
            colonel[1].SetActive(true);

            var scene = SceneManager.GetActiveScene().buildIndex;
            if (scene == 6)
            {
                dialog[1] = "Estos bichos tan molestos han secuestrado a mi amigo, el gran mago. ¿Me hecharías una mano?";
                dialog[4] = "Si queremos salvar al mago primero deberás conocer los peligros de este mundo y cómo combatirlos.";
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //si el dialogo no se acabo mostrando completo
        if (Input.GetMouseButtonDown(0) && text.text.Length < dialog[dialogueI].Length)
        {
            //saltar animacion del dialogo
            if (dialogue != null) StopCoroutine(dialogue);
            text.text = dialog[dialogueI];
            return;
        }
        //si el dialogo acabo pero quedan mas dialogos
        if (Input.GetMouseButtonDown(0) && dialogueI < dialogueLength && text.text.Length == dialog[dialogueI].Length)
        {
            //empezar nuevo dialogo
            if (dialogue != null) StopCoroutine(dialogue);
            dialogueI++;
            dialogue = StartCoroutine(StartDialogue());
            return;
        }
        //si no hay mas dialogos
        if (Input.GetMouseButtonDown(0) && dialogueI >= dialogueLength)
        {
            Time.timeScale = 1.0f;
            Destroy(this.gameObject);
        }
    }
    IEnumerator StartDialogue()
    {
        text.text = "";
        int letterI = 0;
        while (letterI < dialog[dialogueI].Length)
        {
            text.text += dialog[dialogueI][letterI];
            if ((dialogueI - 1) >= 0) { image[dialogueI - 1].SetActive(false); }
            image[dialogueI].SetActive(true);
            letterI++;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }  
}
