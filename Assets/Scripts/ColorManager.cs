using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer sr; // Sprite renderer
    public string currentColor; // Current color
    public Color colorCyan; // Cyan color
    public Color colorYellow; // Yellow color
    public Color colorMagenta; // Magenta color
    public Color colorPink; // Pink color

    private void Start()
    {
        SetRandomColor(); // Set an initial random color
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4); // Random index
        switch (index)
        {
            case 0:
                currentColor = "cyan"; // Set cyan
                sr.color = colorCyan; // Apply cyan
                break;
            case 1:
                currentColor = "yellow"; // Set yellow
                sr.color = colorYellow; // Apply yellow
                break;
            case 2:
                currentColor = "magenta"; // Set magenta
                sr.color = colorMagenta; // Apply magenta
                break;
            case 3:
                currentColor = "pink"; // Set pink
                sr.color = colorPink; // Apply pink
                break;
        }
    }
}
