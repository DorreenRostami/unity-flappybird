using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Bird bird;
    public GameObject playButton;

    private int score = 0;

    private void Awake()
    {
        Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
        playButton.SetActive(true);
    }

    public void GameOver()
    {
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();

        Time.timeScale = 1f;
        bird.enabled = true;
        playButton.SetActive(false);

        PipeMover[] pipes = FindObjectsOfType<PipeMover>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        FindObjectOfType<PipeSpawner>().resetSpawner();
    }

    public void IncScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    
}
