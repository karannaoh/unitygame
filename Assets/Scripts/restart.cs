using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class restart : MonoBehaviour {
    public Button yourButton;
    
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(restartLevel);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + scene.name + "'.");
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        print("Something");
    }
}
