using UnityEngine;

public class Bonus_sc : MonoBehaviour
{

    [SerializeField]
    float speed = 3 ;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(this.transform.position.y < -5.8f){

            Destroy(this.gameObject);
                                                    
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){          // Player ile mi çarpışıyor?
            
            //Üçlü atış bonusunu aktifleştir 
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if(player_sc != null)
            {
                player_sc.TripleShotActive();
            }
             
            Destroy(this.gameObject);           //Bonus nesnesini yok et
            
        }
    }



}
