using UnityEngine;

public class Enemy_Sc : MonoBehaviour
{

[SerializeField]
public int speed= 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(this.transform.position.y < -5.5f){

           // Destroy(this.gameObject);
            this.transform.position = new Vector3(Random.Range(-9.5f, +9.5f),
             7.4f,
            0);
                                                    
        }
    }

    void OnTriggerEnter(Collider other){

        if(other.tag == "Player"){

            //Yapılan: Player'ın canını bir eksilt
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            player_sc.Damage();
            
            //Player_sc player = new Player_sc();   //Bu sahnedeki player değil klon 

            Destroy(this.gameObject);
        }

        else if (other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
