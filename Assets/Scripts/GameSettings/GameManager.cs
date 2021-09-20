using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region enumLabels
    public enum gameMode
    {
        UserMode = 0,

        DeveloperMode = 1,

        EditorMode = 2
    }
    public enum conectionState
    {
        Offline = 0,

        Online = 1,

        Conecting = 2
    }
    public enum gameState
    {
        MenuStaying = 0,

        Playing = 1,

        Win = 2,

        Lose = 2,
    }
    #endregion

    public static GameManager instance;
    [SerializeField] public gameMode m_GameMode = gameMode.UserMode;
    [SerializeField] protected conectionState m_Conection = conectionState.Offline;
    [SerializeField] protected gameState m_State = gameState.MenuStaying;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
