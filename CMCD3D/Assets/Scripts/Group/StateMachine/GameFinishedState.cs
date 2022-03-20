using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedState : State
{
    [SerializeField] private TextMeshProUGUI _endText;
    
    private void OnEnable()
    {
        _endText.enabled = true;
        _endText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
