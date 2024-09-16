using System;
using UnityEngine;

namespace Infrastructure.Services.InputManagement
{
    public interface IMovementInput
    {
        event Action<Vector2> MoveEvent;
        event Action JumpEvent;
        event Action RunEvent;
        event Action RunCancelledEvent;
        event Action<Vector2> LookEvent;
    }
}