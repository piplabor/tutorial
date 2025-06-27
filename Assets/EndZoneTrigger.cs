using UnityEngine;

public class EndZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var startendcontroller = Object.FindFirstObjectByType<StartEndLogic>();
            if (startendcontroller != null)
            {
                startendcontroller.ShowEndScreen();
                gameObject.SetActive(false); // Disable the trigger after it has been activated
            }
            else
            {
                Debug.LogWarning("StartEndLogic component not found in the scene.");
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
