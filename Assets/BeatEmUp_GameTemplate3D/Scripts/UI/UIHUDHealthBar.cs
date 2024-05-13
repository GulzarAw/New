using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIHUDHealthBar : MonoBehaviour {

	public Text nameField;
	public Image playerPortrait;
	public Slider HpSlider;
	public bool isPlayer;
    HealthSystem healthSystem ;

    void OnEnable() {
		HealthSystem.onHealthChange += UpdateHealth;
        if (isPlayer) SetPlayerPortraitAndName();
    }

    void OnDisable() {
		HealthSystem.onHealthChange -= UpdateHealth;
	}

	void Start(){
		if(!isPlayer) Invoke("HideOnDestroy", Time.deltaTime); //hide enemy healthbar at start
		if(isPlayer) SetPlayerPortraitAndName();
	}

	void UpdateHealth(float percentage, GameObject go){
		if(isPlayer && go.CompareTag("Player")){
			HpSlider.value = percentage;
		} 	

		if(!isPlayer && go.CompareTag("Enemy")){
			HpSlider.gameObject.SetActive(true);
			HpSlider.value = percentage;
			nameField.text = go.GetComponent<EnemyActions>().enemyName;
			if(percentage == 0) Invoke("HideOnDestroy", 2);
		}
	}

	void HideOnDestroy(){
		HpSlider.gameObject.SetActive(false);
		nameField.text = "";
	}

	//loads the HUD icon of the player from the player prefab (Healthsystem)
	void SetPlayerPortraitAndName(){
		if(playerPortrait != null){
			
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if(!healthSystem)
			{
				healthSystem = player.GetComponent<HealthSystem>();
			}

			if(player && healthSystem != null){

				Debug.LogError("set_");
				//set portrait
				Sprite HUDPortrait = healthSystem.HUDPortrait;
				playerPortrait.overrideSprite = HUDPortrait;

				//set name
				nameField.text = healthSystem.PlayerName;
			}
		}
	}
}
