using UnityEngine;
using UnityEngine.UI;

public class CardManagerBehaviour : MonoBehaviour
{
    public enum card //todos los elementos, ordenados 
    {
        card2,
        card1
    }
    public card selection = card.card1;
    public card[] orderedCards;
    public Button[] orderedButtons;
    public void Awake()
    {
        for (int i = 0; i < orderedButtons.Length; i++)
        {
            orderedButtons[i].onClick.AddListener(() =>
            {
                selection = orderedCards[i];
                //
                //codigo de visibiliidad de seleccion
                //
            });
        }
    }
}