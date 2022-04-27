using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Book : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    public Word word;
    private Vector2 screenBounds;
    public GameObject Prefab_1;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-speed, speed), -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    void Update()
    {
        TextMeshPro text_book = this.gameObject.GetComponentInChildren<TextMeshPro>();

        //destroy book on groung

        if (transform.position.y < -screenBounds.y + 1.6)
        {
            text_book.color = Color.red;
            
        }


        if (transform.position.y < -screenBounds.y + 1.5)
        {
            Destroy(this.gameObject);
            LifeCount.lifeCount.LoseLife();
            FindObjectOfType<AudioManager>().Play("False");
            GameObject p_1 = Instantiate(Prefab_1, this.transform.position, Quaternion.identity);
            Destroy(p_1.gameObject, 0.3f);
        }


        //change direction
        if (transform.position.x < -screenBounds.x + 2)
        {
            rb.velocity = new Vector2(speed, -speed);
        }

        if (transform.position.x > screenBounds.x - 1)
        {
            rb.velocity = new Vector2(-speed, -speed);
        }

    }
}
