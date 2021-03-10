using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int _currentGlobalLayer = 0;

    
    private float _GameSpeed = 5.0f;

    [SerializeField]
    private float _gameTimer = 0.0f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _gameTimer += _GameSpeed * Time.deltaTime;
        
        if(_gameTimer > _currentGlobalLayer + 1)
        {
            UIManager.instance.CreateLayer(_currentGlobalLayer);
            _currentGlobalLayer += 1;
        }
    }
}
