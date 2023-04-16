using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSettings{
    private static AudioSettingsData musicConfiguration = new AudioSettingsData();
    
    // Getter
    public static float getVolumeMusic(){
        return AudioSettings.musicConfiguration.musicVolume;
    }
    public static float getVolumeSound(){
        return AudioSettings.musicConfiguration.soundVolume;
    }

    public static bool getIsOnMusic(){
        return AudioSettings.musicConfiguration.isMusicON;
    }

    public static bool getIsOnSound(){
        return AudioSettings.musicConfiguration.isSoundON;
    }
  
    // Setter
    public static void setVolumeMusic(float musicVolumeUpdated){
        AudioSettings.musicConfiguration.musicVolume = musicVolumeUpdated;
    }

    public static void setVolumeSound(float soundVolumeUpdated){
        AudioSettings.musicConfiguration.soundVolume = soundVolumeUpdated;
    }
    
    public static void setIsOnMusic(bool isOnMusicUpdated){
        AudioSettings.musicConfiguration.isMusicON = isOnMusicUpdated;
    }

    public static void setIsOnSound(bool isOnSoundUpdated){
        AudioSettings.musicConfiguration.isSoundON = isOnSoundUpdated;
    }

    // Loader
    public static void loadMusicConfData(){
        var json = PlayerPrefs.GetString("AudioConfData", "{}");
        AudioSettings.musicConfiguration = JsonUtility.FromJson<AudioSettingsData>(json);
    }

    // Saver
    public static void saveMusicConfData(){
        var json = JsonUtility.ToJson(AudioSettings.musicConfiguration);
        PlayerPrefs.SetString("AudioConfData", json);
    }
}

public static class IncGameState{
    public static int maxId = 0;
}

public static class GameStates{
    // Atribute for store game data
    private static ScoreData leaderboardContainer = new ScoreData();
    private static SlotNameData slotNameDatas = new SlotNameData();
    private static GameData currentGameData = new GameData();
    private static bool isOneHitKillActive = false;
    private static bool isFullHPPetActive = false;

    // Reset data
    public static void resetGameForTryAgain(){
        int tempIndexQuest = GameStates.getCurrentIndexQuest();
        if(tempIndexQuest==0){
            GameStates.setPoin(0);
        }else{
            GameStates.setPoin(GameStates.getPoinTimeStamp(tempIndexQuest-1));
        }
        GameStates.setSpeed(6f);
        GameStates.setDamage(0);
        GameStates.setIndexCurrentWeapon(0);
        GameStates.setCurrCoordinat(new Vector3());
        GameStates.setCameraPosition(new Vector3(1f, 15f, -22f));
        GameStates.setCurrHealth(100);
    }
    public static void resetGame(){
        GameStates.currentGameData = new GameData();
    }
    public static void resetEnemyData(int currindexQuest){
        GameStates.currentGameData.dataEnemy = new EnemyData(currindexQuest);
    }

    // Adder
    public static void addLeaderboard(string name, double duration){
        Score temp = new Score(name, duration);
        GameStates.leaderboardContainer.addData(temp);
    }
    
