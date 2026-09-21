using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRegionAnalysis2
{
    public static class Config
    {
        public const string CLASSNAME = "Config";



        public static bool DebugFromPercentages = false;
        public static bool DebugRegionCount = false;
        public static bool DebugRegionSize = false;



        public static bool TmgTrainFont = false;
        public static bool TmgLoadTrainingImage = false;
        public static bool TmgFindTrainingLines = false;
        public static bool TmgFindTrainingCharacters = false;
        public static bool TmgCountTrainingCharacters = false;
        public static bool TmgSaveTemplate = false;
        public static bool TmgLoadTemplate = false;
        public static bool TmgLoadTextImage = false;
        public static bool TmgFindTextImageLines = false;
        public static bool TmgFindTextImageCharacters = false;
        public static bool TmgCountTextImageCharacters = false;
        public static bool TmgFindClosestTemplate = false;
        public static bool TmgReadText = false;
        public static bool TmgCompareAgainstActual = false;
        public static bool TmgTextReadReport = false;



    }
}
