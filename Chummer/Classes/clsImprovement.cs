/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Chummer.Backend.Equipment;
using Chummer.Classes;
using Chummer.Backend.Skills;
using Chummer.Backend.Attributes;
using System.Drawing;
using static Chummer.Backend.Skills.SkillsSection;

namespace Chummer
{
    [DebuggerDisplay("{DisplayDebug()}")]
    public class Improvement
    {
        private string DisplayDebug()
        {
            return $"{_objImprovementType} ({_intVal}, {_intRating}) 🡐 {_objImprovementSource}, {_strSourceName}, {_strImprovedName}";
        }

        public enum ImprovementType
        {
            Attribute,
            Text,
            Armor,
            FireArmor,
            ColdArmor,
            ElectricityArmor,
            AcidArmor,
            FallingArmor,
            Dodge,
            Reach,
            Nuyen,
            Essence,
            PhysicalCM,
            StunCM,
            UnarmedDV,
            InitiativeDice,
            MatrixInitiative,
            MatrixInitiativeDice,
            LifestyleCost,
            CMThreshold,
            EnhancedArticulation,
            WeaponCategoryDV,
            WeaponCategoryDice,
            CyberwareEssCost,
            CyberwareTotalEssMultiplier,
            CyberwareEssCostNonRetroactive,
            CyberwareTotalEssMultiplierNonRetroactive,
            SpecialTab,
            Initiative,
            LivingPersonaDeviceRating,
            LivingPersonaProgramLimit,
            LivingPersonaAttack,
            LivingPersonaSleaze,
            LivingPersonaDataProcessing,
            LivingPersonaFirewall,
            Smartlink,
            BiowareEssCost,
            BiowareTotalEssMultiplier,
            BiowareEssCostNonRetroactive,
            BiowareTotalEssMultiplierNonRetroactive,
            GenetechCostMultiplier,
            BasicBiowareEssCost,
            SoftWeave,
            DisableBioware,
            DisableCyberware,
            DisableBiowareGrade,
            DisableCyberwareGrade,
            ConditionMonitor,
            UnarmedDVPhysical,
            Adapsin,
            FreePositiveQualities,
            FreeNegativeQualities,
            FreeKnowledgeSkills,
            NuyenMaxBP,
            CMOverflow,
            FreeSpiritPowerPoints,
            AdeptPowerPoints,
            ArmorEncumbrancePenalty,
            Initiation,
            Submersion,
            Metamagic,
            Echo,
            Skillwire,
            DamageResistance,
            RestrictedItemCount,
            JudgeIntentions,
            JudgeIntentionsOffense,
            JudgeIntentionsDefense,
            LiftAndCarry,
            Memory,
            Concealability,
            SwapSkillAttribute,
            DrainResistance,
            FadingResistance,
            MatrixInitiativeDiceAdd,
            InitiativeDiceAdd,
            Composure,
            UnarmedAP,
            CMThresholdOffset,
            CMSharedThresholdOffset,
            Restricted,
            Notoriety,
            SpellCategory,
            SpellCategoryDamage,
            SpellCategoryDrain,
            ThrowRange,
            SkillsoftAccess,
            AddSprite,
            BlackMarketDiscount,
            ComplexFormLimit,
            SpellLimit,
            QuickeningMetamagic,
            BasicLifestyleCost,
            ThrowSTR,
            IgnoreCMPenaltyStun,
            IgnoreCMPenaltyPhysical,
            CyborgEssence,
            EssenceMax,
            AdeptPower,
            SpecificQuality,
            MartialArt,
            LimitModifier,
            PhysicalLimit,
            MentalLimit,
            SocialLimit,
            FriendsInHighPlaces,
            Erased,
            BornRich,
            Fame,
            MadeMan,
            Overclocker,
            RestrictedGear,
            TrustFund,
            ExCon,
            ContactForceGroup,
            Attributelevel,
            AddContact,
            Seeker,
            PublicAwareness,
            PrototypeTranshuman,
            Hardwire,
            DealerConnection,
            Skill,  //Improve pool of skill based on name
            SkillGroup,  //Group
            SkillCategory, //category
            SkillAttribute, //attribute
            SkillLinkedAttribute, //linked attribute
            SkillLevel,  //Karma points in skill
            SkillGroupLevel, //group
            SkillBase,  //base points in skill
            SkillGroupBase, //group
            SkillKnowledgeForced, //A skill gained from a knowsoft
            ReplaceAttribute, //Alter the base metatype or metavariant of a character. Used for infected.
            SpecialSkills,
            ReflexRecorderOptimization,
            BlockSkillDefault,
            Ambidextrous,
            UnarmedReach,
            SkillSpecialization,
            NativeLanguageLimit,
            AdeptPowerFreeLevels,
            AdeptPowerFreePoints,
            AIProgram,
            CritterPowerLevel,
            CritterPower,
            SwapSkillSpecAttribute,
            SpellResistance,
            LimitSpellCategory,
            LimitSpellDescriptor,
            LimitSpiritCategory,
            WalkSpeed,
            RunSpeed,
            SprintSpeed,
            WalkMultiplier,
            RunMultiplier,
            SprintBonus,
            WalkMultiplierPercent,
            RunMultiplierPercent,
            SprintBonusPercent,
            EssencePenalty,
            EssencePenaltyT100,
            EssencePenaltyMAGOnlyT100,
            FreeSpellsATT,
            FreeSpells,
            DrainValue,
            FadingValue,
            Spell,
            ComplexForm,
            Gear,
            Weapon,
            MentorSpirit,
            Paragon,
            FreeSpellsSkill,
            DisableSpecializationEffects, // Disable the effects of specializations for a skill
            FatigueResist,
            RadiationResist,
            SonicResist,
            ToxinContactResist,
            ToxinIngestionResist,
            ToxinInhalationResist,
            ToxinInjectionResist,
            PathogenContactResist,
            PathogenIngestionResist,
            PathogenInhalationResist,
            PathogenInjectionResist,
            ToxinContactImmune,
            ToxinIngestionImmune,
            ToxinInhalationImmune,
            ToxinInjectionImmune,
            PathogenContactImmune,
            PathogenIngestionImmune,
            PathogenInhalationImmune,
            PathogenInjectionImmune,
            PhysiologicalAddictionFirstTime,
            PsychologicalAddictionFirstTime,
            PhysiologicalAddictionAlreadyAddicted,
            PsychologicalAddictionAlreadyAddicted,
            StunCMRecovery,
            PhysicalCMRecovery,
            AddESStoStunCMRecovery,
            AddESStoPhysicalCMRecovery,
            MentalManipulationResist,
            PhysicalManipulationResist,
            ManaIllusionResist,
            PhysicalIllusionResist,
            DetectionSpellResist,
            AddLimb,
            StreetCredMultiplier,
            StreetCred,
            AttributeKarmaCostMultiplier,
            AttributeKarmaCost,
            ActiveSkillKarmaCostMultiplier,
            SkillGroupKarmaCostMultiplier,
            KnowledgeSkillKarmaCostMultiplier,
            ActiveSkillKarmaCost,
            SkillGroupKarmaCost,
            SkillGroupDisable,
            KnowledgeSkillKarmaCost,
            SkillCategorySpecializationKarmaCostMultiplier,
            SkillCategorySpecializationKarmaCost,
            SkillCategoryKarmaCostMultiplier,
            SkillCategoryKarmaCost,
            SkillGroupCategoryKarmaCostMultiplier,
            SkillGroupCategoryDisable,
            SkillGroupCategoryKarmaCost,
            AttributePointCostMultiplier,
            AttributePointCost,
            ActiveSkillPointCostMultiplier,
            SkillGroupPointCostMultiplier,
            KnowledgeSkillPointCostMultiplier,
            ActiveSkillPointCost,
            SkillGroupPointCost,
            KnowledgeSkillPointCost,
            SkillCategoryPointCostMultiplier,
            SkillCategoryPointCost,
            SkillGroupCategoryPointCostMultiplier,
            SkillGroupCategoryPointCost,
            NewSpellKarmaCostMultiplier,
            NewSpellKarmaCost,
            NewComplexFormKarmaCostMultiplier,
            NewComplexFormKarmaCost,
            NewAIProgramKarmaCostMultiplier,
            NewAIProgramKarmaCost,
            NewAIAdvancedProgramKarmaCostMultiplier,
            NewAIAdvancedProgramKarmaCost,
            BlockSkillSpecializations,
            BlockSkillCategorySpecializations,
            FocusBindingKarmaCost,
            FocusBindingKarmaMultiplier,
            MagiciansWayDiscount,
            BurnoutsWay,
            ContactForcedLoyalty,
            ContactMakeFree,
            FreeWare,
            WeaponAccuracy,
            NumImprovementTypes // 🡐 This one should always be the last defined enum
        }

        public enum ImprovementSource
        {
            Quality,
            Power,
            Metatype,
            Cyberware,
            Metavariant,
            Bioware,
            ArmorEncumbrance,
            Gear,
            Spell,
            Initiation,
            Submersion,
            Metamagic,
            Echo,
            Armor,
            ArmorMod,
            EssenceLoss,
            EssenceLossChargen,
            CritterPower,
            ComplexForm,
            EdgeUse,
            MutantCritter,
            Cyberzombie,
            StackedFocus,
            AttributeLoss,
            Art,
            Enhancement,
            Custom,
            Heritage,
            MartialArt,
            MartialArtTechnique,
            AIProgram,
            SpiritFettering,
            MentorSpirit,
            NumImprovementSources // 🡐 This one should always be the last defined enum
        }

        private readonly Character _objCharacter;
        private string _strImprovedName = string.Empty;
        private string _strSourceName = string.Empty;
        private int _intMin;
        private int _intMax;
        private int _intAug;
        private int _intAugMax;
        private int _intVal;
        private int _intRating = 1;
        private string _strExclude = string.Empty;
        private string _strCondition = string.Empty;
        private string _strUniqueName = string.Empty;
        private string _strTarget = string.Empty;
        private ImprovementType _objImprovementType;
        private ImprovementSource _objImprovementSource;
        private bool _blnCustom;
        private string _strCustomName = string.Empty;
        private string _strCustomId = string.Empty;
        private string _strCustomGroup = string.Empty;
        private string _strNotes = string.Empty;
        private bool _blnAddToRating;
        private bool _blnEnabled = true;
        private int _intOrder;

        #region Helper Methods

        /// <summary>
        /// Convert a string to an ImprovementType.
        /// </summary>
        /// <param name="strValue">String value to convert.</param>
        public static ImprovementType ConvertToImprovementType(string strValue)
        {
            if (strValue.Contains("InitiativePass"))
            {
                strValue = strValue.Replace("InitiativePass","InitiativeDice");
            }
            return (ImprovementType) Enum.Parse(typeof (ImprovementType), strValue);
        }

        /// <summary>
        /// Convert a string to an ImprovementSource.
        /// </summary>
        /// <param name="strValue">String value to convert.</param>
        public static ImprovementSource ConvertToImprovementSource(string strValue)
        {
            if (strValue == "MartialArtAdvantage")
                strValue = "MartialArtTechnique";
            return (ImprovementSource) Enum.Parse(typeof (ImprovementSource), strValue);
        }

        #endregion

        #region Save and Load Methods
        public Improvement(Character objCharacter)
        {
            _objCharacter = objCharacter;
        }

