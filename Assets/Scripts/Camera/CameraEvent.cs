using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraEvent : MonoBehaviour
{
    Animator FadeAnim;
    public GameObject fade;
    public GameObject mainCamera;
    Animator cameraAnim;

    void Start(){
        cameraAnim = mainCamera.GetComponent<Animator>();
        FadeAnim = fade.GetComponent<Animator>();
    }
    void FinishTransPosition()
    {
        FadeAnim.SetTrigger("FadeOut");
        StartCoroutine(waitbeforechangeposition());
    }

    IEnumerator waitbeforechangeposition(){
        yield return new WaitForSeconds(3f);
        FadeAnim.SetTrigger("FadeIn");
    }

    void LastCameraFinished(){
        FadeAnim.SetTrigger("LightOut");
        StartCoroutine(waitbeforenewscene());
    }

    IEnumerator waitbeforenewscene(){
        yield return new WaitForSeconds(3f);
        //Change new postion
        FadeAnim.SetTrigger("LightIn");
    }

    void CameraRunFinished(){
        cameraAnim.SetBool("POV",true);
    }
}
