using MidiPlayerTK;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance; // 싱글톤이 할당될 static 변수
    private static int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    public LineController lineController;
    public PlayerController playerController;
    private  AudioSource audioSource;
    MidiFilePlayer midiFilePlayer;
    public SettingWindow[] windows;

    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
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

    // Line 시뮬레이터 이벤트 -- midiFile
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
                    // 첫 스타트
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
