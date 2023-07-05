using MidiPlayerTK;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance; // �̱����� �Ҵ�� static ����
    private static int score = 0; // ���� ���� ����
    public bool isGameover { get; private set; } // ���� ���� ����

    public LineController lineController;
    public PlayerController playerController;
    private  AudioSource audioSource;
    MidiFilePlayer midiFilePlayer;
    public SettingWindow[] windows;

    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;

        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lineController = FindObjectOfType<LineController>();
        playerController = FindObjectOfType<PlayerController>();
        //midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        //midiFilePlayer.OnEventNotesMidi.AddListener(NotesToPlay);
    }

    // Line �ùķ����� �̺�Ʈ -- midiFile
    //public void NotesToPlay(List<MPTKEvent> mptkEvents)
    //{
    //    Debug.Log("Received " + mptkEvents.Count + " MIDI Events");
    //    // Loop on each MIDI events
    //    foreach (MPTKEvent mptkEvent in mptkEvents)
    //    {
    //        // Log if event is a note on
    //        if (mptkEvent.Command == MPTKCommand.NoteOn)
    //        {
    //            Debug.Log($"Note on Time:{mptkEvent.RealTime} millisecond  Note:{mptkEvent.Value}  Duration:{mptkEvent.Duration} millisecond  Velocity:{mptkEvent.Velocity}");

    //            //--------
    //            playerController.setRotate();
    //            lineController.rotatedEvent(playerController.getTransform(), playerController.getMoveDirection());
    //        }
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (playerController.getIsRunning() == false) Invoke("gameStartSetting", .1f);
            //midiFilePlayer.MPTK_Play();

            if (!isGameover)
            {
                if (playerController.getIsRunning() == false)
                {
                    // ù ��ŸƮ
                    gameStartSetting();
                    //Invoke("gameStartSetting", .5f);
                }
                else
                {
                    playerController.setRotate();
                    lineController.rotatedEvent(playerController.getTransform(), playerController.getMoveDirection());
                }
            }
        } 
        
        //else if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    windows[2].SettingBtnClick();
        //}
    }

    void gameStartSetting()
    {
        audioSource.Play();
        playerController.setIsRunning();
        lineController.rotatedEvent(playerController.getTransform(), playerController.getMoveDirection());
    }

    public void GameOverEvent()
    {
        isGameover = true;
        audioSource.Pause();
        playerController.Die();
        windows[1].SettingBtnClick();
    }

    public void GoalEvent()
    {
        audioSource.Pause();
        playerController.Stop();
        windows[0].SettingBtnClick();
    }


}
