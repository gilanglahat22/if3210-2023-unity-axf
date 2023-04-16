using UnityEngine;
using System;

public abstract class Command
{
    public abstract void Execute();
}

public class MoveCommand : Command
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement _playerMovement, float _h, float _v)
    {
        this.playerMovement = _playerMovement;
        this.h = _h;
        this.v = _v;
    }

    //Trigger perintah movement
    public override void Execute()
    {
        playerMovement.Move(h, v);
        playerMovement.Turning();
        //Menganimasikan player
        playerMovement.Animating(h, v);
    }

}

public class ShootCommand : Command
{

    PlayerWeapon playerWeapon;

    public ShootCommand(PlayerWeapon _playerWeapon)
    {
        playerWeapon = _playerWeapon;
    }

    public override void Execute()
    {
        //Player menembak
        playerWeapon.Shoot();
    }


}

public class OpenCloseCheatMenuCommand : Command
{
          GameManager gameManager;
        public OpenCloseCheatMenuCommand(GameManager _gameManager)
        {
                gameManager = _gameManager;
        }

        public override void Execute()
        {
                // Debug.Log("EXECUTE");
                gameManager.OpenCloseCheatMenu();
        }

}

public class OpenCloseShopkeeperCommand : Command
{
        GameManagerShopkeeper gameManagerShopkeeper;
        public OpenCloseShopkeeperCommand(GameManagerShopkeeper _gameManagerShopkeeper)
        {
                gameManagerShopkeeper = _gameManagerShopkeeper;
        }

        public override void Execute()
        {
                gameManagerShopkeeper.OpenCloseShopkeeper();
        }
}

public class ChangeWeaponCommand : Command
{
        PlayerWeapon playerWeapon;
        int currentWeaponIndex;
        public ChangeWeaponCommand(PlayerWeapon _playerWeapon, int _currentWeaponIndex)
        {
                playerWeapon = _playerWeapon;
                currentWeaponIndex = _currentWeaponIndex;
        }

        public override void Execute()
        {
                playerWeapon.ChangeWeapon(currentWeaponIndex);
        }
}

public class UpdateBowForceCommand : Command
{
        BowForce bowForce;
        float holdDownTime;
        public UpdateBowForceCommand(BowForce _bowForce, float _holdDownTime)
        {
                bowForce = _bowForce;
                holdDownTime = _holdDownTime;
        }

        public override void Execute()
        {
                bowForce.UpdateBowForce(holdDownTime);
        }
}