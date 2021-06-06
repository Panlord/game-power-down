using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreManager : MonoBehaviour 
{
    private List<LoreItem> BaseList;
    private List<LoreItem> PossibleEntries;
    private List<LoreItem> LoreInventory;

    public LoreManager()
    {
        this.BaseList = new List<LoreItem>();
        this.LoreInventory = new List<LoreItem>();

        this.BaseList.Add(new LoreItem("I got chosen! This is a dream come true! An assistant job under a world-renowned professor in my field!\n\nI’ve seen his work and its quality is out of this world. I already have a huge amount of respect for him.\n\nI’m really, really looking forward to the first day!", "Journal 01", false));
        this.BaseList.Add(new LoreItem("I met professor for the first time today. He was really charismatic, just like how everyone expected him to be. Though, besides that sociable exterior, I could tell he was kind of distant and withdrawn.\n\nOur research topic is going to be on the development of a cure for what is currently considered to be an “incurable disease.” Professor claims that such technology would revolutionize medicine.\n\nI don’t think any of us have ever been more excited.", "Journal 02", false));
        this.BaseList.Add(new LoreItem("It’s been a really rough few months. None of the experimental cures seem to be working. Most of my colleagues have left. The rest are seriously considering leaving. They think this research is a dead end. One even joked that professor would have to go full on occult to achieve anything.\n\nProfessor is starting to look more exhausted by the day. Maybe he’s losing hope. As long as I’m here, I’ll take care of him and make sure he is in good health. If anything, more people around will motivate him to keep going.\n\nI’m going to stay here until the end."
        , "Journal 03", false));  
        this.BaseList.Add(new LoreItem("I sometimes hear professor muttering to himself when he’s alone. \n\nThings about how “this is what I must do,” “this is all for her,” and “I hope whatever out there forgives me.”\n\nI can’t go too close to him or else he’d notice me, but he seems to be getting more and more distressed as this research goes on. I don’t think I’ve ever seen him leave this building either.\n\nI’m not confident enough to ask him what’s wrong. As an added precaution, however, I’ll be more gentle around him and keep closer attention to his condition.", "Journal 04", false));
        this.BaseList.Add(new LoreItem("Professor’s office was the worst. There were papers and books scattered everywhere. I took it upon myself to organize everything. That was when I came across a particular sketchbook.\n\nOn the first page was a portrait of a beautiful woman. The rest of the pages were blank. I didn’t know professor was such an artist. Or, is he secretly a legendary story writer? This seems to be a very important work in progress.\n\nA few minutes later, sitting and thinking in absolute silence, I found that interest quickly turning into despair.", "Journal 05", false));
        this.BaseList.Add(new LoreItem("I couldn’t save him. He’s not recognizable to me anymore, and I don’t think he recognizes me.\n\nAll I can do now is run.\n\nNot sure how much energy I have left in me. I’m exhausted, but I have to keep moving.\n\nThink to yourself. There has to be something you can do.", "Journal 06", false));
        this.BaseList.Add(new LoreItem("I’m at my limit. I can’t run any longer. Soon he will find me. \n\nThis is my final play. With the press of a button the message has been scheduled.\n\nI have no regrets. Rather, I am hopeful, hopeful that they will come. Knowing them and how long it has been, that is a guarantee. Then, they will set us free.\n\nAh, someone’s banging on the door. I’ll see you later.", "Journal 07", false));

        this.BaseList.Add(new LoreItem("The diagnosis brings despair. \n\nAn incurable disease. Nothing can be done about it. All you can do is give them the most comfort as you watch them wither away.\n\nBut I refuse this reality. I am world-renowned in this field. If there is anyone who can develop a cure, it has to be me. I love her. She is my everything. I will not let her go.", "Note 01", false));
        this.BaseList.Add(new LoreItem("How long have I been here?\n\nDays? Weeks? Months? I cannot remember. Everyone has left me except for one. \n\nNone of the experiments are working. It just will not go away. Her condition gets worse and worse by the day. I do not have much time left.", "Note 02", false));
        this.BaseList.Add(new LoreItem("Perhaps science is not the answer.\n\nI learned from some studies about the art of the occult. Unlimited strength, eternal youth, immortality. It all seemed too good to be true. Yet, it is theorized that these ends are indeed possible. However, no one in their right mind would do something so immoral.\n\nBut what if the goal was to make a cure-all? It would revolutionize medicine. No one would ever get sick again. It would be the greatest benefit to mankind.\n\nNo, stop convincing yourself that any of this is good.", "Note 03", false));
        this.BaseList.Add(new LoreItem("I do believe in something.\n\nReligion was created to explain what science cannot. The idea of gods and myths tell stories of how things came to be, but we cannot confirm those things for ourselves. After all, we are merely humans, unable to transcend to these supernatural areas of godhood.\n\nI am a scientist. I believe that if one states something, they must prove its existence. However, I would not be lying if I said I did not believe in gods, or at least, some natural force that made everything come to be.\n\nSo, whatever being is out there, watching over me, I dearly hope you will forgive me for what I will do.", "Note 04", false));
        this.BaseList.Add(new LoreItem("I had to do it.\n\nThere was no time left. In my tightening hand is this sketchbook, once rife with blank, white pages. Now, the first page houses a beautiful portrait of her. \n\nDo not worry. You will not stay there forever. One day, you can be free. For you, it is a matter of time.\n\nFor me, the monster called time is no more.", "Note 05", false));
        this.BaseList.Add(new LoreItem("There is so much potential in these occult arts. This new vector of modification in living cells leaves unlimited possibilities in what combinations I can find.\n\nBut most of these experiments require a sacrifice. A living thing to test it on. All of the mice have decayed long ago. There is my only assistant. Perhaps, I could ask-\n\nAbsolutely not. She was the only one who did not leave me in this time of hardship. I respect her for that.\n\nThe only one who should suffer should be me.", "Note 06", false));
        this.BaseList.Add(new LoreItem("RUN", "Note 07", true));

        this.BaseList.Add(new LoreItem("WhY Do tHeY KeEp cOmInG.\n\nI Am mInDiNg mY OwN BuSiNeSs. SeArChInG FoR ThE CuRe.\n\ntHeY PrObAbLy wAnT 'iT'.\n\nI WiLl nOt lEt tHeM.\n\ntHeY WiLl nOt tAkE HeR FrOm mE.\n\nThEy cAn PrY It.\n\nfRoM ThEsE MaLfOrMeD HaNdS.", "??? 01", true));
        this.BaseList.Add(new LoreItem("aHaHaHaHaHaHaHa\n\nA FrEsH ShIpMeNt oF MiCe\n\nVoLuNtEeRiNg tO BeCoMe pArT Of gReAtEr gOoD\n\ni jUsT HaVe tO CaTcH ThEm\n\nTo aDd tHeM To tHe cOlLeCtIoN\n\ncOmE OuT CoMe oUt\n\nWhErEvEr yOu aRe", "??? 02", true));
        this.BaseList.Add(new LoreItem("EhEhEhE\n\ntHe tEsTs aRe gOiNg vErY WeLl\n\nThOsE TeStS\n\ntEsTs tO RiD ThAt tHaT ThAt 'ThInG'\n\nThAnKs tO ThEsE NeW MiCe\n\nBuT I LeArN My lEsSoN\n\nnO DeCaY ThIs tImE\n\nsHe wIlL HaVe mIcE To aCcOmPaNy hEr\n\nInStEaD!!!!!!", "??? 03", true));
        this.BaseList.Add(new LoreItem("My hEaD HuRtS\n\niT HURTS\n\nwHeRe aM I\n\nwHaT Am i\n\nI Do nOt kNoW aNyThInG BuT ThIs PAIN\n\noH\n\nA NeW MoUsE HaS StEpPeD In\n\nThEy wAnT To jOiN ThE OtHeRs", "??? 04", true));
        this.BaseList.Add(new LoreItem("mY My mY\n\nwHaT An iNtErEsTiNg rEaD\n\ntHe pIcTuReS ArE So dEtAiLeD\n\ntHe fIrSt pAgE WaS Of a bEaUtIfUl wOmAn\n\nI WiSh i kNeW HeR\n\ntHe oThEr pIcTuReS\n\nmAnY FaCeS MaNy eXpReSsIoNs mAnY EmOtIoNs\n\nAhAhAhAhAhAhAhAhAhAhA\n\nsO VeRy iNtRiGuInG", "??? 05", true));
        this.BaseList.Add(new LoreItem("I’m glad you made it inside my friend.\n\nThat book should be somewhere around here. \n\nI don’t quite remember where I left it, but I know a few things that can help you.\n\nI might have left it lying somewhere in the hallways. \n\nAnother thing. \n\nIt’s fine to keep your flashlight and map on at all times.\n\nThis building is abandoned. You’re not in any particular danger.", "??? 06", true));

        this.PossibleEntries = new List<LoreItem>(this.BaseList);
    }
    public void Reset()
    {
        this.PossibleEntries.Clear();
        this.LoreInventory.Clear();
        this.PossibleEntries = new List<LoreItem>(this.BaseList);
        Debug.Log(PossibleEntries.Count);
    } 

    // Generate a lore piece and store into the inventory.
    public void GenerateLore()
    {
        var Index = Random.Range(0, this.PossibleEntries.Count);
        var collectedItem = this.PossibleEntries[Index];

        LoreInventory.Add(collectedItem);
        PossibleEntries.Remove(collectedItem);
    }

    public List<LoreItem> ReadLore()
    {
        return this.LoreInventory;
    }
}

public class LoreItem
{
    private string LoreText;
    private string Name;
    private bool Cursed;

    public LoreItem(string inputString, string inputName, bool chooseCurse)
    {
        this.LoreText = inputString;
        this.Name = inputName;
        this.Cursed = chooseCurse;
    }
 
    public string Read() 
    {
        return LoreText;
    }

    public string GetName()
    {
        return this.Name;
    }

    public bool IsCursed()
    {
        return this.Cursed;
    }
}