    // Setter
    public static void setPoinTimeStamp(int value, int indx){
        GameStates.currentGameData.dataPlayer.poinTimestamp[indx] = value;
    }
    public static void setCameraPosition(Vector3 cameraUpdated){
        GameStates.currentGameData.dataPlayer.mainCameraPosition = cameraUpdated;
    }
    public static void setEnemyCount(int enemyCountUpdated){
        GameStates.currentGameData.dataEnemy.enemyCount = enemyCountUpdated;
    }
    public static void setSpawnBossIsActive(bool isActive){
        GameStates.currentGameData.dataEnemy.spawnBossNow = isActive;
    }
    public static void setIsBossDefeated(bool isDefeated){
        GameStates.currentGameData.dataEnemy.isBossDefeated = isDefeated;
    }
    public static void setIsMiniBossSpawn(bool isSpawn){
        GameStates.currentGameData.dataEnemy.isMiniBossSpawn = isSpawn;
    }
    public static void setActiveEnemy(bool isActive, int id){
        GameStates.currentGameData.dataEnemy.enemyData[id].isActive = isActive;
    }
    public static void setCurrRotation(Quaternion rotationUpdated){
        GameStates.currentGameData.dataPlayer.currentRotation = rotationUpdated;
    }
    public static void setPetRotation(Quaternion rotationUpdated, int idx){
        GameStates.currentGameData.dataPlayer.petInventory[idx].currentRotation = rotationUpdated;
    }
    public static void setEnemyRotation(Quaternion rotationUpdated, int id){
        GameStates.currentGameData.dataEnemy.enemyData[id].currentRotation = rotationUpdated;
    }
    public static void setSpeed(float speedUpdated){
        GameStates.currentGameData.dataPlayer.speed = speedUpdated;
    }
    public static void setDamage(int addDamageUpdated){
        GameStates.currentGameData.dataPlayer.damage = addDamageUpdated;
    }
    public static void setHealthEnemy(int healthUpdated, int id){
        GameStates.currentGameData.dataEnemy.enemyData[id].enemyHealth = healthUpdated;
    }
    public static void setEnemyCoordinat(Vector3 coordinatUpdated, int id){
        GameStates.currentGameData.dataEnemy.enemyData[id].coordinat = coordinatUpdated;
    }
    public static void setWeaponData(bool isAvailable, int level, int damage, int indexOfWeaponData){
        GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData] = new WeaponData(isAvailable, level, damage);
    }
    public static void setIsExistWeapon(bool isExist, int indexOfWeaponData){
        GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].isExist = isExist;
    }
    public static void setLevelWeapon(int level, int indexOfWeaponData){
        GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].level = level;
    }
    public static void setDamageWeapon(int damage, int indexOfWeaponData){
        GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].damage = damage;
    }
    public static void setPetData(PetData petDataUpdated, int numberOfPetData){
        GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData] = petDataUpdated;
    }
    public static void setPetDataIsExist(bool isExist, int numberOfPetData){
        GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].isExist = isExist;
    }
    public static void setPetHealth(int healthUpdated, int numberOfPetData){
        GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].hp = healthUpdated;
    }
    public static void setPetCoordinate(Vector3 coordinateUpdated, int numberOfPetData){
        GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].coordinat = coordinateUpdated;
    }
    public static void setSlot1Name(string name){
        GameStates.slotNameDatas.slot1Name = name;
    }
    public static void setSlot2Name(string name){
        GameStates.slotNameDatas.slot2Name = name;
    }
    public static void setSlot3Name(string name){
        GameStates.slotNameDatas.slot3Name = name;
    }
    public static void setPoin(int updatedPoin){
        GameStates.currentGameData.dataPlayer.poin = updatedPoin;
    }

    public static void setPlayerName(string name){
        GameStates.currentGameData.dataPlayer.name = name;
    }

    public static void setCurrDuration(double updatedDuration){
        GameStates.currentGameData.dataPlayer.duration = updatedDuration;
    }

    public static void setCurrHealth(int updatedHealth){
        GameStates.currentGameData.dataPlayer.health = updatedHealth;
    }

    public static void setIndexCurrentWeapon(int updatedIndexWeapon){
        GameStates.currentGameData.dataPlayer.indexCurrentWeapon = updatedIndexWeapon;
    }

    public static void setCurrIndexPet(int updatedIndexPet){
        GameStates.currentGameData.dataPlayer.indexPet = updatedIndexPet;
    }

    public static void setCurrCoordinat(Vector3 coordinatUpdated) {
        GameStates.currentGameData.dataPlayer.currentCoordinat = coordinatUpdated;
    }
    public static void setCurrentIndexQuest(int updatedCurrentIndexQuest){
        GameStates.currentGameData.dataEnemy = new EnemyData(updatedCurrentIndexQuest);
        GameStates.currentGameData.dataPlayer.currindexQuest = updatedCurrentIndexQuest;
    }

    public static void setOneHitKillActive(bool isOneHitKillActive){
        GameStates.isOneHitKillActive = isOneHitKillActive;
    }

    public static void setFullHPPetActive(bool isFullHPPetActive){
        GameStates.isFullHPPetActive = isFullHPPetActive;
    }

    // Getter
    public static int getPoinTimeStamp(int indx){
        return GameStates.currentGameData.dataPlayer.poinTimestamp[indx];
    }
    public static Vector3 getCameraPosition(){
        return GameStates.currentGameData.dataPlayer.mainCameraPosition;
    }
    public static int getEnemyCount(){
        return GameStates.currentGameData.dataEnemy.enemyCount;
    }
    public static bool getSpawnBossIsActive(){
        return GameStates.currentGameData.dataEnemy.spawnBossNow;
    }
    public static bool getIsBossDefeated(){
        return GameStates.currentGameData.dataEnemy.isBossDefeated;
    }
    public static bool getIsMiniBossSpawn(){
        return GameStates.currentGameData.dataEnemy.isMiniBossSpawn;
    }
    public static bool getEnemyIsActived(int id){
        return GameStates.currentGameData.dataEnemy.enemyData[id].isActive;
    }
    public static float getSpeed(){
        return GameStates.currentGameData.dataPlayer.speed;
    }
    public static int getDamage(){
        return GameStates.currentGameData.dataPlayer.damage;
    }
    public static bool getPetDataIsExist(int numberOfPetData){
        return GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].isExist;
    }
    public static int getPetHealth(int numberOfPetData){
        return GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].hp;
    }
    public static Vector3 getPetCoordinate(int numberOfPetData){
        return GameStates.currentGameData.dataPlayer.petInventory[numberOfPetData].coordinat;
    }
    public static Quaternion getPetRotation(int indexPetData){
        return GameStates.currentGameData.dataPlayer.petInventory[indexPetData].currentRotation;
    }
    public static Quaternion getEnemyRotation(int id){
        return GameStates.currentGameData.dataEnemy.enemyData[id].currentRotation;
    }
    public static Quaternion getCurrRotation(){
        return GameStates.currentGameData.dataPlayer.currentRotation;
    }
    public static int getHealthEnemy(int id){
        // Debug.Log("enemy name : " + GameStates.currentGameData.dataEnemy.enemyData[id].getEnemyName());
        return GameStates.currentGameData.dataEnemy.enemyData[id].enemyHealth;
    }
    public static int getCurrentPoin(){
        return GameStates.currentGameData.dataPlayer.poin;
    }
    public static string getSlot1Name(){
        return GameStates.slotNameDatas.slot1Name;
    }
    public static string getSlot2Name(){
        return GameStates.slotNameDatas.slot2Name;
    }
    public static string getSlot3Name(){
        return GameStates.slotNameDatas.slot3Name;
    }
    public static int getCurrentIndexQuest(){
        return GameStates.currentGameData.dataPlayer.currindexQuest;
    }
    public static string getCurrentMainScene(){
        int tempcurrentQuest = GameStates.getCurrentIndexQuest()+1;
        if(tempcurrentQuest==1) return "Level_01";
        else if(tempcurrentQuest==2) return "Level_02";
        else if(tempcurrentQuest==3) return "Level_03";
        else return "Level_04";
    }
    public static ScoreData getLeaderboardList(){
        return GameStates.leaderboardContainer;
    }
    public static List<Enemy> getEnemyDataList(){
        return GameStates.currentGameData.dataEnemy.enemyData;
    }
    public static Enemy getEnemyData(int id){
        return GameStates.currentGameData.dataEnemy.enemyData[id];
    }
    public static List<WeaponData> getListWeaponInventory(){
        return GameStates.currentGameData.dataPlayer.weaponInventory;
    }
    public static bool getIsExistWeapon(int indexOfWeaponData){
        return GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].isExist;
    }
    public static int getLevelWeapon(int indexOfWeaponData){
        return GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].level;
    }
    public static int getDamageWeapon(int indexOfWeaponData){
        return GameStates.currentGameData.dataPlayer.weaponInventory[indexOfWeaponData].damage;
    }

    public static List<PetData> getListPetInventory(){
        return GameStates.currentGameData.dataPlayer.petInventory;
    }

    public static Vector3 getCurrCoordinat(){
        return GameStates.currentGameData.dataPlayer.currentCoordinat;
    }

    public static Vector3 getEnemyCoordinat(int id){
        return GameStates.currentGameData.dataEnemy.enemyData[id].coordinat;
    }

    public static string getCurrentPlayerName(){
        return GameStates.currentGameData.dataPlayer.name;
    }

    public static double getCurrDuration(){
        return GameStates.currentGameData.dataPlayer.duration;
    }

    public static int getCurrHealth(){
        return GameStates.currentGameData.dataPlayer.health;
    }

    public static int getIndexCurrWeapon(){
        return GameStates.currentGameData.dataPlayer.indexCurrentWeapon;
    }

    public static int getCurrIndexPet(){
        return GameStates.currentGameData.dataPlayer.indexPet;
    }

    public static bool getOneHitKillActive(){
        return GameStates.isOneHitKillActive;
    }

    public static bool getFullHPPetActive(){
        return GameStates.isFullHPPetActive;
    }

    // Loader
    public static void loadLeaderboard(){
        var json = PlayerPrefs.GetString("leaderboardListStore", "{}");
        leaderboardContainer = JsonUtility.FromJson<ScoreData>(json);
    }

    public static void loadDataSlot1(){
        var json = PlayerPrefs.GetString("slot1DataStore", "{}");
        GameStates.currentGameData = JsonUtility.FromJson<GameData>(json);
    }

    public static void loadDataSlot2(){
        var json = PlayerPrefs.GetString("slot2DataStore", "{}");
        GameStates.currentGameData = JsonUtility.FromJson<GameData>(json);
    }

    public static void loadDataSlot3(){
        var json = PlayerPrefs.GetString("slot3DataStore", "{}");
        GameStates.currentGameData = JsonUtility.FromJson<GameData>(json);
    }

    public static void loadSlotNameData(){
        var json = PlayerPrefs.GetString("slotNameDataStore", "{}");
        GameStates.slotNameDatas = JsonUtility.FromJson<SlotNameData>(json);
    }

    // Saver
    public static void saveLeaderboard(){
        var json = JsonUtility.ToJson(GameStates.leaderboardContainer);
        PlayerPrefs.SetString("leaderboardListStore", json);
    }
    
    public static void saveSlotData1(){
        var json = JsonUtility.ToJson(GameStates.currentGameData);
        // Debug.Log(json);
        PlayerPrefs.SetString("slot1DataStore", json);
    }

    public static void saveSlotData2(){
        var json = JsonUtility.ToJson(GameStates.currentGameData);
        // Debug.Log(json);
        PlayerPrefs.SetString("slot2DataStore", json);
    }

    public static void saveSlotData3(){
        var json = JsonUtility.ToJson(GameStates.currentGameData);
        // Debug.Log(json);
        PlayerPrefs.SetString("slot3DataStore", json);
    }

    public static void saveSlotNameData(){
        var json = JsonUtility.ToJson(GameStates.slotNameDatas);
        // Debug.Log(json);
        PlayerPrefs.SetString("slotNameDataStore", json);
    }
}