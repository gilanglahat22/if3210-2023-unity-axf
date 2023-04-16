using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public GameManagerShopkeeper gameManagerShopkeeper;
    public PlayerWeapon playerWeapon;
    public BowForce bowForce;

    float holdDownStartTime = 0;

    void FixedUpdate()
    {
        //Menghandle input movement
        Command moveCommand = InputMovementHandling();
        if (moveCommand != null)
        {
            moveCommand.Execute();
        }
    }

    void Update()
    {
        //Mengahndle shoot
        Command shootCommand = InputShootHandling();
        if (shootCommand != null)
        {
            shootCommand.Execute();
        }
        //Menghandle cheat menu
        Command openCloseCheatMenuCommand = InputOpenCloseCheatMenuHandling();
        if (openCloseCheatMenuCommand != null)
        {
            // Debug.Log("TEST");
            openCloseCheatMenuCommand.Execute();
        }

        //Menghandle open shopkeeper
        Command OpenCloseShopkeeperCommand = InputOpenShopkeeperHandling();
        if (OpenCloseShopkeeperCommand != null)
        {
            OpenCloseShopkeeperCommand.Execute();
        }

        Command changeWeaponViaMouseScrollHandlingCommand = ChangeWeaponViaMouseScrollHandling();
        if (changeWeaponViaMouseScrollHandlingCommand != null)
        {
            changeWeaponViaMouseScrollHandlingCommand.Execute();
        }

        Command changeWeaponViaNumberKeyHandlingCommand = ChangeWeaponViaKeyboardHandling();
        if (changeWeaponViaNumberKeyHandlingCommand != null)
        {
            changeWeaponViaNumberKeyHandlingCommand.Execute();
        }

        if (playerWeapon.currentWeaponIndex == 3) {
            Command pullReleaseBowHandling = PullReleaseBowHandling();
            if (pullReleaseBowHandling != null)
            {
                pullReleaseBowHandling.Execute();
            }
        }
    }

    Command InputMovementHandling()
    {
        //Check jika movement sesuai dengan key nya
        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }
        else
        {
            return new MoveCommand(playerMovement, 0, 0); ;
        }
    }

    Command InputOpenShopkeeperHandling()
    {
        //Jika menekan tombol M trigger open shopkeeper command
        if (Input.GetKeyDown(KeyCode.M))
        {
            return new OpenCloseShopkeeperCommand(gameManagerShopkeeper);
        }
        else
        {
            return null;
        }
    }


    
    Command InputShootHandling()
    {
        //Jika menembak trigger shoot command
        if (Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerWeapon);
        }
        else
        {
            return null;
        }
    }

    Command InputOpenCloseCheatMenuHandling()
    {
        //Jika menekan tombol Z trigger open close cheat menu command
        if (Input.GetKeyDown(KeyCode.Z))
        {   
            // Debug.Log("MASUK Z");
            return new OpenCloseCheatMenuCommand(gameManager);
        }
        else
        {
            return null;
        }
    }

    Command ChangeWeaponViaMouseScrollHandling()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        int currentWeaponIndex = playerWeapon.currentWeaponIndex;
        int weaponsLength = playerWeapon.weapons.Length;
        if (scroll > 0f)
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weaponsLength - 1;
            }

        }
        else if (scroll < 0f)
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= weaponsLength)
            {
                currentWeaponIndex = 0;
            }
        }
        return new ChangeWeaponCommand(playerWeapon, currentWeaponIndex);
    }

    Command ChangeWeaponViaKeyboardHandling()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return new ChangeWeaponCommand(playerWeapon, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return new ChangeWeaponCommand(playerWeapon, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return new ChangeWeaponCommand(playerWeapon, 2);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return new ChangeWeaponCommand(playerWeapon, 3);
        }
        else
        {
            return null;
        }
    }

    Command PullReleaseBowHandling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Debug.Log("Mouse button down");
            holdDownStartTime = Time.time;
            return new UpdateBowForceCommand(bowForce, 0);
        }

        else if (Input.GetMouseButton(1))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            return new UpdateBowForceCommand(bowForce, holdDownTime);
        }
        
        else if (Input.GetMouseButtonUp(1))
        {
            // Debug.Log("Mouse button up");
            return new ShootCommand(playerWeapon);
        }

        else
        {
            return null;
        }
    }
}


