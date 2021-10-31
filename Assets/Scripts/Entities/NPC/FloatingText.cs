using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public GameObject floatingText;
    public string textToShow;
    public float sightRadius;
    GameObject target;
    GameObject target2;
    public Camera cameraPlayer1;
    public Camera cameraPlayer2;
    Camera cameraToShow;

    private void Start()
    {
        floatingText.SetActive(false);
        floatingText.GetComponent<TextMesh>().text = textToShow.ToString();
        target = GameObject.Find("Pj1");
        target2 = GameObject.Find("Pj3 (1)");
    }

    private void Update()
    {
        //floatingText.transform.rotation = Quaternion.LookRotation(floatingText.transform.position - cameraToShow.transform.position);
        DetectPlayer();
    }
    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(target.transform.position, transform.position);
        float distancePlayer2 = Vector3.Distance(target2.transform.position, transform.position);
        if (distancePlayer <= sightRadius)
        {
            ShowFloatingTextOnCamera1();
        }
        else if(distancePlayer2 <= sightRadius)
        {
            ShowFloatingTextOnCamera2();
        }
        else
        {
            HideFloatingText();
        }
    }
    void ShowFloatingTextOnCamera1()
    {
        cameraToShow = cameraPlayer1;
        floatingText.SetActive(true);
    }
    void ShowFloatingTextOnCamera2()
    {
        cameraToShow = cameraPlayer2;
        floatingText.SetActive(true);
    }
    void HideFloatingText()
    {
        floatingText.SetActive(false);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, sightRadius);
    }
}
