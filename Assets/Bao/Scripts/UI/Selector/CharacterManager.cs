using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : AutoMonoBehaviour 
{
    [Header("[ Component ]"), Space(6)]
    [SerializeField] private CharacterLoader characterLoader;
    [SerializeField] private CharacterCarousel characterCarousel;

    [Header("[ Informations of character selected ]"), Space(6)]
    [SerializeField] private TextMeshProUGUI nameCharacter;
    [SerializeField] private int index = 0;
    [SerializeField] private string namePlayer = "Player_One";
    [SerializeField] private VSPanelLoadCharacterData vSPanelLoadCharacterData;

    public CharacterLoader CharacterLoader => this.characterLoader;
    public int Count => this.index;

    [ContextMenu("Load Compoent")] 
    protected override void LoadComponent() 
    {
        this.characterCarousel = transform.Find("Load Characters").GetComponent<CharacterCarousel>();
        this.characterLoader = transform.Find("Load Characters").GetComponent<CharacterLoader>();
        this.nameCharacter = transform.Find("Character Name Text").GetComponent<TextMeshProUGUI>();

        this.vSPanelLoadCharacterData = 
            GameObject.Find("Canvas")
                      .transform.Find("Battle VS Panel")
                      .GetComponent<VSPanelLoadCharacterData>();
    }

    protected virtual void Start()
    {
        this.nameCharacter.text = this.characterLoader.Characters[index].name;
        this.SaveDataPlayer();
    }

    public virtual void NextOption() 
    {
        int charactersCount = this.characterLoader.Characters.Count;
        int nextCharacterIndex = (this.index + 1) % charactersCount;
        this.index = nextCharacterIndex;

        this.UpdateCharacterDisplay(false);
        this.SaveDataPlayer();
    }

    public virtual void BackOption() 
    {
        int charactersCount = this.characterLoader.Characters.Count;
        int nextCharacterIndex = (this.index - 1 + charactersCount) % charactersCount;
        this.index = nextCharacterIndex;

        this.UpdateCharacterDisplay(true);
        this.SaveDataPlayer();
    }

    private Character RandomCharacter()
    {
        string randomCharacterName = "Random";
        int key = Random.Range(0, this.characterLoader.CharactersData.Count);

        while (this.characterLoader.CharactersData[key].NameCharacter.Equals(randomCharacterName))
            key = Random.Range(0, this.characterLoader.CharactersData.Count);
        return this.characterLoader.CharactersData[key];
    }

    private void SaveDataPlayer()
    {
        string name = this.characterLoader.Characters[index].name;
        string randomCharacterName = "Random";
        if (name.Equals(randomCharacterName))
        {
            name = this.RandomCharacter().NameCharacter;
            Debug.Log("Character random is :" + name, gameObject);
        }
        PlayerPrefs.SetString(this.namePlayer, name);
        this.vSPanelLoadCharacterData.LoadDataByName(this.namePlayer);
    }

    private void UpdateCharacterDisplay(
        bool isRotateRight
    ) {
        this.characterCarousel.RequestRotate(isRotateRight);
        this.nameCharacter.text = this.characterLoader.Characters[index].name;
    }
}
