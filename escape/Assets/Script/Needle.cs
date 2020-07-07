
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject[] needles; //장애물들
    
    private Rigidbody2D needleRigidbody;

    //컴포넌트가 활성화될 때마다 매번 실행되는 메서드
    private void OnEnable()
    {
        for (int i =0; i<needles.Length;i++)
        {
            if(Random.Range(0,3)==0)
            {
                needles[i].SetActive(true);
            }
            else
            {
                needles[i].SetActive(false);
            }
                
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)  //2D를 붙일것
    {
        if(other.tag == "Player")
        {
            //상대방의 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            if(playerController != null)
            {
                //상대방 PlayerController 컴포턴트의 Die() 메서드 실행
                playerController.Die();
                
            }
        }
        
        
    
    }
}
