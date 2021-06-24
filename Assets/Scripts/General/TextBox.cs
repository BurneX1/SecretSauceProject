using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    private int _index;
    private float _timer;
    public GameObject textBox;
    public Text actTxt;
    public string writtingTxt;
    public float textSpd;
    [SerializeField]
    private bool onDialogue;
    public GameObject gmMang;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(onDialogue == true)
        {

            if (textBox.activeSelf != onDialogue)
            {
                gmMang.GetComponent<PlayerMangr>().NonActionPly();
                textBox.SetActive(true);

            }
            if(actTxt != null)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0f)
                {
                    if (_index > writtingTxt.Length)
                    {
                        return;
                    }
                    _timer += textSpd;
                    
                    actTxt.text = writtingTxt.Substring(0, _index);
                    _index++;

                }
            }
        }
        else
        {
            if (textBox.activeSelf != onDialogue)
            {
                gmMang.GetComponent<PlayerMangr>().EnableActionPlayer();
                textBox.SetActive(false);

            }
        }
    }

    public void WritteText(string newTexts, float wrtTime)
    {
        _index = 0;
        onDialogue = true;
        writtingTxt = newTexts;
        textSpd = wrtTime;
    }

    public void InstantWrite()
    {
        actTxt.text = writtingTxt;
        _index = writtingTxt.Length;
    }

    public void EndWritte()
    {
        _index = 0;
        onDialogue = false;
    }
}
