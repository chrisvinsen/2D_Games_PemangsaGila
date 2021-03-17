using UnityEngine;

public class Stages : MonoBehaviour
{
    public GameObject Male;
    public GameObject Female;

    GameObject torch;
    GameObject barrel;
    GameObject shelf;
    GameObject floor;

    int flag;
    int cnt;

    void Awake()
    {
        if (GameManager.Instance.reset == true)
        {
            PlayerPrefs.SetFloat("Camera", 0.4f);
            newGame();
        }
        else
        {
            continueGame();
        }

        if (PlayerPrefs.GetString("CharacterUsed") == "Male")
        {
            Debug.Log(PlayerPrefs.GetString("CharacterUsed"));
            Male.SetActive(true);
            Female.SetActive(false);
        }
        else
        {
            Male.SetActive(false);
            Female.SetActive(true);
        }
    }

    public void newGame()
    {
        Debug.Log("New game");
        GameManager.Instance.cntTorch = 10;
        GameManager.Instance.cntBarrel = 10;
        GameManager.Instance.cntShelf = 10;
        GameManager.Instance.torches = new int[100];
        GameManager.Instance.barrels = new int[100];
        GameManager.Instance.shelves = new int[100];
        for (int i = 0; i < 100; i++)
        {
            GameManager.Instance.torches[i] = 0;
            GameManager.Instance.barrels[i] = 0;
            GameManager.Instance.shelves[i] = 0;
        }
        cnt = Random.Range(1, 11);
        spawnTorch(cnt);
        cnt = Random.Range(1, 11);
        spawnBarrel(cnt);
        cnt = Random.Range(1, 11);
        spawnShelf(cnt);
    }

    public void continueGame()
    {
        Debug.Log("Continue Game");
        for (int i = 1; i <= 42; i++)
        {
            torch = GameObject.Find("Torch " + i);
            if (GameManager.Instance.torches[i] == 1)
            {
                torch.SetActive(true);
            }
            else
            {
                torch.SetActive(false);
            }
        }
        for (int i = 1; i <= 72; i++)
        {
            barrel = GameObject.Find("Barrel " + i);
            floor = GameObject.Find("Floor " + i);
            if (GameManager.Instance.barrels[i] == 1)
            {
                barrel.SetActive(true);
                floor.SetActive(true);
            }
            else
            {
                barrel.SetActive(false);
                floor.SetActive(false);
            }
        }
        for (int i = 1; i <= 57; i++)
        {
            shelf = GameObject.Find("Shelf " + i);
            if (GameManager.Instance.shelves[i] == 1)
            {
                shelf.SetActive(true);
            }
            else
            {
                shelf.SetActive(false);
            }
        }
    }

    void spawnTorch(int cnt)
    {
        int temp = 0;
        for (int i = 1; i <= 42; i++)
        {
            torch = GameObject.Find("Torch " + i);
            if (torch == null)
            {
                continue;
            }
            if (temp < cnt)
            {
                flag = Random.Range(0, 2);
            } 
            else if (temp == cnt)
            {
                flag = 0;
            }
            if (flag == 1)
            {
                torch.SetActive(true);
                GameManager.Instance.cntTorch++;
                if (temp < cnt)
                {
                    temp++;
                }
            }
            else
            {
                torch.SetActive(false);
            }
            GameManager.Instance.torches[i] = flag;
        }
        Debug.Log("Count Torch : " + GameManager.Instance.cntTorch);
    }

    void spawnBarrel(int cnt)
    {
        int temp = 0;
        for (int i = 1; i <= 72; i++)
        {
            barrel = GameObject.Find("Barrel " + i);
            floor = GameObject.Find("Floor " + i);
            if (barrel == null)
            {
                continue;
            }
            if (temp < cnt)
            {
                flag = Random.Range(0, 2);
            }
            else if (temp == cnt)
            {
                flag = 0;
            }
            if (flag == 1)
            {
                barrel.SetActive(true);
                floor.SetActive(true);
                GameManager.Instance.cntBarrel++;
                if (temp < cnt)
                {
                    temp++;
                }
            }
            else
            {
                barrel.SetActive(false);
                floor.SetActive(false);
            }
            GameManager.Instance.barrels[i] = flag;
        }
        Debug.Log("Count Barrel : " + GameManager.Instance.cntBarrel);
    }

    void spawnShelf(int cnt)
    {
        int temp = 0;
        for (int i = 1; i <= 57; i++)
        {
            shelf = GameObject.Find("Shelf " + i);
            if (shelf == null)
            {
                continue;
            }
            if (temp < cnt)
            {
                flag = Random.Range(0, 2);
            }
            else if (temp == cnt)
            {
                flag = 0;
            }
            if (flag == 1)
            {
                shelf.SetActive(true);
                GameManager.Instance.cntShelf++;
                if (temp < cnt)
                {
                    temp++;
                }
            }
            else
            {
                shelf.SetActive(false);
            }
            GameManager.Instance.shelves[i] = flag;
        }
        Debug.Log("Count Shelf : " + GameManager.Instance.cntShelf);
    }
}
