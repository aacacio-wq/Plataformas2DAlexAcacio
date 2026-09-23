using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]private int monedas;
    private bool _isPaused = false;
    void Awake()
    {
        if(Instance !=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddCoin()
    {
        monedas += 1;
    }

    public void Pause()
    {
        if(_isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    
    }

    public bool IsPaused()
    {
        return _isPaused;
    }
}
