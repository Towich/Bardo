using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroManager : MonoBehaviour
{
    public GameObject background1;

    public GameObject background2;
    // Start is called before the first frame update
    void Start()
    {
        background2.SetActive(false);
        StartCoroutine(ChangeToBackground2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeToBackground2()
    {
        yield return new WaitForSeconds(3f);
        background1.SetActive(false);
        background2.SetActive(true);
    }
}
