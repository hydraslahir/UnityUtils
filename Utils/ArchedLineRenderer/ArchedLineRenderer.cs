using HYDRA;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(LineRenderer))]
public class ArchedLineRenderer : MonoBehaviour
{
    [HideInInspector]
    public LineRenderer LineRenderer;
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.material = Instantiate(ResourcesExtensions.LoadOrThrow<Material>("ArcMaterial"));
        LineRenderer.shadowCastingMode = ShadowCastingMode.Off;
    }

    public void SetColor(Color color)
    {
        LineRenderer.material.color = color;
    }

    public GameObject Origin;
    public GameObject Destination;

    [SerializeField]
    public int Resolution = 10;
    [SerializeField]
    public float Width = 0.1f;

    void Update()
    {
        bool valid = Origin && Destination;
        LineRenderer.enabled = valid;
        if (!valid)
            return;

        LineRenderer.positionCount = Resolution + 1;
        LineRenderer.startWidth = Width;
        LineRenderer.endWidth = Width;

        var start = Origin.transform.position;
        var end = Destination.transform.position;

        for (int i = 0; i < Resolution; i++)
        {
            LineRenderer.SetPosition(i, SampleParabola(start, end, 2, i / (float)Resolution, Vector3.up));
        }
        LineRenderer.SetPosition(Resolution, end);
    }

    Vector3 SampleParabola(Vector3 start, Vector3 end, float height, float t, Vector3 outDirection)
    {
        float parabolicT = (t * 2) - 1;
        //start and end are not level, gets more complicated
        Vector3 travelDirection = end - start;
        Vector3 levelDirection = end - new Vector3(start.x, end.y, start.z);
        Vector3 right = Vector3.Cross(travelDirection, levelDirection);
        Vector3 up = outDirection;
        Vector3 result = start + (t * travelDirection);
        result += ((-parabolicT * parabolicT) + 1) * height * up.normalized;
        return result;
    }
}
