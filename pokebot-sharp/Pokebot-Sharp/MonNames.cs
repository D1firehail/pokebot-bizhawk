﻿using System.Collections.Generic;

namespace Pokebot_Sharp
{
    public static class MonNames
    {
        public static List<string> Names = new List<string>()
        {
            "---", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard",
            "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree",
            "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate",
            "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash",
            "Nidoran F", "Nidorina", "Nidoqueen", "Nidoran M", "Nidorino", "Nidoking",
            "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff",
            "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth",
            "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape",
            "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam",
            "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel",
            "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro",
            "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk",
            "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno",
            "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak",
            "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey",
            "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie",
            "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados",
            "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar",
            "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres",
            "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew",

            "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion",
            "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl",
            "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa",
            "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom",
            "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom",
            "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking",
            "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar",
            "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel",
            "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery",
            "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan",
            "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank",
            "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi",

            "none","none","none","none","none",
            "none","none","none","none","none",
            "none","none","none","none","none",
            "none","none","none","none","none",
            "none","none","none","none","none",

            "Treecko", "Grovyle", "Sceptile",
            "Torchic", "Combusken", "Blaziken",
            "Mudkip", "Marshtomp", "Swampert",
            "Poochyena", "Mightyena", "Zigzagoon", "Linoone",
            "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox",
            "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry",
            "Nincada", "Ninjask", "Shedinja", "Taillow", "Swellow",
            "Shroomish", "Breloom", "Spinda", "Wingull", "Pelipper",
            "Surskit", "Masquerain", "Wailmer", "Wailord", "Skitty", "Delcatty",
            "Kecleon", "Baltoy", "Claydol", "Nosepass", "Torkoal", "Sableye",
            "Barboach", "Whiscash", "Luvdisc", "Corphish", "Crawdaunt", "Feebas", "Milotic",
            "Carvanha", "Sharpedo", "Trapinch", "Vibrava", "Flygon", "Makuhita", "Hariyama",
            "Electrike", "Manectric", "Numel", "Camerupt", "Spheal", "Sealeo", "Walrein", "Cacnea", "Cacturne",
            "Snorunt", "Glalie", "Lunatone", "Solrock", "Azurill", "Spoink", "Grumpig", "Plusle", "Minun",
            "Mawile", "Meditite", "Medicham", "Swablu", "Altaria", "Wynaut", "Duskull", "Dusclops", "Roselia",
            "Slakoth", "Vigoroth", "Slaking", "Gulpin", "Swalot", "Tropius", "Whismur", "Loudred", "Exploud",
            "Clamperl", "Huntail", "Gorebyss", "Absol", "Shuppet", "Banette", "Seviper", "Zangoose", "Relicanth",
            "Aron", "Lairon", "Aggron", "Castform", "Volbeat", "Illumise", "Lileep", "Cradily",
            "Anorith", "Armaldo", "Ralts", "Kirlia", "Gardevoir", "Bagon", "Shelgon", "Salamence", "Beldum",
            "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Kyogre", "Groudon", "Rayquaza",
            "Latias", "Latios", "Jirachi", "Deoxys", "Chimecho",

            "Unown","Unown","Unown","Unown","Unown",
            "Unown","Unown","Unown","Unown","Unown",
            "Unown","Unown","Unown","Unown","Unown",
            "Unown","Unown","Unown","Unown","Unown",
            "Unown","Unown","Unown","Unown","Unown",
            "Unown","Unown"
        };
    }
}
