using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineWidth = 0.05f;

    private Material outlineMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        // Create a new material based on the outline shader
        outlineMaterial = new Material(Shader.Find("Custom/OutlineShader"));
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has the "InteractObjects" tag
            if (hit.collider.CompareTag("InteractObjects"))
            {
                // Set shader properties
                outlineMaterial.SetColor("_Color", outlineColor);
                outlineMaterial.SetFloat("_Outline", outlineWidth);

                // Apply the outline material
                objectRenderer.material = outlineMaterial;
            }
            else
            {
                // Revert to the original material
                objectRenderer.material = originalMaterial;
            }
        }
    }
}
