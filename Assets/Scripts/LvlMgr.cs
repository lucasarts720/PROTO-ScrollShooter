using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlMgr : MonoBehaviour
{
    #region Variables
    /// <summary>
    ///  KC = KillCount
    /// </summary>
    public Text timer, timerFinal, kC, kCF, bossKC, bossKCF;
    public GameObject panel;
    public MOTHER mothership;
    public Transform motherSpawnPoint;
    public Spawner spawner;
    float time;
    public int bajas = 0, killsToBoss = 25, jefesMuertos = 0;
    public bool isPlaying, bossIsActive;
    #endregion

    private void Start()
    {
        panel.gameObject.SetActive(false);
        time = 0;
        isPlaying = true;
        kC.text = bajas.ToString();
        bossKC.text = jefesMuertos.ToString();
    }
    private void Update()
    {
        SpawnBoss();
        Playing();
        if (Input.GetKeyDown(KeyCode.Escape)) { ReturnToMenu("StartMenu"); }
    }

    void SpawnBoss()
    {
        if (bajas % killsToBoss == 0 && bajas > 0 && !bossIsActive)
        {
            spawner.gameObject.SetActive(false);
            Instantiate(mothership, motherSpawnPoint);
            bossIsActive = !bossIsActive;
        }
    }

    public void SpawnerActivate()
    {
        spawner.gameObject.SetActive(true);
        StartCoroutine(spawner.Spawntimer());
    }

    void Playing()
    {
        if (isPlaying == true)
        {
            time = time + Time.deltaTime;
            DisplayTime(time);
            kC.text = bajas.ToString();
            bossKC.text = jefesMuertos.ToString();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void EndGame()
    {
        isPlaying = false;
        panel.gameObject.SetActive(true);
        timerFinal.text = timer.text;
        kCF.text = kC.text;
        bossKCF.text = bossKC.text;
    }
    public void ReturnToMenu(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }
}
