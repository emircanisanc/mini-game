using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D ghostPlayerPf;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] TeleportSO teleportSO;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    bool isTeleporting;
    bool canMove = true;
    bool canTeleport = true;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ghostPlayerPf = Instantiate(ghostPlayerPf.gameObject).GetComponent<Rigidbody2D>();
        ghostPlayerPf.gameObject.SetActive(false);
    }

    void Start()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnDie += DisableMovement;
            playerHealth.OnBorn += EnableMovement;
        }
    }

    void Update()
    {
        if (!canMove)
            return;

        if (isTeleporting)
        {
            teleportSO.teleportTime.Value -= Time.deltaTime;
            if (teleportSO.teleportTime.Value <= 0)
            {
                StopTeleporting();
            }
            else
            {
                ghostPlayerPf.velocity = moveDirection * moveSpeed;
            }
        }
        else
        {
            teleportSO.skillDuration.Value += Time.deltaTime;
            rb2d.velocity = moveDirection * moveSpeed;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveDirection = ctx.ReadValue<Vector2>();
    }

    public void OnTeleport(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            StartTeleporting();
        }

        if (ctx.canceled)
        {
            StopTeleporting();
        }
    }

    private void StartTeleporting()
    {
        if (isTeleporting)
            return;

        if (!canMove || !canTeleport)
            return;


        if (teleportSO.skillDuration.Value >= teleportSO.skillMaxDuration.Value)
        {
            teleportSO.teleportTime.Value = teleportSO.teleportMaxTime.Value;
            isTeleporting = true;
            rb2d.velocity = Vector2.zero;
            ghostPlayerPf.transform.position = transform.position;
            ghostPlayerPf.gameObject.SetActive(true);
        }
    }

    private void StopTeleporting()
    {
        if (!isTeleporting)
            return;

        teleportSO.skillDuration.Value = 0;
        if (teleportSO.teleportTime.Value > 0)
        {
            teleportSO.teleportTime.Value = 0;
        }
        isTeleporting = false;
        ghostPlayerPf.gameObject.SetActive(false);
        ghostPlayerPf.velocity = Vector2.zero;
        if (canMove)
        {
            transform.position = ghostPlayerPf.transform.position;
        }
    }

    private void EnableMovement()
    {
        canMove = true;
    }

    private void DisableMovement()
    {
        rb2d.velocity = Vector2.zero;
        canMove = false;
        if (teleportSO.teleportTime.Value > 0)
        {
            teleportSO.teleportTime.Value = 0;
        }
        isTeleporting = false;
        ghostPlayerPf.gameObject.SetActive(false);
        ghostPlayerPf.velocity = Vector2.zero;
    }

    private void CancelTeleport()
    {
        teleportSO.skillDuration.Value = 0;
        if (teleportSO.teleportTime.Value > 0)
        {
            teleportSO.teleportTime.Value = 0;
        }
        isTeleporting = false;
        ghostPlayerPf.gameObject.SetActive(false);
        ghostPlayerPf.velocity = Vector2.zero;
    }

    public void DisableTeleport()
    {
        canTeleport = false;
    }

    public void EnableTeleport()
    {
        canTeleport = true;
    }
}
