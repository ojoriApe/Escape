
using UnityEngine;

public class NeedleSpawner : MonoBehaviour
{
    public GameObject needlePrefab; //생성할 장애물의 원본 프리팹
    public int count = 2; //생성수

    public float timeBetSpawnMin = 0.5f; //다음 배치까지의 시간간격 최솟값
    public float timeBetSpawnMax = 1.2f; // 최대값
    private float timeBetSpawn;

    public float yPos = 5f; //배치할 위치의 y값
    public float xMin = -2.6f; //배치할 위치의 최소 x
    public float xMax = 2.6f; //최대 x

    private GameObject[] needles; //미리 생성할 장애물
    private int currentIndex = 0; //사용할 현재 순번의 장애물

    //처음 생성한 발판을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(-12, 1);
    private float lastSpawnTime; //마지막 배치 시점

    // Start is called before the first frame update
    void Start()
    {
        //count 만큼의 공간을 가지는 새로운 장애물 배열 생성
        needles = new GameObject[count];

        //count만큼 루프하면서 장애물 생성
        for(int i=0;i<count;i++)
        {
            //needlePrefab을 원본으로 새 장애물을 poolPosition 위치에 복제 생성
            //생성된 장애물을 needles 배열에 할당
            needles[i] = Instantiate(needlePrefab, poolPosition, Quaternion.identity);
        }

        //마지막 배치시점 초기화
        lastSpawnTime = 0f;
        //다음번 배치까지의 시간 간격을 0으로 초기화
        timeBetSpawn = 0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버 상태에서는 동작하지 않음
        if(GameManager.instance.isGameover)
        {
            return;
        }

        //마지막 배치 시점에서 timeBetSpawn이상 시간이 흘렀다면
        if(Time.time >=lastSpawnTime + timeBetSpawn)
        {
            //마지막 배치 시점을 현재 시점으로 갱신
            lastSpawnTime = Time.time;

            //다음 배치까지의 시간 간격을 timeBetSpawnMin, timeBetSpawnMax 사이에서 랜덤 설정
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            //배치할 위치의 x좌표
            float xPos = Random.Range(xMin, xMax);

            //사용할 현재 순번의 발판 장애물 오브젝트를 비활성화하고 즉시 다시 활성화
            //이때 발판의 Needle 컴포넌트의 OnEnable 메서드가 실행됨
            needles[currentIndex].SetActive(false);
            needles[currentIndex].SetActive(true);

            //현재 순번의 장애물을 화면 왼쪽에 재배치
            needles[currentIndex].transform.position = new Vector2(xPos, yPos);
            //순번넘기기
            currentIndex++;

            //마지막 순번에 도달했다면 순번을 리셋
            if(currentIndex>=count)
            {
                currentIndex = 0;
            }
        }
    }
}
