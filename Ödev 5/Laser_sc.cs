using UnityEngine;

public class Lazer_sc : MonoBehaviour
{
    [SerializeField]
    public int speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
               
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(transform.up * speed * Time.deltaTime);

        if (this.transform.position.y > 7)
        {
            if(this.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
