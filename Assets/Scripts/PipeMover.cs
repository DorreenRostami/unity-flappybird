using UnityEngine;

public class PipeMover : MonoBehaviour
{

    private float speed = 3f;
    private Vector2 screenBoundries;

    private void Start()
    {
        screenBoundries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -1*screenBoundries.x - 1)
        {
            Destroy(gameObject);
        }
    }
}
