using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글턴을 할당할 전역변수

    public bool isGameover = false; //게임오버상태
    public Text scoreText; //점수출력 텍스ㅡ UI
    public GameObject gameoverUI; //게임오버 시 활성화할 UI게임 오브젝트

    private int score = 0;

    //게임 시작과 동시에 싱글턴 구성
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스바 누르면 다시시작
        if (isGameover && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //ESC 누르면 종료
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    //플래이어 사망 시 게임오버를 실행하는 메서드
    public void OnplayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);

        //BestScore 키로 저장된 최고기록 가겨오기
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        //이전까지의 최고기록보다 현재 기록이 더 크다면
        if (score>bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        scoreText.text = "Best Score: " + (int)bestScore;
    }
}