        /// <summary>
        /// Save the object's XML to the XmlWriter.
        /// </summary>
        /// <param name="objWriter">XmlTextWriter to write with.</param>
        public void Save(XmlTextWriter objWriter)
        {
            Log.Enter("Save");

            objWriter.WriteStartElement("improvement");
            if (!string.IsNullOrEmpty(_strUniqueName))
                objWriter.WriteElementString("unique", _strUniqueName);
            objWriter.WriteElementString("target", _strTarget);
            objWriter.WriteElementString("improvedname", _strImprovedName);
            objWriter.WriteElementString("sourcename", _strSourceName);
            objWriter.WriteElementString("min", _intMin.ToString());
            objWriter.WriteElementString("max", _intMax.ToString());
            objWriter.WriteElementString("aug", _intAug.ToString());
            objWriter.WriteElementString("augmax", _intAugMax.ToString());
            objWriter.WriteElementString("val", _intVal.ToString());
            objWriter.WriteElementString("rating", _intRating.ToString());
            objWriter.WriteElementString("exclude", _strExclude);
            objWriter.WriteElementString("condition", _strCondition);
            objWriter.WriteElementString("improvementttype", _objImprovementType.ToString());
            objWriter.WriteElementString("improvementsource", _objImprovementSource.ToString());
            objWriter.WriteElementString("custom", _blnCustom.ToString());
            objWriter.WriteElementString("customname", _strCustomName);
            objWriter.WriteElementString("customid", _strCustomId);
            objWriter.WriteElementString("customgroup", _strCustomGroup);
            objWriter.WriteElementString("addtorating", _blnAddToRating.ToString());
            objWriter.WriteElementString("enabled", _blnEnabled.ToString());
            objWriter.WriteElementString("order", _intOrder.ToString());
            objWriter.WriteElementString("notes", _strNotes);
            objWriter.WriteEndElement();

            Log.Exit("Save");
        }

