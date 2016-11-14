using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class next_level : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(restartLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void restartLevel()
    {
        int scene1 = SceneManager.GetActiveScene().buildIndex;
        scene1++;
        if (scene1 == 9)
        {
            SceneManager.LoadScene(1);
        }
        SceneManager.LoadScene(scene1);

    }
}
