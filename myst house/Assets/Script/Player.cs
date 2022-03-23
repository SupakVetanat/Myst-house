using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public static Player instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator Anime;
    [SerializeField] private SpriteRenderer sr;
    public string collisionName;

    [SerializeField] bool isMove;
    [SerializeField] bool isTurn = false;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        AnimaPlayer();
        Turn();
    }
    void Turn()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            isTurn = true;
        }
        else if(Input.anyKey&& !Input.GetKey(KeyCode.W))
        {
            isTurn = false;
        }
    }
    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        isMove = (Input.GetAxisRaw("Horizontal") != 0);


    }
    void FlipSprite()
    {
        bool flip = Mathf.Abs(rb.velocity.x)>Mathf.Epsilon;
        if (flip && Time.timeScale !=0)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    void AnimaPlayer()
    {
        Anime.SetBool("isMove",isMove);
        Anime.SetBool("isTurn", isTurn);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionName = collision.gameObject.name;
    }
}
