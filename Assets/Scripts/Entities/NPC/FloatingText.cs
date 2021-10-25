using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public GameObject floatingText;
    public string textToShow;
    public float sightRadius;
    GameObject target;

    private void Start()
    {
        floatingText.SetActive(false);
        floatingText.GetComponent<TextMesh>().text = textToShow.ToString();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        DetectPlayer();
    }
    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(target.transform.position, transform.position);
        if (distancePlayer <= sightRadius)
        {
            ShowFloatingText();
        }
        else
        {
            HideFloatingText();
        }
    }
    void ShowFloatingText()
    {
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
