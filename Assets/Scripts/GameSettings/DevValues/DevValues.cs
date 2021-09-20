using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DevValues : MonoBehaviour
{
    public GameObject nameField;
    public GameObject valueField;
    public GameObject togle;
    public GameObject slide;
    public string valueName;
    public UnityEvent exEvent;

    [HideInInspector]
    public float slideVal;
    [HideInInspector]
    public bool togleVal;
    public enum valueType
    {
        Bool = 0,
        Float = 1,
    }

    [SerializeField] protected valueType m_ValueType = valueType.Bool;


    private void Awake()
    {

        if (m_ValueType == valueType.Bool)
        {
            togle.gameObject.SetActive(true);
            slide.gameObject.SetActive(false);
        }
        else if (m_ValueType == valueType.Float)
        {
            togle.gameObject.SetActive(false);
            slide.gameObject.SetActive(true);
        }
        nameField.GetComponent<Text>().text = valueName;
        

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (m_ValueType == valueType.Bool)
        {
            valueField.GetComponent<Text>().text = ""  + togleVal;
        }
        else if (m_ValueType == valueType.Float)
        {
            valueField.GetComponent<Text>().text = " " + slideVal;
        }
    }


    public void SlidingVal(float val)
    {
        slideVal =  val;
    }
    public void ToglVal(bool val)
    {
        togleVal = val;
    }
}