        /// <summary>
        /// Load the CharacterAttribute from the XmlNode.
        /// </summary>
        /// <param name="objNode">XmlNode to load.</param>
        public void Load(XmlNode objNode)
        {
            if (objNode == null)
                return;
            Log.Enter("Load");

            objNode.TryGetStringFieldQuickly("unique", ref _strUniqueName);
            objNode.TryGetStringFieldQuickly("target", ref _strTarget);
            objNode.TryGetStringFieldQuickly("improvedname", ref _strImprovedName);
            objNode.TryGetStringFieldQuickly("sourcename", ref _strSourceName);
            objNode.TryGetInt32FieldQuickly("min", ref _intMin);
            objNode.TryGetInt32FieldQuickly("max", ref _intMax);
            objNode.TryGetInt32FieldQuickly("aug", ref _intAug);
            objNode.TryGetInt32FieldQuickly("augmax", ref _intAugMax);
            objNode.TryGetInt32FieldQuickly("val", ref _intVal);
            objNode.TryGetInt32FieldQuickly("rating", ref _intRating);
            objNode.TryGetStringFieldQuickly("exclude", ref _strExclude);
            objNode.TryGetStringFieldQuickly("condition", ref _strCondition);
            if (objNode["improvementttype"] != null)
            _objImprovementType = ConvertToImprovementType(objNode["improvementttype"].InnerText);
            if (objNode["improvementsource"] != null)
            _objImprovementSource = ConvertToImprovementSource(objNode["improvementsource"].InnerText);
            // Legacy shim
            if (_objImprovementType == ImprovementType.LimitModifier && string.IsNullOrEmpty(_strCondition) && !string.IsNullOrEmpty(_strExclude))
            {
                _strCondition = _strExclude;
                _strExclude = string.Empty;
            }
            objNode.TryGetBoolFieldQuickly("custom", ref _blnCustom);
            objNode.TryGetStringFieldQuickly("customname", ref _strCustomName);
            objNode.TryGetStringFieldQuickly("customid", ref _strCustomId);
            objNode.TryGetStringFieldQuickly("customgroup", ref _strCustomGroup);
            objNode.TryGetBoolFieldQuickly("addtorating", ref _blnAddToRating);
            objNode.TryGetBoolFieldQuickly("enabled", ref _blnEnabled);
            objNode.TryGetStringFieldQuickly("notes", ref _strNotes);
            objNode.TryGetInt32FieldQuickly("order", ref _intOrder);

            Log.Exit("Load");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Whether or not this is a custom-made (manually created) Improvement.
        /// </summary>
        public bool Custom
        {
            get => _blnCustom;
            set => _blnCustom = value;
        }

        /// <summary>
        /// User-entered name for the custom Improvement.
        /// </summary>
        public string CustomName
        {
            get => _strCustomName;
            set => _strCustomName = value;
        }

        /// <summary>
        /// ID from the Improvements file. Only used for custom-made (manually created) Improvements.
        /// </summary>
        public string CustomId
        {
            get => _strCustomId;
            set => _strCustomId = value;
        }

        /// <summary>
        /// Group name for the Custom Improvement.
        /// </summary>
        public string CustomGroup
        {
            get => _strCustomGroup;
            set => _strCustomGroup = value;
        }

        /// <summary>
        /// User-entered notes for the custom Improvement.
        /// </summary>
        public string Notes
        {
            get => _strNotes;
            set => _strNotes = value;
        }

        /// <summary>
        /// Name of the Skill or CharacterAttribute that the Improvement is improving.
        /// </summary>
        public string ImprovedName
        {
            get => _strImprovedName;
            set => _strImprovedName = value;
        }

        /// <summary>
        /// Name of the source that granted this Improvement.
        /// </summary>
        public string SourceName
        {
            get => _strSourceName;
            set => _strSourceName = value;
        }

        /// <summary>
        /// The type of Object that the Improvement is improving.
        /// </summary>
        public ImprovementType ImproveType
        {
            get => _objImprovementType;
            set
            {
                if (Enabled)
                {
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, _objImprovementType));
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, value));
                }
                _objImprovementType = value;
            }
        }

        /// <summary>
        /// The type of Object that granted this Improvement.
        /// </summary>
        public ImprovementSource ImproveSource
        {
            get => _objImprovementSource;
            set
            {
                _objImprovementSource = value;
                if (Enabled)
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, ImprovementType.MatrixInitiativeDice));
            }
        }

        /// <summary>
        /// Minimum value modifier.
        /// </summary>
        public int Minimum
        {
            get => _intMin;
            set => _intMin = value;
        }

        /// <summary>
        /// Maximum value modifier.
        /// </summary>
        public int Maximum
        {
            get => _intMax;
            set => _intMax = value;
        }

        /// <summary>
        /// Augmented Maximum value modifier.
        /// </summary>
        public int AugmentedMaximum
        {
            get => _intAugMax;
            set => _intAugMax = value;
        }

        /// <summary>
        /// Augmented score modifier.
        /// </summary>
        public int Augmented
        {
            get => _intAug;
            set => _intAug = value;
        }

        /// <summary>
        /// Value modifier.
        /// </summary>
        public int Value
        {
            get => _intVal;
            set => _intVal = value;
        }

        /// <summary>
        /// The Rating value for the Improvement. This is 1 by default.
        /// </summary>
        public int Rating
        {
            get => _intRating;
            set => _intRating = value;
        }

        /// <summary>
        /// A list of child items that should not receive the Improvement's benefit (typically for excluding a Skill from a Skill Group bonus).
        /// </summary>
        public string Exclude
        {
            get => _strExclude;
            set => _strExclude = value;
        }

        /// <summary>
        /// String containing the condition for when the bonus applies (e.g. a dicepool bonus to a skill that only applies to certain types of tests).
        /// </summary>
        public string Condition
        {
            get => _strCondition;
            set => _strCondition = value;
        }

        /// <summary>
        /// A Unique name for the Improvement. Only the highest value of any one Improvement that is part of this Unique Name group will be applied.
        /// </summary>
        public string UniqueName
        {
            get => _strUniqueName;
            set
            {
                _strUniqueName = value;
                if (Enabled)
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, ImproveType));
            }
        }

        /// <summary>
        /// Whether or not the bonus applies directly to a Skill's Rating
        /// </summary>
        public bool AddToRating
        {
            get => _blnAddToRating;
            set
            {
                _blnAddToRating = value;
                if (Enabled)
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, ImproveType));
            }
        }

        /// <summary>
        /// The target of an improvement, e.g. the skill whose attributes should be swapped
        /// </summary>
        public string Target
        {
            get => _strTarget;
            set => _strTarget = value;
        }

        /// <summary>
        /// Whether or not the Improvement is enabled and provided its bonus.
        /// </summary>
        public bool Enabled
        {
            get => _blnEnabled;
            set
            {
                if (_blnEnabled != value)
                {
                    _blnEnabled = value;
                    ImprovementManager.ClearCachedValue(new Tuple<Character, ImprovementType>(_objCharacter, ImproveType));
                }
            }
        }

        /// <summary>
        /// Sort order for Custom Improvements.
        /// </summary>
        public int SortOrder
        {
            get => _intOrder;
            set => _intOrder = value;
        }

        #endregion

        #region UI Methods
        public TreeNode CreateTreeNode(ContextMenuStrip cmsImprovement)
        {
            TreeNode nodImprovement = new TreeNode
            {
                Tag = SourceName,
                Text = CustomName,
                ToolTipText = Notes.WordWrap(100),
                ContextMenuStrip = cmsImprovement
            };
            if (!string.IsNullOrEmpty(Notes))
            {
                if (Enabled)
                    nodImprovement.ForeColor = Color.SaddleBrown;
                else
                    nodImprovement.ForeColor = Color.SandyBrown;
            }
            else if (Enabled)
                nodImprovement.ForeColor = SystemColors.WindowText;
            else
                nodImprovement.ForeColor = SystemColors.GrayText;

            return nodImprovement;
        }
        #endregion
    }

    public static class ImprovementManager
    {
        // String that will be used to limit the selection in Pick forms.
        private static string s_StrLimitSelection = string.Empty;

        private static string s_StrSelectedValue = string.Empty;
        private static string s_StrForcedValue = string.Empty;
        private static readonly List<Improvement> s_LstTransaction = new List<Improvement>();
        private static readonly Dictionary<Tuple<Character, Improvement.ImprovementType>, int> s_DictionaryCachedValues = new Dictionary<Tuple<Character, Improvement.ImprovementType>, int>((int)Improvement.ImprovementType.NumImprovementTypes);
        #region Properties

        /// <summary>
        /// Limit what can be selected in Pick forms to a single value. This is typically used when selecting the Qualities for a Metavariant that has a specifiec
        /// CharacterAttribute selection for Qualities like Metagenetic Improvement.
        /// </summary>
        public static string LimitSelection
        {
            get => s_StrLimitSelection;
            set => s_StrLimitSelection = value;
        }

        /// <summary>
        /// The string that was entered or selected from any of the dialogue windows that were presented because of this Improvement.
        /// </summary>
        public static string SelectedValue
        {
            get => s_StrSelectedValue;
            set => s_StrSelectedValue = value;
        }

        /// <summary>
        /// Force any dialogue windows that open to use this string as their selected value.
        /// </summary>
        public static string ForcedValue
        {
            get => s_StrForcedValue;
            set => s_StrForcedValue = value;
        }

        public static void ClearCachedValue(Tuple<Character, Improvement.ImprovementType> objImprovementType)
        {
            if (s_DictionaryCachedValues.ContainsKey(objImprovementType))
                s_DictionaryCachedValues[objImprovementType] = int.MinValue;
            else
                s_DictionaryCachedValues.Add(objImprovementType, int.MinValue);
        }

        public static void ClearCachedValues(Character objCharacter)
        {
            foreach (Tuple<Character, Improvement.ImprovementType> objKey in s_DictionaryCachedValues.Keys.ToList())
            {
                if (objKey.Item1 == objCharacter)
                    s_DictionaryCachedValues.Remove(objKey);
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Retrieve the total Improvement value for the specified ImprovementType.
        /// </summary>
        /// <param name="objCharacter">Character to which the improvements belong that should be processed.</param>
        /// <param name="objImprovementType">ImprovementType to retrieve the value of.</param>
        /// <param name="blnAddToRating">Whether or not we should only retrieve values that have AddToRating enabled.</param>
        /// <param name="strImprovedName">Name to assign to the Improvement.</param>
        /// <param name="blnUnconditionalOnly">Whether to only fetch values for improvements that do not have a condition.</param>
        public static int ValueOf(Character objCharacter, Improvement.ImprovementType objImprovementType, bool blnAddToRating = false, string strImprovedName = "", bool blnUnconditionalOnly = true)
        {
            //Log.Enter("ValueOf");
            //Log.Info("objImprovementType = " + objImprovementType.ToString());
            //Log.Info("blnAddToRating = " + blnAddToRating.ToString());
            //Log.Info("strImprovedName = " + ("" + strImprovedName).ToString());

            if (objCharacter == null)
            {
                //Log.Exit("ValueOf");
                return 0;
            }

            // If we've got a value cached for the default ValueOf call for an improvementType, let's just return that
            Tuple<Character, Improvement.ImprovementType> objCacheKey = new Tuple<Character, Improvement.ImprovementType>(objCharacter, objImprovementType);
            if (!blnAddToRating && string.IsNullOrEmpty(strImprovedName) && blnUnconditionalOnly && s_DictionaryCachedValues.TryGetValue(objCacheKey, out int intCachedValue) && intCachedValue != int.MinValue)
            {
                return intCachedValue;
            }

            HashSet<string> lstUniqueName = new HashSet<string>();
            HashSet<Tuple<string, int>> lstUniquePair = new HashSet<Tuple<string, int>>();
            int intValue = 0;
            foreach (Improvement objImprovement in objCharacter.Improvements)
            {
                if (objImprovement.ImproveType == objImprovementType && objImprovement.Enabled && !objImprovement.Custom && (!blnUnconditionalOnly || string.IsNullOrEmpty(objImprovement.Condition)))
                {
                    bool blnAllowed = objImprovement.ImproveType == objImprovementType &&
                        !(objCharacter.RESEnabled && objImprovement.ImproveSource == Improvement.ImprovementSource.Gear &&
                          objImprovementType == Improvement.ImprovementType.MatrixInitiativeDice) &&
                    // Ignore items that apply to a Skill's Rating.
                          objImprovement.AddToRating == blnAddToRating &&
                    // If an Improved Name has been passed, only retrieve values that have this Improved Name.
                          (string.IsNullOrEmpty(strImprovedName) || strImprovedName == objImprovement.ImprovedName);

                    if (blnAllowed)
                    {
                        string strUniqueName = objImprovement.UniqueName;
                        if (!string.IsNullOrEmpty(strUniqueName))
                        {
                            // If this has a UniqueName, run through the current list of UniqueNames seen. If it is not already in the list, add it.
                            if (!lstUniqueName.Contains(strUniqueName))
                                lstUniqueName.Add(strUniqueName);

                            // Add the values to the UniquePair List so we can check them later.
                            lstUniquePair.Add(new Tuple<string, int>(strUniqueName, objImprovement.Value));
                        }
                        else
                        {
                            intValue += objImprovement.Value;
                        }
                    }
                }
            }

            if (lstUniqueName.Contains("precedence0"))
            {
                // Retrieve only the highest precedence0 value.
                // Run through the list of UniqueNames and pick out the highest value for each one.
                int intHighest = (from strValues in lstUniquePair where strValues.Item1 == "precedence0" select strValues.Item2).Concat(new[] { int.MinValue }).Max();
                if (lstUniqueName.Contains("precedence-1"))
                {
                    intHighest += lstUniquePair.Where(strValues => strValues.Item1 == "precedence-1").Sum(strValues => strValues.Item2);
                }
                intValue = Math.Max(intValue, intHighest);
            }
            else if (lstUniqueName.Contains("precedence1"))
            {
                // Retrieve all of the items that are precedence1 and nothing else.
                intValue = Math.Max(intValue, lstUniquePair.Where(strValues => strValues.Item1 == "precedence1" || strValues.Item1 == "precedence-1").Sum(strValues => strValues.Item2));
            }
            else
            {
                // Run through the list of UniqueNames and pick out the highest value for each one.
                intValue += lstUniqueName.Sum(strName => (from strValues in lstUniquePair where strValues.Item1 == strName select strValues.Item2).Concat(new[] { int.MinValue }).Max());
            }

            // Factor in Custom Improvements.
            lstUniqueName.Clear();
            lstUniquePair.Clear();
            int intCustomValue = 0;
            foreach (Improvement objImprovement in objCharacter.Improvements)
            {
                if (objImprovement.Custom && objImprovement.Enabled && (!blnUnconditionalOnly || string.IsNullOrEmpty(objImprovement.Condition)))
                {
                    bool blnAllowed = objImprovement.ImproveType == objImprovementType &&
                        !(objCharacter.RESEnabled && objImprovement.ImproveSource == Improvement.ImprovementSource.Gear &&
                          objImprovementType == Improvement.ImprovementType.MatrixInitiativeDice) &&
                    // Ignore items that apply to a Skill's Rating.
                          objImprovement.AddToRating == blnAddToRating &&
                    // If an Improved Name has been passed, only retrieve values that have this Improved Name.
                          (string.IsNullOrEmpty(strImprovedName) || strImprovedName == objImprovement.ImprovedName);

                    if (blnAllowed)
                    {
                        string strUniqueName = objImprovement.UniqueName;
                        if (!string.IsNullOrEmpty(strUniqueName))
                        {
                            // If this has a UniqueName, run through the current list of UniqueNames seen. If it is not already in the list, add it.
                            if (!lstUniqueName.Contains(strUniqueName))
                                lstUniqueName.Add(strUniqueName);

                            // Add the values to the UniquePair List so we can check them later.
                            lstUniquePair.Add(new Tuple<string, int>(strUniqueName, objImprovement.Value));
                        }
                        else
                        {
                            intCustomValue += objImprovement.Value;
                        }
                    }
                }
            }

            // Run through the list of UniqueNames and pick out the highest value for each one.
            intCustomValue += lstUniqueName.Sum(strName => (from strValues in lstUniquePair where strValues.Item1 == strName select strValues.Item2).Concat(new[] {int.MinValue}).Max());

            //Log.Exit("ValueOf");
            // If this is the default ValueOf() call, let's cache the value we've calculated so that we don't have to do this all over again unless something has changed
            if (!blnAddToRating && string.IsNullOrEmpty(strImprovedName))
            {
                if (s_DictionaryCachedValues.ContainsKey(objCacheKey))
                    s_DictionaryCachedValues[objCacheKey] = intValue + intCustomValue;
                else
                    s_DictionaryCachedValues.Add(objCacheKey, intValue + intCustomValue);
            }

            return intValue + intCustomValue;
        }

        /// <summary>
        /// Convert a string to an integer, converting "Rating" to a number where appropriate.
        /// </summary>
        /// <param name="objCharacter">Character to which the improvements belong that should be processed.</param>
        /// <param name="strValue">String value to parse.</param>
        /// <param name="intRating">Integer value to replace "Rating" with.</param>
        private static int ValueToInt(Character objCharacter, string strValue, int intRating)
        {
            if (string.IsNullOrEmpty(strValue))
                return 0;
            //         Log.Enter("ValueToInt");
            //         Log.Info("strValue = " + strValue);
            //Log.Info("intRating = " + intRating.ToString());
            if (strValue.StartsWith("FixedValues("))
            {
                string[] strValues = strValue.TrimStartOnce("FixedValues(", true).TrimEndOnce(')').Split(',');
                strValue = strValues[Math.Max(Math.Min(strValues.Length, intRating) - 1, 0)];
            }
            if (strValue.Contains("Rating") || AttributeSection.AttributeStrings.Any(strValue.Contains))
            {
                string strReturn = strValue.Replace("Rating", intRating.ToString());
                // If the value contain an CharacterAttribute name, replace it with the character's CharacterAttribute.
                foreach (string strAttribute in AttributeSection.AttributeStrings)
                {
                    strReturn = strReturn.CheapReplace(strAttribute, () => objCharacter.GetAttribute(strAttribute).TotalValue.ToString());
                }

                //Log.Info("strValue = " + strValue);
                //Log.Info("strReturn = " + strReturn);

                // Treat this as a decimal value so any fractions can be rounded down. This is currently only used by the Boosted Reflexes Cyberware from SR2050.
                object objProcess = CommonFunctions.EvaluateInvariantXPath(strReturn, out bool blnIsSuccess);
                int intValue = blnIsSuccess ? Convert.ToInt32(Math.Floor((double)objProcess)) : 0;

                //Log.Exit("ValueToInt");
                return intValue;
            }
            else
            {
                //Log.Exit("ValueToInt");
                int.TryParse(strValue, out int intReturn);
                return intReturn;
            }
        }
        #endregion

        #region Improvement System

        /// <summary>
        /// Create all of the Improvements for an XML Node.
        /// </summary>
        /// <param name="objCharacter">Character to which the improvements belong that should be processed.</param>
        /// <param name="objImprovementSource">Type of object that grants these Improvements.</param>
        /// <param name="strSourceName">Name of the item that grants these Improvements.</param>
        /// <param name="nodBonus">bonus XMLXode from the source data file.</param>
        /// <param name="blnConcatSelectedValue">Whether or not any selected values should be concatinated with the SourceName string when storing.</param>
        /// <param name="intRating">Selected Rating value that is used to replace the Rating string in an Improvement.</param>
        /// <param name="strFriendlyName">Friendly name to show in any dialogue windows that ask for a value.</param>
        /// <returns>True if successfull</returns>
        public static bool CreateImprovements(Character objCharacter, Improvement.ImprovementSource objImprovementSource, string strSourceName,
            XmlNode nodBonus, bool blnConcatSelectedValue = false, int intRating = 1, string strFriendlyName = "")
        {
            Log.Enter("CreateImprovements");
            Log.Info("objImprovementSource = " + objImprovementSource.ToString());
            Log.Info("strSourceName = " + strSourceName);
            Log.Info("nodBonus = " + nodBonus?.OuterXml);
            Log.Info("blnConcatSelectedValue = " + blnConcatSelectedValue.ToString());
            Log.Info("intRating = " + intRating.ToString());
            Log.Info("strFriendlyName = " + strFriendlyName);
            Log.Info("intRating = " + intRating.ToString());

            /*try
            {*/
            if (nodBonus == null)
            {
                s_StrForcedValue = string.Empty;
                s_StrLimitSelection = string.Empty;
                Log.Exit("CreateImprovements");
                return true;
            }
            
            s_StrSelectedValue = string.Empty;

            Log.Info("_strForcedValue = " + s_StrForcedValue);
            Log.Info("_strLimitSelection = " + s_StrLimitSelection);

            // If there is no character object, don't attempt to add any Improvements.
            if (objCharacter == null)
            {
                Log.Info("_objCharacter = Null");
                Log.Exit("CreateImprovements");
                return true;
            }

            string strUnique = nodBonus.Attributes?["unique"]?.InnerText ?? string.Empty;
            // If no friendly name was provided, use the one from SourceName.
            if (string.IsNullOrEmpty(strFriendlyName))
                strFriendlyName = strSourceName;

            if (nodBonus.HasChildNodes)
            {
                Log.Info("Has Child Nodes");
                if (nodBonus["selecttext"] != null)
                {
                    Log.Info("selecttext");

                    if (!string.IsNullOrEmpty(s_StrForcedValue))
                    {
                        LimitSelection = s_StrForcedValue;
                    }
                    else if (objCharacter.Pushtext.Count != 0)
                    {
                        LimitSelection = objCharacter.Pushtext.Pop();
                    }

                    Log.Info("_strForcedValue = " + SelectedValue);
                    Log.Info("_strLimitSelection = " + LimitSelection);

                    if (!string.IsNullOrEmpty(LimitSelection))
                    {
                        s_StrSelectedValue = LimitSelection;
                    }
                    else
                    {
                        // Display the Select Text window and record the value that was entered.
                        frmSelectText frmPickText = new frmSelectText
                        {
                            Description = LanguageManager.GetString("String_Improvement_SelectText", GlobalOptions.Language).Replace("{0}", strFriendlyName)
                        };
                        frmPickText.ShowDialog();

                        // Make sure the dialogue window was not canceled.
                        if (frmPickText.DialogResult == DialogResult.Cancel)
                        {

                            Rollback(objCharacter);
                            ForcedValue = string.Empty;
                            LimitSelection = string.Empty;
                            Log.Exit("CreateImprovements");
                            return false;
                        }

                        s_StrSelectedValue = frmPickText.SelectedValue;
                    }
                    if (blnConcatSelectedValue)
                        strSourceName += " (" + SelectedValue + ')';
                    Log.Info("_strSelectedValue = " + SelectedValue);
                    Log.Info("strSourceName = " + strSourceName);

                    // Create the Improvement.
                    Log.Info("Calling CreateImprovement");

                    CreateImprovement(objCharacter, s_StrSelectedValue, objImprovementSource, strSourceName,
                        Improvement.ImprovementType.Text,
                        strUnique);
                }

                // Check to see what bonuses the node grants.
                foreach (XmlNode bonusNode in nodBonus.ChildNodes)
                {
                    if (!ProcessBonus(objCharacter, objImprovementSource, ref strSourceName, blnConcatSelectedValue, intRating,
                        strFriendlyName, bonusNode, strUnique))
                    {
                        Rollback(objCharacter);
                        return false;
                    }
                }
            }

            // If we've made it this far, everything went OK, so commit the Improvements.
            Log.Info("Calling Commit");
            Commit(objCharacter);
            Log.Info("Returned from Commit");
            // Clear the Forced Value and Limit Selection strings once we're done to prevent these from forcing their values on other Improvements.
            s_StrForcedValue = string.Empty;
            s_StrLimitSelection = string.Empty;

            /*}
            catch (Exception ex)
            {
                objFunctions.LogWrite(CommonFunctions.LogType.Error, "Chummer.ImprovementManager", "ERROR Message = " + ex.Message);
                objFunctions.LogWrite(CommonFunctions.LogType.Error, "Chummer.ImprovementManager", "ERROR Source  = " + ex.Source);
                objFunctions.LogWrite(CommonFunctions.LogType.Error, "Chummer.ImprovementManager",
                    "ERROR Trace   = " + ex.StackTrace.ToString());

                Rollback();
                throw;
            }*/
            Log.Exit("CreateImprovements");
            return true;

        }

        private static bool ProcessBonus(Character objCharacter, Improvement.ImprovementSource objImprovementSource, ref string strSourceName,
            bool blnConcatSelectedValue, int intRating, string strFriendlyName, XmlNode bonusNode, string strUnique)
        {
            if (bonusNode == null)
                return false;
            //As this became a really big nest of **** that it searched past, several places having equal paths just adding a different improvement, a more flexible method was chosen.
            //So far it is just a slower Dictionar<string, Action> but should (in theory...) be able to leverage this in the future to do it smarter with methods that are the same but
            //getting a different parameter injected

            AddImprovementCollection container = new AddImprovementCollection(objCharacter, objImprovementSource,
                strSourceName, strUnique, s_StrForcedValue, s_StrLimitSelection, SelectedValue, blnConcatSelectedValue,
                strFriendlyName, intRating, ValueToInt);

            Action<XmlNode> objImprovementMethod = ImprovementMethods.GetMethod(bonusNode.Name.ToUpperInvariant(), container);
            if (objImprovementMethod != null)
            {
                try
                {
                    objImprovementMethod.Invoke(bonusNode);
                }
                catch (AbortedException)
                {
                    Rollback(objCharacter);
                    return false;
                }

                strSourceName = container.SourceName;
                s_StrForcedValue = container.ForcedValue;
                s_StrLimitSelection = container.LimitSelection;
                s_StrSelectedValue = container.SelectedValue;
            }
            else if (bonusNode.ChildNodes.Count == 0)
            {
                return true;
            }
            else if (bonusNode.NodeType != XmlNodeType.Comment)
            {
                Utils.BreakIfDebug();
                Log.Warning(new object[] {"Tried to get unknown bonus", bonusNode.OuterXml});
                return false;
            }
            return true;
        }

        public static void EnableImprovements(Character objCharacter, IList<Improvement> objImprovementList)
        {
            foreach (Improvement objImprovement in objImprovementList)
            {
                // Enable the Improvement.
                objImprovement.Enabled = true;
            }

            bool blnDoSkillsSectionForceProperyChangedNotificationAll = false;
            bool blnDoAttributeSectionForceProperyChangedNotificationAll = false;
            // Now that the entire list is deleted from the character's improvements list, we do the checking of duplicates and extra effects
            foreach (Improvement objImprovement in objImprovementList)
            {
                switch (objImprovement.ImproveType)
                {
                    case Improvement.ImprovementType.SkillLevel:
                        //TODO: Come back here and figure out wtf this did? Think it removed nested lifemodule skills? //Didn't this handle the collapsing knowledge skills thing?
                        //for (int i = _objCharacter.SkillsSection.Skills.Count - 1; i >= 0; i--)
                        //{
                        //    //wrote as foreach first, modify collection, not want rename
                        //    Skill skill = _objCharacter.SkillsSection.Skills[i];
                        //    for (int j = skill.Fold.Count - 1; j >= 0; j--)
                        //    {
                        //        Skill fold = skill.Fold[i];
                        //        if (fold.Id.ToString() == objImprovement.ImprovedName)
                        //        {
                        //            skill.Free(fold);
                        //            _objCharacter.SkillsSection.Skills.Remove(fold);
                        //        }
                        //    }

                        //    if (skill.Id.ToString() == objImprovement.ImprovedName)
                        //    {
                        //        while(skill.Fold.Count > 0) skill.Free(skill.Fold[0]);
                        //        //empty list, can't call clear as exposed list is RO

                        //        _objCharacter.SkillsSection.Skills.Remove(skill);
                        //    }
                        //}
                        break;
                    case Improvement.ImprovementType.SwapSkillAttribute:
                    case Improvement.ImprovementType.SwapSkillSpecAttribute:
                        blnDoSkillsSectionForceProperyChangedNotificationAll = true;
                        break;
                    case Improvement.ImprovementType.SkillsoftAccess:
                        foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowsoftSkills)
                        {
                            objKnowledgeSkill.Enabled = true;
                        }
                        break;
                    case Improvement.ImprovementType.SkillKnowledgeForced:
                        {
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowledgeSkills.Where(x => x.InternalId == objImprovement.ImprovedName).ToList())
                            {
                                objKnowledgeSkill.Enabled = true;
                            }
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowsoftSkills.Where(x => x.InternalId == objImprovement.ImprovedName).ToList())
                            {
                                objKnowledgeSkill.Enabled = true;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.Attribute:
                        // Determine if access to any Special Attributes have been lost.
                        if (objImprovement.UniqueName == "enableattribute")
                        {
                            switch (objImprovement.ImprovedName)
                            {
                                case "MAG":
                                    objCharacter.MAGEnabled = true;
                                    break;
                                case "RES":
                                    objCharacter.RESEnabled = true;
                                    break;
                                case "DEP":
                                    objCharacter.DEPEnabled = true;
                                    break;
                            }
                        }
                        blnDoAttributeSectionForceProperyChangedNotificationAll = true;
                        break;
                    case Improvement.ImprovementType.SpecialTab:
                        // Determine if access to any special tabs have been lost.
                        if (objImprovement.UniqueName == "enabletab")
                        {
                            switch (objImprovement.ImprovedName)
                            {
                                case "Magician":
                                    objCharacter.MagicianEnabled = true;
                                    break;
                                case "Adept":
                                    objCharacter.AdeptEnabled = true;
                                    break;
                                case "Technomancer":
                                    objCharacter.TechnomancerEnabled = true;
                                    break;
                                case "Advanced Programs":
                                    objCharacter.AdvancedProgramsEnabled = true;
                                    break;
                                case "Critter":
                                    objCharacter.CritterEnabled = true;
                                    break;
                                case "Initiation":
                                    objCharacter.InitiationEnabled = true;
                                    break;
                            }
                        }
                        // Determine if access to any special tabs has been regained
                        else if (objImprovement.UniqueName == "disabletab")
                        {
                            switch (objImprovement.ImprovedName)
                            {
                                case "Cyberware":
                                    objCharacter.CyberwareDisabled = true;
                                    break;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.BlackMarketDiscount:
                        objCharacter.BlackMarketDiscount = true;
                        break;
                    case Improvement.ImprovementType.FriendsInHighPlaces:
                        objCharacter.FriendsInHighPlaces = true;
                        break;
                    case Improvement.ImprovementType.ExCon:
                        objCharacter.ExCon = true;
                        break;
                    case Improvement.ImprovementType.PrototypeTranshuman:
                        string strImprovedName = objImprovement.ImprovedName;
                        // Legacy compatibility
                        if (string.IsNullOrEmpty(strImprovedName))
                            objCharacter.PrototypeTranshuman = 1;
                        else
                            objCharacter.PrototypeTranshuman += Convert.ToDecimal(strImprovedName);
                        break;
                    case Improvement.ImprovementType.Erased:
                        objCharacter.Erased = true;
                        break;
                    case Improvement.ImprovementType.BornRich:
                        objCharacter.BornRich = true;
                        break;
                    case Improvement.ImprovementType.Fame:
                        objCharacter.Fame = true;
                        break;
                    case Improvement.ImprovementType.MadeMan:
                        objCharacter.MadeMan = true;
                        break;
                    case Improvement.ImprovementType.Ambidextrous:
                        objCharacter.Ambidextrous = true;
                        break;
                    case Improvement.ImprovementType.Overclocker:
                        objCharacter.Overclocker = false;
                        break;
                    case Improvement.ImprovementType.RestrictedGear:
                        objCharacter.RestrictedGear = true;
                        break;
                    case Improvement.ImprovementType.TrustFund:
                        objCharacter.TrustFund = objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Adapsin:
                        break;
                    case Improvement.ImprovementType.ContactForceGroup:
                        Contact MadeManContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                        if (MadeManContact != null)
                            MadeManContact.GroupEnabled = false;
                        break;
                    case Improvement.ImprovementType.AddContact:
                        Contact NewContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                        if (NewContact != null)
                        {
                            // TODO: Add code to enable disabled contact
                        }
                        break;
                    case Improvement.ImprovementType.Initiation:
                        objCharacter.InitiateGrade += objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Submersion:
                        objCharacter.SubmersionGrade += objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Metamagic:
                    case Improvement.ImprovementType.Echo:
                        Metamagic objMetamagic = objCharacter.Metamagics.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMetamagic != null)
                        {
                            Improvement.ImprovementSource eSource = objImprovement.ImproveType == Improvement.ImprovementType.Metamagic ? Improvement.ImprovementSource.Metamagic : Improvement.ImprovementSource.Echo;
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == eSource && x.SourceName == objMetamagic.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.CritterPower:
                        CritterPower objCritterPower = objCharacter.CritterPowers.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName || (x.Name == objImprovement.ImprovedName && x.Extra == objImprovement.UniqueName));
                        if (objCritterPower != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.CritterPower && x.SourceName == objCritterPower.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.MentorSpirit:
                    case Improvement.ImprovementType.Paragon:
                        MentorSpirit objMentor = objCharacter.MentorSpirits.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMentor != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MentorSpirit && x.SourceName == objMentor.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.Gear:
                        Gear objGear = objCharacter.Gear.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        objGear?.ChangeEquippedStatus(true);
                        break;
                    case Improvement.ImprovementType.Weapon:
                        // TODO: Re-equip Weapons;
                        break;
                    case Improvement.ImprovementType.Spell:
                        Spell objSpell = objCharacter.Spells.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objSpell != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.Spell && x.SourceName == objSpell.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.ComplexForm:
                        ComplexForm objComplexForm = objCharacter.ComplexForms.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objComplexForm != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.ComplexForm && x.SourceName == objComplexForm.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.MartialArt:
                        MartialArt objMartialArt = objCharacter.MartialArts.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMartialArt != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MartialArt && x.SourceName == objMartialArt.InternalId && x.Enabled).ToList());
                            // Remove the Improvements for any Advantages for the Martial Art that is being removed.
                            foreach (MartialArtTechnique objTechnique in objMartialArt.Techniques)
                            {
                                EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MartialArtTechnique && x.SourceName == objTechnique.InternalId && x.Enabled).ToList());
                            }
                        }
                        break;
                    case Improvement.ImprovementType.SpecialSkills:
                        {
                            string strCategory;
                            switch ((FilterOptions)Enum.Parse(typeof(FilterOptions), objImprovement.ImprovedName))
                            {
                                case FilterOptions.Magician:
                                case FilterOptions.Sorcery:
                                case FilterOptions.Conjuring:
                                case FilterOptions.Enchanting:
                                case FilterOptions.Adept:
                                    strCategory = "Magical Active";
                                    break;
                                case FilterOptions.Technomancer:
                                    strCategory = "Resonance Active";
                                    break;
                                default:
                                    continue;
                            }
                            
                            foreach (Skill objSkill in objCharacter.SkillsSection.Skills.Where(x => x.SkillCategory == strCategory).ToList())
                            {
                                objSkill.Enabled = true;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.SpecificQuality:
                        Quality objQuality = objCharacter.Qualities.FirstOrDefault(objLoopQuality => objLoopQuality.InternalId == objImprovement.ImprovedName);
                        if (objQuality != null)
                        {
                            EnableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.Quality && x.SourceName == objQuality.InternalId && x.Enabled).ToList());
                        }
                        break;
                    /*
                    case Improvement.ImprovementType.SkillSpecialization:
                        {
                            Skill objSkill = objCharacter.SkillsSection.GetActiveSkill(objImprovement.ImprovedName);
                            SkillSpecialization objSkillSpec = objSkill?.Specializations.FirstOrDefault(x => x.Name == objImprovement.UniqueName);
                            //if (objSkillSpec != null)
                            // TODO: Add temporarily removde skill specialization
                        }
                        break;
                        */
                    case Improvement.ImprovementType.AIProgram:
                        AIProgram objProgram = objCharacter.AIPrograms.FirstOrDefault(objLoopProgram => objLoopProgram.InternalId == objImprovement.ImprovedName);
                        if (objProgram != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.AIProgram && x.SourceName == objProgram.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.AdeptPowerFreeLevels:
                    case Improvement.ImprovementType.AdeptPowerFreePoints:
                        // Get the power improved by this improvement
                        Power objImprovedPower = objCharacter.Powers.FirstOrDefault(objPower => objPower.Name == objImprovement.ImprovedName && objPower.Extra == objImprovement.UniqueName);
                        objImprovedPower?.OnPropertyChanged(nameof(objImprovedPower.TotalRating));
                        break;
                    case Improvement.ImprovementType.MagiciansWayDiscount:
                        foreach (Power objLoopPower in objCharacter.Powers.Where(x => x.DiscountedAdeptWay))
                        {
                            objLoopPower.RefreshDiscountedAdeptWay(objLoopPower.AdeptWayDiscountEnabled);
                        }
                        break;
                    case Improvement.ImprovementType.FreeWare:
                        {
                            Cyberware objCyberware = objCharacter.Cyberware.FirstOrDefault(o => o.InternalId == objImprovement.ImprovedName);
                            objCyberware?.ChangeModularEquip(true);
                        }
                        break;
                    case Improvement.ImprovementType.ContactForcedLoyalty:
                        {
                            Contact objContact = objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName);
                            if (objContact != null)
                                objContact.ForcedLoyalty = Math.Max(objContact.ForcedLoyalty, objImprovement.Value);
                        }
                        break;
                    case Improvement.ImprovementType.ContactMakeFree:
                        {
                            Contact objContact = objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName);
                            if (objContact != null)
                                objContact.Free = true;
                        }
                        break;
                }
            }

            if (blnDoSkillsSectionForceProperyChangedNotificationAll)
                objCharacter.SkillsSection.ForceProperyChangedNotificationAll(nameof(Skill.PoolToolTip));
            if (blnDoAttributeSectionForceProperyChangedNotificationAll)
                objCharacter.AttributeSection.ForceAttributePropertyChangedNotificationAll(nameof(CharacterAttrib.AttributeModifiers));
            objCharacter.ImprovementHook(objImprovementList);
        }

        public static void DisableImprovements(Character objCharacter, IList<Improvement> objImprovementList)
        {
            foreach (Improvement objImprovement in objImprovementList)
            {
                // Disable the Improvement.
                objImprovement.Enabled = false;
            }

            bool blnDoSkillsSectionForceProperyChangedNotificationAll = false;
            bool blnDoAttributeSectionForceProperyChangedNotificationAll = false;
            // Now that the entire list is deleted from the character's improvements list, we do the checking of duplicates and extra effects
            foreach (Improvement objImprovement in objImprovementList)
            {
                bool blnHasDuplicate = objCharacter.Improvements.Any(x => x.UniqueName == objImprovement.UniqueName && x.ImprovedName == objImprovement.ImprovedName && x.ImproveType == objImprovement.ImproveType && x.SourceName != objImprovement.SourceName && x.Enabled);

                switch (objImprovement.ImproveType)
                {
                    case Improvement.ImprovementType.SkillLevel:
                        //TODO: Come back here and figure out wtf this did? Think it removed nested lifemodule skills? //Didn't this handle the collapsing knowledge skills thing?
                        //for (int i = _objCharacter.SkillsSection.Skills.Count - 1; i >= 0; i--)
                        //{
                        //    //wrote as foreach first, modify collection, not want rename
                        //    Skill skill = _objCharacter.SkillsSection.Skills[i];
                        //    for (int j = skill.Fold.Count - 1; j >= 0; j--)
                        //    {
                        //        Skill fold = skill.Fold[i];
                        //        if (fold.Id.ToString() == objImprovement.ImprovedName)
                        //        {
                        //            skill.Free(fold);
                        //            _objCharacter.SkillsSection.Skills.Remove(fold);
                        //        }
                        //    }

                        //    if (skill.Id.ToString() == objImprovement.ImprovedName)
                        //    {
                        //        while(skill.Fold.Count > 0) skill.Free(skill.Fold[0]);
                        //        //empty list, can't call clear as exposed list is RO

                        //        _objCharacter.SkillsSection.Skills.Remove(skill);
                        //    }
                        //}
                        break;
                    case Improvement.ImprovementType.SwapSkillAttribute:
                    case Improvement.ImprovementType.SwapSkillSpecAttribute:
                        blnDoSkillsSectionForceProperyChangedNotificationAll = blnDoSkillsSectionForceProperyChangedNotificationAll || objImprovement.Enabled;
                        break;
                    case Improvement.ImprovementType.SkillsoftAccess:
                        if (!blnHasDuplicate)
                        {
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowsoftSkills)
                            {
                                objKnowledgeSkill.Enabled = false;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.SkillKnowledgeForced:
                        if (!blnHasDuplicate)
                        {
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowledgeSkills.Where(x => x.InternalId == objImprovement.ImprovedName).ToList())
                            {
                                objKnowledgeSkill.Enabled = false;
                            }
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowsoftSkills.Where(x => x.InternalId == objImprovement.ImprovedName).ToList())
                            {
                                objKnowledgeSkill.Enabled = false;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.Attribute:
                        // Determine if access to any Special Attributes have been lost.
                        if (objImprovement.UniqueName == "enableattribute" && !blnHasDuplicate)
                        {
                            switch (objImprovement.ImprovedName)
                            {
                                case "MAG":
                                    objCharacter.MAGEnabled = false;
                                    break;
                                case "RES":
                                    objCharacter.RESEnabled = false;
                                    break;
                                case "DEP":
                                    objCharacter.DEPEnabled = false;
                                    break;
                            }
                        }
                        blnDoAttributeSectionForceProperyChangedNotificationAll = true;
                        break;
                    case Improvement.ImprovementType.SpecialTab:
                        // Determine if access to any special tabs have been lost.
                        if (!blnHasDuplicate)
                        {
                            if (objImprovement.UniqueName == "enabletab")
                            {
                                switch (objImprovement.ImprovedName)
                                {
                                    case "Magician":
                                        objCharacter.MagicianEnabled = false;
                                        break;
                                    case "Adept":
                                        objCharacter.AdeptEnabled = false;
                                        break;
                                    case "Technomancer":
                                        objCharacter.TechnomancerEnabled = false;
                                        break;
                                    case "Advanced Programs":
                                        objCharacter.AdvancedProgramsEnabled = false;
                                        break;
                                    case "Critter":
                                        objCharacter.CritterEnabled = false;
                                        break;
                                    case "Initiation":
                                        objCharacter.InitiationEnabled = false;
                                        break;
                                }
                            }
                            // Determine if access to any special tabs has been regained
                            else if (objImprovement.UniqueName == "disabletab")
                            {
                                switch (objImprovement.ImprovedName)
                                {
                                    case "Cyberware":
                                        objCharacter.CyberwareDisabled = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case Improvement.ImprovementType.BlackMarketDiscount:
                        if (!blnHasDuplicate)
                            objCharacter.BlackMarketDiscount = false;
                        break;
                    case Improvement.ImprovementType.FriendsInHighPlaces:
                        if (!blnHasDuplicate)
                            objCharacter.FriendsInHighPlaces = false;
                        break;
                    case Improvement.ImprovementType.ExCon:
                        if (!blnHasDuplicate)
                            objCharacter.ExCon = false;
                        break;
                    case Improvement.ImprovementType.PrototypeTranshuman:
                        string strImprovedName = objImprovement.ImprovedName;
                        // Legacy compatibility
                        if (string.IsNullOrEmpty(strImprovedName))
                        {
                            if (!blnHasDuplicate)
                                objCharacter.PrototypeTranshuman = 0;
                        }
                        else
                            objCharacter.PrototypeTranshuman -= Convert.ToDecimal(strImprovedName);
                        break;
                    case Improvement.ImprovementType.Erased:
                        if (!blnHasDuplicate)
                            objCharacter.Erased = false;
                        break;
                    case Improvement.ImprovementType.BornRich:
                        if (!blnHasDuplicate)
                            objCharacter.BornRich = false;
                        break;
                    case Improvement.ImprovementType.Fame:
                        if (!blnHasDuplicate)
                            objCharacter.Fame = false;
                        break;
                    case Improvement.ImprovementType.MadeMan:
                        if (!blnHasDuplicate)
                            objCharacter.MadeMan = false;
                        break;
                    case Improvement.ImprovementType.Ambidextrous:
                        if (!blnHasDuplicate)
                            objCharacter.Ambidextrous = false;
                        break;
                    case Improvement.ImprovementType.Overclocker:
                        if (!blnHasDuplicate)
                            objCharacter.Overclocker = false;
                        break;
                    case Improvement.ImprovementType.RestrictedGear:
                        if (!blnHasDuplicate)
                            objCharacter.RestrictedGear = false;
                        break;
                    case Improvement.ImprovementType.TrustFund:
                        if (!blnHasDuplicate)
                            objCharacter.TrustFund = 0;
                        break;
                    case Improvement.ImprovementType.Adapsin:
                        break;
                    case Improvement.ImprovementType.ContactForceGroup:
                        if (!blnHasDuplicate)
                        {
                            Contact MadeManContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                            if (MadeManContact != null)
                                MadeManContact.GroupEnabled = true;
                        }
                        break;
                    case Improvement.ImprovementType.AddContact:
                        Contact NewContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                        if (NewContact != null)
                        {
                            // TODO: Add code to disable contact
                        }
                        break;
                    case Improvement.ImprovementType.Initiation:
                        objCharacter.InitiateGrade -= objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Submersion:
                        objCharacter.SubmersionGrade -= objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Metamagic:
                    case Improvement.ImprovementType.Echo:
                        Metamagic objMetamagic = objCharacter.Metamagics.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMetamagic != null)
                        {
                            Improvement.ImprovementSource eSource = objImprovement.ImproveType == Improvement.ImprovementType.Metamagic ? Improvement.ImprovementSource.Metamagic : Improvement.ImprovementSource.Echo;
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == eSource && x.SourceName == objMetamagic.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.CritterPower:
                        CritterPower objCritterPower = objCharacter.CritterPowers.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName || (x.Name == objImprovement.ImprovedName && x.Extra == objImprovement.UniqueName));
                        if (objCritterPower != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.CritterPower && x.SourceName == objCritterPower.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.MentorSpirit:
                    case Improvement.ImprovementType.Paragon:
                        MentorSpirit objMentor = objCharacter.MentorSpirits.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMentor != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MentorSpirit && x.SourceName == objMentor.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.Gear:
                        Gear objGear = objCharacter.Gear.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        objGear?.ChangeEquippedStatus(false);
                        break;
                    case Improvement.ImprovementType.Weapon:
                        // TODO: Unequip Weapons;
                        break;
                    case Improvement.ImprovementType.Spell:
                        Spell objSpell = objCharacter.Spells.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objSpell != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.Spell && x.SourceName == objSpell.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.ComplexForm:
                        ComplexForm objComplexForm = objCharacter.ComplexForms.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objComplexForm != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.ComplexForm && x.SourceName == objComplexForm.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.MartialArt:
                        MartialArt objMartialArt = objCharacter.MartialArts.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMartialArt != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MartialArt && x.SourceName == objMartialArt.InternalId && x.Enabled).ToList());
                            // Remove the Improvements for any Advantages for the Martial Art that is being removed.
                            foreach (MartialArtTechnique objTechnique in objMartialArt.Techniques)
                            {
                                DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.MartialArtTechnique && x.SourceName == objTechnique.InternalId && x.Enabled).ToList());
                            }
                        }
                        break;
                    case Improvement.ImprovementType.SpecialSkills:
                        if (!blnHasDuplicate)
                        {
                            string strCategory;
                            switch ((FilterOptions)Enum.Parse(typeof(FilterOptions), objImprovement.ImprovedName))
                            {
                                case FilterOptions.Magician:
                                case FilterOptions.Sorcery:
                                case FilterOptions.Conjuring:
                                case FilterOptions.Enchanting:
                                case FilterOptions.Adept:
                                    strCategory = "Magical Active";
                                    break;
                                case FilterOptions.Technomancer:
                                    strCategory = "Resonance Active";
                                    break;
                                default:
                                    continue;
                            }

                            string strLoopCategory = string.Empty;
                            foreach (Improvement objLoopImprovement in objCharacter.Improvements.Where(x => x.ImproveType == Improvement.ImprovementType.SpecialSkills && x.Enabled))
                            {
                                FilterOptions eLoopFilter = (FilterOptions)Enum.Parse(typeof(FilterOptions), objLoopImprovement.ImprovedName);
                                switch (eLoopFilter)
                                {
                                    case FilterOptions.Magician:
                                    case FilterOptions.Sorcery:
                                    case FilterOptions.Conjuring:
                                    case FilterOptions.Enchanting:
                                    case FilterOptions.Adept:
                                        strLoopCategory = "Magical Active";
                                        break;
                                    case FilterOptions.Technomancer:
                                        strLoopCategory = "Resonance Active";
                                        break;
                                }
                                if (strLoopCategory == strCategory)
                                    break;
                            }
                            if (strLoopCategory == strCategory)
                                continue;

                            foreach (Skill objSkill in objCharacter.SkillsSection.Skills.Where(x => x.SkillCategory == strCategory).ToList())
                            {
                                objSkill.Enabled = false;
                            }
                        }
                        break;
                    case Improvement.ImprovementType.SpecificQuality:
                        Quality objQuality = objCharacter.Qualities.FirstOrDefault(objLoopQuality => objLoopQuality.InternalId == objImprovement.ImprovedName);
                        if (objQuality != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.Quality && x.SourceName == objQuality.InternalId && x.Enabled).ToList());
                        }
                        break;
                    /*
                    case Improvement.ImprovementType.SkillSpecialization:
                        {
                            Skill objSkill = objCharacter.SkillsSection.GetActiveSkill(objImprovement.ImprovedName);
                            SkillSpecialization objSkillSpec = objSkill?.Specializations.FirstOrDefault(x => x.Name == objImprovement.UniqueName);
                            //if (objSkillSpec != null)
                                // TODO: Temporarily remove skill specialization
                        }
                        break;
                        */
                    case Improvement.ImprovementType.AIProgram:
                        AIProgram objProgram = objCharacter.AIPrograms.FirstOrDefault(objLoopProgram => objLoopProgram.InternalId == objImprovement.ImprovedName);
                        if (objProgram != null)
                        {
                            DisableImprovements(objCharacter, objCharacter.Improvements.Where(x => x.ImproveSource == Improvement.ImprovementSource.AIProgram && x.SourceName == objProgram.InternalId && x.Enabled).ToList());
                        }
                        break;
                    case Improvement.ImprovementType.AdeptPowerFreeLevels:
                    case Improvement.ImprovementType.AdeptPowerFreePoints:
                        // Get the power improved by this improvement
                        Power objImprovedPower = objCharacter.Powers.FirstOrDefault(objPower => objPower.Name == objImprovement.ImprovedName && objPower.Extra == objImprovement.UniqueName);
                        objImprovedPower?.OnPropertyChanged(nameof(objImprovedPower.TotalRating));
                        break;
                    case Improvement.ImprovementType.MagiciansWayDiscount:
                        foreach (Power objLoopPower in objCharacter.Powers.Where(x => x.DiscountedAdeptWay))
                        {
                            objLoopPower.RefreshDiscountedAdeptWay(objLoopPower.AdeptWayDiscountEnabled);
                        }
                        break;
                    case Improvement.ImprovementType.FreeWare:
                        {
                            Cyberware objCyberware = objCharacter.Cyberware.FirstOrDefault(o => o.InternalId == objImprovement.ImprovedName);
                            objCyberware?.ChangeModularEquip(false);
                        }
                        break;
                    case Improvement.ImprovementType.ContactForcedLoyalty:
                        {
                            objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName)?.RecalculateForcedLoyalty();
                        }
                        break;
                    case Improvement.ImprovementType.ContactMakeFree:
                        {
                            if (!blnHasDuplicate)
                            {
                                Contact objContact = objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName);
                                if (objContact != null)
                                    objContact.Free = false;
                            }
                        }
                        break;
                }
            }

            if (blnDoSkillsSectionForceProperyChangedNotificationAll)
                objCharacter.SkillsSection.ForceProperyChangedNotificationAll(nameof(Skill.PoolToolTip));
            if (blnDoAttributeSectionForceProperyChangedNotificationAll)
                objCharacter.AttributeSection.ForceAttributePropertyChangedNotificationAll(nameof(CharacterAttrib.AttributeModifiers));
            objCharacter.ImprovementHook(objImprovementList);
        }

        /// <summary>
        /// Remove all of the Improvements for an XML Node.
        /// </summary>
        /// <param name="objCharacter">Character from which improvements should be deleted.</param>
        /// <param name="objImprovementSource">Type of object that granted these Improvements.</param>
        /// <param name="strSourceName">Name of the item that granted these Improvements.</param>
        public static decimal RemoveImprovements(Character objCharacter, Improvement.ImprovementSource objImprovementSource, string strSourceName = "")
        {
            // If there is no character object, don't try to remove any Improvements.
            if (objCharacter == null)
            {
                return 0;
            }

            Log.Info("objImprovementSource = " + objImprovementSource.ToString());
            Log.Info("strSourceName = " + strSourceName);
            // A List of Improvements to hold all of the items that will eventually be deleted.
            List<Improvement> objImprovementList = string.IsNullOrEmpty(strSourceName)
                ? objCharacter.Improvements.Where(objImprovement => objImprovement.ImproveSource == objImprovementSource).ToList()
                : objCharacter.Improvements.Where(objImprovement => objImprovement.ImproveSource == objImprovementSource && objImprovement.SourceName == strSourceName).ToList();
            return RemoveImprovements(objCharacter, objImprovementList);
        }

        /// <summary>
        /// Remove all of the Improvements for an XML Node.
        /// </summary>
        /// <param name="objCharacter">Character from which improvements should be deleted.</param>
        /// <param name="objImprovementList">List of improvements to delete.</param>
        /// <param name="blnReapplyImprovements">Whether we're reapplying Improvements.</param>
        /// <param name="blnAllowDuplicatesFromSameSource">If we ignore checking whether a potential duplicate improvement has the same SourceName</param>
        public static decimal RemoveImprovements(Character objCharacter, IList<Improvement> objImprovementList, bool blnReapplyImprovements = false, bool blnAllowDuplicatesFromSameSource = false)
        {
            Log.Enter("RemoveImprovements");

            // If there is no character object, don't try to remove any Improvements.
            if (objCharacter == null)
            {
                Log.Exit("RemoveImprovements");
                return 0;
            }

            // Note: As attractive as it may be to replace objImprovementList with an IEnumerable, we need to iterate through it twice for performance reasons

            // Now that we have all of the applicable Improvements, remove them from the character.
            foreach (Improvement objImprovement in objImprovementList)
            {
                // Remove the Improvement.
                objCharacter.Improvements.Remove(objImprovement);
                ClearCachedValue(new Tuple<Character, Improvement.ImprovementType>(objCharacter, objImprovement.ImproveType));
            }
            decimal decReturn = 0;
            bool blnDoSkillsSectionForceProperyChangedNotificationAll = false;
            bool blnDoAttributeSectionForceProperyChangedNotificationAll = false;
            // Now that the entire list is deleted from the character's improvements list, we do the checking of duplicates and extra effects
            foreach (Improvement objImprovement in objImprovementList)
            {
                // See if the character has anything else that is granting them the same bonus as this improvement
                bool blnHasDuplicate = objCharacter.Improvements.Any(x => x.UniqueName == objImprovement.UniqueName && x.ImprovedName == objImprovement.ImprovedName && x.ImproveType == objImprovement.ImproveType && (blnAllowDuplicatesFromSameSource || x.SourceName != objImprovement.SourceName));

                switch (objImprovement.ImproveType)
                {
                    case Improvement.ImprovementType.SkillLevel:
                    //TODO: Come back here and figure out wtf this did? Think it removed nested lifemodule skills? //Didn't this handle the collapsing knowledge skills thing?
                    //for (int i = _objCharacter.SkillsSection.Skills.Count - 1; i >= 0; i--)
                    //{
                    //    //wrote as foreach first, modify collection, not want rename
                    //    Skill skill = _objCharacter.SkillsSection.Skills[i];
                    //    for (int j = skill.Fold.Count - 1; j >= 0; j--)
                    //    {
                    //        Skill fold = skill.Fold[i];
                    //        if (fold.Id.ToString() == objImprovement.ImprovedName)
                    //        {
                    //            skill.Free(fold);
                    //            _objCharacter.SkillsSection.Skills.Remove(fold);
                    //        }
                    //    }

                    //    if (skill.Id.ToString() == objImprovement.ImprovedName)
                    //    {
                    //        while(skill.Fold.Count > 0) skill.Free(skill.Fold[0]);
                    //        //empty list, can't call clear as exposed list is RO

                    //        _objCharacter.SkillsSection.Skills.Remove(skill);
                    //    }
                    //}
                        break;
                    case Improvement.ImprovementType.SwapSkillAttribute:
                    case Improvement.ImprovementType.SwapSkillSpecAttribute:
                        blnDoSkillsSectionForceProperyChangedNotificationAll = true;
                        break;
                    case Improvement.ImprovementType.SkillsoftAccess:
                        foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowledgeSkills.Where(objCharacter.SkillsSection.KnowsoftSkills.Contains).ToList())
                        {
                            objKnowledgeSkill.UnbindSkill();
                            objCharacter.SkillsSection.KnowledgeSkills.Remove(objKnowledgeSkill);
                        }
                        break;
                    case Improvement.ImprovementType.SkillKnowledgeForced:
                        {
                            foreach (KnowledgeSkill objKnowledgeSkill in objCharacter.SkillsSection.KnowledgeSkills.Where(x => x.InternalId == objImprovement.ImprovedName).ToList())
                            {
                                objKnowledgeSkill.UnbindSkill();
                                objCharacter.SkillsSection.KnowledgeSkills.Remove(objKnowledgeSkill);
                            }
                            for (int i = objCharacter.SkillsSection.KnowsoftSkills.Count; i >= 0; --i)
                            {
                                KnowledgeSkill objSkill = objCharacter.SkillsSection.KnowsoftSkills[i];
                                if (objSkill.InternalId == objImprovement.ImprovedName)
                                {
                                    objSkill.UnbindSkill();
                                    objCharacter.SkillsSection.KnowsoftSkills.RemoveAt(i);
                                }
                            }
                        }
                        break;
                    case Improvement.ImprovementType.Attribute:
                        // Determine if access to any Special Attributes have been lost.
                        if (objImprovement.UniqueName == "enableattribute" && !blnHasDuplicate)
                        {
                            switch (objImprovement.ImprovedName)
                            {
                                case "MAG":
                                    objCharacter.MAGEnabled = false;
                                    break;
                                case "RES":
                                    objCharacter.RESEnabled = false;
                                    break;
                                case "DEP":
                                    objCharacter.DEPEnabled = false;
                                    break;
                            }
                        }
                        blnDoAttributeSectionForceProperyChangedNotificationAll = blnDoAttributeSectionForceProperyChangedNotificationAll || objImprovement.Enabled;
                        break;
                    case Improvement.ImprovementType.SpecialTab:
                        // Determine if access to any special tabs have been lost.
                        if (!blnHasDuplicate)
                        {
                            if (objImprovement.UniqueName == "enabletab")
                            {
                                switch (objImprovement.ImprovedName)
                                {
                                    case "Magician":
                                        objCharacter.MagicianEnabled = false;
                                        break;
                                    case "Adept":
                                        objCharacter.AdeptEnabled = false;
                                        break;
                                    case "Technomancer":
                                        objCharacter.TechnomancerEnabled = false;
                                        break;
                                    case "Advanced Programs":
                                        objCharacter.AdvancedProgramsEnabled = false;
                                        break;
                                    case "Critter":
                                        objCharacter.CritterEnabled = false;
                                        break;
                                    case "Initiation":
                                        objCharacter.InitiationEnabled = false;
                                        break;
                                }
                            }
                            // Determine if access to any special tabs has been regained
                            else if (objImprovement.UniqueName == "disabletab")
                            {
                                switch (objImprovement.ImprovedName)
                                {
                                    case "Cyberware":
                                        objCharacter.CyberwareDisabled = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case Improvement.ImprovementType.BlackMarketDiscount:
                        if (!blnHasDuplicate)
                            objCharacter.BlackMarketDiscount = false;
                        break;
                    case Improvement.ImprovementType.FriendsInHighPlaces:
                        if (!blnHasDuplicate)
                            objCharacter.FriendsInHighPlaces = false;
                        break;
                    case Improvement.ImprovementType.ExCon:
                        if (!blnHasDuplicate)
                            objCharacter.ExCon = false;
                        break;
                    case Improvement.ImprovementType.PrototypeTranshuman:
                        string strImprovedName = objImprovement.ImprovedName;
                        // Legacy compatibility
                        if (string.IsNullOrEmpty(strImprovedName))
                        {
                            if (!blnHasDuplicate)
                                objCharacter.PrototypeTranshuman = 0;
                        }
                        else
                            objCharacter.PrototypeTranshuman -= Convert.ToDecimal(strImprovedName);
                        break;
                    case Improvement.ImprovementType.Erased:
                        if (!blnHasDuplicate)
                            objCharacter.Erased = false;
                        break;
                    case Improvement.ImprovementType.BornRich:
                        if (!blnHasDuplicate)
                            objCharacter.BornRich = false;
                        break;
                    case Improvement.ImprovementType.Fame:
                        if (!blnHasDuplicate)
                            objCharacter.Fame = false;
                        break;
                    case Improvement.ImprovementType.MadeMan:
                        if (!blnHasDuplicate)
                            objCharacter.MadeMan = false;
                        break;
                    case Improvement.ImprovementType.Ambidextrous:
                        if (!blnHasDuplicate)
                            objCharacter.Ambidextrous = false;
                        break;
                    case Improvement.ImprovementType.Overclocker:
                        if (!blnHasDuplicate)
                            objCharacter.Overclocker = false;
                        break;
                    case Improvement.ImprovementType.RestrictedGear:
                        if (!blnHasDuplicate)
                            objCharacter.RestrictedGear = false;
                        break;
                    case Improvement.ImprovementType.TrustFund:
                        if (!blnHasDuplicate)
                            objCharacter.TrustFund = 0;
                        break;
                    case Improvement.ImprovementType.Adapsin:
                        {
                            if (!blnHasDuplicate)
                            {
                                foreach (Cyberware objCyberware in objCharacter.Cyberware.DeepWhere(x => x.Children, x => x.Grade.Adapsin))
                                {
                                    string strNewName = objCyberware.Grade.Name.FastEscapeOnceFromEnd("(Adapsin)").Trim();
                                    // Determine which GradeList to use for the Cyberware.
                                    objCyberware.Grade = objCharacter.GetGradeList(objCyberware.SourceType, true).FirstOrDefault(x => x.Name == strNewName);
                                }
                            }
                        }
                        break;
                    case Improvement.ImprovementType.ContactForceGroup:
                        if (!blnHasDuplicate)
                        {
                            Contact MadeManContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                            if (MadeManContact != null)
                                MadeManContact.GroupEnabled = true;
                        }
                        break;
                    case Improvement.ImprovementType.AddContact:
                        Contact NewContact = objCharacter.Contacts.FirstOrDefault(c => c.GUID == objImprovement.ImprovedName);
                        if (NewContact != null)
                            objCharacter.Contacts.Remove(NewContact);
                        break;
                    case Improvement.ImprovementType.Initiation:
                        objCharacter.InitiateGrade -= objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Submersion:
                        objCharacter.SubmersionGrade -= objImprovement.Value;
                        break;
                    case Improvement.ImprovementType.Metamagic:
                    case Improvement.ImprovementType.Echo:
                        Metamagic objMetamagic = objCharacter.Metamagics.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMetamagic != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, objImprovement.ImproveType == Improvement.ImprovementType.Metamagic ? Improvement.ImprovementSource.Metamagic : Improvement.ImprovementSource.Echo, objMetamagic.InternalId);
                            objCharacter.Metamagics.Remove(objMetamagic);
                        }
                        break;
                    case Improvement.ImprovementType.CritterPower:
                        CritterPower objCritterPower = objCharacter.CritterPowers.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName || ( x.Name == objImprovement.ImprovedName && x.Extra == objImprovement.UniqueName));
                        if (objCritterPower != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.CritterPower, objCritterPower.InternalId);
                            objCharacter.CritterPowers.Remove(objCritterPower);
                        }
                        break;
                    case Improvement.ImprovementType.MentorSpirit:
                    case Improvement.ImprovementType.Paragon:
                        MentorSpirit objMentor = objCharacter.MentorSpirits.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMentor != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.MentorSpirit, objMentor.InternalId);
                            objCharacter.MentorSpirits.Remove(objMentor);
                        }
                        break;
                    case Improvement.ImprovementType.Gear:
                        Gear objGear = objCharacter.Gear.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objGear != null)
                        {
                            decReturn += objGear.DeleteGear();
                            decReturn += objGear.TotalCost;
                            objCharacter.Gear.Remove(objGear);
                        }
                        break;
                    case Improvement.ImprovementType.Weapon:
                    {
                        Vehicle objVehicle = null;
                        WeaponMount objWeaponMount = null;
                        VehicleMod objVehicleMod = null;
                        Weapon objWeapon = objCharacter.Weapons.DeepFirstOrDefault(x => x.Children, x => x.InternalId == objImprovement.ImprovedName) ??
                                           objCharacter.Vehicles.FindVehicleWeapon(objImprovement.ImprovedName, out objVehicle, out objWeaponMount, out objVehicleMod);
                        if (objWeapon != null)
                        {
                            decReturn += objWeapon.DeleteWeapon();
                            decReturn += objWeapon.TotalCost;
                            Weapon objParent = objWeapon.Parent;
                            if (objParent != null)
                                objParent.Children.Remove(objWeapon);
                            else if (objVehicleMod != null)
                                objVehicleMod.Weapons.Remove(objWeapon);
                            else if (objWeaponMount != null)
                                objWeaponMount.Weapons.Remove(objWeapon);
                            else if (objVehicle != null)
                                objVehicle.Weapons.Remove(objWeapon);
                            else
                                objCharacter.Weapons.Remove(objWeapon);
                        }
                    }
                        break;
                    case Improvement.ImprovementType.Spell:
                        Spell objSpell = objCharacter.Spells.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objSpell != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.Spell, objSpell.InternalId);
                            objCharacter.Spells.Remove(objSpell);
                        }
                        break;
                    case Improvement.ImprovementType.ComplexForm:
                        ComplexForm objComplexForm = objCharacter.ComplexForms.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objComplexForm != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.ComplexForm, objComplexForm.InternalId);
                            objCharacter.ComplexForms.Remove(objComplexForm);
                        }
                        break;
                    case Improvement.ImprovementType.MartialArt:
                        MartialArt objMartialArt = objCharacter.MartialArts.FirstOrDefault(x => x.InternalId == objImprovement.ImprovedName);
                        if (objMartialArt != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.MartialArt, objMartialArt.InternalId);
                            // Remove the Improvements for any Advantages for the Martial Art that is being removed.
                            foreach (MartialArtTechnique objAdvantage in objMartialArt.Techniques)
                            {
                                decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.MartialArtTechnique, objAdvantage.InternalId);
                            }
                            objCharacter.MartialArts.Remove(objMartialArt);
                        }
                        break;
                    case Improvement.ImprovementType.SpecialSkills:
                        if (!blnHasDuplicate)
                            objCharacter.SkillsSection.RemoveSkills((FilterOptions)Enum.Parse(typeof(FilterOptions), objImprovement.ImprovedName), !blnReapplyImprovements);
                        break;
                    case Improvement.ImprovementType.SpecificQuality:
                        Quality objQuality = objCharacter.Qualities.FirstOrDefault(objLoopQuality => objLoopQuality.InternalId == objImprovement.ImprovedName);
                        if (objQuality != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.Quality, objQuality.InternalId);
                            objCharacter.Qualities.Remove(objQuality);
                        }
                        break;
                    case Improvement.ImprovementType.SkillSpecialization:
                        {
                            Skill objSkill = objCharacter.SkillsSection.GetActiveSkill(objImprovement.ImprovedName);
                            SkillSpecialization objSkillSpec = objSkill?.Specializations.FirstOrDefault(x => x.Name == objImprovement.UniqueName);
                            if (objSkillSpec != null)
                                objSkill.Specializations.Remove(objSkillSpec);
                        }
                        break;
                    case Improvement.ImprovementType.AIProgram:
                        AIProgram objProgram = objCharacter.AIPrograms.FirstOrDefault(objLoopProgram => objLoopProgram.InternalId == objImprovement.ImprovedName);
                        if (objProgram != null)
                        {
                            decReturn += RemoveImprovements(objCharacter, Improvement.ImprovementSource.AIProgram, objProgram.InternalId);
                            objCharacter.AIPrograms.Remove(objProgram);
                        }
                        break;
                    case Improvement.ImprovementType.AdeptPowerFreeLevels:
                    case Improvement.ImprovementType.AdeptPowerFreePoints:
                        // Get the power improved by this improvement
                        Power objImprovedPower = objCharacter.Powers.FirstOrDefault(objPower => objPower.Name == objImprovement.ImprovedName &&
                                        objPower.Extra == objImprovement.UniqueName);
                        if (objImprovedPower != null)
                        {
                            if (objImprovedPower.TotalRating <= 0)
                            {
                                objImprovedPower.Deleting = true;
                                objCharacter.Powers.Remove(objImprovedPower);
                            }

                            objImprovedPower.OnPropertyChanged(nameof(objImprovedPower.TotalRating));
                        }
                        break;
                    case Improvement.ImprovementType.MagiciansWayDiscount:
                        foreach (Power objLoopPower in objCharacter.Powers.Where(x => x.DiscountedAdeptWay))
                        {
                            objLoopPower.RefreshDiscountedAdeptWay(objLoopPower.AdeptWayDiscountEnabled);
                        }
                        break;
                    case Improvement.ImprovementType.FreeWare:
                        {
                            Cyberware objCyberware = objCharacter.Cyberware.FirstOrDefault(o => o.InternalId == objImprovement.ImprovedName);
                            if (objCyberware != null)
                            {
                                decReturn += objCyberware.DeleteCyberware();
                                decReturn += objCyberware.TotalCost;
                                objCharacter.Cyberware.Remove(objCyberware);
                            }
                        }
                        break;
                    case Improvement.ImprovementType.ContactForcedLoyalty:
                        {
                            objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName)?.RecalculateForcedLoyalty();
                        }
                        break;
                    case Improvement.ImprovementType.ContactMakeFree:
                        {
                            if (!blnHasDuplicate)
                            {
                                Contact objContact = objCharacter.Contacts.FirstOrDefault(x => x.GUID == objImprovement.ImprovedName);
                                if (objContact != null)
                                    objContact.Free = false;
                            }
                        }
                        break;
                }
            }
            if (blnDoSkillsSectionForceProperyChangedNotificationAll)
                objCharacter.SkillsSection.ForceProperyChangedNotificationAll(nameof(Skill.PoolToolTip));
            if (blnDoAttributeSectionForceProperyChangedNotificationAll)
                objCharacter.AttributeSection.ForceAttributePropertyChangedNotificationAll(nameof(CharacterAttrib.AttributeModifiers));
            objCharacter.ImprovementHook(objImprovementList);

            Log.Exit("RemoveImprovements");
            return decReturn;
        }

        /// <summary>
        /// Create a new Improvement and add it to the Character.
        /// </summary>
        /// <param name="objCharacter">Character to which the improvements belong that should be processed.</param>
        /// <param name="strImprovedName">Speicific name of the Improved object - typically the name of an CharacterAttribute being improved.</param>
        /// <param name="objImprovementSource">Type of object that grants this Improvement.</param>
        /// <param name="strSourceName">Name of the item that grants this Improvement.</param>
        /// <param name="objImprovementType">Type of object the Improvement applies to.</param>
        /// <param name="strUnique">Name of the pool this Improvement should be added to - only the single higest value in the pool will be applied to the character.</param>
        /// <param name="intValue">Set a Value for the Improvement.</param>
        /// <param name="intRating">Set a Rating for the Improvement - typically used for Adept Powers.</param>
        /// <param name="intMinimum">Improve the Minimum for an CharacterAttribute by the given amount.</param>
        /// <param name="intMaximum">Improve the Maximum for an CharacterAttribute by the given amount.</param>
        /// <param name="intAugmented">Improve the Augmented value for an CharacterAttribute by the given amount.</param>
        /// <param name="intAugmentedMaximum">Improve the Augmented Maximum value for an CharacterAttribute by the given amount.</param>
        /// <param name="strExclude">A list of child items that should not receive the Improvement's benefit (typically for Skill Groups).</param>
        /// <param name="blnAddToRating">Whether or not the bonus applies to a Skill's Rating instead of the dice pool in general.</param>
        /// <param name="strTarget">What target the Improvement has, if any (e.g. a target skill whose attribute to replace).</param>
        /// <param name="strCondition">Condition for when the bonus is applied.</param>
        public static void CreateImprovement(Character objCharacter, string strImprovedName, Improvement.ImprovementSource objImprovementSource,
            string strSourceName, Improvement.ImprovementType objImprovementType, string strUnique,
            int intValue = 0, int intRating = 1, int intMinimum = 0, int intMaximum = 0, int intAugmented = 0,
            int intAugmentedMaximum = 0, string strExclude = "", bool blnAddToRating = false, string strTarget = "", string strCondition = "")
        {
            Log.Enter("CreateImprovement");
            Log.Info(
                "strImprovedName = " + strImprovedName);
            Log.Info(
                "objImprovementSource = " + objImprovementSource.ToString());
            Log.Info(
                "strSourceName = " + strSourceName);
            Log.Info(
                "objImprovementType = " + objImprovementType.ToString());
            Log.Info( "strUnique = " + strUnique);
            Log.Info(
                "intValue = " + intValue.ToString());
            Log.Info(
                "intRating = " + intRating.ToString());
            Log.Info(
                "intMinimum = " + intMinimum.ToString());
            Log.Info(
                "intMaximum = " + intMaximum.ToString());
            Log.Info(
                "intAugmented = " + intAugmented.ToString());
            Log.Info(
                "intAugmentedMaximum = " + intAugmentedMaximum.ToString());
            Log.Info( "strExclude = " + strExclude);
            Log.Info(
                "blnAddToRating = " + blnAddToRating.ToString());
            Log.Info("strCondition = " + strCondition);

            // Do not attempt to add the Improvements if the Character is null (as a result of Cyberware being added to a VehicleMod).
            if (objCharacter != null)
            {
                // Record the improvement.
                Improvement objImprovement = new Improvement(objCharacter)
                {
                    ImprovedName = strImprovedName,
                    ImproveSource = objImprovementSource,
                    SourceName = strSourceName,
                    ImproveType = objImprovementType,
                    UniqueName = strUnique,
                    Value = intValue,
                    Rating = intRating,
                    Minimum = intMinimum,
                    Maximum = intMaximum,
                    Augmented = intAugmented,
                    AugmentedMaximum = intAugmentedMaximum,
                    Exclude = strExclude,
                    AddToRating = blnAddToRating,
                    Target = strTarget,
                    Condition = strCondition
                };

                // Add the Improvement to the list.
                objCharacter.Improvements.Add(objImprovement);
                ClearCachedValue(new Tuple<Character, Improvement.ImprovementType>(objCharacter, objImprovement.ImproveType));

                // Add the Improvement to the Transaction List.
                s_LstTransaction.Add(objImprovement);
            }

            Log.Exit("CreateImprovement");
        }

        /// <summary>
        /// Clear all of the Improvements from the Transaction List.
        /// </summary>
        public static void Commit(Character objCharacter)
        {
            Log.Enter("Commit");
            // Clear all of the Improvements from the Transaction List.

            objCharacter.ImprovementHook(s_LstTransaction);
            s_LstTransaction.Clear();
            Log.Exit("Commit");
        }

        /// <summary>
        /// Rollback all of the Improvements from the Transaction List.
        /// </summary>
        private static void Rollback(Character objCharacter)
        {
            Log.Enter("Rollback");
            // Remove all of the Improvements that were added.
            foreach (Improvement objImprovement in s_LstTransaction)
            {
                RemoveImprovements(objCharacter, objImprovement.ImproveSource, objImprovement.SourceName);
                ClearCachedValue(new Tuple<Character, Improvement.ImprovementType>(objCharacter, objImprovement.ImproveType));
            }

            s_LstTransaction.Clear();
            Log.Exit("Rollback");
        }

        #endregion
    }
}
