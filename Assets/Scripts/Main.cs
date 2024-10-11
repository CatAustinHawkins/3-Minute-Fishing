using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{

    public GameObject[] FishSpawn;
    public int Fishes;

    public GameObject[] FishesImage;
    public int FishSpawnCount;

    public bool InTrigger;

    public int FishCount;

    public int Timer = 30;


    public TextMeshProUGUI FishCountText;

    public TextMeshProUGUI CountDownText;

    public GameObject FishCollected;

    public GameObject GameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        StartCoroutine(FishSpawning());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && InTrigger)
        {
            Fishes = Random.Range(0, 6);
            FishSpawn[FishSpawnCount].SetActive(false);
            StartCoroutine(FishSpawning());

            FishSpawnCount = Random.Range(0, 6);
            FishesImage[FishSpawnCount].SetActive(true);
            FishCollected.SetActive(true);

            if(FishSpawnCount < 5)
            {
                FishCount++;
                FishCountText.text = FishCount.ToString();
            }

            if(Timer == 0)
            {
                GameOverMenu.SetActive(true);
            }
        }
    }

    IEnumerator FishSpawning()
    {
        yield return new WaitForSeconds(1f);
        FishSpawned();
    }

    public void FishSpawned()
    {
        FishSpawnCount = Random.Range(0, 6);
        FishSpawn[FishSpawnCount].SetActive(true);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        Timer = Timer - 1;
        CountDownText.text = Timer.ToString();
        StartCoroutine(Countdown());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FishSpawn")
        {
            InTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "FishSpawn")
        {
            InTrigger = false;
        }
    }

    public void Continue()
    {
        FishCollected.SetActive(false);
        FishesImage[0].SetActive(false);
        FishesImage[1].SetActive(false);
        FishesImage[2].SetActive(false);
        FishesImage[3].SetActive(false);
        FishesImage[4].SetActive(false);
        FishesImage[5].SetActive(false);
        FishesImage[6].SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
