using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;
using System.Collections;
using System;
using System.Net;
using Assets.scripts.utils;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public string Name { get; set; }

    // Game Settings
    public string Language { get; set; }

    // WordBrain

    public int CurrentHints { get; set; }

    public string ActiveCategory { get; set; }

    public int ActiveLevelIndex { get; set; }

    public int ActiveDailyPuzzleIndex { get; set; }

    public DateTime NextDailyPuzzleAt { get; set; }
    public int ShowReviewAtLevel { get; set; }
    public bool SeenReviewScreen { get; set; }
    public bool GaveReview { get; set; }
    public bool RefusedReview { get; set; }
    public bool NoLike { get; internal set; }

    public Dictionary<string, bool> CompletedLevels;

    public Dictionary<string, BoardState> SavedBoardStates;

    //

    public static User FillData(string properties)
    {
        return new User
        {
            Id = utils.GetIntDataValue(properties, "ID:"),
            Name = utils.GetDataValue(properties, "Name:")
        };
    }
}

/// <summary>
/// Holds infomation about the state of a board that is being play.
/// </summary>
public class BoardState
{
    public enum TileState
    {
        NotUsed,
        Found,
        UsedButNotFound
    }
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string wordBoardId { get; set; }      // Unique id for this board

    public int wordBoardSize { get; set; }       // The size of the board

    public string[] words;              // The words in the board
    public bool[] foundWords;           // The words that have been found (index in foundWords corresponds to index in words)
    public TileState[] tileStates;          // The state of each tile on the board
    public char[] tileLetters;      // The letter that goes in each tile on the board

    public int NextHintIndex
    {
        get
        {
            return nextHintIndex;
        }
        set
        {
            nextHintIndex = value;
        }
    }
    public int nextHintIndex;       // The index into words that indicates which word will have a letter shown when the hint button it clicked
    public List<int[]> hintLettersShown;    // The letters that have been shown by hints. (List of int[2] where the first element is the word index and the second element is the letter index)
}

public class Level
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Image { get; set; }

    [Ignore]
    public string Word
    {
        get
        {
            //var selectedLanguage = Main.Instance().LoggedUser.Language.ToLower();
            //if (selectedLanguage == "en_us")
            //    return Engleza;
            //if (selectedLanguage == "pt_pt" || selectedLanguage == "pt_br")
            //    return Portugheza;
            return Romana;
        }
    }

    public string Romana { get; set; }
    public string Engleza { get; set; }
    public string Portugheza { get; set; }

    public override string ToString()
    {
        return string.Format(@"
            Id={0}, 
            Image={1}, 
            Romana={2}, 
            Engleza={3},
            Portugheza={4}",
            Id,
            Image,
            Romana,
            Engleza,
            Portugheza);
    }
}