using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRigidBody2D;
    private float flapStrength = 6f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] birdSprites;
    private int spriteIndex;

    private Vector2 screenBoundries;
    private float birdHeight;

    GameManager gm;

    private void Awake()
    {
        birdRigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenBoundries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.2f, 0.2f);
        birdHeight = spriteRenderer.bounds.size.y;
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdRigidBody2D.velocity = Vector2.up * flapStrength;
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, -1*screenBoundries.y + birdHeight/2, screenBoundries.y - birdHeight / 2);
        transform.position = viewPos;
    }

    private void AnimateSprite()
    {
        spriteRenderer.sprite = birdSprites[spriteIndex];
        spriteIndex += 1;
        if(spriteIndex >= birdSprites.Length)
        {
            spriteIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gm.GameOver();
        }
        else if(collision.gameObject.tag == "ScoreZone")
        {
            gm.IncScore();
        }
    }
}
