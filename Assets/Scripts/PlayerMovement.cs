using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 startingPosition;

    public Transform boundaryHolder;

    Boundary playerBoundary;

    public Collider2D playerCollider { get; private set; }

    public PlayerController Controller;

    public int? LockedFingerID { get; set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(boundaryHolder.GetChild(0).position.y,
                                      boundaryHolder.GetChild(1).position.y,
                                      boundaryHolder.GetChild(2).position.x,
                                      boundaryHolder.GetChild(3).position.x);
    }

    private void OnEnable()
    {
        Controller.Players.Add(this);
    }
    private void OnDisable()
    {
        Controller.Players.Remove(this);
    }

    public void MoveToPosition(Vector2 position)
    {
        Vector2 clampedMousePos = new Vector2(Mathf.Clamp(position.x, playerBoundary.Left,
                                                                              playerBoundary.Right),
                                                      Mathf.Clamp(position.y, playerBoundary.Down,
                                                                              playerBoundary.Up));

        rb.MovePosition(clampedMousePos);
    }

    public void ResetPosition()
    {
        rb.position = new Vector2 (0,-4);
    }
}
