using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteract : InteractableAction
{
    private int _txtIndx = 0;
    public bool noLoopable;
    public string[] textLines;
    public float delayTxt;
    public TextBox cmp_txtMng;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activation()
    {
        base.Activation();
        if(textLines.Length > 0)
        {
            if(_txtIndx >= textLines.Length)
            {
                if (cmp_txtMng.writtingTxt != cmp_txtMng.actTxt.text)
                {
                    cmp_txtMng.InstantWrite();
                }
                else
                {
                    cmp_txtMng.EndWritte();
                    if (noLoopable == true)
                    {
                        gameObject.SetActive(false);
                    }
                    _txtIndx = 0;
                    return;
                }
                
            }
            else
            {
                if (_txtIndx <= 0)
                {
                    cmp_txtMng.WritteText(textLines[_txtIndx], delayTxt);
                    _txtIndx++;
                }
                else if (cmp_txtMng.writtingTxt != cmp_txtMng.actTxt.text)
                {
                    cmp_txtMng.InstantWrite();
                }
                else
                {
                    cmp_txtMng.WritteText(textLines[_txtIndx], delayTxt);
                    _txtIndx++;
                }
            }
        }

    }
}
