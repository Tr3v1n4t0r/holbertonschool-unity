using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void AnimDone()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        pc.enabled = true;
        transform.gameObject.SetActive(false);
    }
}
