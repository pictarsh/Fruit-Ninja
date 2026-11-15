
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BladeScripts : MonoBehaviour
{
    public float minCuttingSpeed = 1f;
    public int score = 0;
    public TextMeshProUGUI scoreText, finalScoreText;
    public AudioSource slashSound;
    public GameObject ScoreFrame;
    public GameObject spawner;
    public GameObject expl;
    public GameObject gameOverFrame;
    public InputAction mouseInput;
    
    private bool _isCutting = false;
    private TrailRenderer _trail;
    private Vector2 _prevPos;
    private Collider _blade;
    void Awake()
    {
        _blade = GetComponent<Collider>();
        _blade.enabled = false;
        
        _trail = GetComponent<TrailRenderer>();
        _trail.enabled = false;
    }

    void OnEnable()
    {
        mouseInput.Enable();
    }

    void OnDisable()
    {
        mouseInput.Disable();
    }

    void Update()
    {
        float mousePressed = mouseInput.ReadValue<float>();
        
        if (mousePressed > 0)
        {
            StartCutting();
            _isCutting = true;
        }

        if (mousePressed < 1)
        {
            _isCutting = false;
            _trail.enabled = false;
            _blade.enabled = false;
        }

        if (_isCutting)
        {
            UpdatePosition();   
        }

    }

    private void StartCutting()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        _trail.enabled = true;
    }

    private void UpdatePosition()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        
        float velocity = (pos - _prevPos).magnitude / Time.deltaTime;

        _blade.enabled = velocity > minCuttingSpeed;
        

        if (_blade.enabled)
        {
            slashSound.Play();
        }

        _prevPos = pos;
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = $"Score: {score}";
    }

    public void ActivateGameOverFrame()
    {
        ScoreFrame.SetActive(false);
        gameOverFrame.SetActive(true);
        finalScoreText.text = $"Your Score:\n{score}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            spawner.GetComponent<FruitSpawnerScripts>().StopSpawning();
            Instantiate(expl, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            // gameOverFrame.SetActive(true);
            print("Game Over!!!");
            ActivateGameOverFrame();
        }
    }
}
