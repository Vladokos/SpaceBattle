using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBtn : MonoBehaviour
{
    public Animator commingSoon;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SignInD()
    {
        commingSoon.SetBool("ClisckSignIn", true);
    }
    public void SignInU()
    {
        StartCoroutine(stopAnim());
    }
    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(1.3f);
        commingSoon.SetBool("ClisckSignIn", false);
    }
}
