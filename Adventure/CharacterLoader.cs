using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Adventure
{
    public class CharacterLoader
    {
        public CharacterList Characters { get; private set; }
        string FileName { get; set; }
        public void LoadCharacters(string fileName)
        {
            FileName = fileName;
            string characterXml = File.ReadAllText(fileName);
            Characters = characterXml.ParseXML<CharacterList>();
        }

        public void SaveCharacters()
        {
            string characterXml = Characters.SerializeObject<CharacterList>();
            File.WriteAllText(FileName, characterXml);
        }

        public void DeleteCharacter(Character ch)
        {
            List<CharacterType> charList = Characters.Character.ToList();
            charList.Remove(charList.Find(c => c.ID == ch.ID));
            Characters.Character = charList.ToArray();
        }

        public void UpdateCharacter(Character ch)
        {
            for (int i = 0; i < Characters.Character.Length; i++)
            {
                if (Characters.Character[i].ID == ch.ID)
                {
                    Characters.Character[i] = ch.Translate();
                    break;
                }
            }
        }

        public Character reloadCharacter(int id)
        {
            List<CharacterType> charList = Characters.Character.ToList();
            CharacterType theChar = charList.Find(c => c.ID == id);
            return new Character(theChar);
        }
    }
}
