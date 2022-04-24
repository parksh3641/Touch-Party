using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour
{

}

public enum GamePlayType
{
    GameChoice1 = 0,
    GameChoice2,
    GameChoice3,
    GameChoice4,
    GameChoice5,
    GameChoice6,
    GameChoice7,
    GameChoice8
}

public enum OptionType
{
    Music = 0,
    SFX,
    Language,
    Logout
}

public enum LanguageType
{
    Korean = 0,
    English
}

public enum LoginType
{
    None = 0,
    Guest,
    Google,
    Facebook
}

public enum MoneyType
{
    Gold = 0,
    Crystal
}