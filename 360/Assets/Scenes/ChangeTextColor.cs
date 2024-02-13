using UnityEngine;
using TMPro;

public class ChangeTextColor : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Color originalColor;

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        originalColor = textMeshPro.color;
    }

    public void HoverIn()
    {
        // Changez la couleur du texte vers le bleu #52BBEA
        textMeshPro.color = new Color(0.3215686f, 0.7333333f, 0.9176471f);
    }

    public void HoverOut()
    {
        // Revenez à la couleur d'origine
        textMeshPro.color = originalColor;
    }
}
