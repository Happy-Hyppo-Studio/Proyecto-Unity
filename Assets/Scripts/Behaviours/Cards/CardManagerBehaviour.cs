using UnityEngine;
using UnityEngine.UI;

public class CardManagerBehaviour : MonoBehaviour
{
    
    public int selection = 0;
    public card[] orderedCards;
    public Button[] orderedButtons;
    public Image selectedAlly;

    public void Awake()
    {
        for (int i = 0; i < orderedButtons.Length; i++)
        {
            int sel = i;
            orderedButtons[i].onClick.AddListener(() =>
            {
                Debug.Log(selection);
                selection = sel;

                selectedAlly.GetComponent<RectTransform>().localPosition = new Vector3 (-200.0f+135.0f*sel, 0.0f, 0.0f);
            });
        }
    }
}