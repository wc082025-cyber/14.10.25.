
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CharacterClass;   

namespace Getter
{

    public static class CharacterRepository
    {
        private const string DataFilePath = "Getter/characters.json";

        
        private static readonly Lazy<IReadOnlyDictionary<string, BaseStats>> _cache
            = new Lazy<IReadOnlyDictionary<string, BaseStats>>(LoadAll);

        public static BaseStats Get(string className)
        {
            if (!_cache.Value.TryGetValue(className, out var stats))
                throw new KeyNotFoundException($"No character data for \"{className}\".");

            return new BaseStats(
                name:          stats.Name,
                vigor:         stats.Vigor,
                endurance:     stats.Endurance,
                strength:      stats.Strength,
                dexterity:     stats.Dexterity,
                intellegence:  stats.Intellegence,
                faith:         stats.Faith,
                backstory:     stats.Backstory);
        }

        private static IReadOnlyDictionary<string, BaseStats> LoadAll()
        {
            if (!File.Exists(DataFilePath))
                throw new FileNotFoundException($"Character data file not found at \"{DataFilePath}\".");

            var json = File.ReadAllText(DataFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };

            var dtos = JsonSerializer.Deserialize<List<CharacterData>>(json, options)
                       ?? new List<CharacterData>();

            var dict = new Dictionary<string, BaseStats>(StringComparer.OrdinalIgnoreCase);
            foreach (var d in dtos)
            {
                dict[d.Name] = new BaseStats(
                    name:          d.Name,
                    vigor:         d.Vigor,
                    endurance:     d.Endurance,
                    strength:      d.Strength,
                    dexterity:     d.Dexterity,
                    intellegence:  d.Intellegence,
                    faith:         d.Faith,
                    backstory:     d.Backstory);
            }

            return dict;
        }
    }
    internal sealed class CharacterData
    {
        public string Name { get; set; } = string.Empty;
        public int Vigor { get; set; }
        public int Endurance { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellegence { get; set; }
        public int Faith { get; set; }
        public string Backstory { get; set; } = string.Empty;
    }
}