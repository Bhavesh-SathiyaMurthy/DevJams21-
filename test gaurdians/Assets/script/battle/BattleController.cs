using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    [SerializeField] Camera WorldCamara;
    [SerializeField] Camera battleCamara;

    public event Action OnBossEncounter;
    public event Action OnEndBoss;

    public static BattleController instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator BossEncounter()
    {

        yield return new WaitForEndOfFrame();

        OnBossEncounter?.Invoke();
        
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            battleCamara.gameObject.SetActive(true);
            WorldCamara.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            battleCamara.gameObject.SetActive(false);
            WorldCamara.gameObject.SetActive(true);
            OnEndBoss?.Invoke();
        }
        
    }
}
