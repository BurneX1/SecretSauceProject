using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIpuzzBase : MonoBehaviour
{
    public GameObject plyCtrll;
    private Pause ps;
    public KeyCode[] keysToUse;
    public UnityEvent onFinishEvent;
    // Start is called before the first frame update
    void Start()
    {
        ps = plyCtrll.GetComponent<Pause>();

    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ps.paused == false)
        {
            ClosePuzzle();
            
        }
    }

    public void ClosePuzzle()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void FinishPuzzle()
    {

        onFinishEvent.Invoke();
        ClosePuzzle();
    }
}
