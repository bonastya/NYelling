using RedBlueGames.Tools.TextTyper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameControl : MonoBehaviour
{
    public TextTyper grinchText;

    private Queue<string> dialogueLines = new Queue<string>();

    [SerializeField]
    [Tooltip("The text typer element to test typing with")]
    private TextTyper testTextTyper;

    [SerializeField]
    private AudioClip printSoundEffect;

    public Animator GrinchAnimator;



    public Animator GrinchVolumeAnimator;

    public List<GameObject> targetsVolumes;

    public HeartControl GrinchHeartControl;
    public HeartControl PlayerHeartControl;


    public GameObject GamePanel;


    // Start is called before the first frame update
    void Start()
    {


        grinchText = GameObject.FindFirstObjectByType<TextTyper>();
        //grinchText.TypeText("Я не думал что вы сможете пройти моё испытание, ну ладно", 0.04f);
        
        //WaitAndSay(4, "Я всё равно подарки вам не отдам!");



        this.grinchText.PrintCompleted.AddListener(this.HandlePrintCompleted);
        this.grinchText.CharacterPrinted.AddListener(this.HandleCharacterPrinted);

        CutsceneManager.Instance.StartCutscene("Cut_Scene_1");

        dialogueLines.Enqueue("Я думал вы не сможете меня догнать... <delay=0.5>Ну ладно.</delay>.");
        dialogueLines.Enqueue("Всё равно вы не сможете меня победить.");
        dialogueLines.Enqueue("Я вызываю вас на <size=80><anim=fullshake>Б А Т Л</anim></size>.");

        


    }



    public void StartDialog()
    {
        ShowScript();
        GrinchAnimator.SetBool("speak", true);
    }

/*    IEnumerator WaitAndSay(int sek, string str)
    {
        yield return new WaitForSeconds(sek);
        grinchText.TypeText(str, 0.04f);

    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ShowScript()
    {
        if (dialogueLines.Count <= 0)
        {
            GrinchAnimator.SetBool("speak", false);
            StartCoroutine(Fight());
            return;
        }

        grinchText.TypeText(dialogueLines.Dequeue(),0.07f);
    }

    private void HandleCharacterPrinted(string printedCharacter)
    {
        // Do not play a sound for whitespace
        if (printedCharacter == " " || printedCharacter == "\n")
        {
            return;
        }

        var audioSource = this.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = this.printSoundEffect;
        //audioSource.Play();
    }

    private void HandlePrintCompleted()
    {
        Debug.Log("TypeText Complete");
        ShowScript();
    }




    private IEnumerator Fight()
    {
        GamePanel.SetActive(true);
        yield return new WaitForSeconds(1f);


        for(int num =0; num < 3; num++)
        {

            GrinchVolumeAnimator.SetInteger("fight", num+1);
            yield return new WaitForSeconds(3f);
            GrinchVolumeAnimator.SetInteger("fight", 0);

            targetsVolumes[num].SetActive(true);

            //запустить анимацию цифр

            yield return new WaitForSeconds(3f);

            if (targetsVolumes[num].GetComponent<TargetVolume>().isPlayerHere)
            {
                print("yes");
                GrinchHeartControl.HealthDecrease();
            }
            else
            {
                print("no");
                PlayerHeartControl.HealthDecrease();
            }

            targetsVolumes[num].SetActive(false);





        }







    }
}
