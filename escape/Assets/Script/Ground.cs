
using UnityEngine;

public class Ground : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.tag =="Needle" && !GameManager.instance.isGameover)
        {
            GameManager.instance.AddScore(1);

        }
    }
}
/*OnTrigger 계열 : 충돌시 통과
 * OnCollision 계열 : 충돌시 밀어냄
 * 
 * 
 * 
 */